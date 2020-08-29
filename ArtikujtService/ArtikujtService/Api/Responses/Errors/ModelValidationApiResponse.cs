using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ArtikujtService.Api.Responses.Errors
{
    public class ModelValidationApiResponse: ApiResponse
    {
        public string Message { get; }

        public ModelValidationApiResponse(ModelStateDictionary modelState)
        {
            Succeeded = false;
            Message = "Validation Failed";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ApiError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
