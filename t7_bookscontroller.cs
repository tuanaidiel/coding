using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private const string ValidBearerToken = "mysecrettoken123";
        private const string ValidApiKey = "secretapikey123";

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            //Check authentication
            bool isAuthenticated = false;
            string authHeader = Request.Headers["Authorization"];
            string apiKeyHeader = Request.Headers["x-api-key"];

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                string token = authHeader.Substring("Bearer ".Length).Trim();
                isAuthenticated = token == ValidBearerToken;
            }

            else if (!string.IsNullOrEmpty(apiKeyHeader))
            {
                isAuthenticated = apiKeyHeader == ValidApiKey;
            }

            if (!isAuthenticated)
            {
                return Unauthorized(new { message = "Invalid or missing authentication credentials" });
            }


            // validate JSON payload
            if (book == null || string.IsNullOrEmpty(book.Title?.Trim()) || string.IsNullOrEmpty(book.Author?.Trim()) || book.Year == 0)
            {
                return BadRequest(new { message = "All fields (title, author, year) are required and cannot be empty" });
            }

            //book addition logic is here
            //example, return success
            return StatusCode(201, new { message = "Book added successfully" });
        }
    }
}