using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost]
        public IActionResult Add(AddFoodRequest addFoodRequest)
        {
            var result = _foodService.Add(addFoodRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UpdateFoodRequest updateFoodRequest)
        {
            var result = _foodService.Update(updateFoodRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{foodId}")]
        public IActionResult Delete([FromRoute] int foodId)
        {
            var result = _foodService.Delete(foodId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _foodService.GetAll();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{foodId}")]
        public IActionResult GetFoodById([FromRoute] int foodId)
        {
            var result = _foodService.GetFoodById(foodId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
