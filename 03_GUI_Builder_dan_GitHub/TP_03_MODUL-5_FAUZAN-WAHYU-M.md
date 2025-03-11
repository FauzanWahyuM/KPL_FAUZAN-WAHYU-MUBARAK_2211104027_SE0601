<div align="center">
TUGAS PENDAHULUAN <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL V <br>
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
## Tugas Pendahuluan
---

1. SOAL MENAMBAHKAN METHOD DENGAN GENERIC
Tanpa membuat file baru (gunakan file yang dibuat saat membuat project):

    - Buatlah sebuah class bernama “HaloGeneric”.
    - Pada class tersebut, tambahkan sebuah method dengan nama “SapaUser” yang memiliki generic parameter yang akan melakukan print “Halo user X” dimana X adalah input/nilai argument yang diberikan pada method tersebut.
    - Panggil method tersebut pada fungsi/method utama dengan input String dengan isi nilai nama panggilan praktikan.

2. SOAL MENAMBAHKAN METHOD DENGAN GENERIC
Tanpa membuat file baru (gunakan file yang dibuat saat membuat project dan pastikan branch aktif adalah pada branch generic-class):
    - Buatlah sebuah class bernama “DataGeneric” dengan mengikuti class model yang ditunjukkan pada gambar/tabel di bawah ini. Class tersebut memiliki property “Data” yang bertipe generic “T” dan memiliki konstruktor dengan parameter data.

    | DataGeneric         |
    |---------------------|
    | - data: T           |
    | + DataGeneric(T)    |
    | + PrintData(): void |

    - Class tersebut juga memiliki method bernama PrintData yang melakukan print di console dengan output “Data yang tersimpan adalah: Y”, dengan “Y” adalah nilai dari property “data” dari kelas tersebut.
    - Panggil method PrintData() setelah mengisi “data” dengan NIM pada fungsi/method utama.

---
## Jawaban 
---

1. Source Code 

    ```c#
    class Program
    {
        static void Main()
        {
            // Memanggil metode generic SapaUser
            HaloGeneric.SapaUser("Fauzan");
        }
    }

    // HaloGeneric.cs
    class HaloGeneric
    {
        public static void SapaUser<T>(T user)
        {
            Console.WriteLine($"Halo user {user}");
        }
    }
    ```
    <br>

    Output :
    ![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/TP1.png)
    <br>

    Penjelasan Program :
    - Pada kelas Main() adalah titik masuk utama program. Di dalamnya, kita memanggil metode `SapaUser<T>()` dari kelas HaloGeneric, dengan argumen berupa string "Fauzan".
    - Pada kelas HaloGeneric `SapaUser<T>(T user)` adalah metode generic. T adalah parameter generic, yang berarti metode ini bisa menerima berbagai tipe data. Dalam contoh pemanggilan di Main(), T secara otomatis ditentukan sebagai string, karena argumen yang diberikan adalah "Fauzan". `Console.WriteLine($"Halo user {user}")` Mencetak teks "Halo user X", di mana X adalah nilai yang diberikan sebagai argumen metode.
    <br>

2. Source Code 

    ```c#
    class Program
    {
        static void Main()
        {
            // Memanggil metode generic SapaUser
            HaloGeneric.SapaUser("Fauzan");

            // Menggunakan kelas DataGeneric
            DataGeneric<string> dataGeneric = new DataGeneric<string>("NIM : 2211104027");
            dataGeneric.PrintData();
        }
    }

    // HaloGeneric.cs
    class HaloGeneric
    {
        public static void SapaUser<T>(T user)
        {
            Console.WriteLine($"Halo user {user}");
        }
    }

    // DataGeneric.cs
    class DataGeneric<T>
    {
        private T data;

        public DataGeneric(T data)
        {
            this.data = data;
        }

        public void PrintData()
        {
            Console.WriteLine($"Data yang tersimpan adalah {data}");
        }
    }
    
    ```
    <br>

    Output :
    ![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/TP2.png)
    <br>

    Penjelasan Program :
     Kelas `HaloGeneric` memiliki metode `SapaUser<T>()`, yang memungkinkan pemanggilan dengan berbagai tipe data, seperti string, integer, atau tipe lainnya, tanpa perlu menulis ulang metode untuk setiap tipe. Sementara itu, `DataGeneric<T>` adalah kelas generic yang dapat menyimpan data dengan tipe yang fleksibel, ditentukan saat pembuatan objek, dan mencetaknya menggunakan metode `PrintData()`. Pada `Main()`, metode `SapaUser()` dipanggil dengan input `"Fauzan"`, dan objek `DataGeneric<string>` dibuat untuk menyimpan `"NIM : 2211104027"`, lalu mencetaknya ke layar. Dengan penggunaan generic, program ini menjadi lebih fleksibel, efisien, dan aman dalam menangani berbagai tipe data tanpa harus menulis ulang kode untuk setiap tipe yang berbeda.
    <br>