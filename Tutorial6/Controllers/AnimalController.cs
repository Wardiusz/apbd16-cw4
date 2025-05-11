using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    // api/animal => [controller] = animal
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        // GET api/animal
        [HttpGet]
        public IActionResult GetAnimalList()
        {
            var tests = Database.Animals;
            return Ok(tests);
        }
        
        // GET api/animal/{id} => {id} = 1
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            return Ok(animal);
        }

        // POST api/animal { "id": 4, "name": "Test4" }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal) {
            Database.Animals.Add(animal);
            return Created();
        }

        // POST api/animal { "id": 1, "name": "Test1" }
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal) {
            if (!Database.UpdateAnimal(id, animal))
                return NotFound();
            return NoContent();
        }

        // DELETE api/animal { "id": 1 }
        [HttpDelete("{id}")] public IActionResult DeleteAnimal(int id) {
            if (!Database.DeleteAnimal(id))
                return NotFound();
            return NoContent();
        }
        
        // GET api/animal/{id} => {id} = 1
        [HttpGet("search/{name}")]
        public IActionResult GetAnimalByName(string name) {
            var animal = Database.Animals.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(animal);
        }
    }
}
