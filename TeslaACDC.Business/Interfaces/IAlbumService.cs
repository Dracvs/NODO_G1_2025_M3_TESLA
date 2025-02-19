using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;



public interface IAlbumService
{
    Task<BaseMessage<Album>> GetList();
    Task<BaseMessage<Album>> AddAlbum(Album album);
    Task<BaseMessage<Album>> FindById(int id);
    Task<BaseMessage<Album>> FindByName(string name);
    Task<BaseMessage<Album>> FindByProperties(string name, int year);

    #region Learning to Test
    Task<string> HealthCheckTest();
    Task<string> TestAlbumCreation(Album album);
    
    #endregion
}