﻿using Microsoft.AspNetCore.Mvc;
using SimpleRules;
using SimpleRulesEngineSample.Entities;
using SimpleRulesEngineSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRulesEngineSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly SimpleRulesEngine _rulesEngine;

        public HomeController(SimpleRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }

        public IActionResult Index()
        {
            var model = new ValidationResultsModel();
            var user = new User
                {
                    Username = "kanant",
                    Password = "password123",
                    ConfirmPassword = "password1234",
                    EmailAddress = "kanant",
                    PhoneNumber = "12345"
                };
            model.UserValidationResults = _rulesEngine.Validate<User>(user).Errors;
            var registration = new Registration
                {
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now.AddDays(-6)
                };
            model.RegistrationValidationResults = _rulesEngine.Validate<Registration>(registration).Errors;
            var activity = new Activity
                {
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now.AddDays(-6),
                    Capacity = 25
                };
            model.ActivityValidationResults = _rulesEngine.Validate<Activity>(activity).Errors;

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
