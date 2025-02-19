using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public interface IUnitOfWork
{
    IRepository<int, Artist> ArtistRepository{get;}
    IRepository<int, Album> AlbumRepository{get;}
    Task SaveAsync();
}