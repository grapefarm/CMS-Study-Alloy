using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Project3.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models.Pages
{
    /// <summary>
    /// A campaign page that groups reusable promotion cards.
    /// </summary>
    [SiteContentType(
        GUID = "B8EBBAF0-9329-4903-8E0B-5D1F8B32451A",
        DisplayName = "活動頁",
        Description = "用於呈現活動說明與多張促銷卡片",
        GroupName = Globals.GroupNames.Specialized)]
    [SiteImageUrl]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(StartPage) })]
    public class PromotionPage : SitePageData
    {
        [CultureSpecific]
        [Display(Name = "活動導言", GroupName = SystemTabNames.Content, Order = 310)]
        public virtual XhtmlString Introduction { get; set; }

        [CultureSpecific]
        [Display(Name = "促銷卡片", Description = "僅能放入「促銷卡片」Block", GroupName = SystemTabNames.Content, Order = 320)]
        [AllowedTypes(typeof(PromotionBlock))]
        public virtual ContentArea PromotionItems { get; set; }
    }
}
