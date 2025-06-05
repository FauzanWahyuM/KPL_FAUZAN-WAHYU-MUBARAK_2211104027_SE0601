<div align="center">
TUGAS JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL XIII <br>
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
Tugas Jurnal Modul 13
---

### 1. MENJELASKAN DESIGN PATTERN SINGLETON

#### a. Dua Contoh Kondisi Penggunaan Singleton Pattern

Jawaban : Design pattern Singleton digunakan saat kita ingin memastikan hanya ada satu instance dari suatu kelas yang dapat diakses secara global.

- Contoh 1: Logger / Sistem Logging
Sebuah aplikasi besar hanya memerlukan satu objek Logger untuk mencatat semua aktivitas ke file log, agar konsisten dan efisien.

- Contoh 2: Database Connection Manager
Aplikasi yang terhubung ke database sebaiknya hanya menggunakan satu instance koneksi utama agar tidak membanjiri resource server dan menghindari konflik antar koneksi.




#### b. Langkah-langkah Mengimplementasikan Singleton Pattern

1. Buat constructor private

    - Agar objek tidak bisa dibuat dari luar kelas.

2. Buat field static yang menyimpan satu-satunya instance

    ```csharp
    private static Singleton _instance;
    ```

3. Buat method static GetInstance()

    - Method ini akan memeriksa apakah instance sudah dibuat. Jika belum, buatlah. Jika sudah, kembalikan yang sudah ada.

    ```c
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }
    ```

    (Opsional) Gunakan mekanisme thread-safe untuk menghindari race condition pada aplikasi multi-thread.


#### c. Kelebihan dan Kekurangan Singleton Pattern

1. Kelebihan :
    - Menghemat memori : Hanya satu instance dibuat selama aplikasi berjalan.

    - Global Access : Dapat diakses dari bagian mana pun dalam program.

    - Konsistensi data : Cocok untuk state atau konfigurasi global yang tidak boleh duplikat.

2. Kekurangan :
    - Menyulitkan unit testing : Karena bergantung pada instance global, sulit mengganti dengan mock object.

    - Menyebabkan hidden dependency : Kelas yang menggunakan singleton jadi tergantung pada objek global, menurunkan fleksibilitas.

    - Tidak cocok untuk aplikasi paralel / multi-thread tanpa penanganan ekstra : Bisa menyebabkan bug seperti race condition jika tidak dibuat thread-safe.


### 2. IMPLEMENTASI DAN PEMAHAMAN DESIGN PATTERN OBSERVER

#### a. Implementasi Kode

```csharp
using System;
using System.Collections.Generic;

public class PusatDataSingleton
{
    // Property Singleton
    private static PusatDataSingleton? _instance;

    // Atribut untuk menyimpan data
    private List<string> DataTersimpan;

    // Konstruktor private (agar tidak bisa dibuat objek dari luar)
    private PusatDataSingleton()
    {
        DataTersimpan = new List<string>();
    }

    // Method untuk mengakses instance Singleton
    public static PusatDataSingleton GetDataSingleton()
    {
        if (_instance == null)
        {
            _instance = new PusatDataSingleton();
        }
        return _instance;
    }

    // Menambahkan data ke list
    public void AddSebuahData(string input)
    {
        DataTersimpan.Add(input);
    }

    // Menghapus data berdasarkan index
    public void HapusSebuahData(int index)
    {
        if (index >= 0 && index < DataTersimpan.Count)
        {
            DataTersimpan.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Index tidak valid!");
        }
    }

    // Mengembalikan list data
    public List<string> GetSemuaData()
    {
        return DataTersimpan;
    }

    // Menampilkan semua data
    public void PrintSemuaData()
    {
        if (DataTersimpan.Count == 0)
        {
            Console.WriteLine("Tidak ada data tersimpan.");
            return;
        }

        Console.WriteLine("Isi Data yang Tersimpan:");
        for (int i = 0; i < DataTersimpan.Count; i++)
        {
            Console.WriteLine($"{i}. {DataTersimpan[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var data1 = PusatDataSingleton.GetDataSingleton();
        var data2 = PusatDataSingleton.GetDataSingleton();

        data1.AddSebuahData("Fauzan Wahyu M");
        data1.AddSebuahData("Wahyu Isnantia Q G");
        data1.AddSebuahData("Syahrul Zaki Khuzaini");
        data1.AddSebuahData("Gideon Toranawa Ladiyo");
        data1.AddSebuahData("Sesuatu Entitas Hitam");

        Console.WriteLine("\nPrint dari data-2:");
        data2.PrintSemuaData();

        Console.WriteLine("\nMenghapus Sesuatu Entitas Hitam");
        data2.HapusSebuahData(data2.GetSemuaData().IndexOf("Sesuatu Entitas Hitam"));

        Console.WriteLine("\nPrint dari data-1 setelah penghapusan:");
        data1.PrintSemuaData();

        Console.WriteLine($"\nJumlah data di data-1: {data1.GetSemuaData().Count}");
        Console.WriteLine($"Jumlah data di data-2: {data2.GetSemuaData().Count}");
    }
}
```
<br>

#### b. Output

![TP_SC_SS](/13_Design_Pattern_Implementation/img/output-jrnl.png)
<br>

#### c. Penjelasaan Program

Program diatas menerapkan design pattern Singleton untuk memastikan hanya ada satu objek PusatDataSingleton yang digunakan di seluruh program. Objek ini menyimpan data dalam bentuk list string (DataTersimpan) dan hanya bisa diakses melalui method GetDataSingleton(). Konstruktor dibuat private agar objek tidak bisa dibuat dari luar class, dan instance disimpan dalam properti _instance. Method tambahan disediakan untuk menambahkan, menghapus, menampilkan, dan mengambil seluruh data yang tersimpan. Dalam method Main(), dua variabel (data1 dan data2) sebenarnya menunjuk ke instance yang sama, sehingga perubahan pada satu variabel otomatis terlihat pada yang lain. Hasil program menunjukkan bahwa menghapus data melalui data2 juga memengaruhi isi data1, membuktikan bahwa objeknya memang tunggal (singleton).