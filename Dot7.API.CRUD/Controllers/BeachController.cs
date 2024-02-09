using Dot7.API.CRUD.Data;
using Dot7.API.CRUD.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dot7.API.CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class BeachController : ControllerBase
{
    private readonly ThucTapTotNghiepDbContext _thucTapTotNghiepDbContext;

    public BeachController(ThucTapTotNghiepDbContext thucTapTotNghiepDbContext)
    {
        _thucTapTotNghiepDbContext = thucTapTotNghiepDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var beaches = await _thucTapTotNghiepDbContext.Beach.ToListAsync();
        return Ok(beaches);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Beach newBeach)
    {
        _thucTapTotNghiepDbContext.Beach.Add(newBeach);
        await _thucTapTotNghiepDbContext.SaveChangesAsync();
        return Ok(newBeach);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var beachById = await _thucTapTotNghiepDbContext.Beach.Where(_ => _.Id == id).FirstOrDefaultAsync();
        return Ok(beachById);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Beach beachToUpdate)
    {
        _thucTapTotNghiepDbContext.Beach.Update(beachToUpdate);
        await _thucTapTotNghiepDbContext.SaveChangesAsync();
        return Ok(beachToUpdate);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var beachToDelete = await _thucTapTotNghiepDbContext.Beach.FindAsync(id);
        if (beachToDelete == null)
        {
            return NotFound();
        }
        _thucTapTotNghiepDbContext.Beach.Remove(beachToDelete);
        await _thucTapTotNghiepDbContext.SaveChangesAsync();
        return Ok();
    }
}