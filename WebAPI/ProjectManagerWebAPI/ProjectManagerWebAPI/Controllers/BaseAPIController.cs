using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManagerWebAPI.Controllers
{
    public class BaseAPIController : ApiController
    {
        protected delegate IHttpActionResult WebMethodDelegate();        

        protected IHttpActionResult tryCatchWebMethod(WebMethodDelegate method)
        {
            try
            {
                return method();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }            
        }
    }
}
