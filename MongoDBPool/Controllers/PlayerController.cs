using System.Linq;
using System.Web.Mvc;
using MongoDBPool.Models;
using MongoDBPool.Repository;
using MongoDBPool.Services;
using MongoDBPool.ViewModels;


namespace MongoDBPool.Controllers
{
     public class PlayerController : Controller
     {
        
         private readonly PlayerRepository _playerRop;   
         private readonly RegistorPlayerService _playerRegistrationService;
       
        public PlayerController()
        {
            _playerRop = new PlayerRepository();
         
            _playerRegistrationService = new RegistorPlayerService(new PlayerRepository(), new PlayerValidator());
        }

        public ActionResult Index()
        {
            return View(_playerRop.SelectAllAsList().OrderBy(x => x.FirstName));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PlayerCreateViewModel model)
        {       
              var player = new Player(model.FirstName, model.LastName, model.Age, model.EmailAddress);
              var emailMesage = _playerRegistrationService.PlayerRegistration(player).EmailAddress;
              if (emailMesage == "Player Email Already Exist ")
            {         
                ModelState.AddModelError("PlayerCheck", emailMesage);
                return View();        
            }
            
                return RedirectToAction("Index");                    
          }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_playerRop.SelectById(id));
        }

        [HttpPost]
        public ActionResult Edit(PlayerCreateViewModel model, FormCollection collection)
        {
            var player = new Player(int.Parse((collection["Id"])), model.FirstName, model.LastName, model.Age, model.EmailAddress);

            _playerRop.Update(player);

            return RedirectToAction("Index");
        }    
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
           return View(_playerRop.SelectById(id));
        }

      [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id) 
      {
        _playerRop.Delete(id);
        return RedirectToAction("Index");
      }
     }
}
