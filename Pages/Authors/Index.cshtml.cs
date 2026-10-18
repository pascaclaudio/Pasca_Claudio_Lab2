using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pasca_Claudio_Lab2.Models;
using Pasca_Claudio_Lab2.Data;

namespace Pasca_Claudio_Lab2.Pages.AuthorPages;

public class IndexModel : PageModel
{
    private readonly Pasca_Claudio_Lab2Context _context;

    public IndexModel(Pasca_Claudio_Lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Author.ToListAsync();
    }
}
