using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc;
using Project3.Models.Blocks;
using Project3.Models.Pages;
using Project3.Models.ViewModels;
using System;
using System.Linq;

namespace Project3.Controllers
{
    /// <summary>
    /// Adds campaign-specific, request-time logic to PromotionPage.
    /// </summary>
    public class PromotionPageController : PageControllerBase<PromotionPage>
    {
        private readonly IContentLoader _contentLoader;

        public PromotionPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(PromotionPage currentPage)
        {
            var model = new PromotionPageViewModel(currentPage)
            {
                ActivePromotionCount = CountActivePromotions(currentPage, DateTime.Today)
            };

            return View(model);
        }

        private int CountActivePromotions(PromotionPage page, DateTime today)
        {
            if (page.PromotionItems == null)
            {
                return 0;
            }

            return page.PromotionItems.FilteredItems
                .Select(item => TryLoadPromotion(item.ContentLink))
                .Count(promotion => promotion != null &&
                    (!promotion.CampaignStartDate.HasValue || promotion.CampaignStartDate.Value.Date <= today) &&
                    (!promotion.CampaignEndDate.HasValue || promotion.CampaignEndDate.Value.Date >= today));
        }

        private PromotionBlock TryLoadPromotion(ContentReference contentLink)
        {
            return _contentLoader.TryGet(contentLink, out PromotionBlock promotion) ? promotion : null;
        }
    }
}
