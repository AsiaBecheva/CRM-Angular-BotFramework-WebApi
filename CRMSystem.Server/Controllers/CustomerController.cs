using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Server.Controllers
{
    //[Authorize(Roles = "Employees", Policy = "OnlyEmployees")]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        // GET api/<controller>/name
        [HttpGet("{name}")]
        public string GetEmail(string name)
        {
            return "value";
        }

        [HttpGet("{name}")]
        public string GetStatus(string name)
        {
            return "value";
        }

        [HttpGet("{name}")]
        public string GetPhone(string name)
        {
            return "value";
        }

        [HttpGet("{name}")]
        public string GetInfo(string name)
        {
            return "value";
        }
    }
}
