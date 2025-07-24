using Microsoft.AsptNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApi.Controllers
{
    //book entity
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
    }


    //dbcontext
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
    }

    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;
        public BooksController(BookContext context)
        {
            _context = context;
        }

        //POST /api/books
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid book data",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { message = "Book added successfully", id = book.Id });
        }

        //GET /api/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        //GET /api/books/search?author=xyz&year=2024
        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery]
        string? author, [FromQuery] int? year)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            }

            if (year.HasValue)
            {
                query = query.Where(b => b.Year == year.Value);
            }

            var books = await query.OrderByDescending(b => b.Year).ToListAsync();
            return Ok(books);
        }
    }
}


// Program.cs

using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseInMemoryDatabase("BookLibrary"));

// Add CORS to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();