using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cs460hw1.Models;
using System.Reflection;
using Microsoft.VisualBasic;


namespace HW1.Unittest
{
    public class TeamCreatorViewModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //TEST NUMBER ONE
        //TESTING FOR THE NAMES
        //THEY MUST BE LEGAL NAMES
        [Test]
        public void NameValidation()
        {
            var teamCreator = new TeamCreatorViewModel
            {

                Names = "Invalid Name@123"
            };
            
            var context = new ValidationContext(teamCreator);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(teamCreator, context, results, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(r => r.ErrorMessage =="Only letters, spaces, and the characters ,.-_' are allowed."));
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //TEST NUMBER 2 TEAM SIZES
        //IT SHOULDNT BE MORE 10 OR LESS THAN 2
        
        //helper function to validate model
        private List<ValidationResult> ValidateModel(TeamCreatorViewModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);

            return validationResults;
        }
        [Test]
        public void TeamSize_BelowMin_Fails()
        {
            var teamCreator = new TeamCreatorViewModel
            {
                Names = "Name is Valid",
                NumTeams = 1
            };

        var validationResults = ValidateModel(teamCreator);

        Assert.That(validationResults.Count, Is.GreaterThan(0));
        Assert.That(validationResults[0].ErrorMessage, Is.EqualTo("Team size must be between 2 and 10."));
        }

        //TEST NUMBER 3
        //SHOULD TEST IF THE TEAM SIZE IS GREATER THAN 11
        public void TeamSize_BelowMax_Fails()
        {
            var teamCreator = new TeamCreatorViewModel
            {
                Names = "Name is Valid",
                NumTeams = 11
            };

        var validationResults = ValidateModel(teamCreator);

        Assert.That(validationResults.Count, Is.GreaterThan(0));
        Assert.That(validationResults[0].ErrorMessage, Is.EqualTo("Team size must be between 2 and 10."));
        }


        //TEST NUMBER 4
        //TEST THE VALID RANGE OF TEAMS
        [Test]
        public void TeamSize_WithinRange()
        {
            var teamCreator = new TeamCreatorViewModel
            {
                Names = "Name is Valid",
                NumTeams = 5
            };

            var validationResults = ValidateModel(teamCreator);

            Assert.That(validationResults.Count, Is.EqualTo(0));
        }
    }
}