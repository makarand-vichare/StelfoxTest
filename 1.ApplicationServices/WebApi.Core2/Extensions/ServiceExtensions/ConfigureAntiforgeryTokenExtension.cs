using Microsoft.Extensions.DependencyInjection;

public static class ConfigureAntiforgeryTokenExtension
{
    public static void ConfigureAntiforgeryToken(this IServiceCollection services)
    {
        services.AddAntiforgery(options =>
        {
            options.HeaderName = "X-XSRF-TOKEN";
            options.SuppressXFrameOptionsHeader = false;
        });
    }
}