using AutoMapper;
using Yummy.WebApi.Dtos.FeatureDtos;
using Yummy.WebApi.Dtos.MessageDtos;
using Yummy.WebApi.Dtos.ProductDtos;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, GetFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();

			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, GetFeatureDto>().ReverseMap();
			CreateMap<Message, UpdateFeatureDto>().ReverseMap();
			CreateMap<Message, CreateFeatureDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDto>()
				.ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName))
				.ReverseMap();


		}
	}
}
