using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _21_IF4101_Transactional_API.Models;

//namespace _21_IF4101_Transactional_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NewsController : ControllerBase
//    {
//        private readonly _21IF4101TransactionalContext _context;

//        public NewsController(_21IF4101TransactionalContext context)
//        {
//            _context = new _21IF4101TransactionalContext();
//        }

//        [Route("[action]")]
//        // GET: api/News
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<News>>> GetNews()
//        {
//            return await _context.News.ToListAsync();
//        }

//        [Route("[action]")]
//        // GET: api/News/1
//        [HttpGet("{id}")]
//        public async Task<ActionResult<News>> GetNews(int id)
//        {
//            var news = await _context.News.FindAsync(id);

//            if (news == null)
//            {
//                return NotFound();
//            }

//            return news;
//        }

//        // PUT: api/News/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [Route("[action]")]
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutNews(int id, News news)
//        {
//            if (id != news.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(news).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!NewsExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/News
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [Route("[action]")]
//        [HttpPost]
//        public async Task<ActionResult<News>> PostNews(News news)
//        {
//            _context.News.Add(news);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetNews", new { id = news.Id }, news);
//        }

//        // DELETE: api/News/5
//        [Route("[action]")]
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<News>> DeleteNews(int id)
//        {
//            var news = await _context.News.FindAsync(id);
//            if (news == null)
//            {
//                return NotFound();
//            }

//            _context.News.Remove(news);
//            await _context.SaveChangesAsync();

//            return news;
//        }

//        private bool NewsExists(int id)
//        {
//            return _context.News.Any(e => e.Id == id);
//        }
//    }
//}




namespace _21_IF4101_Transactional_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly _21IF4101TransactionalContext _context;

        public NewsController(_21IF4101TransactionalContext context)
        {
            _context = new _21IF4101TransactionalContext();
        }

        // GET: api/Student
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await _context.News.Select(newsItem => new News()
            {
                Id = newsItem.Id,
                Title = newsItem.Title,
                Description = newsItem.Description,
                Author = newsItem.Author,
                PublicationDate = newsItem.PublicationDate,
                ModificationDate = newsItem.ModificationDate,
                FileNew = newsItem.FileNew,
                Imagen = newsItem.Imagen

        }).ToListAsync();

        }

        [Route("[action]")]
        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var student = await _context.News.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/News/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.Id }, news);
        }

        [Route("[action]")]
        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}