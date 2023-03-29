using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("getcarsbrandid")]
        public IActionResult GetCarsBrandId(int id)
        {
            var result = _carService.GetCarsBrandId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
                
        }


        [HttpPost("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
