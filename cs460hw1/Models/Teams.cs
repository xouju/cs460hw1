using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace cs460hw1.Models
{
    public class Team
    {
        public required string Name { get; set; }//this is for the name of the team
        public List<string> Members { get; set; } = new List<string>();
    

        public Team(string name)
        {
        name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }




}