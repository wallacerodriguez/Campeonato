using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Torneio.App.Interfaces;
using Torneio.Domain.Entities;
using Torneio.MVC.ViewModel;

namespace Torneio.MVC.Controllers
{
    public class CampeonatosController : Controller
    {
        private readonly IUnitOfWorkAppService _unitOfWork;
        public CampeonatosController(IUnitOfWorkAppService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Campeonatos
        public ActionResult Index()
        {
            var campeonatosViewModel = Mapper.Map<IEnumerable<Campeonato>, IEnumerable<CampeonatoViewModel>>(_unitOfWork.CampeonatoAppService.GetAll());
            return View(campeonatosViewModel);
        }

        // GET: Campeonatos/Details/5
        public ActionResult Details(int id)
        {
            var campeonatoViewModel = Mapper.Map<Campeonato, CampeonatoViewModel>(_unitOfWork.CampeonatoAppService.GetByID(id));

            return View(campeonatoViewModel);
        }

        // GET: Campeonatos/Create
        public ActionResult Create()
        {
            var timesViewModel = Mapper.Map<IEnumerable<Time>, IEnumerable<TimeViewModel>>(_unitOfWork.TimeAppService.GetAll());
            ViewBag.Times = new SelectList
               (timesViewModel,
                   "TimeId",
                   "Nome"
               );

            return View();
        }

        // POST: Campeonatos/Create
        [HttpPost]
        public ActionResult Create(CampeonatoViewModel campeonato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var campeonatoDomain = Mapper.Map<CampeonatoViewModel, Campeonato>(campeonato);
                    campeonatoDomain.TimesCampeonatos = new List<TimeCampeonato>();
                    foreach (var x in campeonato.TimeId)
                    {
                        var time = new TimeCampeonato()
                        {
                            CampeonatoId = campeonato.CampeonatoId,
                            TimeId = x
                        };

                        campeonatoDomain.TimesCampeonatos.Add(time);
                    }
                    _unitOfWork.CampeonatoAppService.Insert(campeonatoDomain);
                    _unitOfWork.Commit();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Campeonatos/Edit/5
        public ActionResult Edit(int id)
        {
            var campeonato = _unitOfWork.CampeonatoAppService.GetByID(id);
            var campeonatoViewModel = Mapper.Map<Campeonato, CampeonatoViewModel>(campeonato);

            var timesViewModel = Mapper.Map<IEnumerable<Time>, IEnumerable<TimeViewModel>>(_unitOfWork.TimeAppService.GetAll());
            campeonatoViewModel.TimeId = campeonatoViewModel.TimesCampeonatos.Select(c => c.TimeId).ToList();
            ViewBag.Times = new SelectList
               (timesViewModel,
                   "TimeId",
                   "Nome",
                   campeonatoViewModel.TimesCampeonatos.Select(c => c.TimeId).ToList()

               );


            return View(campeonatoViewModel);
        }

        // POST: Campeonatos/Edit/5
        [HttpPost]
        public ActionResult Edit(CampeonatoViewModel campeonato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var campeonatoDomain = _unitOfWork.CampeonatoAppService.GetByID(campeonato.CampeonatoId);

                    campeonatoDomain.TimesCampeonatos.Clear();

                    foreach (var x in campeonato.TimeId)
                    {
                        var time = new TimeCampeonato()
                        {
                            CampeonatoId = campeonato.CampeonatoId,
                            TimeId = x
                        };

                        campeonatoDomain.TimesCampeonatos.Add(time);
                    }
                    _unitOfWork.CampeonatoAppService.Update(campeonatoDomain);
                    _unitOfWork.Commit();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var timesViewModel = Mapper.Map<IEnumerable<Time>, IEnumerable<TimeViewModel>>(_unitOfWork.TimeAppService.GetAll());
                ViewBag.Times = new SelectList
                 (timesViewModel,
                     "TimeId",
                     "Nome",
                     campeonato.TimesCampeonatos.Select(c => c.TimeId).ToList()

                 );
                return View();
            }
        }

        // GET: Campeonatos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Campeonatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var campeonatoDomain = _unitOfWork.CampeonatoAppService.GetByID(id);
                _unitOfWork.CampeonatoAppService.Delete(campeonatoDomain);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public PartialViewResult ListaJogos(int id)
        {
            var campeonato = _unitOfWork.CampeonatoAppService.GetByID(id);
            var campeonatoView = Mapper.Map<Campeonato, CampeonatoViewModel>(campeonato);
            var listaTimesView = new List<TimeViewModel>();
            foreach (var time in campeonatoView.TimesCampeonatos)
            {
                listaTimesView.Add( Mapper.Map<Time, TimeViewModel>(_unitOfWork.TimeAppService.GetByID(time.TimeId)));
            }

            return PartialView(listaTimesView);
        }
    }
}   
