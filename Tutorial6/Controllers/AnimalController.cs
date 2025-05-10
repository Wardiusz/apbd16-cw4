using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    // api/tests => [controller] = Tests
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        // GET api/tests
        [HttpGet]
        public IActionResult GetAnimalList()
        {
            var tests = Database.Animals;
            return Ok(tests);
        }
        
        // GET api/tests/{id} => {id} = 1
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            return Ok(animal);
        }

        // POST api/tests { "id": 4, "name": "Test4" }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal) {
            Database.Animals.Add(animal);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal) {
            if (!Database.UpdateAnimal(id, animal))
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")] public IActionResult DeleteAnimal(int id) {
            if (!Database.DeleteAnimal(id))
                return NotFound();
            return NoContent();
        }
    }
}
