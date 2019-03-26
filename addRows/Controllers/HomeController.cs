using AddPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace addRows.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.ConStr);
            IEnumerable<People> ppl = mgr.GetAllPeople();
            return View(ppl);

        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<People> people)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.ConStr);
            foreach (People p in people)
            {
                mgr.AddPerson(p);
            }

            return Redirect("/home/index");
        }
    }
}