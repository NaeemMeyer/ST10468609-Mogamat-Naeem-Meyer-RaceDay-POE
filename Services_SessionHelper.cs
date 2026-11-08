namespace RaceDayMVC.Services;

public static class SessionHelper
{
    public static bool IsLoggedIn(
        IHttpContextAccessor contextAccessor)
    {
        return contextAccessor.HttpContext
            .Session
            .GetInt32("UserId")
               != null;
    }

    public static string GetRole(
        IHttpContextAccessor contextAccessor)
    {
        return contextAccessor
            .HttpContext
            .Session
            .GetString("Role");
    }
}
