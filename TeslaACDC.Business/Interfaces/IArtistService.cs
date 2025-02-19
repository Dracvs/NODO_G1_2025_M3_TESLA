using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IArtistService
{
    public Task<Artist> FindById(int id);
    public Task<Artist> AddArtist(Artist artist);
}