using Azure.Identity;
using BankProject.Data;
using BankProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace BankProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;



        public ClientController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Client> ObjClientList = _db.Clients;
            return View(ObjClientList);
        }

        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddClient(Client obj)
        {
            if (obj != null)
            {
                obj.Bank = Bank.LastBankLoggin.Name;

                if (obj.Id!=null && obj.Name!=null )
                {
                    Bank.LastBankLoggin.addFounds(obj.Founds,_db);
                    _db.Clients.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("Name", "This Bank allready exists!");


            }
            return View(obj);
        }


        public IActionResult ShowClients(int? iden)
        {
            IEnumerable<Client> list1 = _db.Clients.Where(row => row.Bank == Bank.LastBankLoggin.Name);

            if (iden == 1)
            {
                list1 = from cl in _db.Clients
                        orderby cl.Name ascending
                        where cl.Bank == Bank.LastBankLoggin.Name
                        select cl;
            }
            if (iden == 2)
            {
                list1 = from cl in _db.Clients
                        orderby cl.Founds ascending
                        where cl.Bank == Bank.LastBankLoggin.Name
                        select cl;
            }

            return View(list1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowClients(int dd)
        {
            IEnumerable<Client> list1 = _db.Clients.Where(row => row.Id == dd && row.Bank== Bank.LastBankLoggin.Name);

            return View(list1);
        }

        public void AddFounds(Client obj, int quantity)
        {
            obj.AddFounnds(quantity,_db);
        }

    }
}
