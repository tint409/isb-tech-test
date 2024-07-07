using AutoMapper;
using ISBTest.BL;
using ISBTest.DAL.Contracts;
using ISBTest.DAL.Entities;
using ISBTest.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISBTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly IDataLoader<Property> _dataLoader;
        private readonly IPropertyCrudProcessor _crudProcessor;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyController(
            ILogger<PropertyController> logger,
            IDataLoader<Property> dataLoader,
            IPropertyCrudProcessor crudProcessor,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _dataLoader = dataLoader;
            _crudProcessor = crudProcessor;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<PropertyModel>> Get()
        {
            return (await _dataLoader.List()).Select(x => _mapper.Map<PropertyModel>(x)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return BadRequest();

            var found = _mapper.Map<PropertyModel>(await _dataLoader.Get(x => x.Id == guid));
            return found == null ? NotFound() : new JsonResult(found);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyModel property)
        {
            var succeed = await _crudProcessor.Create(_mapper.Map<Property>(property));

            if (!succeed)
                return BadRequest();

            await _unitOfWork.CommitAsync();
            return new JsonResult(property);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PropertyModel property)
        {
            var succeed = await _crudProcessor.Update(_mapper.Map<Property>(property));

            if (!succeed)
                return BadRequest();

            await _unitOfWork.CommitAsync();
            return new JsonResult(property);
        }
    }
}
