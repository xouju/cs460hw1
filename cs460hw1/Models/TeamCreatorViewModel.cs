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

        //this right here is what kinda saved me
        //i had an issue with an error that kept appearing despite the amount of times i had to delete and re-add certain lines of code
        //then i went to chatgpt and wondered why the "teams must be filled in" error kept popping up even though the program was made so it would create teams itself
        //then chatgpt didn't give me a good answer so i had to think myself why it wasn't working
        //so then i figured that it must be because the program thinks im supposed to create the names myself or something
        //then it showed me bindnever and it was supposed to help prevent the error message popping up since it was within the system
        //but then it wasn't working then it turns out it was an error within my teams.cs because i forgot to change the code and the bindnever was working finally
        [BindNever]
        public List<List<string>> Teams { get; set; } = new List<List<string>>();
    }

    
}