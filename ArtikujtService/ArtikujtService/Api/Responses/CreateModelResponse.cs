using ArtikujtService.Api.Models;
using ArtikujtService.Results;

namespace ArtikujtService.Api.Responses
{
    public class CreateModelResponse<TModel, TApiModel> : ApiResponse 
        where TApiModel : ApiModel<TModel>

    {
        public TApiModel Model { get; set; }

        public CreateModelResponse(TApiModel apiModel, ServiceResult serviceResult) : base(serviceResult)
        {
            Model = apiModel;
        }
    }
}
