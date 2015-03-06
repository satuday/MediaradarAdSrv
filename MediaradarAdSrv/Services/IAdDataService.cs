using System;
namespace MediaradarAdSrv.Services
{
    public interface IAdDataService
    {
        global::System.Collections.Generic.IEnumerable<global::MediaradarAdSrv.AdDataSrv.Ad> GetAdsByDateRange(DateTime from, DateTime to);
    }
}
