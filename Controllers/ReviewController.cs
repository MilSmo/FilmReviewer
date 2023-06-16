using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmReviewerApp.Data;
using FilmReviewerApp.Models;

namespace FilmReviewerApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly FilmReviewerAppContext _context;
        public Dictionary<string, int> Films_Ratings { get; } = new Dictionary<string, int>();

        public ReviewController(FilmReviewerAppContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index(string searchString)
        {
            var reviews = from r in _context.Review
                          select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                reviews = reviews.Where(r => r.FilmTitle.Contains(searchString));
                ViewBag.SearchString = searchString;
            }

            return _context.Review != null ?
                          View(await reviews.ToListAsync()) :
                          Problem("Entity set 'FilmReviewerAppContext.Review'  is null.");
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,ReviewText,Rating,FilmTitle,SeriesTitle,UserName")] Review review)
        {
            if (ModelState.IsValid)
            {
                
                // var user = new User { Name = review.UserName };
                // _context.Add(user);
                // await _context.SaveChangesAsync();


                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(review);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ReviewId,ReviewText,Rating,FilmTitle,SeriesTitle,UserName")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'FilmReviewerAppContext.Review'  is null.");
            }
            var review = await _context.Review.FindAsync(id);
            if (review != null)
            {
                _context.Review.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int? id)
        {
            return (_context.Review?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }
    }
}
