import re
from pathlib import Path

enumRegex = re.compile(r"(enum (\w*)(?: : \w+)? \{)([^\}]*)(\})".replace(" ", r"\s*"))
nameRegex = re.compile(r"[A-Z_]*")

# files = ["src/SDL/blendmode.cs"]
files = Path("src/SDL").rglob("*.cs")

for file in files:

    with open(file) as fp:
        text = fp.read()

    def replace(x):
        enumName = x.group(2)
        def csharpifyName(x):
            x = x.group(0)
            result = "".join(w.title() for w in x.split("_"))
            if result.lower().startswith(enumName.lower()):
                result = result[len(enumName):]
            if result.lower().startswith("Flags".lower()):
                result = result[len("Flags"):]
            return result
        members = x.group(3)
        members = nameRegex.sub(csharpifyName, members)
        return x.group(1) + members + x.group(4)

    # for item in enumRegex.finditer(text):
    #     print(replace(item))
    # if enumRegex.findall(text):
    with open(file, "w") as fp:
        fp.write(enumRegex.sub(replace, text))
