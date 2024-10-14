using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cs460hw1.Models;
using System.Linq; // Make sure to include this for LINQ methods
using System;
using System.Text;

namespace cs460hw1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Displays the index view
        //home page of the program
        public IActionResult Index()
        {
            return View();
        }

        // Displays the privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        // Displays the team creator view
        //the main page that matters the most
        public IActionResult TeamCreator()
        {
            return View(new TeamCreatorViewModel { Names = string.Empty });
        }

        // Handles form submission to generate teams
        //when the names are entered, it is supposed to split the names and make sure there aren't any errors, etc.
        // From here below, I had to watch some YouTube Videos for some help.
        // this part took quite some time because the errors were right within my eye so there was so many deletes and repasting
        //I believe this part took a couple of hours only because I wasn't even finding the error and the error wasn't even here. It was in my Teams.cs and I forgot to change the value names
        [HttpPost]
        public IActionResult GenerateTeams(TeamCreatorViewModel model)
        {
            Debug.WriteLine($"Entered Names: {model.Names}");

            // Validate model state; this will capture required and range validation.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            // Process names into a list
            var namesList = model.Names
                                 .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(name => name.Trim())
                                 .ToList();

            // Generate teams based on the number of teams requested
            model.Teams = CreateTeams(namesList, model.NumTeams);

            // Create HTML string for the generated teams
            var html = new StringBuilder();
            for (int i = 0; i < model.NumTeams; i++)
            {
                html.Append($"<div class='team'><h5 class='team-name'>Team {i + 1}</h5><ul>");
                foreach (var member in model.Teams[i])
                {
                    html.Append($"<li>{member}</li>");
                }
                html.Append("</ul></div>");
            }

            return Content(html.ToString(), "text/html"); // Return the generated HTML
        }

        // Creates evenly distributed teams from the list of names
        private List<List<string>> CreateTeams(List<string> names, int numTeams)
        {
            var teams = new List<List<string>>(numTeams);
            
            // Initialize empty lists for each team
            for (int i = 0; i < numTeams; i++)
            {
                teams.Add(new List<string>());
            }

            // Shuffle the names randomly
            var random = new Random();
            var shuffledNames = names.OrderBy(x => random.Next()).ToList();

            // Distribute the names across the teams
            for (int i = 0; i < shuffledNames.Count; i++)
            {
                teams[i % numTeams].Add(shuffledNames[i]);
            }

            return teams;
        }

        // Handles error responses
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
