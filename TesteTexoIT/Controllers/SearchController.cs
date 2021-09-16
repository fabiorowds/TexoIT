using Microsoft.AspNetCore.Mvc;
using System;
using TestoTexoIT.Application.Services;

namespace TesteTexoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {

        SearchMinMaxService _service;

        public SearchController(SearchMinMaxService service)
        {
            _service = service;
        }

        [HttpGet("searchminmax")]
        public ActionResult SearchMinMax()
        {
            try
            {
                return Ok(_service.Search());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
