using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace College.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected List<string> GetValidationErrors(object dto)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(dto);

            bool IsValid = Validator.TryValidateObject(dto, context, results, true);

            if (IsValid) return [];

            return results.Select(r => r.ErrorMessage ?? "validation error message").ToList();
        }
    }
}
