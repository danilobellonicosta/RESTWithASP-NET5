using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTWithASP_NET5.Business;
using RESTWithASP_NET5.Data.VO;

namespace RESTWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IBookBusiness _bookService;

        public BookController(ILogger<PersonController> logger, IBookBusiness bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookService.FindByID(id);

            if (book != null)
                return Ok(book);

            return NotFound();
        }

        [HttpPost()]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();
            else
                return Ok(_bookService.Create(book));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();
            else
                return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
