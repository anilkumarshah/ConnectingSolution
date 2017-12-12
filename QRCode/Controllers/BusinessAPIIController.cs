using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace QRCode.Controllers
{
    public class BusinessAPIIController : ApiController
    {
        //[Route("api/BusinessAPII/Disposition/{id}")]
        [HttpGet, HttpPost]
        public string Disposition(int id)
        {

            return "Your disposition value is " + Convert.ToString(id);
        }
        [Route("api/BusinessAPII/ValidateUser/")]
        public HttpResponseMessage ValidateUser([FromBody] string data)
        {
            string result = "anil";
            var resp = new HttpResponseMessage()
            {
                Content = new StringContent("[{\"Name\":\""+ result + "\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]")
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }
        [Route("api/BusinessAPII/Post/")]
        public object Post([FromBody] Customer customer)
        {
            // return Request.CreateResponse(HttpStatusCode.OK, new  {customer = customer});
           // string result = customer.contact_name;
            byte[] QRCode = ReadImageFile("C:\\Users\\anils\\Desktop\\Remittance UI\\Sanbox Partner Portal Error.jpg");
            String result = Convert.ToBase64String(QRCode);
            var resp = new HttpResponseMessage()
            {

                Content = new StringContent("[{\"QRCodeType\":\"mVisa\"},{\"QRCodeGenerationTime\":\""+ DateTime.Now.ToString() + "\"},{\"QRCodeIssuedBy\":\"UDIO\"},{\"QRCOdeByteContent\":\"" + result + "\"}]")
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }

        [Route("api/BusinessAPII/QRCOdeGeneration/")]
        public object QRCOdeGeneration([FromBody] Customer customer)
        {
            // return Request.CreateResponse(HttpStatusCode.OK, new  {customer = customer});
            // string result = customer.contact_name;
            byte[] QRCode = ReadImageFile("C:\\Users\\anils\\Desktop\\Remittance UI\\Sanbox Partner Portal Error.jpg");
            String result = Convert.ToBase64String(QRCode);
            var resp = new HttpResponseMessage()
            {

                Content = new StringContent("[{\"QRCodeType\":\"mVisa\"},{\"QRCodeGenerationTime\":\"" + DateTime.Now.ToString() + "\"},{\"QRCodeIssuedBy\":\"UDIO\"},{\"QRCOdeByteContent\":\"" + result + "\"}]")
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }

        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }
    }

    public class Customer
    {
        public string contact_name { get; set; }
        public string company_name { get; set; }
        
    }
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
