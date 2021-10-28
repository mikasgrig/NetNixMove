using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MacawSitecoreProject.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MacawSitecoreProject.Models;

namespace MacawSitecoreProject.Controllers
{
    public class NetNixMoveController : Controller
    {
        private readonly INetNixClient _netNixClient;

        public NetNixMoveController(INetNixClient netNixClient)
        {
            _netNixClient = netNixClient;
        }
        public async Task<IActionResult> Index()
        {   
            var allMove = await _netNixClient.GetAllSoonMovesAsync();
            foreach (var move in allMove)
            {
                move.ReleaseDate = move.ReleaseDate.Substring(0, 10);
            }
            
            return View(allMove.ToList());
        }
        public async Task<IActionResult> Details(Guid? id, Guid directorId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var move = await _netNixClient.GetMoveAsync(id);
            var moveLike = await _netNixClient.GetMoveLikeAsync(id);
            move.Director.Id = directorId;
            var detailMove = new FullMoveDetailModel
            {
                Id = move.Id,
                Name = move.Name,
                ReleaseDate = move.ReleaseDate,
                ShortDescription = move.ShortDescription,
                Description = move.Description,
                Image = move.Image,
                Director = move.Director,
                Like = Decimal.ToInt32(moveLike.Like)
            };

            return View(detailMove);
        }
        public async Task<IActionResult> DetailsDirector(Guid directorId, Guid moveId)
        {
            if (directorId == null)
            {
                return NotFound();
            }
            var director = await _netNixClient.GetDirectorAsync(directorId);
            director.MoveId = moveId;
            director.Id = directorId;
    
            return View(director);
        }
        [HttpPost]
        public async Task<IActionResult> AddLike(Guid? id, Guid directorId)
        {
            await _netNixClient.AddLike(new MoveLikeWriteModel
            {
                MovieId = (Guid)id
            });
            
            return RedirectToAction("Details", new
            {
                id = id,
                directorId = directorId
            });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}