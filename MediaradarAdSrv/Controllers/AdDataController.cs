using MediaradarAdSrv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trirand.Web.Mvc;

namespace MediaradarAdSrv.Controllers
{
    public class AdDataController : Controller
    {
        [OutputCache(Duration = 20, VaryByParam = "none")]
        public ActionResult Index()
        {

            var gridModel = new Models.AdGridViewModel();

            setUpFullGrid(gridModel.FullAdsGrid);
            setupCoverGrid(gridModel.CoverAdsGrid);
            setupTop5AdsGrid(gridModel.Top5AdsByPageCoverageGrid);
            setupTop5BrandGrid(gridModel.Top5BrandByPageCoverageGrid);

            return View(gridModel);
        }

        private void setUpFullGrid(JQGrid adsGrid)
        {
            adsGrid.ID = "fullGrid";
            adsGrid.SortSettings.AutoSortByPrimaryKey = false;
            adsGrid.SortSettings.InitialSortColumn = "BrandName";
            adsGrid.SortSettings.MultiColumnSorting = true;
            adsGrid.DataUrl = Url.Action("FullGridDataRequested");
        }

        private void setupCoverGrid(JQGrid adsGrid)
        {
            adsGrid.ID = "coverGrid";
            adsGrid.SortSettings.AutoSortByPrimaryKey = false;
            adsGrid.SortSettings.InitialSortColumn = "BrandName";
            adsGrid.SortSettings.MultiColumnSorting = true;
            adsGrid.DataUrl = Url.Action("CoverGridDataRequest");
        }

        private void setupTop5AdsGrid(JQGrid adsGrid)
        {
            adsGrid.ID = "top5AdsGrid";
            adsGrid.SortSettings.AutoSortByPrimaryKey = false;
            adsGrid.SortSettings.MultiColumnSorting = true;

            adsGrid.SortSettings.InitialSortColumn = "NumPages";
            adsGrid.SortSettings.InitialSortDirection = SortDirection.Desc;
            adsGrid.DataUrl = Url.Action("Top5AdsGridDataRequest");
        }

        private void setupTop5BrandGrid(JQGrid adsGrid)
        {
            adsGrid.ID = "top5BrandGrid";
            adsGrid.SortSettings.AutoSortByPrimaryKey = false;
            adsGrid.SortSettings.MultiColumnSorting = true;

            adsGrid.SortSettings.InitialSortColumn = "NumPages";
            adsGrid.SortSettings.InitialSortDirection = SortDirection.Desc;
            adsGrid.DataUrl = Url.Action("Top5BrandGridDataRequest");
        }

        public JsonResult CoverGridDataRequest()
        {
            IEnumerable<AdDataSrv.Ad> ads;
            DateTime from = new DateTime(2011, 1, 1), to = new DateTime(2011, 4, 1);
            var key = from.ToShortDateString() + "-" + to.ToShortDateString();
            if (Session[key.ToString()] != null)
            {
                ads = Session[key.ToString()] as IEnumerable<AdDataSrv.Ad>;
            }
            else
            {
                ServiceClient.AdSrv adService = new ServiceClient.AdSrv();
                ads = adService.GetAdsByDateRange(from, to);
                Session.Add(key.ToString(), ads);
            }

            var gridModel = new AdGridViewModel();

            setupCoverGrid(gridModel.FullAdsGrid);

            var model = from a in ads
                        where a.Position == "Cover" && a.NumPages >= 0.5m
                        select new Models.AdsViewModel()
                        {
                            AdId = a.AdId,
                            BrandId = a.Brand.BrandId,
                            BrandName = a.Brand.BrandName,
                            NumPages = a.NumPages,
                            Position = a.Position
                        };

            return gridModel.FullAdsGrid.DataBind(model.AsQueryable());
        }

        public JsonResult FullGridDataRequested(string jqGridID)
        {
            IEnumerable<AdDataSrv.Ad> ads;
            DateTime from = new DateTime(2011, 1, 1), to = new DateTime(2011, 4, 1);
            var key = from.ToShortDateString() + "-" + to.ToShortDateString();
            if (Session[key.ToString()] != null)
            {
                ads = Session[key.ToString()] as IEnumerable<AdDataSrv.Ad>;
            }
            else
            {
                ServiceClient.AdSrv adService = new ServiceClient.AdSrv();
                ads = adService.GetAdsByDateRange(from, to);
                Session.Add(key.ToString(), ads);
            }

            var gridModel = new AdGridViewModel();

            setUpFullGrid(gridModel.FullAdsGrid);


            var model = from a in ads
                        select new Models.AdsViewModel()
                        {
                            AdId = a.AdId,
                            BrandId = a.Brand.BrandId,
                            BrandName = a.Brand.BrandName,
                            NumPages = a.NumPages,
                            Position = a.Position
                        };

            
            return gridModel.FullAdsGrid.DataBind(model.AsQueryable());
        }

        public JsonResult Top5AdsGridDataRequest()
        {
            IEnumerable<AdDataSrv.Ad> ads;
            DateTime from = new DateTime(2011, 1, 1), to = new DateTime(2011, 4, 1);
            var key = from.ToShortDateString() + "-" + to.ToShortDateString();
            if (Session[key.ToString()] != null)
            {
                ads = Session[key.ToString()] as IEnumerable<AdDataSrv.Ad>;
            }
            else
            {
                ServiceClient.AdSrv adService = new ServiceClient.AdSrv();
                ads = adService.GetAdsByDateRange(from, to);
                Session.Add(key.ToString(), ads);
            }

            var gridModel = new AdGridViewModel();

            setupCoverGrid(gridModel.FullAdsGrid);

            var model = from a in ads
                        select new Models.AdsViewModel()
                        {
                            AdId = a.AdId,
                            BrandId = a.Brand.BrandId,
                            BrandName = a.Brand.BrandName,
                            NumPages = a.NumPages,
                            Position = a.Position
                        };
            model = model.OrderByDescending(a => a.NumPages).Distinct().Take(5).OrderByDescending(a => a.NumPages).ThenBy(a => a.BrandName);
            return gridModel.FullAdsGrid.DataBind(model.AsQueryable());
        }

        public JsonResult Top5BrandGridDataRequest()
        {
            IEnumerable<AdDataSrv.Ad> ads;
            DateTime from = new DateTime(2011, 1, 1), to = new DateTime(2011, 4, 1);
            var key = from.ToShortDateString() + "-" + to.ToShortDateString();
            if (Session[key.ToString()] != null)
            {
                ads = Session[key.ToString()] as IEnumerable<AdDataSrv.Ad>;
            }
            else
            {
                ServiceClient.AdSrv adService = new ServiceClient.AdSrv();
                ads = adService.GetAdsByDateRange(from, to);
                Session.Add(key.ToString(), ads);
            }

            var gridModel = new AdGridViewModel();

            setupCoverGrid(gridModel.FullAdsGrid);

            var model = from a in ads
                        select new Models.AdsViewModel()
                        {
                            AdId = a.AdId,
                            BrandId = a.Brand.BrandId,
                            BrandName = a.Brand.BrandName,
                            NumPages = a.NumPages,
                            Position = a.Position
                        };
            model = model.OrderByDescending(a => a.NumPages).Distinct().Take(5).OrderByDescending(a => a.NumPages).ThenBy(a => a.BrandName);
            return gridModel.FullAdsGrid.DataBind(model.AsQueryable());
        }
    }

    
}