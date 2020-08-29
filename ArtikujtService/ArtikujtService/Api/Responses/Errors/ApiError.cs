using ArtikujtService.Results;
using Microsoft.AspNetCore.Identity;

namespace ArtikujtService.Api.Responses.Errors
{
    public class ApiError
    {
        /// <summary>
        /// Code of the error
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Description of the error
        /// </summary>
        public string Description { get; set; }

        public ApiError() { }

        public ApiError(string code, string description) {
            Code = code;
            Description = description;
        }

        public ApiError(IdentityError error)
        {
            Code = error.Code;
            Description = error.Description;
        }

        public ApiError(ServiceError error)
        {
            Code = error.Code;
            Description = error.Description;
        }
    }
}
