﻿
namespace VirtualPetCareWebAPI.Entity.Concretes.Responses
{
    public class GetUserPetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
    }
}
