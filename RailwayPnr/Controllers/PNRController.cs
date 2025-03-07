using Microsoft.AspNetCore.Mvc;
using RailwayPnr.Services;
using System.Threading.Tasks;

namespace RailwayPnr.Controllers
{
    public class PNRController : Controller
    {
        private readonly IPNRService _pnrService;

        public PNRController(IPNRService pnrService)
        {
            _pnrService = pnrService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPNRStatus(string pnrNumber)
        {
            try
            {
                var result = await _pnrService.GetPNRStatusAsync(pnrNumber);
                return Json(result); // ✅ Send valid JSON response
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred", message = ex.Message });
                // ✅ Return JSON instead of plain text error
            }
        }

    }
}