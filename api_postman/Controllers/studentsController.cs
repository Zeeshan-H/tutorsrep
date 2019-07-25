using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace api_postman.Controllers
{

         [Authoriza]
    public class studentsController : ApiController
    {


   
       [HttpGet]
       [Route("api/students")]
    
        public IEnumerable<tbl_student> Get()
        {
            using (tutorEntities1 entities = new tutorEntities1())
            {

                return entities.tbl_student.ToList();

            }


        }

          public tbl_student Get(int id)
          {
              using (tutorEntities1 entities = new tutorEntities1())
              {

                  return entities.tbl_student.FirstOrDefault(t => t.id == id);

              }


          }

          [HttpPost]
          [Route("api/students")]

          public HttpResponseMessage Post([FromBody] tbl_student tutor)
          {
              try
              {
                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      entities.tbl_student.Add(tutor);
                      entities.SaveChanges();
                      var message = Request.CreateResponse(HttpStatusCode.Created, tutor);
                      message.Headers.Location = new Uri(Request.RequestUri + tutor.id.ToString());
                      return message;
                  }
              }
              catch (Exception e)
              {
                  return Request.CreateResponse(HttpStatusCode.BadRequest, e);

              }

          }
        [HttpDelete]



          public HttpResponseMessage Delete(int id)
          {

              try
              {


                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      var entity = entities.tbl_student.Remove(entities.tbl_student.FirstOrDefault(t => t.id == id));


                      if (entity == null)
                      {

                          return Request.CreateResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be deleted");
                      }
                      else
                      {
                          entities.tbl_student.Remove(entity);
                          entities.SaveChanges();
                          return Request.CreateResponse(HttpStatusCode.OK);
                      }


                  }
              }
              catch (Exception e)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

              }

          }


        [HttpPut]

          public HttpResponseMessage Put(int id, [FromBody]tbl_student tutor)
          {

              try
              {

                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      var entity = entities.tbl_student.FirstOrDefault(t => t.id == id);

                      if (entity == null)
                      {


                          return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be updated");
                      }


                      else
                      {

                          entity.id = tutor.id;
                          entity.Email = tutor.Email;
                          entity.Name = tutor.Name;
                          entity.City = tutor.City;
                          entity.Address = tutor.Address;
                          entity.Description = tutor.Description;
                          entity.Dob = tutor.Dob;
                          entity.Phone = tutor.Phone;
                          entity.Class = tutor.Class;
                          entity.Subjects = tutor.Subjects;

                          entities.SaveChanges();
                          return Request.CreateResponse(HttpStatusCode.OK);
                      }
                  }
              }

              catch (Exception e)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

              }
          }

    
    
    }
}
