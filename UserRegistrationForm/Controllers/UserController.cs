using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistrationForm.Models;
using UserRegistrationForm.Models.Repositories;

namespace UserRegistrationForm.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _userRepository.AddUser(user);
                if (isAdded)
                {
                    TempData["SuccessMessage"] = "User added successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Index()
        {
            List<User> users= _userRepository.GetAllUsers();
            return View(users);

        }

        public ActionResult Details(int id)
        {
            var user = _userRepository.GetAllUsers().Find(x => x.Id == id);
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user=_userRepository.GetAllUsers().Find(x => x.Id == id);
            return View(user);
        }

        [HttpPost]

        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid){

                bool isUpdated = _userRepository.UpdateUser(user);
                if (isUpdated)
                {
                    TempData["UpdateMessage"] = "User updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetAllUsers().Find(x => x.Id == id);
            return View(user);
        }
        
        [HttpPost]

        public ActionResult Delete(int id,User user)
        {
            bool isDeleted = _userRepository.DeleteUser(id);
            if (isDeleted)
            {
                TempData["DeleteMessage"] = "User deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
       




    }
}
