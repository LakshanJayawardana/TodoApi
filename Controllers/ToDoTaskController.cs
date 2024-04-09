using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoTaskController : ControllerBase
{
    private readonly ShopDbContext _context;
    public ToDoTaskController(ShopDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult GetAllToDoTasksAction()
    {
        // Get tasks from database
        var products = _context.TodoItems.ToArray();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public ActionResult GetProduct(long id)
    {
        var product = _context.TodoItems.Find(id);
        return Ok(product);
    }
}


    