using Jarvis.Web.Models.ViewModels;
using Jarvis.Web.Services;
using System.Collections.Generic;
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
        } //GetPeople

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetPersonById([FromUri] int id, Person payload)
        {
            PeopleService peopleSvc = new PeopleService();
            Person person = peopleSvc.GetPersonById(id);
            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage CreatePerson(Person payload)
        {
            PeopleService peopleSvc = new PeopleService();
            int id = peopleSvc.CreatePerson(payload);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        } //CreatePerson

        [Route("{id:int}")]
        [HttpPut]
        public HttpResponseMessage UpdatePerson([FromUri] int id, [FromBody] Person payload)
        {
            PeopleService peopleSvc = new PeopleService();

            peopleSvc.UpdatePerson(payload);

            return Request.CreateResponse(HttpStatusCode.OK, payload);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeletePerson([FromUri] int id)
        {
            PeopleService peopleSvc = new PeopleService();

            peopleSvc.DeletePerson(id);

            return Request.CreateResponse(HttpStatusCode.OK, id);
        } //DeletePerson
    }
}
