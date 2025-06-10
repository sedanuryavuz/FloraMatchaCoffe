using AutoMapper;
using Flora.BusinessLayer.Abstract;
using Flora.DtoLayer.MenuTableDto;
using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());

        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var entity = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }
            _menuTableService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var entity = _menuTableService.TGetById(updateMenuTableDto.MenuTableId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateMenuTableDto, entity);
            _menuTableService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            return Ok(value);
        }
        [HttpGet("ChangeStatusToTrue")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("Durum başarılı bir şekilde değiştirildi.");
        }
        [HttpGet("ChangeStatusToFalse")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("Durum başarılı bir şekilde değiştirildi.");
        }
    }
}
