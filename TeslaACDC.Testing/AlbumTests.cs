using System.Net;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;


namespace TeslaACDC.Tests;

[TestClass]
public class AlbumTests
{
    //private IAlbumRepository<int, Album> _albumRepository;
    private readonly Album _correctAlbum;
    
    public AlbumTests()
    {
        //_albumRepository = Substitute.For<IAlbumRepository<int, Album>>();
        _correctAlbum = new Album(){
            Id = 1
        };
    }

     /* 
        Patrón AAA
        A = Arrange
        A = Act
        A = Assert
     */

    [TestMethod]
    public async Task HealthCheckTest()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest();

        // Arrange
        Assert.AreEqual(response, "OK");
    }

    [TestMethod]
    public async Task HealthCheckTestIsOk()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(true);

        // Arrange
        Assert.AreEqual(response, "OK!");
    }

    [TestMethod]
    public async Task HealthCheckTestIsNotOkay()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(false);

        // Arrange
        Assert.AreEqual(response, "Not cool");
    }

    [TestMethod]
    public async Task ValidateAlbumCreation()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "Rude Awakening (RE-MASTERED)",
            Year = 2025,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.AreEqual(response, String.Empty);

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_nameisempty()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 2025,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El nombre es requerido"));

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_yearoutofrangelower()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 1899,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));

    }

    [TestMethod]
    public async Task ValidateAlbumCreation_yearoutofrangehigher()
    {
        // Arrange
        var service = new AlbumService(null);
        var album = new Album(){
            Name =  "",
            Year = 2026,
            ArtistId = 1,
            Genre = Genre.Metal,
            Id = 1
        };

        // Act
        var response = await service.TestAlbumCreation(album);

        //Assert
        Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));
    }

    [TestMethod]
    //Decorado
    public async Task FindById_FindsSomething()
    {
        // Arrange
        // MOCKING
        // _albumRepository.FindAsync(1).ReturnsForAnyArgs(Task.FromResult<Album>(_correctAlbum));
        // var service = new AlbumService(_albumRepository);

        // // Act
        // var result = await service.FindById(5);

        // // Assert
        // Assert.AreEqual(result.TotalElements, 1);
    }

    [TestMethod]
    public async Task FindById_NotFound()
    {
        // Arrange
        // MOCKING
        // _albumRepository.FindAsync(1).ReturnsForAnyArgs(Task.FromResult<Album>(null));
        // var service = new AlbumService(_albumRepository);

        // // Act
        // var result = await service.FindById(5);

        // // Assert
        // //Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        // Assert.IsTrue(result.TotalElements == 0 && result.StatusCode == HttpStatusCode.NotFound);
    }

    // [TestMethod]
    // public async Task FindById_ThrowException()
    // {
    //             // Arrange
    //     // MOCKING
    //     _albumRepository.FindAsync(1).ThrowsAsyncForAnyArgs(new Exception("ERROR"));
    //     var service = new AlbumService(_albumRepository);

    //     // Act
    //     //var result = await service.FindById(5);

    //     // Assert
    //     //Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
    //     Assert.ThrowsException<Exception>(async () => await service.FindById(5));
    // }

    // [TestMethod]
    // public async Task AddAlbum_NameIsIncorrect()
    // {
    //     // Arrange
    //     // MOCKING
    //     _albumRepository.AddAsync(new Album());
    //     var service = new AlbumService(_albumRepository);

    //     // Act
    //     var result = await service.AddAlbum(_correctAlbum);

    //     // Assert
    //     Assert.AreEqual(result.TotalElements, 0);
    // }

    // [TestMethod]
    // public async Task AssignGroups()
    // {
    //     var list = new List<int>();
    //     var isComplete = true;
    //     while (isComplete)
    //     {
    //         var index = new Random().Next(1, 31);
    //         var whereIs = list.FindIndex(x => x == index);
    //         if(whereIs == -1)
    //         {
    //             list.Add(index);
    //         }
    //         if(list.Count == 30)
    //         {
    //             isComplete = false;
    //         }
    //     }
    //     Console.WriteLine("STOP!");
    //     Assert.IsTrue(isComplete);
    // }

}