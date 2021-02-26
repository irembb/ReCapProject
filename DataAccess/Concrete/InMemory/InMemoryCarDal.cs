using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2000,DailyPrice=600,Description="SUV"},
                new Car{CarId=2,BrandId=2,ColorId=2,ModelYear=2016,DailyPrice=1000.99,Description="SEDAN"},
                new Car{CarId=3,BrandId=1,ColorId=3,ModelYear=2020,DailyPrice=2599.99,Description="SUV"},
                new Car{CarId=4,BrandId=3,ColorId=5,ModelYear=2015,DailyPrice=1000000,Description="HATCHBACK"},
                new Car{CarId=5,BrandId=2,ColorId=4,ModelYear=2018,DailyPrice=1000000,Description="SEDAN"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear= car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.CarId == carId).ToList();
            
        }
        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
