using EbillAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EbillAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetInvByInvNo(string invNo)
        {
            try
            {
                InvoiceService invoiceService = new InvoiceService();
                var result = invoiceService.GetInvByInvNoApi(invNo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
