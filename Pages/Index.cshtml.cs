using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FilmContext _db;

        public IndexModel(ILogger<IndexModel> logger, FilmContext db)
        {
            _logger = logger;
            this._db = db;
        }

        public void OnGet()
        {
            var films = _db.Films
                .Include(r => r.Realisateur) // Includes are left join. Performance issue possible. See 1:46:57 https://www.youtube.com/watch?v=qkJ9keBmQWo&t=48s
                .ToList();
        }
    }
}
