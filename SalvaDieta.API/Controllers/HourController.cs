using SalvaDieta.Domain.Commands.HourCommands;
using SalvaDieta.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalvaDieta.API.Controllers
{
    public class HourController : BaseController
    {
        private readonly IHourApplicationService _service;

        public HourController(IHourApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/Hours")]
        public Task<HttpResponseMessage> Get()
        {
            var Hours = _service.Get();
            return CreateResponse(HttpStatusCode.OK, Hours);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/Hour/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var Hours = _service.Get(id);
            return CreateResponse(HttpStatusCode.OK, Hours);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/Hours/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var Hours = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.OK, Hours);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/Hour")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateHourCommand(
                hourOfDay: (DateTime)body.hourOfDay,
                active: (bool)body.actvate,
                reserved: (bool)body.reserved,
                dayId: (int)body.dayId
            );

            var Hour = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, Hour);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/Hour/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateHourCommand(
                id: id,
                hourOfDay: (DateTime)body.hourOfDay,
                active: (bool)body.active,
                reserved: (bool)body.reserved,
                dayId: (int)body.dayId
            );

            var product = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/Hour/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var Hour = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, Hour);
        }

    }
}

