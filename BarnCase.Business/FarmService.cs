using System;
using System.Collections.Generic;
using BarnCase.DataAccess;
using BarnCase.Entities;

namespace BarnCase.Business
{
    public class FarmService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IUserMoneyRepository _moneyRepo;

        public FarmService(IAnimalRepository animalRepository,
                           IUserMoneyRepository moneyRepository)
        {
            _animalRepo = animalRepository;
            _moneyRepo = moneyRepository;
        }

        public List<Animal> GetAnimals(string username)
        {
            return _animalRepo.GetAnimals(username);
        }

        public void AddAnimal(Animal animal)
        {
            _animalRepo.AddAnimal(animal);
        }

        public void UpdateAnimal(Animal animal)
        {
            _animalRepo.UpdateAnimal(animal);
        }

        public void DeleteAnimal(Guid id)
        {
            _animalRepo.RemoveAnimal(id);
        }

        public decimal GetMoney(string username)
        {
            return _moneyRepo.GetMoney(username);
        }

        public void SetMoney(string username, decimal money)
        {
            _moneyRepo.SetMoney(username, money);
        }
    }
}
