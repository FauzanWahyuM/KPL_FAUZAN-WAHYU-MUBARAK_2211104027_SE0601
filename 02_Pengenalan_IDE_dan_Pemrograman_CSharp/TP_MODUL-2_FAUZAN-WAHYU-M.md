<div align="center">
TUGAS PENDAHULUAN <br>
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
Tugas Pendahuluan Modul 2
---

### 1.  IKUTI INSTALASI VISUAL STUDIO PADA MODUL 2 SERTA MEMBUAT PROJECT CONSOLE/TANPA GUI

![TP_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/awal.png)
    <br>

### 2. MENAMBAHKAN KODE IMPLEMENTASI 

#### a. Identifikasi Huruf Vokal atau Konsonan

- Source Code

    ```csharp
    static void Main()
    {
        Console.Write("Masukkan satu huruf: ");
        char huruf = Char.Parse(Console.ReadLine().ToUpper());

        if ("AIUEO".Contains(huruf))
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf vokal");
        }
        else
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf konsonan");
        }
    }
    ```
    <br>

- Output Vokal

    ![TP_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-tp2.png)
        <br>

- Output Konsonan

    ![TP_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-tp3.png)
        <br>

- Penjelasan Program
Program di atas meminta pengguna untuk memasukkan satu huruf melalui konsol. Input dari pengguna kemudian diubah menjadi huruf kapital menggunakan `ToUpper()` agar pengecekan huruf vokal tidak tergantung pada kapitalisasi. Huruf yang dimasukkan akan diperiksa apakah termasuk dalam kumpulan huruf vokal "A", "I", "U", "E", atau "O" dengan menggunakan metode `Contains`. Jika termasuk vokal, maka program mencetak bahwa huruf tersebut adalah huruf vokal; jika tidak, maka dicetak sebagai huruf konsonan. Program ini berguna untuk mengklasifikasikan huruf berdasarkan jenis vokal atau konsonan secara sederhana.


#### b. Cetak Deret Bilangan Genap dengan Iterasi

- Source Code

    ```csharp
    static void Main()
    {
        int[] angkaGenap = { 2, 4, 6, 8, 10 };

        for (int i = 0; i < angkaGenap.Length; i++)
        {
            Console.WriteLine($"Angka genap {i + 1} : {angkaGenap[i]}");
        }
    }
    ```
    <br>

- Output

    ![TP_SC_SS](/02_Pengenalan_IDE_dan_Pemrograman_CSharp/img/output-tp1.png)
        <br>

- Penjelasan Program
Program ini mendeklarasikan sebuah array bertipe `int` bernama `angkaGenap` yang berisi lima bilangan genap mulai dari 2 hingga 10. Program kemudian menggunakan perulangan `for` untuk mengiterasi setiap elemen dalam array. Pada setiap iterasi, indeks array (`i`) digunakan untuk mengakses nilai dari elemen dan menampilkannya ke konsol. Nomor urut ditampilkan dengan menambahkan 1 pada nilai indeks agar dimulai dari 1, bukan 0. Hasil output menunjukkan urutan bilangan genap beserta nilainya secara berurutan.

