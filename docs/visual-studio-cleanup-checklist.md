# Visual Studio Clean Code Checklist

Quick setup guide to get Visual Studio enforcing the `.editorconfig` rules automatically.

## 1. Enable Format on Save

- **Tools** > **Options** > **Text Editor** > **C#**
- Check **Format document on save**

## 2. Configure Code Cleanup Profile

- Open any `.cs` file
- Click the broom icon (bottom of editor) > **Configure Code Cleanup**

### Include these fixers:

- Remove unused usings
- Sort usings
- Apply EditorConfig formatting
- Apply file-scoped namespaces
- Add accessibility modifiers
- Apply expression-body preferences

## 3. Assign a Keyboard Shortcut

- **Tools** > **Options** > **Environment** > **Keyboard**
- Search for: `EditorContextMenus.CodeWindow.RunCodeCleanupProfile`
- Bind to: `Ctrl+Shift+F`

## 4. Before Every Commit

1. Run **Code Cleanup** on modified files
2. Fix any remaining warnings
3. Verify with: `dotnet format --verify-no-changes`

## 5. Recommended Extensions

- **EditorConfig Language Service** — syntax highlighting for `.editorconfig`
- **Roslynator** — additional refactoring suggestions (optional)

> For `dotnet format` CLI usage, see [`dotnet-format-guide.md`](dotnet-format-guide.md).

## 5. Verify EditorConfig Is Applied
- Change spacing/braces intentionally
- Run cleanup → code should auto-fix

Done.