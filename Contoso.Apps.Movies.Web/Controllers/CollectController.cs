using Contoso.Apps.Common;
using Contoso.Apps.Common.Controllers;
using Contoso.Apps.Movies.Data.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Apps.Movies.Controllers
{
    [AllowAnonymous]
    public class CollectController : BaseController
    {
        [HttpPost]
        public async Task<bool> Log(string user_id, string item_id, string event_type, string session_id)
        {
            Contoso.Apps.Movies.Data.Models.User user = (Contoso.Apps.Movies.Data.Models.User)Session["User"];
            
            if (user != null)
            {
                string name = user.Email;
                int userId = user.UserId;

                Item i = await SqlDbHelper.GetItem(int.Parse(item_id));

                if (i != null)
                {
                    CollectorLog log = new CollectorLog();
                    log.id = Guid.NewGuid().ToString();
                    log.UserId = userId;
                    log.ContentId = i.ImdbId;
                    log.ItemId = int.Parse(item_id);
                    log.Event = event_type;
                    log.SessionId = session_id;
                    log.Created = DateTime.Now;

                    await SqlDbHelper.CreateEvent(log);
                }
            }

            return true;
        }

        
    }
}