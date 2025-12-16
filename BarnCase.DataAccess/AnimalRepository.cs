using System;
using System.Collections.Generic;
using System.Linq;
using BarnCase.Entities;

namespace BarnCase.DataAccess
{
    public class AnimalRepository : IAnimalRepository
    {
        public List<Animal> GetAnimals(string username)
        {
            using (var db = new BarnCaseDbContext())
            {
                return db.Animals
                   .Where(a => a.Username == username)
                   .ToList();
            }
        }

        public void AddAnimal(Animal animal)
        {
            using (var db = new BarnCaseDbContext())
            {
                db.Animals.Add(animal);
                db.SaveChanges();
            }
        }

        public void UpdateAnimal(Animal animal)
        {
            using (var db = new BarnCaseDbContext())
            {
                db.Animals.Attach(animal);
                db.Entry(animal).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void RemoveAnimal(Guid id)
        {
            using (var db = new BarnCaseDbContext())
            {
                var animal = db.Animals.Find(id);
                if (animal != null)
                {
                    db.Animals.Remove(animal);
                    db.SaveChanges();
                }
            }
        }
    }
}