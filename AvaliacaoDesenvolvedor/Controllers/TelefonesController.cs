using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvaliacaoDesenvolvedor.Models;
using System.Text.RegularExpressions;

namespace AvaliacaoDesenvolvedor.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly Context _context;

        public TelefonesController(Context context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var context = _context.Telefones.Include(t => t.Contato);
            return View(await context.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones
                .Include(t => t.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["ContatoId"] = new SelectList(_context.Contatos, "Id", "Nome");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,ContatoId")] Telefone telefone)
        {
            if (Regex.Match(telefone.Numero, @"^\d{5}-\d{4}$").Success)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(telefone);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "O número de telefone deve estar no formato #####-####!");
            }
                ViewData["ContatoId"] = new SelectList(_context.Contatos, "Id", "Nome", telefone.ContatoId);
                return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["ContatoId"] = new SelectList(_context.Contatos, "Id", "Nome", telefone.ContatoId);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,ContatoId")] Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return NotFound();
            }
            if (Regex.Match(telefone.Numero, @"^\d{5}-\d{4}$").Success)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(telefone);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TelefoneExists(telefone.Id))
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
            }
            else
            {
                ModelState.AddModelError(string.Empty, "O número de telefone deve estar no formato #####-####!");
            }
            ViewData["ContatoId"] = new SelectList(_context.Contatos, "Id", "Nome", telefone.ContatoId);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones
                .Include(t => t.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.Id == id);
        }
    }
}
