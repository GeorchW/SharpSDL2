import re
from pathlib import Path

structRegex = re.compile(r"(struct \w* \{)([^\}]*)(\})".replace(" ", r"\s*"))
fieldRegex = re.compile(r"(\s*)(public \w+ )(\w+);(?: /\*(.*)\*/)?")

# files = ["src/SDL/events.cs"]
files = Path("src/SDL").rglob("*.cs")

for file in files:
    with open(file) as fp:
        text = fp.read()

    def replace(x):
        def csharpifyField(x):
            whitespace = x.group(1)
            prefix = x.group(2)
            name = x.group(3)
            comment = x.group(4)

            name = name[0].upper() + name[1:]

            result = whitespace + prefix + name + ";"
            if comment:
                result = "{}///<summary>{}</summary>\n{}".format(
                    whitespace, comment, result)
            return result
        members = x.group(2)
        members = fieldRegex.sub(csharpifyField, members)
        return x.group(1) + members + x.group(3)

    # for item in structRegex.finditer(text):
    #     print(replace(item))
    # if structRegex.findall(text):
    with open(file, "w") as fp:
        fp.write(structRegex.sub(replace, text))
