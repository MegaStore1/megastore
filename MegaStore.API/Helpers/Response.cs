using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers
{
    public class Response
    {
        private ResponseCode statusCode;
        public ResponseCode StatusCode
        {
            get { return statusCode; }
            set { statusCode = value; }
        }


        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}