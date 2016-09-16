using SalvaDieta.Domain.Commands.DayCommands;
using SalvaDieta.Domain.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalvaDieta.API.Controllers
{
    public class DayController : BaseController
    {
        private readonly IDayApplicationService _service;

        public DayController(IDayApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/days")]
        public Task<HttpResponseMessage> Get()
        {
            var days = _service.Get();
            return CreateResponse(HttpStatusCode.OK, days);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/day/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var days = _service.Get(id);
            return CreateResponse(HttpStatusCode.OK, days);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/days/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var days = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.OK, days);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/day")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateDayCommand(
                dayofweek: (DateTime)body.dayOfWeek,
                active: (bool)body.active,      
                reserved: (bool)body.reserved
            );

            var day = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, day);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/day/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateDayCommand(
                id: id,
                dayofweek: (DateTime)body.dayOfWeek,
                active: (bool)body.active,
                reserved: (bool)body.reserved
            );

            var product = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpDelete]
        [Authorize]
        [Route("api/day/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var day = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, day);
        }

    }
}
