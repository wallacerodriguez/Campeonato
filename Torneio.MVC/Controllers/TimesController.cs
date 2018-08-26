using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using Torneio.App;
using Torneio.App.Interfaces;
using Torneio.Domain.Entities;
using Torneio.MVC.ViewModel;

namespace Torneio.MVC.Controllers
{
    public class TimesController : Controller
    {

        private readonly IUnitOfWorkAppService _UoW;

        public TimesController(IUnitOfWorkAppService UoW)
        {
            _UoW = UoW;
        }
        // GET: Times
        public ActionResult Index()
        {
            var timesViewModel = Mapper.Map<IEnumerable<Time>, IEnumerable<TimeViewModel>>(_UoW.TimeAppService.GetAll());
            return View(timesViewModel);
        }

        // GET: Times/Details/5
        public ActionResult Details(int id)
        {
            var timesViewModel = Mapper.Map<Time, TimeViewModel>(_UoW.TimeAppService.GetByID(id));

            return View(timesViewModel);
        }

        // GET: Times/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Times/Create
        [HttpPost]
        public ActionResult Create(TimeViewModel time)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var timeDomain = Mapper.Map<TimeViewModel, Time>(time);
                    _UoW.TimeAppService.Insert(timeDomain);
                    _UoW.Commit();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Times/Edit/5
        public ActionResult Edit(int id)
        {
            var timesViewModel = Mapper.Map<Time, TimeViewModel>(_UoW.TimeAppService.GetByID(id));

            return View(timesViewModel);
        }

        // POST: Times/Edit/5
        [HttpPost]
        public ActionResult Edit(TimeViewModel time)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var timeDomain = Mapper.Map<TimeViewModel, Time>(time);
                    _UoW.TimeAppService.Update(timeDomain);
                    _UoW.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Times/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var timeDomain = _UoW.TimeAppService.GetByID(id);
                _UoW.TimeAppService.Delete(timeDomain);
                _UoW.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
