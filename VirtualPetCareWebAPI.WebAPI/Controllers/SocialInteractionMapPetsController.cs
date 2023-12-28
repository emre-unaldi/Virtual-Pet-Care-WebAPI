using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SocialInteractionMapPetsController : ControllerBase
    {
        private readonly ISocialInteractionService _socialInteractionService;

        public SocialInteractionMapPetsController(ISocialInteractionService socialInteractionService)
        {
            _socialInteractionService = socialInteractionService;
        }

        [HttpPost]
        public IActionResult Add(AddSocialInteractionMapPetRequest addSocialInteractionMapPetRequest)
        {
            _socialInteractionService.Add(addSocialInteractionMapPetRequest);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDetail()
        {
            var result = _socialInteractionService.GetDetails();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{petId}")]
        public IActionResult GetByPetId(int petId)
        {
            var result = _socialInteractionService.GetByPetId(petId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}

