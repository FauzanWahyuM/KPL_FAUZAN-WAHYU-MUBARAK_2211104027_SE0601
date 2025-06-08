<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL III <br>
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

### 1. PROJECT BARU SERTA MENAMBAHKAN GUI

![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl1.png)
    <br>

### 2. MENAMBAHKAN IMPLEMENTASI KALKULATOR SEDERHANA 

Karena NIM saya jika di mod, hasilnya 2211104027 % 3 == 2, Jadi saya memakai format ini :

![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/format.png)
    <br>

- Source Code

    ```csharp
    namespace modul3_2211104027
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            string input = "";
            int angka1 = 0;
            bool tambah = false;


            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void button9_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btnplus_Click(object sender, EventArgs e)
            {
                if (input != "")
                {
                    angka1 = int.Parse(input);
                    input = "";
                    tambah = true;
                    lblhasil.Text = "+";
                }
            }

            private void btnsamadengan_Click(object sender, EventArgs e)
            {
                if (input != "")
                {
                    int angka2 = int.Parse(input);
                    int hasil = 0;

                    if (tambah)
                    {
                        hasil = angka1 + angka2;
                        tambah = false;
                    }

                    lblhasil.Text = hasil.ToString();
                    input = hasil.ToString(); 
                }
            }

            private void btnnol_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input; 
            }

            private void btnsatu_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btndua_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btntiga_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btnempat_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btnlima_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btntujuh_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btndelapan_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btnsembilan_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                input += btn.Text;
                lblhasil.Text = input;
            }

            private void btnclear_Click(object sender, EventArgs e)
            {
                input = "";
                angka1 = 0;
                tambah = false;
                lblhasil.Text = "Hasil :";
            }
        }
    }
    ```
    <br>

- Output Design 
![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl2.png)
    <br>

- Output Setelah Dijalankan
![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl3.png)
    <br>
![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl4.png)
    <br>
![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl5.png)
    <br>
![JURNAL_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-jrnl6.png)
    <br>

- Penjelasan Program
Program ini adalah aplikasi kalkulator sederhana berbasis Windows Forms dalam bahasa C#, yang dapat melakukan operasi penjumlahan antara dua angka. Pengguna dapat memasukkan angka melalui tombol-tombol angka (0–9) yang menambahkan karakter ke variabel `input` dan menampilkannya pada label `lblhasil`. Saat tombol tambah (`+`) ditekan, nilai dalam `input` dikonversi menjadi `angka1`, lalu input dikosongkan dan program menandai bahwa operasi penjumlahan akan dilakukan. Ketika tombol sama dengan (`=`) ditekan, program menghitung hasil penjumlahan antara `angka1` dan angka kedua yang dimasukkan, lalu menampilkan hasilnya di label. Program juga memiliki tombol clear untuk mereset seluruh data dan tampilan agar bisa digunakan kembali dari awal.


### 3. Commit Github