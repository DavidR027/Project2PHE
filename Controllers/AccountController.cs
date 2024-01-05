using System.Web.Mvc;
using Project2PHE.Services;
using Project2PHE.DTOs.Accounts;
using Project2PHE.Contexts;
using Project2PHE.Repositories;
using Project2PHE.ViewModels;

namespace Project2PHE.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountServices _accountServices;

        public AccountController()
        {
            _accountServices = new AccountServices(new AccountRepository(new RegisterDbContext()));
        }

        // GET: Account
        public ActionResult Index()
        {
            var accounts = _accountServices.GetAllAccount();
            return View(accounts);
        }

        // GET: Account/Details/5
        public ActionResult Details(string id)
        {
            var account = _accountServices.GetAccountByGuid(id);
            return View(account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(AccountDTO accountDto)
        {
            try
            {
                _accountServices.UpdateAccount(accountDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logins()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            System.Diagnostics.Debug.WriteLine("Attempting to log in with email: " + login.Email);

            var accountDto = _accountServices.GetAccountByEmail(login.Email);

            if (accountDto != null)
            {
                System.Diagnostics.Debug.WriteLine("Found an account with the provided email.");

                if (accountDto.Password == login.Password)
                {
                    System.Diagnostics.Debug.WriteLine("Password matches. Logging in.");

                    Session["Guid"] = accountDto.Guid;
                    Session["Role"] = accountDto.Role;

                    if (accountDto.Role == "Vendor")
                    {
                        return RedirectToAction("Registers", "Vendor");
                    }
                    else if (accountDto.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Vendor");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Password does not match.");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No account found with the provided email.");
            }

            return RedirectToAction("Logins");
        }

        // GET: Account/Edit/5
        public ActionResult Edit(string id)
        {
            var account = _accountServices.GetAccountByGuid(id);
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AccountDTO accountDto)
        {
            try
            {
                _accountServices.UpdateAccount(accountDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(string id)
        {
            var account = _accountServices.GetAccountByGuid(id);
            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _accountServices.DeleteAccount(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}