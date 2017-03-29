using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ms.logDemoAPI.Model;
using ms.logBasic.Service;
using System.Linq;
using Raven.Client.Document;
using Microsoft.Extensions.Logging;
using Serilog;
using ms.logDemo.Types.Contact;

namespace ms.logDemoAPI.Controllers
{
   
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }
        
        //Get/Contact
        [HttpGet]
        public IActionResult Get()
        {
            var list = _service.GetList();//Data();
            Log.Information("Fetched Contact list {@Contacts}", list);
            return Json(list); 
        }


        [HttpGet("{id}")]
        public IActionResult Getitem(int id)
        {
            Log.Information("Fetching a contact with {id}",id);

            var result = _service.GetItem(id);//Data().Where(x => x.Id == id).Select(x => x).SingleOrDefault();

            Log.Information("After Fetching  contact {@Contact}", result);

            var item = (result == null ? new ContactDTO() : result);

            Log.Verbose("The generated contact PostCode is {PostCode}", result.PostCode);

            return Json(item);
        }

        public IActionResult Index()
        {
            return View();
        }

        private List<logDemoAPI.Model.Contact> Data()
        {
            return new List<logDemoAPI.Model.Contact> { new logDemoAPI.Model.Contact { Id = 1, Address1 = "11 Cambridge Way", Address2 = "Cambridge", PostCode = "CB1 1WW", Age = 25 },
               new logDemoAPI.Model.Contact  { Id = 2, Address1 = "12 Havehill Way", Address2 = "Haverhill", PostCode = "CB21 1WW", Age = 35 },
                  new logDemoAPI.Model.Contact  { Id = 3, Address1 = "12 Barhill Way", Address2 = "Barhill", PostCode = "CB21 1WW", Age = 45 }
            };
        }

    }
}