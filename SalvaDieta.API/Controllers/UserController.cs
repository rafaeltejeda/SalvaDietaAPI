using SalvaDieta.Domain.Commands.UserCommands;
using SalvaDieta.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalvaDieta.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;

        public UserController(IUserApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/users")]
        [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Get()
        {
            var users = _service.Get();
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("api/users/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var users = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        [Route("api/user/{id}")]
        public Task<HttpResponseMessage> GetById(string email)
        {
            var result = _service.GetByEmail(email);
            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("api/users")]
        //[Authorize]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(               
                nome: (string)body.nome,                
                email: (string)body.email,
                password: (string)body.password,
                address: (string)body.address,
                complement: (string)body.complement,
                number: (string)body.number,
                district: (string)body.district,
                city: (string)body.city,
                zip: (string)body.zip,
                state: (string)body.state,
                homePhone: (string)body.homePhone,
                cellPhone: (string)body.cellPhone,
                photo: (string)body.photo,
                facebook: (string)body.facebook,
                twitter: (string)body.twitter,
                instagram: (string)body.instagram,
                youTube: (string)body.youTube,
                isAdmin: (bool)body.isAdmin
            );

            var user = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpPut]
        [Route("api/users")]
        //[Authorize]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateUserCommand(
                id: id,               
                nome: (string)body.nome,
                email: (string)body.email,
                password: (string)body.password,
                address: (string)body.address,
                complement: (string)body.complement,
                number: (string)body.number,
                district: (string)body.district,
                city: (string)body.city,
                zip: (string)body.zip,
                state: (string)body.state,
                homePhone: (string)body.homePhone,
                cellPhone: (string)body.cellPhone,
                photo: (string)body.photo,
                facebook: (string)body.facebook,
                twitter: (string)body.twitter,
                instagram: (string)body.instagram,
                youTube: (string)body.youtube,
                isAdmin: (bool)body.isAdmin
            );

            var user = _service.Update(command);
            return CreateResponse(HttpStatusCode.Created, user);
        }
    }
}
