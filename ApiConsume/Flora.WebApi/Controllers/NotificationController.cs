using AutoMapper;
using Flora.BusinessLayer.Abstract;
using Flora.DtoLayer.MenuTableDto;
using Flora.DtoLayer.NotificationDto;
using Flora.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Flora.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult NatificationList()
        {
            return Ok(_notificationService.TGetAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationsByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {

            var entity = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TInsert(entity);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var entity = _notificationService.TGetById(updateNotificationDto.NotificationId);
            if (entity == null)
            {
                return NotFound("Güncellenecek veri bulunamadı.");
            }
            _mapper.Map(updateNotificationDto, entity);
            _notificationService.TUpdate(entity);
            return Ok("Başarılı bir şekilde güncellendi.");
        }
        [HttpGet("TNotificationStatusChangeToTrue/{id}")]
        public IActionResult TNotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme yapıldı.");
        }
        [HttpGet("TNotificationStatusChangeToFalse/{id}")]
        public IActionResult TNotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme yapıldı.");
        }
    }
}
