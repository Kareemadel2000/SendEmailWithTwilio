using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmailWithTwilio.Dtos;
using SendEmailWithTwilio.Services;

namespace SendEmailWithTwilio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSServices _smsServices;

        public SMSController(ISMSServices smsServices)
        {
            _smsServices = smsServices;
        }

        [HttpPost("send")]
        public IActionResult Send(SendSmsDto dto)
        {
            var result = _smsServices.Send(dto.MobileNmber, dto.Body);

            if(!string.IsNullOrEmpty(result.ErrorMessage)) 
                return BadRequest(result.ErrorMessage);
            return Ok(result);

        }
    }

}
