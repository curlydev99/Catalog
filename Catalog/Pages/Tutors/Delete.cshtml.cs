﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Tutors
{
    public class DeleteModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public DeleteModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tutore Tutore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutore = await _context.Tutore.FirstOrDefaultAsync(m => m.ID == id);

            if (Tutore == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutore = await _context.Tutore.FindAsync(id);

            if (Tutore != null)
            {
                _context.Tutore.Remove(Tutore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
