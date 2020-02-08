import shutil
from pprint import pprint
import re
import os

replacements = [
    (
        re.compile(
            r"""(\[DllImport\(.*)(\)\]\s*public static extern \w*) SDL_(\w*)\("""),
        lambda m: (m.expand(r'\1, EntryPoint="SDL_\3"\2 \3(')
                   if "EntryPoint" not in m.group(1)
                   else m.group(0))
    ),
    (
        re.compile(r'([^"])SDL_(\w*)'),
        r'\1\2'
    ),
    (
        re.compile(r'\? bool\.TRUE : bool\.FALSE'.replace(' ', '\s*')),
        r''
    ),
    (
        re.compile(r'public enum bool\n\s*\{([^\}])*\}', re.MULTILINE),
        r''
    ),
    (
        re.compile(r'''
\s*\#region \ Floating \ Point \ Render \ Functions
(.*?)
\#endregion''', re.X | re.DOTALL),
        r'\1'
     )
]

with open("SDL2.cs") as fp:
    data = fp.read()

regionFinder = re.compile(r'''
\s*\#region \ ([^\n]*)\n
(.*?)
\#endregion
''', re.X | re.DOTALL)

for x, y in replacements:
    data = x.sub(y, data)

regions = {region.group(1): region.group(0)
           for region in regionFinder.finditer(data)}
pprint([region for region in regions])

license = regions["License"]
usings = regions["Using Statements"]
del regions["License"]
del regions["Using Statements"]

rest = []
if os.path.isdir("SDL"):
    shutil.rmtree("SDL")
os.makedirs("SDL")


def writeFile(name, content):
    filename = "SDL/{}.cs".format(name.replace(".h", "").replace(", ", "-"))
    with open(filename, "w") as fp:
        fp.write(license)
        fp.write("\n")
        fp.write(usings)
        fp.write("""
namespace SDL2
{
    public static partial class SDL
    {
""")
        fp.write(content)
        fp.write("""
    }
}
""")


for name, region in regions.items():
    name = name.strip()
    if name.endswith(".h"):
        writeFile(name, region)
    else:
        rest.append(region)

writeFile("SDL-CS", "\n".join(rest))


os.remove("SDL2.cs")
