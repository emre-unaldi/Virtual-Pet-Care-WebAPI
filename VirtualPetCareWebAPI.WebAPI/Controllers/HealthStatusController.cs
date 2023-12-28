using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HealthStatusController : ControllerBase
    {
        private readonly IHealthStatusService _healthStatusService;

        public HealthStatusController(IHealthStatusService healthStatusService)
        {
            _healthStatusService = healthStatusService;
        }

        [HttpPost]
        public IActionResult Add(AddHealthStatusRequest addHealthStatusRequest)
        {
            var result = _healthStatusService.Add(addHealthStatusRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UpdateHealthStatusRequest updateHealthStatusRequest)
        {
            var result = _healthStatusService.Update(updateHealthStatusRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{healthStatusId}")]
        public IActionResult Delete([FromRoute] int healthStatusId)
        {
            var result = _healthStatusService.Delete(healthStatusId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _healthStatusService.GetAll();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{healthStatusId}")]
        public IActionResult GetHealthStatusById([FromRoute] int healthStatusId)
        {
            var result = _healthStatusService.GetHealthStatusById(healthStatusId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
