
using Microsoft.AspNetCore.Mvc;
using Post.Services;
using System.Collections.Generic;

namespace Post.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController
    {
        private readonly IGatewayService _gatewayService;
        public GatewayController(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        [HttpGet]
        public void GetPosts(int? pageNumber, int pageSize)
        {
            //_gatewayService.GetAllPostsByUser(pageNumber, pageSize);            
        }
    }
}