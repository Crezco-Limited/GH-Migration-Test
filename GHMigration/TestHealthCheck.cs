using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GHMigration;

public class TestHealthCheck : IHealthCheck
{
    private readonly TestHealthCheckOptions _options;

    public TestHealthCheck(TestHealthCheckOptions options)
    {
        _options = options;
    }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var healthCheckResult = _options.ReportHealthy
            ? HealthCheckResult.Healthy()
            : HealthCheckResult.Unhealthy();
        
        return Task.FromResult(healthCheckResult);
    }
}

public class TestHealthCheckOptions
{
    public bool ReportHealthy { get; set; }
}