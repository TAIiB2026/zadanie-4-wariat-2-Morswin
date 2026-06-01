using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private readonly GetDataInterface getDataService; 
        private readonly FormSubmitInterface formSubmitService;
        public GetDataController(GetDataInterface getDataService, FormSubmitInterface formSubmitService)
        {
            this.getDataService = getDataService; 
            this.formSubmitService = formSubmitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await this.getDataService.GetAsync();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var res = await this.getDataService.GetAsyncByID(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KsiazkaDTO ksiazkaDto)
        {
            var result = await this.formSubmitService.AddAsync(ksiazkaDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] KsiazkaDTO ksiazkaDto)
        {
            var result = await this.formSubmitService.UpdateAsync(id, ksiazkaDto);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
