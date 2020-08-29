using ArtikujtService.Api.Responses.Errors;
using ArtikujtService.Results;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ArtikujtService.Api.Responses
{
    public class ApiResponse
    {
        public bool Succeeded { get; set; }
        public List<ApiError> Errors { get; set; } = new List<ApiError>();

        public ApiResponse() { }
        public ApiResponse(ServiceResult result)
        {
            Succeeded = result.Succeeded;
            Errors = result.Errors.Select(error => new ApiError(error)).ToList();
        }

        public ApiResponse(IdentityResult result)
        {
            Succeeded = result.Succeeded;
            Errors = result.Errors.Select(error => new ApiError(error)).ToList();
        }

        public ApiResponse(SignInResult signInResult)
        {
            Succeeded = signInResult.Succeeded;
        }
    }
}
