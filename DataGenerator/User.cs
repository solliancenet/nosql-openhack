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

        public int CategoryId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        static public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400001, Email = "mixcomedy@contosomovies.com", Name = "Mixed Comedy Fan 1", CategoryId = 35,
                FirstName = "Emily",
                LastName = "Baker",
                Address = "2120 Figuroa Parkway",
                City = "Alexandria",
                State = "Texas",
                PostalCode = "69433",
                Country = "United States",
                Phone = "201-555-4983"
            });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400002, Email = "mixaction@contosomovies.com", Name = "Mixed Action Fan", CategoryId = 28,
                FirstName = "Walter",
                LastName = "Pang",
                Address = "73 Rocky Road",
                City = "Carson",
                State = "Idaho",
                PostalCode = "05844",
                Country = "United States",
                Phone = "717-555-5992"
            });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400003, Email = "mixcomedy@contosomovies.com", Name = "Mixed Comedy Fan 2", CategoryId = 35,
                FirstName = "Tuco",
                LastName = "Melendres",
                Address = "8390 Flatiron Street",
                City = "Olton",
                State = "New Hampshire",
                PostalCode = "13397",
                Country = "United States",
                Phone = "632-555-0197"
            });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400004, Email = "action@contosomovies.com", Name = "Action Fan", CategoryId = 28,
                FirstName = "Brennan",
                LastName = "Singh",
                Address = "409 Balboa Course",
                City = "San Diego",
                State = "Arizona",
                PostalCode = "80226",
                Country = "United States",
                Phone = "485-555-2829"
            });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400005, Email = "drama@contosomovies.com", Name = "Drama Fan", CategoryId = 18,
                FirstName = "Gloria",
                LastName = "Albertson",
                Address = "44825 San Gabriel Parkway",
                City = "Coolsborough",
                State = "North Carolina",
                PostalCode = "37539",
                Country = "United States",
                Phone = "867-555-5309"
            });
            users.Add(new Contoso.Apps.Movies.Data.Models.User { UserId = 400006, Email = "comedy@contosomovies.com", Name = "Comedy Fan", CategoryId = 35,
                FirstName = "Elton",
                LastName = "Morris",
                Address = "59 Butler Street",
                City = "New York",
                State = "New York",
                PostalCode = "01324",
                Country = "United States",
                Phone = "376-555-9960"
            });

            return users;
        }
    }
}