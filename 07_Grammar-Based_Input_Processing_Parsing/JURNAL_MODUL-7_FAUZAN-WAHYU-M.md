# Cover 

<div align="center">
TUGAS PENDAHULUAN <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL VII <br>
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
## Jurnal Modul 7
---

1. Source Code

JSON DESERIALIZATION 1 :

![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal1.1.png)
<br>

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DataMahasiswa2211104027
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Course> Courses { get; set; }

        public static void ReadJSON()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jurnal7_1_2211104027.json");
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                DataMahasiswa2211104027 mahasiswa = JsonSerializer.Deserialize<DataMahasiswa2211104027>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Console.WriteLine("=== Data Mahasiswa ===");
                Console.WriteLine($"Nama: {mahasiswa.FirstName} {mahasiswa.LastName}");
                Console.WriteLine($"Gender: {mahasiswa.Gender}");
                Console.WriteLine($"Usia: {mahasiswa.Age}");
                Console.WriteLine($"Alamat: {mahasiswa.Address.StreetAddress}, {mahasiswa.Address.City}, {mahasiswa.Address.State}");
                Console.WriteLine("Mata Kuliah:");
                foreach (var course in mahasiswa.Courses)
                {
                    Console.WriteLine($"- {course.Code}: {course.Name}");
                }
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan!");
                Console.WriteLine($"Mencari di: {filePath}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DataMahasiswa2211104027.ReadJSON();
        }
    }
}
```
<br>

Output : 
![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal1.png)
<br>

Penjelasan Program :
Program ini membaca data mahasiswa dari file JSON bernama **"jurnal7_1_2211104027.json"** yang berisi informasi seperti nama, gender, usia, alamat, dan daftar mata kuliah. Data JSON kemudian dideserialisasi menjadi objek **DataMahasiswa2211104027** menggunakan **System.Text.Json** dengan opsi agar nama properti tidak case-sensitive. Setelah deserialisasi, informasi mahasiswa ditampilkan ke layar, termasuk alamat dan mata kuliah yang diambil. Jika file JSON tidak ditemukan, program akan menampilkan pesan error beserta lokasi pencarian file. Program ini menggunakan metode **ReadJSON()** untuk membaca file dan dieksekusi dalam **Main()**.
<br>

2. Source Code

JSON DESERIALIZATION 2 : 

![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal2.1.png)
<br>

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nim { get; set; }
    }

    public class TeamData
    {
        public List<Member> Members { get; set; }
    }

    public class TeamMembers2211104027
    {
        public static void ReadJSON()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "jurnal7_2_2211104027.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File JSON tidak ditemukan!");
                Console.WriteLine($"Mencari di: {filePath}");
                return;
            }

            string jsonContent = File.ReadAllText(filePath);

            TeamData teamData = JsonSerializer.Deserialize<TeamData>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (teamData?.Members == null || teamData.Members.Count == 0)
            {
                Console.WriteLine("Data anggota tim tidak ditemukan atau kosong.");
                return;
            }

            Console.WriteLine("Team member list:");
            foreach (var member in teamData.Members)
            {
                Console.WriteLine($"{member.Nim} {member.FirstName} {member.LastName} ({member.Age} {member.Gender})");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TeamMembers2211104027.ReadJSON();
        }
    }
}
```
<br>

Output :
![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal2.2.png)
<br>

Penjelasan Program :
Program ini membaca data anggota tim dari file JSON bernama **"jurnal7_2_2211104027.json"**, yang berisi informasi seperti nama, gender, usia, dan NIM. Data JSON kemudian dideserialisasi menjadi objek **TeamData** menggunakan **System.Text.Json** dengan opsi agar nama properti tidak case-sensitive. Jika file tidak ditemukan, program akan menampilkan pesan error dan lokasi pencarian file. Jika data anggota tim kosong, program akan memberi tahu pengguna bahwa data tidak ditemukan. Program ini menampilkan daftar anggota tim dalam format **NIM Nama (Usia Gender)** setelah berhasil membaca JSON.
<br>

