namespace dotNET_Temporal.Util;

public static class Functions
{
    public static bool OnLocalhost(this IHostEnvironment hostEnvironment) => hostEnvironment.EnvironmentName.Equals("Localhost");
}
