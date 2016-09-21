using SalvaDieta.Domain.Commands.UserCommands;
using SalvaDieta.Domain.Entities;
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
        //[Authorize(Roles = "admin")]
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
        //[Authorize]
        [Route("api/users/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var users = _service.Get(id);
            return CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/user/email")]
        public Task<HttpResponseMessage> GetByEmail()
        {
            var email = User.Identity.Name;
            var result = _service.GetByEmail(email);
            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Authorize]
        [Route("api/users/info")]
        public Task<HttpResponseMessage> GetByToken()
        {
            var email = User.Identity.Name;
            var result = _service.GetByEmail(email);
            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/user")]       
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(               
                name: (string)body.name,                
                email: (string)body.email,
                password: (string)body.passwordConfirmation,
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
                youTube: (string)body.youTube               
            );

            var user = _service.Register(command);
            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/user/{id:int:min(1)}")]        
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateUserCommand(
                id: id,               
                name: (string)body.name,
                email: (string)body.email,               
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
                youTube: (string)body.youtube               
            );

            var user = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPut]
        [Authorize]
        [Route("api/user/password-reset/")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var email = User.Identity.Name;
            var command = new UpdatePasswordCommand(

                email: email,
                currentPassword: (string)body.password,
                newPassword: (string)body.newPassword,
                confirmeNewPassword: (string)body.confirmeNewPassword,
                password: (string)body.password
                
                );

            var user = _service.updatePassword(command);
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/user/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var user = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
