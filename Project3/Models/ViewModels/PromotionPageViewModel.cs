using Project3.Models.Pages;

namespace Project3.Models.ViewModels
{
    /// <summary>
    /// Adds request-time business data to the CMS page model.
    /// </summary>
    public class PromotionPageViewModel : PageViewModel<PromotionPage>
    {
        public PromotionPageViewModel(PromotionPage currentPage)
            : base(currentPage)
        {
        }

        public int ActivePromotionCount { get; set; }

        public int EndingSoonPromotionCount { get; set; }
    }
}
