using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWTodoList.Data;
using TWTodoList.Models;

namespace TWTodoList.Pages.Todos;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Listagem de Tarefas";
        Todos = _context.Todos.OrderBy(todo => todo.Date).ToList();
    }

    public IActionResult OnGetDelete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null) return NotFound();

        _context.Remove(todo);
        _context.SaveChanges();
        return RedirectToPage();
    }

    public IActionResult OnGetToComplete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null) return NotFound();

        todo.IsCompleted = true;

        _context.SaveChanges();

        return RedirectToPage();
    }
}