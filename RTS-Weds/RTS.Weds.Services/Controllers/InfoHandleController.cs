using RTS.Weds.Business.Contracts;
using RTS.Weds.Business.Model;
using RTS.Weds.Common;
using RTS.Weds.Services.Base;
using RTS.Weds.Services.Interface;
using RTS.Weds.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTS.Weds.Services.Controllers
{
    
    public class InfoHandleController : BaseController, IInfoHandle
    {
         InfoHandleManager _infoHandleManafer;
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";
        public InfoHandleController(InfoHandleManager infoHandleManager) {

            _infoHandleManafer = infoHandleManager;
        }
        // GET: api/InfoHandle
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/InfoHandle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InfoHandle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/InfoHandle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/InfoHandle/5
        public void Delete(int id)
        {
        }

        //api/InfoHandle/getAllCandidateData/Male
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateType"></param>
        /// <returns></returns>
        
        [HttpGet]
       
        public HttpResponseMessage getAllCandidateData(string candidateType)
        {
           var data= _infoHandleManafer.getAllCandidateData(candidateType);
            HttpResponseMessage response = Request.CreateResponse<CandidateData>(HttpStatusCode.OK, data);

            return response;
        }

        public IEnumerable<object> serachAllData(object searchCriteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> getCandidateDetails(string candidateId)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public HttpResponseMessage registerCandidate()
        {
            var data = _infoHandleManafer.registerCandidate();
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }
        [HttpPost]
        public HttpResponseMessage insertPersonalDetails(Canditate_Personal candidatePersonalData )
        {
            HttpResponseMessage response = new HttpResponseMessage();

            if (candidatePersonalData != null)
            {
                candidatePersonalData.ImageData = candidatePersonalData.ImageData;

                var data = _infoHandleManafer.insertCandidatePersonalDetails(candidatePersonalData);
                response = Request.CreateResponse<object>(HttpStatusCode.OK, data);
            }
            else {
                response = Request.CreateResponse<object>(HttpStatusCode.BadRequest, null);

            }

            return response;

        }

        [HttpPost]
        public HttpResponseMessage insertBirthdetails(BirthDetails birthData)
        {
            var data = _infoHandleManafer.insertBirthdetails(birthData);
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }

        [HttpPost]
        public HttpResponseMessage insertAddressDetails(AddressDetails addressData)
        {
            var data = _infoHandleManafer.insertAddressDetails(addressData);
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }


        [HttpPost]
        public HttpResponseMessage insertEducationDetails(EducationDetails educationData)
        {
            var data = _infoHandleManafer.insertEducationDetails(educationData);
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }

        [HttpPost]
        public HttpResponseMessage insertFamilyetails(FamilyDetails familyData)
        {
            var data = _infoHandleManafer.insertFamilyetails(familyData);
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }


        [HttpPost]
        public HttpResponseMessage insertExpectationdetails(ExpectationDetails expectationData)
        {
            var data = _infoHandleManafer.insertExpectationdetails(expectationData);
            HttpResponseMessage response = Request.CreateResponse<object>(HttpStatusCode.OK, data);

            return response;
        }

        [HttpGet]
        public HttpResponseMessage getCandidateData(int candidateId, string CandidateType)
        {
            var data = _infoHandleManafer.getCandidateData(candidateId, CandidateType);
            HttpResponseMessage response = Request.CreateResponse<IEnumerable<CompleteCandidate>>(HttpStatusCode.OK, data);

            return response;
        }
        [HttpPost]
        public HttpResponseMessage getSearchedData(SearchRequest searchCriteria)
        {
            var data = _infoHandleManafer.getSearchedData(searchCriteria);
            HttpResponseMessage response = Request.CreateResponse<IEnumerable<CompleteCandidate>>(HttpStatusCode.OK, data);

            return response;
        }

        [HttpPost]
        public HttpResponseMessage sendEmailToContact(EmailTemplate email) {

            //var data = sendEmail( email);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        private bool sendEmail(EmailTemplate email)
        {
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("riyajshaikh09@gmail.com", "babalu@09#");
            objeto_mail.From = new MailAddress(email.SenderEmail);
            objeto_mail.To.Add(new MailAddress("riyajshaikh09@outlook.com"));
            objeto_mail.Subject =string.Format("From {0} : for - {1}",email.SenderName, email.Subject);
            objeto_mail.Body = email.Message;
            client.Send(objeto_mail);

            return true;
        }
    }
}
