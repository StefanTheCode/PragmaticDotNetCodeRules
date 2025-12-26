# Visual Studio Clean Code Checklist

## 1. Enable Format on Save
- Tools → Options → Text Editor → C#
- ✔ Format document on save

## 2. Configure Code Cleanup Profile
- Open any `.cs` file
- Click broom icon → Configure Code Cleanup

### Include:
- ✔ Remove unused usings
- ✔ Sort usings
- ✔ Apply EditorConfig formatting
- ✔ Apply file-scoped namespaces

## 3. Assign Shortcut
- Tools → Options → Environment → Keyboard
- Bind **Run Code Cleanup** to:
  `Ctrl + Shift + F`

## 4. Use Cleanup Before Commit
- Run Code Cleanup on modified files
- Fix warnings before pushing

## 5. Verify EditorConfig Is Applied
- Change spacing/braces intentionally
- Run cleanup → code should auto-fix

Done.