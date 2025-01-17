using System.ComponentModel.DataAnnotations;

namespace TicTacToeWeb.Utilities
{
    public class DividesByAttribute : ValidationAttribute
    {
        public int DividesBy { get; set; }
        public DividesByAttribute(int dividesBy)
        {
            DividesBy = dividesBy;
        }

        public bool Validate(int input)
        {
            if(input == 0)
                return false;
            
            int result = input % DividesBy;
            if (result == 0)
                return true;
            else
                return false;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int input = (int)value;

            if (Validate(input) == false)
                return new ValidationResult($"The size of the board must be divisable by {DividesBy}");
            return ValidationResult.Success;
        }
        
    }
}
