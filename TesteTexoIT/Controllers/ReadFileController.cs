using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestoTexoIT.Application.Services;

namespace TesteTexoIT.Controllers
{
    [ApiController]
    [Route("file")]
    public class ReadFileController : Controller
    {

        ReadFileService _service;

        public ReadFileController(ReadFileService service)
        {
            _service = service;
        }

        [HttpPost("read")]
        public ActionResult ReadFile(IFormFile file)
        {
            try
            {
                _service.ReadFile(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
