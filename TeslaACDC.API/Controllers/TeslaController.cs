namespace TeslaACDC.Controllers;

using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.DTO;
using System.Net;

[ApiController] // @Controller
[Route("api/[controller]")]
public class TeslaController : ControllerBase
{
    private readonly IAlbumService _albumService;
    private readonly IMatematika _matematikaService;

    public TeslaController(IAlbumService albumService, IMatematika matematikaService)
    {
        _albumService = albumService;
        _matematikaService = matematikaService;
    }

    [HttpGet]
    [Route("getalbums")]
    public async Task<IActionResult> GetAllAlbums()
    {
        return Ok(await _albumService.GetList());
    }

    [HttpGet]
    [Route("GetAlbumById")]
    public async Task<IActionResult> GetAlbumById(int id)
    {
        var response = await _albumService.FindById(id);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpGet]
    [Route("GetAlbumByName")]
    public async Task<IActionResult> GetAlbumByName(string name)
    {
        var response = await _albumService.FindByName(name);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpGet]
    [Route("GetAlbumByNameYear")]
    public async Task<IActionResult> GetAlbumByNames(string name, int year)
    {
        var response = await _albumService.FindByName(name);
        return StatusCode((int)response.StatusCode, response);
    }
}

