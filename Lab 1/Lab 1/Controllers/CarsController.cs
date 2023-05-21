using Lab_1.Filters;
using Lab_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private static List<Car> _cars = new List<Car>
    {
        new (1, "BMW", "X6", 2019, 1000000,"Gas"),
        new (2, "Spranza", "A113", 2011, 150000, "Gas")
    };

    // Get: api/Cars
    [HttpGet]
    public ActionResult<List<Car>> GetAllCars()
    {
        return _cars;       //default status code return is 200
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
        Car _car = _cars.FirstOrDefault(c => c.Id == id);
        if (_car is null)
        {
            return NotFound(new { message = "Car isn't Found!"});
        }
        return _car; 
    }

    [HttpPost]
    [Route("v1")]
    public ActionResult<Car> AddNewCar_V1(Car NewCar)
    {
        NewCar.Id = _cars.Count + 1;
        NewCar.Type = "Gas";

        _cars.Add(NewCar);
        return CreatedAtAction(
            "GetCarById",   // nameof(GetCarById)
            new { ID = NewCar.Id },         // return in headers
            new GeneralResponse("Car Added ^_^")      // return message in body
        );  //201 created successfuly .. next step tp the user .. message or any body
    }

    [HttpPost]
    [Route("v2")]
    [TypeValidate]
    public ActionResult<Car> AddNewCar_V2(Car NewCar)
    {
        NewCar.Id = _cars.Count + 1;

        _cars.Add(NewCar);
        return CreatedAtAction(
            "GetCarById",   // nameof(GetCarById)
            new { ID = NewCar.Id },         // return in headers
            new GeneralResponse("Car Added ^_^")      // return message in body
        );  //201 created successfuly .. next step tp the user .. message or any body
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Car> UpdateCar(int id, Car NewCarData) 
    { 
        if (NewCarData.Id != id)
        {
            return BadRequest(new { message = "Car isn't Found!" });
        }
        Car car = _cars.FirstOrDefault(c => c.Id == id);
        if (car is null)
        {
            return NotFound();
        }
        car.ProductionDate = NewCarData.ProductionDate;
        car.Name = NewCarData.Name;
        car.Model = NewCarData.Model;
        car.Prise = NewCarData.Prise;
        return CreatedAtAction(
            "GetCarById", 
            new { NewCarData.Id }, 
            new GeneralResponse("Car Updated :)")
        );
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteCar(int id)
    {
        Car carToDelete = _cars.FirstOrDefault(c => c.Id == id);
        if (carToDelete is null)
        {
            return NotFound();
        }
        _cars.Remove(carToDelete);
        return NoContent();       // every thing is ok but there is nothing to return
    }
}
