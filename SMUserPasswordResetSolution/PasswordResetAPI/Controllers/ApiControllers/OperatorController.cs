using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PasswordResetAPI.BAL;
using PasswordResetAPI.Models;

namespace PasswordResetAPI.Controllers
{
    public class OperatorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult reset(string userName)
        {
            string result;
            try
            {
                SMOperator op = new SMOperator();
               result= op.ResetOperatorPass(userName);
            }
            catch(Exception ex)
            {
                result = ex.Message.ToString();
            }
            return Ok(result);
        }

       /* [HttpGet]
        public IHttpActionResult reset()
        {
            Operator op2 = new Operator();

            op2.email = "asdasd";
            op2.userName = "asdsada";
            
            try
            {
                SMOperator op = new SMOperator();
                //op.ResetOperatorPass(userName);
            }
            catch (Exception ex)
            {

            }
            return Ok(op2);
        }*/
    }
}
