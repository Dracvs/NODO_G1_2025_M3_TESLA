using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        [Route("GetAllAlbums")]
        public async Task<IActionResult> GetAllAlbums()
        {
            var albums = await _albumService.GetList();
            return Ok(albums);
        }

        [HttpPost]
        [Route("AddAlbum")]
        public async Task<IActionResult> AddAlbum(Album album)
        {
            var result = await _albumService.AddAlbum(album);
            return Ok(result);
        }

        [HttpGet("getAlbumByName")]
        public async Task<IActionResult> GetAlbumByName(string name)
        {
            var result = await _albumService.FindByName(name);
            return result.TotalElements >  0 ? 
                Ok(result) :
                NotFound(result);
        }
        

    }
}
