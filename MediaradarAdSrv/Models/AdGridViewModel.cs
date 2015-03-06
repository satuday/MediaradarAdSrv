using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Trirand.Web.Mvc;

namespace MediaradarAdSrv.Models
{
    public class AdGridViewModel
    {
        public AdGridViewModel()
        {

            setupFullGrid();
            setupCoverGrid();
            setupTop5AdsGrid();
            setupTop5BrandGrid();
        }

        private void setupFullGrid()
        {
            FullAdsGrid = new JQGrid
                                {
                                    Columns = new List<JQGridColumn>()
                                                                 {
                                                                     new JQGridColumn { DataField = "AdId", 
                                                                                        PrimaryKey = true,
                                                                                        Editable = false,
                                                                                        Width = 75 },
                                                                     new JQGridColumn { DataField = "BrandId",
                                                                                        Width = 75 },
                                                                     new JQGridColumn { DataField = "BrandName", 
                                                                                        Width = 150},
                                                                     new JQGridColumn { DataField = "NumPages", 
                                                                                        Width = 75 },
                                                                     new JQGridColumn { DataField = "Position",
                                                                                        Width = 75 
                                                                                      }                                     
                                                                 },
                                    Width = Unit.Pixel(640)
                                };
            FullAdsGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        private void setupCoverGrid()
        {
            CoverAdsGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "AdId", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandId",
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandName", 
                                                        Width = 150},
                                     new JQGridColumn { DataField = "NumPages", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "Position",
                                                        Width = 75 
                                                      }                                     
                                 },
                Width = Unit.Pixel(640)
            };
            CoverAdsGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        private void setupTop5AdsGrid()
        {
            Top5AdsByPageCoverageGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "AdId", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandId",
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandName", 
                                                        Width = 150},
                                     new JQGridColumn { DataField = "NumPages", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "Position",
                                                        Width = 75 
                                                      }                                     
                                 },
                Width = Unit.Pixel(640)
            };
            Top5AdsByPageCoverageGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        private void setupTop5BrandGrid()
        {
            Top5BrandByPageCoverageGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "AdId", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandId",
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "BrandName", 
                                                        Width = 150},
                                     new JQGridColumn { DataField = "NumPages", 
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "Position",
                                                        Width = 75 
                                                      }                                     
                                 },
                Width = Unit.Pixel(640)
            };
            Top5BrandByPageCoverageGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        public JQGrid FullAdsGrid { get; set; }

        public JQGrid CoverAdsGrid { get; set; }

        public JQGrid Top5AdsByPageCoverageGrid { get; set; }

        public JQGrid Top5BrandByPageCoverageGrid { get; set; }


    }

}