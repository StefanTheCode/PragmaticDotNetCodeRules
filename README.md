# Pragmatic .NET Code Rules - Starter Kit

> **Production-ready code quality defaults for .NET teams. Free for newsletter subscribers.**

Drop these files into any .NET solution and get:
- Consistent code style enforced by `.editorconfig`
- Centralized build rules with `Directory.Build.props`
- Nullable warnings treated as errors (the ones that actually matter)
- Formatting verification in CI
- Architecture test starter examples
- PR hygiene and dependency management out of the box

No theory. No bloated frameworks. **Defaults that work on day one.**

---

## What's Included

| File / Folder | Purpose |
|---|---|
| `.editorconfig` | Code style, naming conventions, formatting rules, and diagnostic severities for C# and .NET |
| `Directory.Build.props` | Centralized compiler settings, analyzers, and pragmatic warnings-as-errors - applied to every project in the solution |
| `global.json` | Pins the .NET SDK version with `rollForward: latestFeature` for reproducible builds |
| `.github/workflows/quality.yml` | CI quality gate: restore > format check > build > test |
| `.github/pull_request_template.md` | PR checklist focused on code quality and consistency |
| `.github/ISSUE_TEMPLATE/` | Clean bug report and feature request templates |
| `.github/dependabot.yml` | Automated dependency updates - grouped and low-noise |
| `pre-commit` | Git hook that runs `dotnet format --verify-no-changes` before every commit |
| `tests/.../ArchitectureTests.cs` | Starter architecture tests using NetArchTest - ready to adapt |
| `docs/visual-studio-cleanup-checklist.md` | Step-by-step VS setup for format-on-save and code cleanup |
| `docs/dotnet-format-guide.md` | How to run `dotnet format` locally, common commands, and pre-commit setup |

---

## Quick Start

### Use in a new project

```bash
# Clone and start building on top of it
git clone https://github.com/ACodeManDotNet/PragmaticDotNetCodeRules.git
cd PragmaticDotNetCodeRules
dotnet build
dotnet test
```

### Use in an existing solution

1. Copy these files into the **root of your solution**:
   - `.editorconfig`
   - `Directory.Build.props`
   - `global.json`
   - `pre-commit`

2. Copy the `.github/` folder for CI, PR templates, and Dependabot.

3. Run formatting to see what your codebase needs:
   ```bash
   dotnet format --verify-no-changes
   ```

4. Fix violations:
   ```bash
   dotnet format
   ```

5. Commit, push, and let CI enforce the rules going forward.

**Setup time: 5-10 minutes.**

---

## What Each File Does

### `.editorconfig`

Defines code style rules that IDEs and `dotnet format` enforce automatically:

- **Formatting**: 4-space indentation, UTF-8, consistent newlines
- **Naming**: PascalCase for types/members, `_camelCase` for private fields, `IPrefix` for interfaces
- **Code style**: File-scoped namespaces, braces required, prefer pattern matching
- **Diagnostics**: IDE0005 (unused usings), IDE0055 (formatting), and more - set to `warning`

### `Directory.Build.props`

Applied automatically to every `.csproj` in your solution. No need to duplicate settings per project:

- Enables nullable reference types and implicit usings
- Turns on .NET analyzers at `latest-recommended` level
- Enforces code style rules during build (`EnforceCodeStyleInBuild`)
- **Warnings-as-errors** for nullable violations (CS8600-CS8625), `CA2016` (CancellationToken forwarding), and `CA2208` (argument exceptions)
- Suppresses `CS1591` (missing XML comments) - noisy for most teams

### `global.json`

Pins the .NET SDK version so every developer and CI agent uses the same SDK. `rollForward: latestFeature` allows patch updates without breaking builds.

### CI Quality Gate

The GitHub Actions workflow runs on every push and PR:

1. **Restore** - ensures packages resolve cleanly
2. **Format check** - fails if code doesn't match `.editorconfig`
3. **Build** - Release configuration, affected by warnings-as-errors
4. **Test** - runs all test projects

SDK version is read from `global.json` - no hardcoded versions in CI.

### Architecture Tests

Starter tests using [NetArchTest](https://github.com/BenMorris/NetArchTest) that show how to enforce:

- Interface naming conventions (`I` prefix)
- Layer dependency rules (Domain must not reference Infrastructure)
- Naming smell detection (no `*Helper` classes)

These tests pass out of the box. Adapt the namespaces and rules to your project structure.

### Pre-Commit Hook

The `pre-commit` script runs `dotnet format --verify-no-changes` before every commit. Install it:

```bash
# Option A: Copy to git hooks
cp pre-commit .git/hooks/pre-commit

# Option B: Point git to repo root for hooks
git config core.hooksPath .
```

### Dependabot

Configured for low-noise dependency management:
- NuGet packages checked weekly, minor + patch updates grouped into one PR
- GitHub Actions checked monthly
- Max 5 open PRs at a time

---

## Running Format Locally

```bash
# Check for violations (same as CI)
dotnet format --verify-no-changes

# Fix all violations automatically
dotnet format

# Fix only whitespace
dotnet format whitespace

# Fix only style rules
dotnet format style

# Verbose output to see what changed
dotnet format --verbosity diagnostic
```

See [`docs/dotnet-format-guide.md`](docs/dotnet-format-guide.md) for more details.

---

## About the Course

This starter kit is **Module 01 material** from:

**[Pragmatic .NET Code Rules](https://thecodeman.net/pragmatic-dotnet-code-rules)**

The full course goes deeper into:
- Advanced EditorConfig patterns and team rollout strategies
- Static code analysis (StyleCop, SonarAnalyzer) - when to use what
- Diagnostic severities and custom warnings-as-errors policies
- Full architecture test suites for layered and modular architectures
- CI quality gates with build-break policies
- Logging and observability rules
- AI-assisted PR reviews and dependency auditing

---

## What's Next

You've got the foundation. Here's how to take it further:

1. **Customize `.editorconfig`** - adjust severities to match your team's tolerance
2. **Expand `WarningsAsErrors`** - add more diagnostic IDs as your team matures
3. **Add more architecture tests** - enforce your actual layer boundaries
4. **Add static analysis** - StyleCop or SonarAnalyzer for deeper checks *(covered in the course)*
5. **Roll out to existing projects** - the course covers migration strategies for legacy codebases

---

## License

You can use this kit freely in personal and commercial projects.
It's meant to improve real codebases, not just sell content.

Happy coding.