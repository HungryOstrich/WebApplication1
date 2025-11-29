using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entry.Where(e => e.CreatedById == GetUserId()).Include(e => e.Exercise).Include(e => e.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry
                .Include(e => e.Exercise)
                .Include(e => e.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name");
            ViewData["WorkoutId"] = new SelectList(_context.Workout.Where(e => e.CreatedById == GetUserId()), "Id", "Id");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkoutId,ExerciseId,Weight,Sets,Reps")] EntryDTO entryDTO)
        {
            Entry entry = new Entry()
            {
                Id = entryDTO.Id,
                WorkoutId = entryDTO.WorkoutId,
                ExerciseId = entryDTO.ExerciseId,
                Weight = entryDTO.Weight,
                Sets = entryDTO.Sets,
                Reps = entryDTO.Reps,
                CreatedById = GetUserId()
            };
            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", entry.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Id", entry.WorkoutId);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry
                .Where(e => e.CreatedById == GetUserId())
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", entry.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Id", entry.WorkoutId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkoutId,ExerciseId,Weight,Sets,Reps")] EntryDTO entryDTO)
        {
            if (id != entryDTO.Id)
            {
                return NotFound();
            }

            Entry entry = new Entry() 
            {
                Id = entryDTO.Id,
                WorkoutId = entryDTO.WorkoutId,
                Exercise = entryDTO.Exercise,
                Weight = entryDTO.Weight,
                Sets = entryDTO.Sets,
                Reps = entryDTO.Reps,
                CreatedById = GetUserId()
            };
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id, GetUserId()))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Name", entry.ExerciseId);
            ViewData["WorkoutId"] = new SelectList(_context.Workout, "Id", "Id", entry.WorkoutId);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry
                .Where(e => e.CreatedById == GetUserId())
                .Include(e => e.Exercise)
                .Include(e => e.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (EntryExists(id, GetUserId()))
            {
                var entry = await _context.Entry.FindAsync(id);
                _context.Entry.Remove(entry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id, string userId)
        {
            return _context.Entry.Any(e => e.Id == id && e.CreatedById == userId);
        }
    }
}
