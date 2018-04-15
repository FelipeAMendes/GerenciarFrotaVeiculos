namespace ManageFleet.Domain.Validations
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidationResult()
        {
            this.IsValid = true;
        }

        public ValidationResult(string message)
        {
            IsValid = true;
            Message = message;
        }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = IsValid;
            Message = message;
        }
    }
}