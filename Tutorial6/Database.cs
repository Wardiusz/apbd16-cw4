using Tutorial6.Models;

namespace Tutorial6;

public static class Database {
    public static List<Animal> Animals = new List<Animal>() 
    {
        new Animal() { Id = 1, Name = "Test1", Category = "Category1", Weight = 10.0, FurColor = "black" },
        new Animal() { Id = 2, Name = "Test2", Category = "Category2", Weight = 20.0, FurColor = "yellow" },
        new Animal() { Id = 3, Name = "Test3", Category = "Category3", Weight = 30.0, FurColor = "red" }
    };

    public static List<Visit> Visits = new List<Visit>() 
    {
        new Visit() { Id = 1, AnimalId = 2, Date = new DateTime(2025, 6, 2), Description = "Test1", Price = 10 },
        new Visit() { Id = 2, AnimalId = 3, Date = new DateTime(2025, 7, 10), Description = "Test2", Price = 20 },
        new Visit() { Id = 3, AnimalId = 1, Date = new DateTime(2025, 9, 20), Description = "Test3", Price = 30 }
    };
    
    public static bool UpdateAnimal(int id, Animal updated) {
        var a = Animals.FirstOrDefault(x => x.Id == id);
        if (a == null) return false;
        a.Name = updated.Name;
        a.Category = updated.Category;
        a.Weight = updated.Weight;
        a.FurColor = updated.FurColor;
        return true;
    }

    // Helper for deleting Animal
    public static bool DeleteAnimal(int id) {
        var a = Animals.FirstOrDefault(x => x.Id == id);
        if (a == null) return false;
        Animals.Remove(a);
        return true;
    }
    
}