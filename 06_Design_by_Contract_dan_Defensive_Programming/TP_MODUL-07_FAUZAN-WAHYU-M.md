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
## Tugas Pendahuluan
---

1. Link Github Repository Kelompok : `https://github.com/FauzanWahyuM/tpmodul7_kelompok_6.git`

<br>

2. Screenshot Hasil Run :
![TP_SC_SS](/06_Design_by_Contract_dan_Defensive_Programming/img/TP1.png)
<br>
![TP_SC_SS](/06_Design_by_Contract_dan_Defensive_Programming/img/TP2.png)
<br>

3. Penjelasan Program Pertama :
Code diatas adalah cara menerapkan **deserialisasi JSON** untuk membaca data mahasiswa dari file `tp7_1_2211104027.json`. Class `DataMahasiswa` memiliki tiga properti: `Nama`, `NIM`, dan `Fakultas`, yang sesuai dengan struktur JSON yang akan dibaca. Method `ReadJSON()` bertugas untuk **memeriksa keberadaan file JSON**, kemudian membacanya menggunakan `File.ReadAllText()`, dan melakukan deserialisasi menggunakan `JsonConvert.DeserializeObject<T>()` dari **Newtonsoft.Json**. Jika file ditemukan, program akan mencetak informasi mahasiswa dalam format `"Nama <nama> dengan nim <nim> dari fakultas <fakultas>"`, sedangkan jika file tidak ditemukan, akan muncul pesan error. Method `Main()` akan memanggil `ReadJSON()` untuk mengeksekusi program saat dijalankan.
<br>

4. Penjelasan Program Kedua :
Output yang dihasilkan dari code kedua adalah membaca dan menampilkan data mahasiswa serta daftar mata kuliah dari file JSON. Class `DataMahasiswa` menyimpan informasi mahasiswa seperti **nama, NIM, dan fakultas**, sedangkan `CourseData` menyimpan daftar mata kuliah yang diambil. Method `ReadJSONMahasiswa()` membaca file `tp7_1_2211104027.json`, kemudian melakukan **deserialisasi JSON** menggunakan `JsonConvert.DeserializeObject<DataMahasiswa>()`, lalu menampilkan data mahasiswa. Method `ReadJSONCourses()` membaca file `tp7_2_2211104027.json`, kemudian menampilkan daftar mata kuliah dengan format **MK <nomor> <kode_mata_kuliah> - <nama_mata_kuliah>**. Saat program dijalankan, method `Main()` akan memanggil kedua method tersebut untuk menampilkan **data mahasiswa dan daftar mata kuliah** secara bersamaan.
