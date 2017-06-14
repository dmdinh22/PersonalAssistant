using Jarvis.Web.Models.ViewModels;
using Jarvis.Web.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jarvis.Web.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleApiController : ApiController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage GetPeople()
        {
            PeopleService peopleSvc = new PeopleService();
            List<Person> peopleList = peopleSvc.GetPeople();
            return Request.CreateResponse(HttpStatusCode.OK, peopleList);
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage CreatePerson(Person model)
        {
            PeopleService peopleSvc = new PeopleService();
            int id = peopleSvc.CreatePerson(model);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}
