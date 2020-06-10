using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Driven.Design.API.Models.Custumer;
using Data.Driven.Design.Application.Services;
using Data.Driven.Design.Application.Services.Custumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Data.Driven.Design.API.Controllers
{
    [Route("api/[controller]")]
    public class CustumerController : Controller
    {
        private readonly ICustumerService _service;
        /// <summary>
        /// Contructor from the class.
        /// </summary>
        public CustumerController(ICustumerService service, ILoadDataBase ldb)
        {
            _service = service;
            ldb.LoadCustumer();
        }

        /// <summary>
        /// Gets all the custumers in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<GetAllCustumers.Response>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllCustumersAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(InsertCustumer.Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsertCustumer.Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody]InsertCustumer.Request request)
        {
            var response = await _service.InsertCustumerAsync(request);
            if (response.HasSucced())
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
