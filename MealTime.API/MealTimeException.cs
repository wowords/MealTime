namespace MealTime.API
{
    public class MealTimeException : Exception
    {
        public MealTimeException()
        {

        }

        public MealTimeException(string message) : base(message)
        {

        }
        public MealTimeException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}
