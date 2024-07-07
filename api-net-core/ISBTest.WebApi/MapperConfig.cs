using AutoMapper;
using ISBTest.DAL.Entities;
using ISBTest.WebApi.Models;

namespace ISBTest.WebApi;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Property, Property>();
        CreateMap<Property, PropertyModel>();
        CreateMap<PropertyModel, Property>();

        CreateMap<Contact, ContactModel>();
        CreateMap<ContactModel, Contact>();

        CreateMap<OwnershipChange, OwnershipChangeModel>();
        CreateMap<OwnershipChangeModel, OwnershipChange>();
    }
}
