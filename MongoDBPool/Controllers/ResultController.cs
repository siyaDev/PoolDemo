using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDBPool.Models;
using MongoDBPool.Repository;
using MongoDBPool.Services;
using MongoDBPool.ViewModels;


namespace MongoDBPool.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/
        private readonly ResultRepository _resultRepo;
        private readonly PlayerRepository _playerRop;
        private readonly ResultsService _resultsService;

        public ResultController()
        {
            _resultRepo = new ResultRepository();
            _playerRop = new PlayerRepository();
            _resultsService = new ResultsService(new PlayerRepository(), new ResultRepository());
        }

        public ActionResult Index(string id)
        {

            return View(_resultRepo.SelectAllAsList());
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_resultRepo.SelectById(int.Parse(id)));
        }

        [HttpPost]
        public ActionResult Edit(EditResultsView model, FormCollection collection)
        {
            var results = new Results(int.Parse((collection["_id"])), model.HostBallLeft, model.OppnentBallLeft);

            _resultRepo.Update(results);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateResult(string id, FormCollection form)
        {
            //Get select player by id
            var currentPlayer = _playerRop.SelectById(int.Parse(id));
            //filtering players list
            var listOfPlayer = _playerRop.SelectAllAsList().Where(x => x.Id != int.Parse(id)).OrderBy(x => x.FirstName);
            var blackBallPlayer = _playerRop.SelectAllAsList().OrderBy(x => x.FirstName);
            var blackballplayerlist = blackBallPlayer.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString(), Selected = false }).ToList();
            var selectList = listOfPlayer.Select(x => new SelectListItem{Text = x.FirstName + " " + x.LastName,Value = x.Id.ToString(),Selected = false}).ToList();
            //inserting markup tags for dropdown
            selectList.Insert(0, new SelectListItem { Selected = true, Text = "Choose", Value = "Choose" });
            blackballplayerlist.Insert(0, new SelectListItem { Selected = true, Text = "Choose", Value = "Choose" });

            var viewModel = new PlayerCreateViewModel() { SelectedPLayerValue = selectList, BalckBallPLayerValue = blackballplayerlist };
            viewModel.FirstName = currentPlayer.FirstName;
            viewModel.LastName = currentPlayer.LastName;
            viewModel.Age = currentPlayer.Age;
            viewModel.Id = currentPlayer.Id;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateResult(string id, PlayerCreateViewModel modelView, FormCollection form)
        {
            TryUpdateModel(modelView, form.ToValueProvider());
            var hostPlayer = _playerRop.SelectById(int.Parse(id));
            var opponent = _playerRop.SelectById(int.Parse(form["Opponent"]));
            var blackBallPlayer = _playerRop.SelectById(int.Parse(form["BlackBallPlayer"]));

            var newResult = new Results(hostPlayer.Id, opponent.Id, DateTime.Today, int.Parse(form["MyList1"]), int.Parse(form["MyList2"]),blackBallPlayer.Id, int.Parse(form["blackBall"]));
            _resultsService.ResultsEvaluation(newResult);
            _resultsService.CalculatePoints(newResult);

            ViewBag.id = id;

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult DisplayResults(string id)
        {
            var viewModel = new DisplayResultView();
            viewModel.HostResults = _resultRepo.SelectAllResultsAsList(int.Parse(id));

            return View(viewModel);
        }



    }

    }



