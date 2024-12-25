
using CollegeApplication.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace CollegeApplication.CustomValidations
{
    public class ValidateAddmisiondateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? date = (DateTime?)value;
            // define the conditons 

            if (!date.HasValue)
            {
                return (new ValidationResult("Pleas Enter valid Addmision Date"));
            }
            if (date < DateTime.Now)
            {
                return (new ValidationResult("Addmision Date Must be grerater or eqall to todays date"));
            }
            return ValidationResult.Success;
        }
    }
}
