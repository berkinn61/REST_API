using Microsoft.AspNetCore.Mvc;

namespace _01_MyFirstWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        [HttpPut("increment")]
        public ActionResult<int> Increment([FromBody] int number)
        {
            return Ok(number + 1);
        }

        [HttpPut("add")]
        public ActionResult<int> Add([FromBody] AddNumbersRequest request)
        {
            return Ok(request.Number1 + request.Number2);
        }
    }

    public class AddNumbersRequest
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}
