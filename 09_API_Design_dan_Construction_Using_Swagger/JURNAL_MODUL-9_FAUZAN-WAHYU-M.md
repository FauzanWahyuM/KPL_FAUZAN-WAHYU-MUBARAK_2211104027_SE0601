<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL IX <br>
<!-- JUDUL -->
 <br>

<img src="https://lac.telkomuniversity.ac.id/wp-content/uploads/2021/01/cropped-1200px-Telkom_University_Logo.svg-270x270.png" width="250px">

<br>

Disusun Oleh: <br>
Fauzan Wahyu Mubarak - 2211104027 <br>
SE-06-01 <br>

<br>

Asisten Praktikum : <br>
Naufal El Kamil Aditya Pratama Rahman <br>
Imelda Alfiana Palupi Dewi <br>

<br>

Dosen Pengampu : <br>
Yudha Islami Sulistya, S.Kom., M.Cs <br>

<br>

PROGRAM STUDI S1 REKAYASSA PERANGKAT LUNAK <br>
FAKULTAS INFORMATIKA <br> 
TELKOM UNIVERSITY PURWOKERTO <br>

</div>

---
## Jurnal Modul 9
---

1. Source Code

    - API (Program.cs):

    ```c#
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    ```
    <br>

    - API (Models/Movie.cs):

    ```c#
    namespace modul9_2211104027.Models
    {
        public class Movie
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public List<string> Stars { get; set; }
            public string Description { get; set; }

            public Movie() { }
        }
    }

    ```
     <br>

    - API (Controller/MovieController.cs) :
        
    ```c#
    using Microsoft.AspNetCore.Mvc;
    using modul9_2211104027.Models;

    namespace modul9_2211104027.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class MoviesController : ControllerBase
        {
            private static List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Iron Man",
                    Director = "Jon Favreau",
                    Stars = new List<string> { "Robert Downey Jr", "Gwyneth Paltrow", "Terrence Howard" },
                    Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil."
                },
                new Movie
                {
                    Title = "Thor",
                    Director = "Kenneth Branagh",
                    Stars = new List<string> { "Chris Hemsworth", "Anthony Hopkins", "Natalie Portman" },
                    Description = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders."
                }
            };

            [HttpGet]
            public ActionResult<List<Movie>> GetAll()
            {
                return movies;
            }

            [HttpGet("{id}")]
            public ActionResult<Movie> Get(int id)
            {
                if (id < 0 || id >= movies.Count)
                    return NotFound();

                return movies[id];
            }

            [HttpPost]
            public ActionResult AddMovie([FromBody] Movie newMovie)
            {
                movies.Add(newMovie);
                return Ok();
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                if (id < 0 || id >= movies.Count)
                    return NotFound();

                movies.RemoveAt(id);
                return Ok();
            }
        }
    }
    ```
    <br>


2. Output :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal1.png)

    - Mencoba “GET /api/Movies” saat baru dijalankan yang mengeluarkan list film dari TOP 3 IMDB seperti pada tampilan berikut pada saat dicoba dengan menekan tombol “Try it out” dan tombol “Execute” : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal2.png)
    <br>

    - Menambahkan Movie baru yaitu urutan ke-4 pada TOP IMDB list dengan memanggil API pada bagian “POST /api/Movies” : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal3.png)
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal4.png)
    <br>

    - Cek list/array dari semua Movie lagi dengan “GET /api/Movies”, pastikan Movie yang baru ditambahkan sebelumnya sudah ada :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal5.png)
    <br>

    - Mencoba meminta Movie dengan index 3, “GET /api/Movies/3” yang seharusnya mengembalikan Movie yang baru saja ditambah :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal6.png)
    <br>

    - Menghapus objek Movie dengan index ke-1 dengan “DELETE /api/Movies/1” :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal7.png)
    <br>

    - Cek list/array dari semua Movie sekali lagi dengan “GET /api/Movies”, film dengan ranking kedua “Godfather” sudah tidak ada di list :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/outputjurnal8.png)
    <br>

3. Penjelasan Program :
    ini adalah tugas API sederhana dengan menggunakan Swagger yang berbasis ASP.NET Core yang berfungsi untuk mengelola data film. API menyediakan endpoint untuk menampilkan semua film, mengambil film berdasarkan indeks, menambahkan film baru, dan menghapus film berdasarkan indeks. Setiap film memiliki properti seperti Title, Director, Stars, dan Description, yang didefinisikan dalam kelas Movie. Data film disimpan dalam list statis sebagai penyimpanan sementara (in-memory). Swagger digunakan saat mode pengembangan untuk mempermudah dokumentasi dan pengujian API. Pelatihan ini bertujuan untuk mengetahui bagaimana mendokumentasikan sebuah API dengan baik dan benar.
    <br>

