using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaradarAdSrv.AdDataSrv;

namespace MediaradarAdSrv.ServiceClient
{
    public class AdSrv
    {
        public IEnumerable<Ad> GetAdsByDateRange(DateTime from, DateTime to)
        {
            using(var client = new AdDataServiceClient())
            {
                var ads = client.GetAdDataByDateRange(from, to);
                return ads;
            }
        }

    }
}