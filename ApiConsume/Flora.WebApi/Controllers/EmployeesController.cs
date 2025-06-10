using AutoMapper;
using Flora.BusinessLayer.Abstract;
using Flora.DtoLayer.AboutDto;
using Flora.DtoLayer.EmployeeDto;
using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _employeeService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateEmployeeDto createEmployeeDto)
        {
            var entity = _mapper.Map<Employee>(createEmployeeDto);
            _employeeService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _employeeService.TGetById(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı.");
            }
            _employeeService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateEmployeeDto updateEmployeeDto)
        {
            var entity = _employeeService.TGetById(updateEmployeeDto.EmployeeId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateEmployeeDto, entity);
            _employeeService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _employeeService.TGetById(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı.");
            }
            return Ok(value);
        }
    }
}