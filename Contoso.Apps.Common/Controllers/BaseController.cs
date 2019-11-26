using Contoso.Apps.Movies.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Apps.Common.Controllers
{
    [System.Web.Mvc.Authorize]
    public class BaseController : Controller
    {
        static protected IQueryable<Item> items;
        static protected IQueryable<Category> categories;
        static protected IQueryable<Order> orders;
        static protected IQueryable<User> users;

        public BaseController()
        {
            if (items == null)
                items = SqlDbHelper.GetItems();

            if (categories == null)
                categories = SqlDbHelper.GetCategories();


            if (users == null)
                users = SqlDbHelper.GetUsers();
        }

        public async Task<ActionResult> SetUser(int userId)
        {
            Movies.Data.Models.User user = await SqlDbHelper.GetUser(userId);
            Session["User"] = user;

            this.HttpContext.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(user.Email), new string[] { /* fill roles if any */ });

            return RedirectToAction("Index", "Home");
        }

        public ActionResult NewUser(string email)
        {
            Movies.Data.Models.User user = new Movies.Data.Models.User();
            user.Email = "newuser@contosomovies.com";
            user.UserId = 1;

            Session["User"] = user;

            this.HttpContext.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(user.Email), new string[] { /* fill roles if any */ });

            return RedirectToAction("Index", "Home");
        }

        public string DisplayName { get; set; }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            if (Request.IsAuthenticated)
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    string displayNameClaim = "http://schemas.microsoft.com/identity/claims/displayname";
                    var claim = claimsIdentity.FindFirst(displayNameClaim);
                    if (claim != null)
                    {
                        DisplayName = claim.Value;
                    }
                }
                //DisplayName = ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst("http://schemas.microsoft.com/identity/claims/displayname").Value;
            }
            base.EndExecute(asyncResult);
        }
    }
}