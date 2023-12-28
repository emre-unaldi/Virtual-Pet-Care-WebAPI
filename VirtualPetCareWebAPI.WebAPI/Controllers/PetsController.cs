using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public IActionResult Add(AddPetRequest addPetRequest)
        {
            var result = _petService.Add(addPetRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UpdatePetRequest updatePetRequest)
        {
            var result = _petService.Update(updatePetRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{petId}")]
        public IActionResult Delete([FromRoute] int petId)
        {
            var result = _petService.Delete(petId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _petService.GetAll();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{petId}")]
        public IActionResult GetPetById([FromRoute] int petId)
        {
            var result = _petService.GetPetById(petId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
