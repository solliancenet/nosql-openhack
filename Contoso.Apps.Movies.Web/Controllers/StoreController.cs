using AutoMapper;
using Contoso.Apps.Common;
using Contoso.Apps.Common.Controllers;
using Contoso.Apps.Common.Extensions;
using Contoso.Apps.Movies.Data.Models;
using Contoso.Apps.Movies.Logic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Apps.Movies.Web.Controllers
{
    [AllowAnonymous]
    public class StoreController : BaseController
    {
        public StoreController()
        {
        }

        // GET: Store
        public ActionResult Index(string categoryId)
        {
            User user = (User)Session["User"];

            List<Item> products = RecommendationHelper.GetViaFunction("top", 0, 100);

            var randomVm = Mapper.Map<List<Models.ProductListModel>>(RecommendationHelper.GetViaFunction("random", 0, 10));
            
            var productsVm = Mapper.Map<List<Models.ProductListModel>>(products);

            // Retrieve category listing:
            var categoriesVm = Mapper.Map<List<Models.CategoryModel>>(categories.ToList());

            var vm = new Models.StoreIndexModel
            {
                RandomProducts = randomVm,
                Products = productsVm,
                Categories = categoriesVm
            };

            return View(vm);
        }

        public ActionResult Genre(int categoryId)
        {
            List<Item> products = SqlDbHelper.GetItemsByCategory(categoryId).ToList();

            var productsVm = Mapper.Map<List<Models.ProductListModel>>(products);

            // Retrieve category listing:
            var categoriesVm = Mapper.Map<List<Models.CategoryModel>>(categories.ToList());

            var vm = new Models.StoreIndexModel
            {
                Products = productsVm,
                Categories = categoriesVm
            };

            return View(vm);
        }

        // GET: Store/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item product = await SqlDbHelper.GetItem(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var productVm = Mapper.Map<Models.ProductModel>(product);

            // Find related products, based on the category
            var relatedProducts = items.Where(p => p.CategoryId == product.CategoryId && p.ItemId != product.ItemId).Take(10).ToList();
            var relatedProductsVm = Mapper.Map<List<Models.ProductListModel>>(relatedProducts);

            // Retrieve category listing
            var categoriesVm = Mapper.Map<List<Models.CategoryModel>>(categories);

            // Retrieve "new products" as a list of three random products not equal to the displayed one
            var newProducts = items.Where(p => p.ItemId != product.ItemId).Take(50).ToList().Shuffle().Take(3);

            var newProductsVm = Mapper.Map<List<Models.ProductListModel>>(newProducts);

            var vm = new Models.StoreDetailsModel
            {
                Product = productVm,
                RelatedProducts = relatedProductsVm,
                SimilarProducts = null,
                NewProducts = newProductsVm,
                Categories = categoriesVm
            };

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }

            base.Dispose(disposing);
        }
    }
}
