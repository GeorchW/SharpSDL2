import os
import re
import sys

import lxml.etree

'''
This script takes SDL2 doxygen documentation and annotates the members with it.
How to use:
1. Clone the libsdl repository
2. Go into the docs folder, open the doxyfile and add this line:
    GENERATE_XML=YES
3. Run doxygen
4. Amalgate the generated XML using the command on top of the output/xml/combine.xslt file
5. Use the generated XML file (all.xml) as a parameter to this script
'''

print("Loading XML file...")
xmlFile = lxml.etree.parse(sys.argv[1])
print("done.")

def createSummaryTag(summary):
    if "\n" in summary:
        return "<summary>\n{}\n</summary>".format(summary)
    elif len(summary) > 0:
        return "<summary>{}</summary>".format(summary)
    else:
        return ""

def get_doc(api, additional_summary=None):
    lines = []

    doc = xmlFile.xpath(
        ".//memberdef[@kind='function']/name[text()='{}']/..".format(api))
    if len(doc) == 0:
        if additional_summary is not None:
            return createSummaryTag(additional_summary)
        else:
            return ""
    element = doc[0]

    brief = element.xpath("./briefdescription//text()")
    detailed = element.xpath("./detaileddescription/para/text()")
    summary = "\n\n".join(filter(lambda x: len(x) > 0, ["".join(brief), "".join(detailed)])).strip()
    summary = re.sub(r"\n\s*\n", "\n", summary)
    if additional_summary is not None:
        summary += "\n\n" + additional_summary
    lines.append(createSummaryTag(summary))

    params = element.xpath("./detaileddescription//parameteritem")
    for param in params:
        name = "".join(param.xpath(".//parametername/text()"))
        desc = "".join(param.xpath(".//parameterdescription//text()")).strip()
        if len(desc) > 0:
            lines.append('<param name="{}">{}</param>'.format(name, desc))

    # parameters: List[BeautifulSoup] = content.find("h2", text="Function Parameters").findNextSibling("div").findAll("tr")
    # for param in parameters:
    #     name, desc = param.findAll("td")
    #     lines.append('///<param name="{}">{}</param>'.format(name.text, desc.text))

    result = "\n".join(lines)
    return result


dir = "SharpSDL2/src/SDL/"
dllImportRegex = re.compile(
    r"([ \t]*)" + r"(\[DllImport.*\WEntryPoint = \"(.*)\".*\])".replace(" ", r"\s*"))
commentRegex = re.compile(r"/\*((?:.|\n)*?)\*/\s*\n")
for file in os.listdir(dir):
    print(file)
    with open(dir + file) as fp:
        text = fp.read()
    comments = list(commentRegex.finditer(text))
    commentsByEndIndex = {comment.end(): comment.group(1) for comment in comments}

    def replace(match):
        ws, dllimport, entrypoint = match.groups()
        print("Getting the doc for {}...".format(entrypoint))
        comment = commentsByEndIndex.get(match.start(), None)
        if comment is not None:
            comment_lines = comment.strip().split("\n")
            comment_lines = [line.strip().lstrip("*").strip() for line in comment_lines]
            comment = "\n".join(comment_lines)
            comment = "Binding info:\n" + comment
        doc = get_doc(entrypoint, additional_summary=comment)
        print(doc)
        if len(doc) > 0:
            doc_reformatted = "\n".join(ws + "/// " + line for line in doc.split("\n"))
            return doc_reformatted + "\n" + ws + dllimport
        else:
            return ws + dllimport
    replacement = dllImportRegex.sub(replace, text)
    print(replacement)
    with open(dir + file, "w") as fp:
        fp.write(replacement)
