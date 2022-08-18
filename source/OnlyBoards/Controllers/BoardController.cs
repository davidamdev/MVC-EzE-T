using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OnlyBoards.Controllers
{
    public class BoardController : Controller
    {
        private readonly Context _context;

        public BoardController(Context context)
        {
            _context = context;
        }

        // GET: Board
        public async Task<IActionResult> Index()
        {
              return _context.Boards != null ? 
                          View(await _context.Boards.ToListAsync()) :
                          Problem("Entity set 'Context.Boards'  is null.");
        }

        // GET: Board/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var board = await _context.Boards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // GET: Board/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Size,Manufacturer,Price,Quantity")] Board board)
        {
            if (ModelState.IsValid)
            {
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Board/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Size,Manufacturer,Price,Quantity")] Board board)
        {
            if (id != board.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.ID))
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
            return View(board);
        }

        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var board = await _context.Boards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boards == null)
            {
                return Problem("Entity set 'Context.Boards'  is null.");
            }
            var board = await _context.Boards.FindAsync(id);
            if (board != null)
            {
                _context.Boards.Remove(board);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
          return (_context.Boards?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
