using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaradarAdSrv.AdDataSrv;

namespace MediaradarAdSrv.Services
{
    public class AdDataService : MediaradarAdSrv.Services.IAdDataService
    {
        public IEnumerable<Ad> GetAdsByDateRange(DateTime from, DateTime to)
        {
            IEnumerable<AdDataSrv.Ad> ads;
            var key = from.ToShortDateString() + "-" + to.ToShortDateString();
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                ads = HttpContext.Current.Session[key.ToString()] as IEnumerable<AdDataSrv.Ad>;
            }
            else
            {
                using (var client = new AdDataServiceClient())
                {
                    ads = client.GetAdDataByDateRange(from, to);
                    HttpContext.Current.Session.Add(key.ToString(), ads);
                }
            }
            return ads;
        }

    }
}