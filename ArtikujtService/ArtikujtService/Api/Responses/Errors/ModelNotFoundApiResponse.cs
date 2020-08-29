using Microsoft.AspNetCore.Mvc;

namespace ArtikujtService.Api.Responses.Errors
{
    public class ModelNotFoundApiResponse : NotFoundObjectResult
    {

        public ModelNotFoundApiResponse(string modelName)
            : base(new ModelNotFoundResponseBody(modelName))
        {
        }

        public class ModelNotFoundResponseBody : ApiResponse
        {
            public ModelNotFoundResponseBody(string modelName)
            {
                Succeeded = false;
                Errors.Add(new ApiError
                {
                    Code = nameof(ModelNotFoundApiResponse),
                    Description = $"{modelName} was not found"
                });
            }

        }
    }
}
