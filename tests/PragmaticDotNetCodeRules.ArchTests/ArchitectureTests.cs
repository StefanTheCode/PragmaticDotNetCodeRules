using System.Reflection;
using NetArchTest.Rules;
using Xunit;

namespace PragmaticDotNetCodeRules.ArchTests;

/// <summary>
/// Starter architecture tests.
/// Adapt these rules to match your project's structure and conventions.
/// </summary>
public class ArchitectureTests
{
    private static readonly Assembly ApplicationAssembly =
        Assembly.Load("PragmaticDotNetCodeRules");

    [Fact]
    public void Interfaces_ShouldStartWithI()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .AreInterfaces()
            .Should()
            .HaveNameStartingWith("I")
            .GetResult();

        Assert.True(result.IsSuccessful,
            "All interfaces should follow the IMyInterface naming convention.");
    }

    [Fact]
    public void Domain_ShouldNotDependOnInfrastructure()
    {
        // Example: Enforce clean architecture layering.
        // Adapt these namespace names to your actual project structure.
        //
        // In a real project:
        //   - "YourApp.Domain" should NOT reference "YourApp.Infrastructure"
        //   - "YourApp.Application" should NOT reference "YourApp.Api"

        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ResideInNamespace("PragmaticDotNetCodeRules.Domain")
            .ShouldNot()
            .HaveDependencyOn("PragmaticDotNetCodeRules.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful,
            "Domain layer should not depend on Infrastructure.");
    }

    [Fact]
    public void Controllers_ShouldNotDependOnRepositories()
    {
        // Example: Prevent controllers from bypassing your service layer.
        // Adapt this to your actual project namespaces.

        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ResideInNamespace("PragmaticDotNetCodeRules.Controllers")
            .ShouldNot()
            .HaveDependencyOn("PragmaticDotNetCodeRules.Repositories")
            .GetResult();

        Assert.True(result.IsSuccessful,
            "Controllers should not depend directly on repositories.");
    }

    [Fact]
    public void Classes_ShouldNotHaveNameEndingWithHelper()
    {
        // Naming smell: "Helper" classes often indicate misplaced logic.
        // This test catches vague naming before it spreads.

        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .AreClasses()
            .ShouldNot()
            .HaveNameEndingWith("Helper")
            .GetResult();

        Assert.True(result.IsSuccessful,
            "Avoid generic 'Helper' class names — use specific, descriptive names instead.");
    }
}
