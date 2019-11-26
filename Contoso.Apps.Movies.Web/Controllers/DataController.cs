using Contoso.Apps.Common;
using Contoso.Apps.Movies.Data.Models;
using Contoso.Apps.Movies.Logic;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Contoso.Apps.Movies.Web.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DataController : ApiController
    {
        public DataController()
        {
        }

        [HttpGet]
        [Route("api/logs")]
        public IHttpActionResult Logs()
        {
            List<CollectorLog> logs = new List<CollectorLog>();

            Contoso.Apps.Movies.Data.Models.User user = (Contoso.Apps.Movies.Data.Models.User)HttpContext.Current.Session["User"];

            if (user != null)
            {
                string name = user.Email;
                int userId = user.UserId;

                logs = SqlDbHelper.GetUserLogs(userId, 100);
            }

            return Json(logs);
        }

        [HttpGet]
        [Route("api/similar")]
        public IHttpActionResult SimilarUsers(string algo)
        {
            List<Data.Models.User> users = new List<Data.Models.User>();

            Contoso.Apps.Movies.Data.Models.User user = (Contoso.Apps.Movies.Data.Models.User)HttpContext.Current.Session["User"];
            string name = user.Email;
            int userId = user.UserId;

            switch (algo)
            {
                case "jaccard":
                    users = RecommendationHelper.GetViaFunction(userId);
                    break;
                case "pearson":
                    users = RecommendationHelper.GetViaFunction(userId);
                    break;
            }
            
            return Json(users);
        }

        [HttpGet]
        [Route("api/recommend")]
        public IHttpActionResult Recommend(string algo, int count)
        {
            List<Item> products = new List<Item>();

            if (HttpContext.Current.Session != null && HttpContext.Current.Session["User"] != null)
            {
                Contoso.Apps.Movies.Data.Models.User user = (Contoso.Apps.Movies.Data.Models.User)HttpContext.Current.Session["User"];
                string name = user.Email;
                int userId = user.UserId;

                products = RecommendationHelper.GetViaFunction(algo, userId, count);
            }
            else
                products = RecommendationHelper.GetViaFunction(algo, 0, count);

            return Json(products);
        }
    }
}