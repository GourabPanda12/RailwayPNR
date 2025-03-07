using RailwayPnr.Models;

namespace RailwayPnr.Services
{
    public interface IPNRService
    {
        Task<PNRResponse> GetPNRStatusAsync(string pnrNumber);
    }
}
