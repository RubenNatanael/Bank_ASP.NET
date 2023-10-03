using BankProject.Data;
using BankProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankProject.Controllers
{
    public class BankController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BankController( ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Bank> objBankyList  = _db.Banks;
            return View(objBankyList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bank obj)
        {

            if(ModelState.IsValid)
            {
                Bank Nobj = _db.Banks.Where(x => x.Name == obj.Name).FirstOrDefault();
                if (Nobj == null)
                {
                    _db.Banks.Add(obj);
                    _db.SaveChanges();
                    TempData["YourId"] = "Yor Id is: " + obj.Id.ToString();
                    return RedirectToAction("Index","Home");
                    

                }
                else
                    ModelState.AddModelError("Name", "This Bank allready exists!");


            }
            return View(obj);
        
        }



        //GET

        public IActionResult Edit_I()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_I(Bank obj)
        {

            Bank Nobj = _db.Banks.FirstOrDefault(x => x.Name == obj.Name);
            Bank objCopy = _db.Banks.FirstOrDefault(x => x.Id == obj.Id);


            if (obj._Password == objCopy._Password)
            {
                if (_db.Banks.Any(x => x.Id == obj.Id))
                {
                    if ((Nobj != null && obj.Id == Nobj.Id) || Nobj == null)
                    {
                        if (ModelState.IsValid)
                        {
                            objCopy.Name = obj.Name;
                            objCopy._Founds = obj._Founds;
                            _db.Banks.Update(objCopy);
                            _db.SaveChanges();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                        ModelState.AddModelError("Name", "The name of this Bank allready exists!");

                }
                else ModelState.AddModelError("Id", "The Id doesent exists!");
            }
            else ModelState.AddModelError("_Password", "The password is incorrect!");

            return View(obj);

        }

        

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var bankFromDb = _db.Banks.Find(id);
            //var categoryFromDbFirst = _db.Banks.FirstOrDefault(u=> u.Id==id);
            if (bankFromDb == null)
            { return NotFound(); }

            return View(bankFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bank obj)
        {
            Bank objCopy = _db.Banks.FirstOrDefault(x => x.Id == obj.Id);


            if (obj._Password == objCopy._Password)
            {
                if (ModelState.IsValid)
                {
                    objCopy.Name = obj.Name;
                    objCopy._Founds = obj._Founds;
                    _db.Banks.Update(objCopy);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            else ModelState.AddModelError("_Password", "The password is incorrect!");

            return View(obj);

        }
        public IActionResult Loggin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Loggin(string name, string _password)
        {
            if(name=="admin" &&  _password=="admin")
            {
                Bank.Admin = true;
                return RedirectToAction("Index", "Home");

            }

            if (_db.Banks.Any(x => x.Name == name && x._Password == _password))
            {
                Bank BankLoged = _db.Banks.FirstOrDefault(x => x.Name == name);

                if (ModelState.IsValid)
                {
                    Bank.LastBankLoggin = BankLoged;
                    TempData["Founds"] = "Yor Founds are: " + BankLoged._Founds.ToString();
                    return RedirectToAction("Index","Home");

                }
            }
            else  ModelState.AddModelError("Name","Name or password is incorrect");
            
            return View();

        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AddFounds()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFounds(int Quantity)
        {
            if(Quantity > 0)
            {
                if (ModelState.IsValid)
                {
                    Bank.LastBankLoggin.addFounds(Quantity,_db);
                    return RedirectToAction("Index", "Home" );

                }
            }
            else ModelState.AddModelError("Founds", "Introduce a numerical value between 1-10000");
            return View(Quantity);
            
        }


    }
}
