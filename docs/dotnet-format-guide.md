# dotnet format Guide

## What is dotnet format?

`dotnet format` is a built-in .NET CLI tool that enforces `.editorconfig` rules automatically.
It fixes formatting, code style, and analyzer violations — no extra tools needed.

## Common Commands

### Check for violations (CI / pre-commit)

```bash
dotnet format --verify-no-changes
```

Returns a non-zero exit code if any files need formatting. Use this in CI.

### Fix all violations

```bash
dotnet format
```

Fixes everything it can automatically. Run this before committing.

### Fix only whitespace/formatting

```bash
dotnet format whitespace
```

### Fix only code style rules

```bash
dotnet format style
```

### Fix only analyzer warnings

```bash
dotnet format analyzers
```

## Pre-Commit Hook

This repo includes a `pre-commit` hook that runs `dotnet format --verify-no-changes` before every commit.

### Install the hook

```bash
# Copy the hook into your local git hooks directory
cp pre-commit .git/hooks/pre-commit

# Make it executable (macOS/Linux)
chmod +x .git/hooks/pre-commit
```

### Or set a custom hooks path

```bash
git config core.hooksPath .
```

> **Note:** This makes Git look for hooks in the repo root, where the `pre-commit` file already lives.

## Tips

- Run `dotnet format` after pulling changes to fix any conflicts
- If a rule is too strict, adjust the severity in `.editorconfig` rather than disabling format
- Use `dotnet format --verbosity diagnostic` to see exactly what's being changed
- VS Code + C# Dev Kit will respect `.editorconfig` rules for real-time feedback
