using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DccMeter.Api.Domain.Models
{
    public class ModifyUserContext : IValidatableObject
    {
        [DataMember(Name ="id")]
        [Required, FromRoute(Name ="id")]
        public int Id { get; set; }

        [DataMember(Name ="command")]
        [FromBody]
        public ModifyUserCommand Command { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            RegisterUserCommand? command = validationContext.ObjectInstance as RegisterUserCommand;

            if (command == null)
            {
                throw new ArgumentNullException(nameof(validationContext.ObjectInstance));
            }

            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (command.UserName.IsNullOrEmpty() || command.UserName.Length > 100)
            {
                validationResults.AddValidationCodeResult("User name not provided, or User name length is larger than 100", Severity.Error);
            }
            else if (command.Eid <= 0)
            {
                validationResults.AddValidationCodeResult("Eid must be greater then zero.", Severity.Error);
            }

            return validationResults;
        }
    }
}
