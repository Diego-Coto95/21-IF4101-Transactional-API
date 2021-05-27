using _21_IF4101_Transactional_API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _21_IF4101_Transactional_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommentsController : ControllerBase
    {
        private readonly _21IF4101TransactionalAPIContext _context;

        public NewsCommentsController(_21IF4101TransactionalAPIContext context)
        {
            _context = context;
        }

        // GET: api/NewsComments
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsComment>>> GetNewsComments()
        {
            return await _context.NewsComment.Select(newsCommentItem => new NewsComment()
            {
                Id = newsCommentItem.Id,
                Author = newsCommentItem.Author,
                Date = newsCommentItem.Date,
                Comment = newsCommentItem.Comment,
                IdNews = newsCommentItem.IdNews
            }).ToListAsync();
        }

        // GET: api/NewsComments/1
        [Route("[action]")]
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsComment>> GetNewsComment(int id)
        {
            var newsComment = await _context.NewsComment.FindAsync(id);

            if (newsComment == null)
            {
                return NotFound();
            }
            return newsComment;
        }

        // POST: api/NewsComments/PostNewsComment
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<News>> PostNewsComment(NewsComment newsComment)
        {
            _context.NewsComment.Add(newsComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsComment", new { id = newsComment.Id }, newsComment);
        }


        // DELETE: api/NewsComments/5
        [Route("[action]")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsComment>> DeleteNewsComment(int id)
        {
            var newsComment = await _context.NewsComment.FindAsync(id);
            if (newsComment == null)
            {
                return NotFound();
            }

            _context.NewsComment.Remove(newsComment);
            await _context.SaveChangesAsync();

            return newsComment;
        }

        private bool NewsCommentExists(int id)
        {
            return _context.NewsComment.Any(e => e.Id == id);
        }
    }
}
