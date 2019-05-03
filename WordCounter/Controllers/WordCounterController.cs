using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WordCounter.Models;

namespace WordCounter.Controllers
{
    public class WordCountersController : Controller
    {
        [HttpGet("/wordcounters")]
        public ActionResult Index()
        {
            List<Counter> allCounters = Counter.GetAll();
            return View(allCounters);
        }

        [HttpGet("/wordcounters/new")]
        public ActionResult New()
        {
            return View();
        }

        // [HttpPost("/wordcounters")]
        // public ActionResult Create(string targetWord, string targetPhrase)
        // {
        //     Counter newCounter = new Counter(targetWord, targetPhrase);
        //     return RedirectToAction("Index");
        // }

        [HttpPost("/wordcounters/show")]
        public ActionResult Create(string targetWord, string targetPhrase)
                {
            Counter newCounter = new Counter(targetWord, targetPhrase);
            return View("Show", newCounter);
        }

        [HttpGet("/wordcounters/{id}")]
        public ActionResult Show(int id)
        {
            Counter selectedCounter = Counter.FindCounterById(id);
            return View(selectedCounter);
        }
    }
}