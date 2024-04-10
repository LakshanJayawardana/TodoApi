using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TodoApi.Data;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public async Task<ActionResult> GetAllToDoTasksAction()
    {
        // Get tasks from database
        var products = await _context.TodoItems.ToListAsync();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetToDoTask(long Id)
    {
        var product = await _context.TodoItems.FindAsync(Id);
        if(product == null){
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTask(TodoItem item)
    {
        if(!ModelState.IsValid){
            return BadRequest();
        }
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetToDoTask), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutTask(long id, TodoItem item)
    {
        if(id != item.Id){
            return BadRequest();
        }
        _context.Entry(item).State = EntityState.Modified;
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException){
            if(!_context.TodoItems.Any(e => e.Id == id)){
                return NotFound();
            }
            else{
                throw;
            }

        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(long id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if(item == null){
            return NotFound();
        }
        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}


    