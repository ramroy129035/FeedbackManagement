using Microsoft.AspNetCore.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class HomeController : Controller
    {
        // Temporary storage for submitted feedback
        private static List<Feedback> feedbackList = new List<Feedback>();

        // Home Page
        public IActionResult Index()
        {
            return View();
        }

        // Display Feedback Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Submit Feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);

                return View("Success", feedback);
            }

            return View(feedback);
        }

        // Display All Submitted Feedback
        public IActionResult FeedbackList()
        {
            return View(feedbackList);
        }
    }
}