using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

//this part was the one thing that screwed me over
//i kept having to go to stack overflow and chatgpt as to why my program wasn't working
//i figured out why it was because I didn't change the value names and because i didn't, my cshtml wasn't working and nothing else was working properly and the same error message would keep popping up
//chatgpt didn't really help here, i kinda had to sit here and ask myself what did I change in order for nothing to work anymore
//it turns out i changed the the "Name" and "Members" from something else because I confused myself.

namespace cs460hw1.Models
{
    public class Team
    {
        public required string Name { get; set; }//this is for the name of the team
        public List<string> Members { get; set; } = new List<string>();
    

        public Team(string name)
        {
        // Assign the parameter 'name' to the 'Name' property
        name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }




}