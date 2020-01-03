using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Contoso.Apps.Movies.Data.Models
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        static public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400001, Email = "mixcomedy@contosomovies.com", Name = "Mixed Comedy Fan 1" });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400002, Email = "mixaction@contosomovies.com", Name = "Mixed Action Fan" });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400003, Email = "mixcomedy@contosomovies.com", Name = "Mixed Comedy Fan 2" });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400004, Email = "action@contosomovies.com", Name = "Action Fan" });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400005, Email = "drama@contosomovies.com", Name = "Drama Fan" });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400006, Email = "comedy@contosomovies.com", Name = "Comedy Fan" });

            return users;
        }
    }
}