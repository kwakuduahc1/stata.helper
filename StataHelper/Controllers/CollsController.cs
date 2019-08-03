using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StataHelper.Model;
using StataHelper.Model.Context;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace StataHelper.Controllers
{
    public class CollsController : Controller
    {
        private readonly AppDbContext db;

        public CollsController(DbContextOptions<AppDbContext> options) => db = new AppDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List() => await db.LabelCollections.OrderByDescending(x => x.LabelName).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(short id)
        {
            var lab = await db.LabelCollections.FindAsync(id);
            return lab == null ? (IActionResult)NotFound(new { Message = "Label was not found" }) : Ok(lab);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LabelCollections collections)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (await db.LabelCollections.AnyAsync(x => x.LabelName == collections.LabelName))
                return BadRequest(new { Message = "Label already exists" });
            db.Add(collections);
            await db.SaveChangesAsync();
            return Created($"", collections);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] LabelCollections collections)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Entry(collections).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Accepted(collections);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] LabelCollections collections)
        {
            var lab = await db.Labels.FindAsync(collections.LabelCollectionsID);
            db.Entry(lab).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Accepted(collections);
        }
    }
}