<div align="center">
TUGAS PENDAHULUAN <br>
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
## Tugas Pendahuluan Modul 9
---

1. Source Code 

    - API (Program.cs):

        ```c#
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        ```
        <br>

    - API (Models/Mahasiswa.cs):

        ```c#
        namespace tpmodul9_2211104027.Models
        {
            public class Mahasiswa
            {
                public string Nama { get; set; }
                public string Nim { get; set; }
            }
        }
        ```
        <br>

    - API (Controller/MahasiswaController.cs):

        ```c#
        using Microsoft.AspNetCore.Mvc;
        using tpmodul9_2211104027.Models;
        using System.Collections.Generic;
        using tpmodul9_2211104027.Models;

        namespace MahasiswaAPI.Controllers
        {
            [ApiController]
            [Route("api/[controller]")]
            public class MahasiswaController : ControllerBase
            {
                private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
                {
                    new Mahasiswa { Nama = "Fauzan Wahyu Mubarak", Nim = "2211104027" },
                    new Mahasiswa { Nama = "Gideon Toranawa Ladiyo", Nim = "2211104022" },
                    new Mahasiswa { Nama = "Syahrul Zaki Khuzaini", Nim = "2211104014" }
                };

                // GET /api/mahasiswa
                [HttpGet]
                public ActionResult<IEnumerable<Mahasiswa>> GetAll()
                {
                    return Ok(mahasiswaList);
                }

                // GET /api/mahasiswa/{index}
                [HttpGet("{id}")]
                public ActionResult<Mahasiswa> GetByIndex(int id)
                {
                    if (id < 0 || id >= mahasiswaList.Count)
                        return NotFound("Mahasiswa tidak ditemukan.");

                    return Ok(mahasiswaList[id]);
                }

                // POST /api/mahasiswa
                [HttpPost]
                public ActionResult Add([FromBody] Mahasiswa newMahasiswa)
                {
                    mahasiswaList.Add(newMahasiswa);
                    return Ok("Mahasiswa berhasil ditambahkan.");
                }

                // DELETE /api/mahasiswa/{index}
                [HttpDelete("{id}")]
                public ActionResult Delete(int id)
                {
                    if (id < 0 || id >= mahasiswaList.Count)
                        return NotFound("Mahasiswa tidak ditemukan.");

                    mahasiswaList.RemoveAt(id);
                    return Ok("Mahasiswa berhasil dihapus.");
                }
            }
        }
        ```
        <br>

2. Output :
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output1.png)
    <br>

    - Output Mencoba “GET /api/mahasiswa” saat baru dijalankan : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output2.png)
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output3.png)
    <br>

    - Output Menambahkan mahasiswa dengan “POST/api/mahasiswa” : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output4.png)
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output5.png)
    <br>

    - Output Cek list/array dari semua mahasiswa lagi dengan “GET /api/mahasiswa”, pastikan mahasiswa yang baru ditambahkan sebelumnya ada di list mahasiswa: : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output6.png)
    <br>

    - Output Mencoba meminta mahasiswa dengan index 0, “GET /api/mahasiswa/0” yang seharusnya mengeluarkan nama dan nim anda : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output7.png)
    <br>

    - Output Menghapus objek mahasiswa dengan index ke-0 dengan “DELETE /api/mahasiswa/0” : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output8.png)
    <br>

     - Output Cek list/array dari semua mahasiswa sekali lagi dengan “GET /api/mahasiswa”, pastikan nama anda sudah tidak muncul di list tersebut : 
    ![TP_SC_SS](/09_API_Design_dan_Construction_Using_Swagger/img/output9.png)
    <br>


3. Penjelasan Program :
    Pembuatan Web API berbasis Swagger yang menggunakan ASP.NET Core untuk mengelola data mahasiswa. API ini menyediakan endpoint untuk melakukan operasi dasar CRUD (Create, Read, Delete) pada daftar mahasiswa yang disimpan dalam list statis. Struktur data mahasiswa terdiri dari dua properti: Nama dan Nim, yang didefinisikan dalam kelas Mahasiswa. Terdapat empat endpoint utama: GET untuk mengambil seluruh data atau data mahasiswa berdasarkan indeks, POST untuk menambahkan mahasiswa baru, dan DELETE untuk menghapus data berdasarkan indeks. Jika indeks yang diminta tidak valid, API akan mengembalikan pesan kesalahan. Tugas ini digunakan sebagai latihan dalam pembuatan REST API dengan .NET serta mendokumentasikan API dengan baik dan benar.
    <br>
