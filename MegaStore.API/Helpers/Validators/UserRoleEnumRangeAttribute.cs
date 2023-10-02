using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MegaStore.API.Models;

namespace MegaStore.API.Helpers.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UserRoleEnumRangeAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public UserRoleEnumRangeAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("The provided type is not an enum.");
            }
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} is required");
            }

            var enumValues = Enum.GetValues(_enumType);
            int min = 1;
            int max = enumValues.Length - 1;

            if (int.TryParse(value.ToString(), out int intValue) && intValue >= min && intValue <= max)
            {
                return ValidationResult.Success;
            }

            UserRole[] roles = (UserRole[])Enum.GetValues(typeof(UserRole));
            string rolesSpecification = "";
            // Enumerate (loop through) the enum values
            for (int i = 1; i < roles.Length; i++)
            {
                UserRole role = roles[i];
                rolesSpecification += $" {i}: {role} \n";
            }

            return new ValidationResult($"The field {validationContext.DisplayName} must be a number between {min} and {max}\n {rolesSpecification}");
        }
    }
}