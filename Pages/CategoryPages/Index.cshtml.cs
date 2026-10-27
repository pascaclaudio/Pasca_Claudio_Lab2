using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pasca_Claudio_Lab2.Models;
using Pasca_Claudio_Lab2.Data;
using Pasca_Claudio_Lab2.ViewModels; // Asigură-te că ai adăugat acest using pentru ViewModel

namespace Pasca_Claudio_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Pasca_Claudio_Lab2Context _context;

    public IndexModel(Pasca_Claudio_Lab2Context context)
    {
        _context = context;
    }

    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();

        CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
                .ThenInclude(c => c.Book)
                    .ThenInclude(b => b.Author)
            .AsNoTracking()
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
            CategoryData.Books = category.BookCategories.Select(s => s.Book);
        }
    }
}