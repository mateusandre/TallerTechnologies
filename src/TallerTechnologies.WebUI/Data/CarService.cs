using TallerTechnologies.WebUI.Data.Models;

namespace TallerTechnologies.WebUI.Data
{
    public class CarService
    {
        private List<Car> Cars = new()
        {
            new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
            new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
            new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
            new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
            new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
        };

        public bool GuessPrice(int id, decimal guess)
        {
            bool result = false;
            var range = 5000;

            var car = GetCar(id);

            if (car != default)
            {
                result = guess >= (car.Price - range) && guess <= (car.Price + range); 
            }

            return result;
        }

        public List<Car> GetAllCars()
        {
            return Cars;
        }

        public Car GetCar(int id)
        {
            return Cars.FirstOrDefault(x => x.Id == id) ?? new();
        }

        public void AddCar(Car car)
        {
            int lastId = Cars.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0;
            car.Id = lastId + 1;
            Cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            if (car.Id != default)
            {
                var carToUpdate = Cars.FirstOrDefault(x => x.Id == car.Id);

                if (carToUpdate is not null)
                {
                    Cars.Remove(carToUpdate);
                    Cars.Add(car);
                }
            }
        }

        public void DeleteCar(int id)
        {
            var car = Cars.FirstOrDefault(x => x.Id == id);

            if (car is not null) 
            {
                Cars.Remove(car);
            }
        }
    }
}