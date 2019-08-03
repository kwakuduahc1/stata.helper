using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StataHelper.Model;
using StataHelper.Model.Context;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace StataHelper.Controllers
{
    public class LabelsController : Controller
    {
        private readonly AppDbContext db;

        public LabelsController(DbContextOptions<AppDbContext> options) => db = new AppDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List(short id) => await db.Labels.Where(x => x.LabelCollectionsID == id).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(short id)
        {
            var lab = await db.Labels.FindAsync(id);
            return lab == null ? (IActionResult)NotFound(new { Message = "Label was not found" }) : Ok(lab);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Labels label)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (await db.Labels.AnyAsync(x => x.Label == label.Label))
                return BadRequest(new { Message = "Label already exists" });
            db.Add(label);
            await db.SaveChangesAsync();
            return Created($"", label);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Labels label)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Entry(label).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Accepted(label);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Labels label)
        {
            var lab = await db.Labels.FindAsync(label.LabelsID);
            db.Entry(lab).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Accepted(label);
        }
    }
}