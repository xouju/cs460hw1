using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cs460hw1.Models
{
    public class TeamCreatorViewModel
    {

        //this right here is to make sure the names have the required things in them
        //these characters are allowed ,.-_', the others are not allowed in the name
        //there needs to be an error message created so when a person tries to create a name with the unavailable characters, it will not take you to the team creation until it is fix
        [Required(ErrorMessage ="Names are required.")]
        [RegularExpression(@"^[a-zA-Z ,\.\-_'\r\n]+$", ErrorMessage = "Only letters, spaces, and the characters ,.-_' are allowed.")]
        public required string Names { get; set; }

        //also another error message needs to be created for the team szies
        //the teams must be between 2 and 10
        //if someone tries to generate a team of 1, it shouldn't generate and an error message should pop up
        //the same thing should happen with any number above 10
        [Range(2, 10, ErrorMessage = "Team size must be between 2 and 10.")]
        public int NumTeams { get; set; }

        [BindNever]
        public List<List<string>> Teams { get; set; } = new List<List<string>>();
    }

    
}