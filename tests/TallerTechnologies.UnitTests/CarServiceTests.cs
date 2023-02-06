using TallerTechnologies.WebUI.Data;
using TallerTechnologies.WebUI.Data.Models;
using TallerTechnologies.WebUI.Pages;

namespace TallerTechnologies.UnitTests
{
    public class CarServiceTests
    {
        private readonly CarService _carService = new();

        [Fact]
        public void Should_get_all_cars()
        {
            var cars = _carService.GetAllCars();

            Assert.True(cars.Any());
        }

        [Fact]
        public void Should_add_a_car()
        {
            var car = new Car()
            {
                Make = "TestMake",
                Model = "TestModel",
                Color = "Black",
                Doors = 4,
                Price = 100000,
                Year = 2023
            };

            _carService.AddCar(car);

            var cars = _carService.GetAllCars();
            Assert.Contains<Car>(cars, x => x.Make == car.Make && x.Model == car.Model);
        }

        [Fact]
        public void Should_delete_a_car()
        {
            _carService.DeleteCar(1);
            var cars = _carService.GetAllCars();
            Assert.DoesNotContain(cars, x => x.Id == 1);
        }

        [Fact]
        public void Should_update_a_car()
        {
            var car = new Car()
            {
                Id = 1,
                Make = "TestMake updated",
                Model = "TestModel",
                Color = "Black",
                Doors = 4,
                Price = 100000,
                Year = 2023
            };
            _carService.UpdateCar(car);

            var updatedCar = _carService.GetCar(car.Id);

            Assert.Equal(car.Make, updatedCar.Make);
        }

        [Theory]
        [InlineData(75000)]
        [InlineData(79995)]
        [InlineData(84995)]
        public void Should_guess_a_price_successfully(decimal guess)
        {
            bool result = _carService.GuessPrice(1, guess);
            Assert.True(result);
        }

        [Theory]
        [InlineData(94999)]
        [InlineData(84996)]
        public void Should_guess_a_price_unsuccessfully(decimal guess)
        {
            bool result = _carService.GuessPrice(1, guess);
            Assert.False(result);
        }
    }
}