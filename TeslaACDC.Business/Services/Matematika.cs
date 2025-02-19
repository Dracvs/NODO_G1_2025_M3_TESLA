using System;
using System.Net;
using System.Text;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
namespace TeslaACDC.Business.Services;

public class Matematika : IMatematika
{
    public async Task<float> Multiply(float factora, float factorb)
    {
        var multiplication = factora * factorb;
        return multiplication;
    }

    public async Task<BaseMessage<string>> Divide(float sideLenght)
    {
        if (sideLenght == 0)
        {
            return new()
            {
                Message = "No se puede dividir entre 0",
                StatusCode = HttpStatusCode.InternalServerError,
                TotalElements = 0,
                ResponseElements = new() {}
            };
        }
        
        var side = 10;
        float cociente = 0f;
        try
        {
            cociente = side / sideLenght;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new()
            {
                Message = $"[ERROR] {ex.Message}",
                StatusCode = HttpStatusCode.InternalServerError,
                TotalElements = 0,
                ResponseElements = new() {  }
            };
        }

        return new()
        {
            Message = "",
            StatusCode = HttpStatusCode.OK,
            TotalElements = 1,
            ResponseElements = new() { cociente.ToString() }
        };
    }

    public async Task<float> SquareArea(float sideLenghtA, float sideLenghtB, float sideLenghtC, float sideLenghtD)
    {
        /********************************
        Operadores Lógicos
        == Igual a
        != Diferente de o no es igual a
        > mayor que
        < menor que
        >= mayor o igual
        <= menor o igual
        || o
        true or false
        ! negación
        ?:
        ***************************/
        var nombre = "Lucho";
        var apodo = "lucho";
        if (sideLenghtA == sideLenghtB && sideLenghtA == sideLenghtC &&
            sideLenghtA == sideLenghtD)
        {
            // Hago algo si el resultado es verdadero
        }
        else
        {

        }

        if (nombre.ToLower().Equals(apodo.ToUpper()) || String.IsNullOrEmpty(nombre)
            || String.IsNullOrWhiteSpace(apodo))
        {
            var palabra = "";
        }

        // Ciclos
        while (nombre != apodo)
        {
            /// Evalua primero, ejecuta después.
            /// Si la evaluación falla, no ejecuta.
        }

        do
        {
            // Ejecuta al menos una vez. luego evalua, y continua, o termina
        }
        while (nombre != apodo);

        for (var i = 0; i <= 10; i++)
        {
            // Se escribe igual en todos los lenguajes
        }
        for (var i = 10; i <= 0; i--)
        {
            // Se escribe igual en todos los lenguajes
        }

        var listaNombres = new List<string>() { "Pedro", "Ana", "Johan", "Sakura", "Neo", "Goku" };

        foreach (var item in listaNombres)
        {
            Console.WriteLine(item);
        }
        float respuesta = 0;
        return respuesta;



    }

    public async Task<float> Sum(float sumando, float sumando_2)
    {
        var sumatoria = sumando + sumando_2;
        return sumatoria;
    }
}
