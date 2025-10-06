
namespace GeniyIdiotClassLibrary
{
    public class ValidationResult<T>
    {
        public bool _Success { get; }
        public string ErrorMessage { get; }
        public T Value { get; }

        public ValidationResult(bool isSuccess, string errorMessage, T value)
        {
            _Success = isSuccess;
            ErrorMessage = errorMessage;
            Value = value;
        }

        public static ValidationResult<T> Success(T value)
            => new ValidationResult<T>(true, "", value);

        public static ValidationResult<T> Fail(string errorMessage)
            => new ValidationResult<T>(false, errorMessage, default(T));


    }
}
