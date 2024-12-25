using CollegeApplication.Interfaces___Implimentaions.Interfaces;
using CollegeApplication.Interfaces___Implimentaions;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApplication.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class Logingcontroller : ControllerBase
    {

        private readonly ILog _loging;

        // Define constructor ;;;

        public Logingcontroller(ILog loging)
        {
            _loging = loging;
        }

        // define the first action method 

        [HttpGet]
        [Route("LogtoDatabase")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public ActionResult Index()
        {
            _loging.Log("This is Log to DataBase");
            return Ok();
        }

    }
}
