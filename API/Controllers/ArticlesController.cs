using API.Models;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly TheBeerHouseDbContext _dbContext;

        public ArticlesController(TheBeerHouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles = await _dbContext.Articles
                        .OrderByDescending(a => a.ReleaseDate).ToListAsync();

            return articles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            return await _dbContext.Articles.FindAsync(id);
        }
    }
}