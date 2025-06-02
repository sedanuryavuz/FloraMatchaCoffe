using AutoMapper;
using Flora.BusinessLayer.Abstract;
using Flora.DtoLayer.CategoryDto;
using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var count = _categoryService.TGetAll().Count;
            return Ok(count);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var count = _categoryService.TActiveCategoryCount();
            return Ok(count);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var count = _categoryService.TPassiveCategoryCount();
            return Ok(count);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var entity = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }
            _categoryService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var entity = _categoryService.TGetById(updateCategoryDto.CategoryId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateCategoryDto, entity);
            _categoryService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            return Ok(value);
        }
    }
}