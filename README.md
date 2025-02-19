

# Codename: Nikola Tesla's ACDC
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/dracvs/NIKOLA_TESLA_G1_2025_NODO/.github%2Fworkflows%2Fdotnet.yml)


## Abstract

---
Este readme tendrá los comandos resumidos de todo lo hecho hasta la fecha de forma cronológica

### 2025-01-15

```shell
# Verificar que mi .net está en la versión correcta
dotnet --info
dotnet --version

# Crear una solución nueva
dotnet new sln -n TeslaACDC
# Crear un api nuevo
dotnet new webapi -o TeslaACDC.API
# Agregar el api a la solucion
dotnet sln add TeslaACDC.API

# Compilar mi proyecto y revisar que está bien escrito
dotnet build

# Ejecutar mi proyecto
dotnet watch # si estoy en la carpeta del api
dotnet watch --project TeslaACDC.API # si estoy en la carpeta raíz del proyecto donde está la solución.

# Eliminar todos los archivos temporales de construcción
dotnet clean

# Agregar una libreria de clase
dotnet new classlib -o TeslaACDC.Business

# Agregarlo a la solución
dotnet sln add TeslaACDC.Business/

# Agregar una libreria de clase
dotnet new classlib -o TeslaACDC.Data

# Agregarlo a la solución
dotnet sln add TeslaACDC.Data/

# Agregar un proyecto de Testing
# Guardar la colección de Bruno en Ese proyecto.

# instalar dotnet Entity Framework como herramienta global para todos mis proyectos
dotnet tool install -- dotnet-ef

# NUGET: Manejador de paquetes para .net
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL 
#optional: agregar la bandera de la versión
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL  --version 9.0.3

# Busca todos los paquetes de nuget y si no están se los baja.
dotnet restore

# Agregar el Design en TeslaACDC.Data
dotnet add package Microsoft.EntityFrameworkCore.Design

# Agregar el Design y las librerias de utileria en TeslaACDC.API
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.Tools

# hacer la migración inicial para crear las tablas
dotnet ef migrations add InitialCreate --project TeslaACDC.Data --startup-project TeslaACDC.API/

# Ejecutar la migración el Postgres. Sin esto, la DB no se actualiza
dotnet ef database update
```



# Convenciones

- Un DTO (Data Transport Object) No tiene métodos.
- Por lo regular se guardan como structs
- un booleano, se debe escribir siempre como un verbo y una pregunta dicotómica i.e:
    - IsAdmin yes/no
    - IsCorrect yes/no
    - IsEnabled yes/no
    - HasAttributes yes/no

## Tarea 
Para la casa, entregable el lunes 20 de Enero de 2025 5:59


1ro: debe devolver una array de albums
2do: debe recibir dos valores y sumarlos, devolver el resultado
3ro: debe calcular el area de un cuadrado.
4to: Calcular area de un triangulo
5to: Calcular el área de un cuadrado recibiendo todos los lados.
Extra Curricular
6to: PONER EL PIPELINE DE GITHUB A FUNCIONAR

# Semana #2

---
- Corregir el ASYNC y el AWAIT en todos mis métodos y todos mis controladores
- Quitar los metodos del DTO
- Quitar la palabra DTO en el nombre del DTO a los DTOS
- Corregir que los Business solo devuelvan el resultado y nada más. Quitar los mensajes de String.
- LINQ (LINK o LIN-Q)
- acciones de un CRUD
    - Buscar por ID
    - Buscar por Nombre
    - Agregar
    - Editar
    - Eliminar
    - Buscar por Artista

- Instalar BeeKeeper
- Crear una cuenta de SupaBase [https://supabase.com]
- Entity Framework + Migraciones.

- Buscar por nombre
- Buscar por año de publicación
- Buscar por rango de publicación (año de inicio, año final)
- Buscar por nombre de artista
- Buscar por Genero (album)


# Semana 3

---

## Sobre Postgres

*Para Windows:*
Seguir la guía [https://shade-mass-f6b.notion.site/Instalar-Postgress-en-windows-13637fdf1cc28020adcdf53e6f2d9c33] y utilizar la instancia local. Esto es necesario para que no sea pesado.
Si tu computador lo soporta, utilizar, docker, no es requerido.

*Para Linux:*
Seguir la guía: [https://www.postgresql.org/download/linux/] y utilizar una instancia local. Si tu distribución y computador soporta docker, utilizarlo. No es requerido

*Para MacOS:*
Si estás en Apple Silicon (M1, M2, M3, M4) utilizar docker. No hay de otra. 
Si estás en Intel (iN) puedes usar una instancia local o docker. Como prefiereas.

```Csharp
// Agregar la conexión al program.cs 
builder.Services.AddDbContext<NikolaContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("NikolaDatabase"))
);
```

- Mover la conexión de la base de datos al Pipeline

- Usando la guía del proyecto: 
    - Crear el Servicio de Artista, Album, Canción
    - Para cada modelo agregar: buscar por id, buscar por nombre, buscar por gango, agregar, editar, eliminar.

- Condiciones para el artista:
    - El nombre del artista no peude estar vacío
    - El artista no puede estar repetido

- Condiciones para el Album
    - El disco no puede tener una fecha anterior a 1901 y superior a 2025
    - Agrerar duración al disco en segundos, y representar en minutos segundos.

- Condiciones para la canción:
    - debe tener: nombre, duración
    - La duración debe ser en segundos.
    - representar en minutos

- Implementar todos los basemessages para cada servicio individual.