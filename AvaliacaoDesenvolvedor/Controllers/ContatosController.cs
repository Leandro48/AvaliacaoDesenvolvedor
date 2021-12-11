using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvaliacaoDesenvolvedor.Models;

namespace AvaliacaoDesenvolvedor.Controllers
{
    public class ContatosController : Controller
    {
        private readonly Context _context;

        public ContatosController(Context context)
        {
            _context = context;
        }

        // GET: Contatos
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Contatos.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string nome)
        {
            var nomes = from m in _context.Contatos select m;

            if (!String.IsNullOrEmpty(nome))
            {
                nomes = nomes.Where(s => s.Nome!.Contains(nome));
                return View(nomes);
            }

            return View(await _context.Contatos.ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                //adicionado este include para incluir os telefones na lista de detalhes
                .Include(t => t.Telefones)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
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
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .Include(t => t.Telefones)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contatos
                .Include(t => t.Telefones)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            //verifica se não existem telefones dentro do contato
            if (!contato.Telefones.Any())
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
            else
            {                
                ModelState.AddModelError(string.Empty, "O contato possui telefones cadastrados e não pode ser excluído!");
                return View(contato);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
