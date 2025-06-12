<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL II <br>
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
## Tugas Jurnal
---

### 1. MEMBUAT PROJECT/CONSOLE TANPA GUI 

![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/awal2.png)
    <br>

### 2. MENAMBAHKAN KODE IMPLEMENTASI 

#### a. Input dan Sambutan Nama Praktikan

- Source Code

    ```csharp
    static void Main()
    {
        // Input nama
        Console.Write("Masukkan nama Anda: ");
        string nama = Console.ReadLine();
        Console.WriteLine($"Selamat datang, {nama}!");
    }
    ```
    <br>

- Output

 ![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-jrnl1.png)
     <br>

- Penjelasan Program
Program ini meminta pengguna untuk memasukkan nama melalui konsol dengan menampilkan pesan "Masukkan nama Anda:". Input yang dimasukkan oleh pengguna disimpan dalam variabel `nama` bertipe string. Setelah itu, program mencetak pesan sapaan yang memuat nama pengguna, yaitu "Selamat datang, \[nama]!". Program ini berfungsi sebagai bentuk interaksi sederhana dengan pengguna menggunakan input dan output teks. Keseluruhan proses berjalan secara berurutan dalam metode `Main`.



#### b. Cetak Array dengan Penanda Kelipatan Index

- Source Code

    ```csharp
    static void Main()
    {
        int[] data = new int[50];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = i;
            if (i % 6 == 0)
                Console.WriteLine($"{data[i]} #$#$");
            else if (i % 2 == 0)
                Console.WriteLine($"{data[i]} ##");
            else if (i % 3 == 0)
                Console.WriteLine($"{data[i]} $$");
            else
                Console.WriteLine($"{data[i]}");
        }
    }
    ```
    <br>

- Output

![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-jrnl2.png)
![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-jrnl3.png)
    <br>

- Penjelasan Program
Program ini membuat sebuah array `data` berukuran 50 elemen bertipe integer dan mengisi setiap elemen dengan nilai indeksnya sendiri. Kemudian, program melakukan iterasi dari indeks 0 sampai 49 dan mencetak setiap nilai elemen ke konsol. Untuk setiap elemen, program menambahkan string khusus sesuai dengan aturan kelipatan: jika indeks kelipatan 6, cetak dengan "#\$#\$"; jika hanya kelipatan 2, cetak dengan "##"; jika hanya kelipatan 3, cetak dengan "\$\$". Jika indeks tidak memenuhi kondisi kelipatan tersebut, hanya mencetak nilai indeks saja tanpa tambahan string. Program ini menunjukkan cara memanipulasi output berdasarkan kondisi tertentu pada indeks array.



#### c. Cek Bilangan Prima dari Input Angka

- Source Code

    ```csharp
    static void Main()
    {
            Console.Write("Masukkan angka (1-10000): ");
            string input = Console.ReadLine();
            int angka = Convert.ToInt32(input);

            bool prima = true;
            if (angka <= 1)
            {
                prima = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(angka); i++)
                {
                    if (angka % i == 0)
                    {
                        prima = false;
                        break;
                    }
                }
            }

            if (prima)
                Console.WriteLine($"Angka {angka} merupakan bilangan prima");
            else
                Console.WriteLine($"Angka {angka} bukan merupakan bilangan prima");
    }
    ```
    <br>

- Output Bukan Prima

![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-jrnl4.png)
    <br>

- Output Prima
![JURNAL_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-jrnl5.png)
    <br>

- Penjelasan Program
Program ini meminta pengguna untuk memasukkan sebuah angka antara 1 hingga 10.000, kemudian mengkonversi input tersebut menjadi tipe data integer. Selanjutnya, program memeriksa apakah angka tersebut adalah bilangan prima dengan cara mengecek pembagi dari 2 hingga akar kuadrat angka tersebut. Jika ditemukan pembagi selain 1 dan angka itu sendiri, maka angka tersebut bukan bilangan prima. Akhirnya, program menampilkan hasil pengecekan ke konsol, memberitahu apakah angka yang dimasukkan merupakan bilangan prima atau bukan.
