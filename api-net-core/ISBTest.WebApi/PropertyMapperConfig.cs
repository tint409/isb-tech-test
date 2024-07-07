using AutoMapper;
using ISBTest.DAL.Entities;
using ISBTest.WebApi.Models;

namespace ISBTest.WebApi;

public class PropertyMapperConfig : Profile
{
    public PropertyMapperConfig()
    {
        CreateMap<Property, Property>();
        CreateMap<Property, PropertyModel>();
        CreateMap<PropertyModel, Property>();
    }
}
