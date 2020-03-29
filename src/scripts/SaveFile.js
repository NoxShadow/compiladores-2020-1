function createContentFile(path, content) {
    const fso = CreateObject("Scripting.FileSystemObject");
    const s = fso.CreateTextFile(path, True);
    s.writeline(content);

    s.Close();

    debugger;
}