using AutoMapper;
using ISBTest.DAL;
using ISBTest.DAL.Entities;

namespace ISBTest.BL;

public interface IPropertyCrudProcessor
{
    Task<bool> Create(Property entity);
    Task<bool> Update(Property entity);
}

public class PropertyCrudProcessor(IRepository<Property> _repository, IMapper _mapper) : IPropertyCrudProcessor
{
    public async Task<bool> Create(Property entity)
    {
        var existingWithId = await _repository.Get(x => x.Id == entity.Id);
        if (existingWithId != null)
            return false;

        await _repository.Add(entity);
        return true;
    }

    public async Task<bool> Update(Property entity)
    {
        var found = await _repository.Get(x => x.Id == entity.Id, false);
        if (found == null)
            return false;

        _mapper.Map<Property, Property>(entity, found);
        return true;
    }
}