3. Source Code

JSON DESERIALIZATION 3 :

![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal3.1.png)
<br>

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace modul7_2211104027
{
    public class GlossaryItem2211104027
    {
        public class GlossaryRoot
        {
            [JsonPropertyName("glossary")]
            public Glossary Glossary { get; set; }
        }

        public class Glossary
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("GlossDiv")]
            public GlossDiv GlossDiv { get; set; }
        }

        public class GlossDiv
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("GlossList")]
            public GlossList GlossList { get; set; }
        }

        public class GlossList
        {
            [JsonPropertyName("GlossEntry")]
            public GlossEntry GlossEntry { get; set; }
        }

        public class GlossEntry
        {
            [JsonPropertyName("ID")]
            public string ID { get; set; }

            [JsonPropertyName("SortAs")]
            public string SortAs { get; set; }

            [JsonPropertyName("GlossTerm")]
            public string GlossTerm { get; set; }

            [JsonPropertyName("Acronym")]
            public string Acronym { get; set; }

            [JsonPropertyName("Abbrev")]
            public string Abbrev { get; set; }

            [JsonPropertyName("GlossDef")]
            public GlossDef GlossDef { get; set; }

            [JsonPropertyName("GlossSee")]
            public string GlossSee { get; set; }
        }

        public class GlossDef
        {
            [JsonPropertyName("para")]
            public string Para { get; set; }

            [JsonPropertyName("GlossSeeAlso")]
            public string[] GlossSeeAlso { get; set; }
        }

        public static void ReadJSON()
        {
            try
            {
                string filePath = "jurnal7_3_2211104027.json"; // Sesuaikan dengan NIM Anda
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File JSON tidak ditemukan!");
                    return;
                }

                string jsonContent = File.ReadAllText(filePath);
                GlossaryRoot glossaryData = JsonSerializer.Deserialize<GlossaryRoot>(jsonContent);

                if (glossaryData?.Glossary?.GlossDiv?.GlossList?.GlossEntry != null)
                {
                    GlossEntry entry = glossaryData.Glossary.GlossDiv.GlossList.GlossEntry;
                    Console.WriteLine("GlossEntry Data:");
                    Console.WriteLine($"ID       : {entry.ID}");
                    Console.WriteLine($"SortAs   : {entry.SortAs}");
                    Console.WriteLine($"GlossTerm: {entry.GlossTerm}");
                    Console.WriteLine($"Acronym  : {entry.Acronym}");
                    Console.WriteLine($"Abbrev   : {entry.Abbrev}");
                    Console.WriteLine($"GlossSee : {entry.GlossSee}");
                    Console.WriteLine($"Definition: {entry.GlossDef.Para}");
                    Console.WriteLine("GlossSeeAlso: " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
                }
                else
                {
                    Console.WriteLine("Data GlossEntry tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saat membaca JSON: " + ex.Message);
            }
        }

        public static void Main()
        {
            ReadJSON();
        }
    }
}
```
<br>

Output :
![TP_SC_SS](/07_Grammar-Based_Input_Processing_Parsing/img/Jurnal3.2.png)
<br>

Penjelasan Program :
Program ini membaca dan menampilkan data dari file JSON bernama **"jurnal7_3_2211104027.json"**, yang berisi informasi tentang entri glosarium dalam struktur bertingkat. JSON tersebut dideserialisasi menjadi objek **GlossaryRoot** menggunakan **System.Text.Json** dengan atribut **JsonPropertyName** untuk mencocokkan nama properti. Jika file tidak ditemukan atau data tidak tersedia, program akan menampilkan pesan error. Setelah membaca data, program menampilkan informasi seperti **ID, GlossTerm, Acronym, Abbreviation, Definition**, dan **GlossSeeAlso**. Jika terjadi kesalahan saat membaca JSON, program akan menangkap dan menampilkan pesan error.
<br>