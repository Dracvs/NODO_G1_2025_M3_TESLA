using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;


public class ArtistService : IArtistService
{
    private readonly NikolaContext _context;
    //private IArtistRepository<int, Artist> _artistRepository;

    public ArtistService(NikolaContext context)
    {
        _context = context;
        //_artistRepository = new ArtistRepository<int, Artist>(_context);
    }
    
    public async Task<Artist> AddArtist(Artist artist)
    {
        //await _artistRepository.AddAsync(artist);
        return artist;
    }

    public async Task<Artist> FindById(int id)
    {
        //var artist = await _artistRepository.FindAsync(id);
        return  new Artist();//artist;
    }
}