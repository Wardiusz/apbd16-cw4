using Tutorial6.Models;

namespace Tutorial6.Controllers;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/animals/{animalId}/[controller]")]
public class VisitController : ControllerBase {
    [HttpGet]
    public IActionResult GetByAnimal(int animalId) {
        var visits = Database.Visits.Where(v => v.AnimalId == animalId);
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult CreateVisit(int animalId, Visit visit) {
        if (!Database.Animals.Any(a => a.Id == animalId))
            return NotFound("Animal not found");

        visit.Id = Database.Visits.Any() ? Database.Visits.Max(v => v.Id) + 1 : 1;
        visit.AnimalId = animalId;
        Database.Visits.Add(visit);
        return CreatedAtAction(nameof(GetByAnimal), new { animalId = animalId }, visit);
    }
}