using Microsoft.AspNetCore.Mvc;
using System;
using TesteTexoIT.Domain.Entities;
using TestoTexoIT.Application.Services;

namespace TesteTexoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwardController : Controller
    {
        AwardService _service;

        public AwardController(AwardService service)
        {
            _service = service;
        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            {
                try
                {
                    return Ok(_service.Get(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            {
                try
                {
                    return Ok(_service.GetAll());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("add")]
        public ActionResult Add([FromBody] Award award)
        {
            {
                try
                {
                    _service.Add(award);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] Award award)
        {
            {
                try
                {
                    _service.Update(award);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            {
                try
                {
                    _service.Delete(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("deleteall")]
        public ActionResult DeleteAll()
        {
            {
                try
                {
                    _service.DeleteAll();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
