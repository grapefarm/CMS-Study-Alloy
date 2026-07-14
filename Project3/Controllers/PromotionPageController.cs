using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc;
using Project3.Business.Promotions;
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
        private readonly IPromotionStatusService _promotionStatusService;

        public PromotionPageController(IContentLoader contentLoader, IPromotionStatusService promotionStatusService)
        {
            _contentLoader = contentLoader;
            _promotionStatusService = promotionStatusService;
        }

        public IActionResult Index(PromotionPage currentPage)
        {
            var model = CreateModel(currentPage, DateTime.Today);

            return View(model);
        }

        private PromotionPageViewModel CreateModel(PromotionPage page, DateTime today)
        {
            var model = new PromotionPageViewModel(page);

            if (page.PromotionItems == null)
            {
                return model;
            }

            var promotionStatuses = page.PromotionItems.FilteredItems
                .Select(item => TryLoadPromotion(item.ContentLink))
                .Where(promotion => promotion != null)
                .Select(promotion => _promotionStatusService.GetStatus(promotion, today))
                .ToList();

            model.ActivePromotionCount = promotionStatuses.Count(status =>
                status == PromotionStatus.Active || status == PromotionStatus.EndingSoon);
            model.EndingSoonPromotionCount = promotionStatuses.Count(status => status == PromotionStatus.EndingSoon);

            return model;
        }

        private PromotionBlock TryLoadPromotion(ContentReference contentLink)
        {
            return _contentLoader.TryGet(contentLink, out PromotionBlock promotion) ? promotion : null;
        }
    }
}
