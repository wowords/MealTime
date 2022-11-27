namespace MealTime.Models
{
    public class ServiceResult
    {
        public bool IsOk { get;}
        public string ErrorMessage { get;}
        public string OkMessage { get; set; }

        public ServiceResult(bool isOk, string errorMessage, string okMessage)
        {
            IsOk = isOk;
            ErrorMessage = errorMessage;
            OkMessage = okMessage;
        }
        public static ServiceResult Ok() => new ServiceResult(true, null, null);
        public static ServiceResult Error(string errorMsg) => new ServiceResult(false, errorMsg, null);
        public static ServiceResult OkWithMsg(string okMsg) => new ServiceResult(false, null, okMsg);
                 
    }
    public class ServiceResult<T>
    {
        public bool IsOk { get; }
        public T Value { get; }
        public string OkMessage { get; set; }
        public ServiceResult(bool isOk, T value, string okMessage)
        {
            IsOk = isOk;
            Value = value;
            OkMessage = okMessage;
        }
        public static ServiceResult<T> Ok(T value) => new ServiceResult<T>(true, value, null);
        public static ServiceResult<T> Error(string message) => new ServiceResult<T>(true, default, message);
    }
}
