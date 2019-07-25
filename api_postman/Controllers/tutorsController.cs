using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace api_postman.Controllers
{
    
    
    public class tutorsController : ApiController
    {
    
  
        [AllowAnonymous]
 
        [HttpGet]
        [Route("api/tutors")]


        public IEnumerable<tbl_tutor> Get()
        {
            using (tutorEntities1 entities = new tutorEntities1())
            {

                return entities.tbl_tutor.ToList();

            }
            

       

             
    }

         

          public tbl_tutor Get(int id)
          {
              using (tutorEntities1 entities = new tutorEntities1())
              {

                  return entities.tbl_tutor.FirstOrDefault(t => t.ID == id);

              }


          }
           
            
            
            
       [AllowAnonymous]
        [HttpPost]
            [Route("api/tutors")]


          public HttpResponseMessage Post([FromBody] tbl_tutor tutor)
          {
              try
              {
                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      entities.tbl_tutor.Add(tutor);
                      entities.SaveChanges();
                      var message = Request.CreateResponse(HttpStatusCode.Created, tutor);
                      message.Headers.Location = new Uri(Request.RequestUri + tutor.ID.ToString());
                      return message;
                  }
              }
              catch (Exception e)
              {
                  return Request.CreateResponse(HttpStatusCode.BadRequest, e);

              }

          }

        
        [AllowAnonymous]
      [HttpDelete]

          public HttpResponseMessage Delete(int id)
          {

              try
              {


                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      var entity = entities.tbl_tutor.Remove(entities.tbl_tutor.FirstOrDefault(t => t.ID == id));


                      if (entity == null)
                      {

                          return Request.CreateResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be deleted");
                      }
                      else
                      {
                          entities.tbl_tutor.Remove(entity);
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

        [AllowAnonymous]
        [HttpPut]

          public HttpResponseMessage Put(int id, [FromBody]tbl_tutor tutor)
          {

              try
              {

                  using (tutorEntities1 entities = new tutorEntities1())
                  {

                      var entity = entities.tbl_tutor.FirstOrDefault(t => t.ID == id);

                      if (entity == null)
                      {


                          return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be updated");
                      }


                      else
                      {

                          entity.ID = tutor.ID;
                          entity.City = tutor.City;
                          entity.Email = tutor.Email;
                          entity.Name = tutor.Name;
                          entity.Qualified = tutor.Qualified;
                          entity.Gender = tutor.Gender;
                          entity.Phone = tutor.Phone;
                          entity.Classes = tutor.Classes;
                          entity.Address = tutor.Address;
                          entity.Available = tutor.Available;
                          entity.Dob = tutor.Dob;
                          entity.Experience = tutor.Experience;
                          entity.Subjects = tutor.Subjects;
                          entity.Description = tutor.Description;


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
