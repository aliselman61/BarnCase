using System;
using System.Collections.Generic;
using BarnCase.Entities;

namespace BarnCase.DataAccess
{
    public interface IAnimalRepository
    {
        List<Animal> GetAnimals(string username);
        void AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void RemoveAnimal(Guid id);
    }
}
