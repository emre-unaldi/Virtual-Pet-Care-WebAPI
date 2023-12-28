using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost]
        public IActionResult Add(AddActivityRequest addActivityRequest)
        {
            var result = _activityService.Add(addActivityRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UpdateActivityRequest updateActivityRequest)
        {
            var result = _activityService.Update(updateActivityRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{activityId}")]
        public IActionResult Delete([FromRoute] int activityId)
        {
            var result = _activityService.Delete(activityId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _activityService.GetAll();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{activityId}")]
        public IActionResult GetActivityById([FromRoute] int activityId)
        {
            var result = _activityService.GetActivityById(activityId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
