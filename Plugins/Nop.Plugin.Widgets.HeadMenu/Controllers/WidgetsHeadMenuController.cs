using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Plugin.Widgets.HeadMenu.Models;

namespace Nop.Plugin.Widgets.HeadMenu.Controllers
{
    public class WidgetsHeadMenuController : BasePluginController
    {
          private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly ICacheManager _cacheManager;

        public WidgetsHeadMenuController(IWorkContext workContext,
            IStoreContext storeContext,
            IStoreService storeService, 
            IPictureService pictureService,
            ISettingService settingService,
            ICacheManager cacheManager)
        {
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._storeService = storeService;
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._cacheManager = cacheManager;
        }



        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var nivoSliderSettings = _settingService.LoadSetting<HeadMenuSettings>();
            var model = new ConfigurationModel();

            model.Text1 = nivoSliderSettings.Text1;
            model.Link1 = nivoSliderSettings.Link1;

            model.Text2 = nivoSliderSettings.Text2;
            model.Link2 = nivoSliderSettings.Link2;
         

            return View("~/Plugins/Widgets.HeadMenu/Views/WidgetsHeadMenu/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            //load settings for a chosen store scope
            var nivoSliderSettings = _settingService.LoadSetting<HeadMenuSettings>();
            nivoSliderSettings.Text1 = model.Text1;
            nivoSliderSettings.Link1 = model.Link1;
            nivoSliderSettings.Text2 = model.Text2;
            nivoSliderSettings.Link2 = model.Link2;
             _settingService.SaveSetting(nivoSliderSettings);

            //now clear settings cache
            _settingService.ClearCache();

            return Configure();
        }


        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {

            return View("~/Plugins/Widgets.HeadMenu/Views/WidgetsHeadMenu/PublicInfo.cshtml");
        }
    }
}
