using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _21_IF4101_Transactional_API.Models.Entities;

namespace _21_IF4101_Transactional_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly _21IF4101TransactionalAPIContext _context;

        public NewsController(_21IF4101TransactionalAPIContext context)
        {
            _context = new _21IF4101TransactionalAPIContext();
        }

        // GET: api/News/GetNews
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
                PublicationDate = newsItem.PublicationDate.ToString(),
                ModificationDate = newsItem.ModificationDate.ToString(),
                FileNews = newsItem.FileNews,
                Imagen = newsItem.Imagen

            }).ToListAsync();
        }

        [Route("[action]")]
        // GET: api/News/1
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // PUT: api/News/1 --->Also you have to put the id 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> PutNews(News news)
        {

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(news.Id))
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

        // POST: api/News/PostNews
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.Id }, news);
        }

        [Route("[action]")]
        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            //DELELTE NEWS COMMENTS
            var x = (from NewsComment in _context.NewsComment
                     where NewsComment.IdNews == id
                     select NewsComment).ToArray();

            for (int i = 0; i < x.Length; i++)
            {

                _context.NewsComment.Remove(x[i]);
                await _context.SaveChangesAsync();
            }

            //DELELTE NEWS
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