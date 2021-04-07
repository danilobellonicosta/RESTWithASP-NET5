using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithASP_NET5.Models;
using RESTWithASP_NET5.Services;

namespace RESTWithASP_NET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);

            if (person != null)
                return Ok(person);

            return NotFound();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Create(person));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);

            return NoContent();
        }

        //[HttpGet("media/{firstNumber}/{secondNumber}")]
        //public IActionResult Media(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

        //        return Ok(media.ToString());
        //    }

        //    return BadRequest("Invalid Input.");
        //}

        //[HttpGet("sqrt/{firstNumber}")]
        //public IActionResult Sqrt(string firstNumber)
        //{
        //    if (IsNumeric(firstNumber))
        //    {
        //        var sqrt = Math.Sqrt(ConvertToDouble(firstNumber));

        //        return Ok(sqrt.ToString());
        //    }

        //    return BadRequest("Invalid Input.");
        //}

        //private bool IsNumeric(string strNumber)
        //{
        //    double number;
        //    bool isNumber = double.TryParse(strNumber,
        //                                    System.Globalization.NumberStyles.Any,
        //                                    System.Globalization.NumberFormatInfo.InvariantInfo,
        //                                    out number);
        //    return isNumber;
        //}

        //private double ConvertToDouble(string strNumber)
        //{
        //    double doubleValue;

        //    if (double.TryParse(strNumber, out doubleValue))
        //        return doubleValue;

        //    return 0;
        //}

        //private decimal ConvertToDecimal(string strNumber)
        //{
        //    decimal decimalValue;

        //    if (decimal.TryParse(strNumber, out decimalValue))
        //        return decimalValue;

        //    return 0;
        //}

        //private bool ValidDivOperation(string firstNumber, string secondNumber)
        //{
        //    if (ConvertToDecimal(firstNumber) == 0 && ConvertToDecimal(secondNumber) > 0)
        //        return false;

        //    return true;
        //}
    }
}
