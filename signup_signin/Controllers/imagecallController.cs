﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class imagecallController : ApiController
    {
        public IEnumerable<tbl_img> Get()
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.tbl_img.ToList();

            }





        }

    }
}
