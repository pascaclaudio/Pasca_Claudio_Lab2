using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pasca_Claudio_Lab2.Models;
using Pasca_Claudio_Lab2.Data;

namespace Pasca_Claudio_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Pasca_Claudio_Lab2Context _context;

    public IndexModel(Pasca_Claudio_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .ToListAsync();
    }
}
