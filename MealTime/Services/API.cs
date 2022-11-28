namespace MealTime.Services
{
    public class API
    {
        public static class User
        {
            public static string GetUsers(string baseUri) => $"{baseUri}/api/Users/GetUsers";
            public static string CreateUser(string baseUri) => $"{baseUri}/api/Users/Create";
        }
    }
}
