
using System.ComponentModel.DataAnnotations;

namespace System.Collections.Generic
{
    public static class ValidationResultsExtensions
    {
        public static void AddValidationCodeResult(this List<ValidationResult> validationResults, ValidationCodeResult validationResult)
        {
            if (validationResults == null)
            {
                throw new ArgumentNullException("validationResults");
            }

            if (validationResult == null)
            {
                throw new ArgumentNullException("validationResult");
            }

            validationResults.Add(validationResult);
        }

        public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message)
        {
            if (validationResults == null)
            {
                throw new ArgumentNullException("validationResults");
            }

            validationResults.AddValidationCodeResult(new ValidationCodeResult(message));
        }

        public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, int code)
        {
            if (validationResults == null)
            {
                throw new ArgumentNullException("validationResults");
            }

            validationResults.AddValidationCodeResult(new ValidationCodeResult(message, code));
        }

        public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, Severity severity)
        {
            if (validationResults == null)
            {
                throw new ArgumentNullException("validationResults");
            }

            validationResults.AddValidationCodeResult(new ValidationCodeResult(message, severity));
        }

        public static void AddValidationCodeResult(this List<ValidationResult> validationResults, string message, int code, Severity severity)
        {
            if (validationResults == null)
            {
                throw new ArgumentNullException("validationResults");
            }

            validationResults.AddValidationCodeResult(new ValidationCodeResult(message, code, severity));
        }
    }
}