using Microsoft.AspNetCore.Mvc;
using SendNotification.Api.Rrepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SendNotification.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepo _notificationRepo;

        public NotificationController(INotificationRepo notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        // GET: api/<NtificationController>


        // POST api/<NtificationController>
        [HttpPost("SendNotification")]
        public   IActionResult SendNotification([FromBody] string Message)
        {
            var result =  _notificationRepo.SendNotification(Message);
            return Ok(result);
        }

        // PUT api/<NtificationController>/5
        
    }
}
