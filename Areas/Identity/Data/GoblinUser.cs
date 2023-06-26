using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using goblin_cheese.Models.Game;

namespace goblin_cheese.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GoblinUser class
public class GoblinUser : IdentityUser
{  
    [PersonalData]
    public string? GoblinName { get; set; }

    [PersonalData]
    public string? FullName { get; set; }

    [PersonalData]
    public DateTime? SignupDate { get; set; }
    public List<Game> FavouriteGames { get; } = new List<Game>();
}

