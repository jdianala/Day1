using FourLayer.Services;
using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourLayer.Presentation.Controllers
{
    // John Dianala
    
    public class AccountsController : Controller
    {
       
        private AccountService _service;
        
        public AccountsController(AccountService service)
        {
            _service = service;
        }
        // GET: Accounts
        public ActionResult Index()
        {
        
            return View(_service.ListAccounts());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(string id)
        {
            return View(_service.FindAccount(id));
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create(AccountDTO account)
        {
            try
            {
                // TODO: Add insert logic here
                _service.OpenAccount(account.Username, account.AccountType, account.Balance);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(string id)
        {

            return View(_service.FindAccount(id));
        }

        //POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AccountDTO account)
        {
            try
            {
                // TODO: Add update logic here
            
                _service.SaveAccount(account);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_service.FindAccount(id));
        }

        //POST: Accounts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(string id, AccountDTO account)
        {
            try
            {
                // TODO: Add delete logic here
                _service.DeleteAccount(id);
                return RedirectToAction("Index");
            }
            catch
            {
                //return View();
                return RedirectToAction("Index");
            }
        }
    }
}
