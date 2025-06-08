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

### 1. BUATLAH PROJECT BARU

![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/awal.png)
    <br>

### 2. MENAMBAHKAN GUI

![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-tp1.png)
    <br>

### 3. MENAMBAHKAN FITUR SAAT BUTTON DI-KLIK 

- Source Code

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace tpmodul3_2211104027
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void btnkirim_Click(object sender, EventArgs e)
            {
                string nama = txtinput.Text;
                lbloutput.Text = "Halo " + nama;
            }
        }
    }
    ```
    <br>

- Output Sebelum Dijalankan
![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-tp2.png)
    <br>

- Output Setelah Dijalankan
![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-tp3.png)
    <br>

- Penjelasan Program
Program ini merupakan aplikasi Windows Forms berbasis C# yang dirancang untuk menampilkan sapaan kepada pengguna. Ketika tombol dengan nama `btnkirim` diklik, program akan mengambil teks dari kontrol input teks `txtinput` dan menyimpannya ke dalam variabel `nama`. Selanjutnya, label `lbloutput` akan menampilkan pesan sapaan berupa "Halo \[nama]" sesuai input yang diberikan pengguna. Proses ini berlangsung di dalam event handler `btnkirim_Click`, yang dipicu oleh aksi klik tombol. Program ini mendemonstrasikan interaksi dasar antara kontrol input, tombol, dan label dalam aplikasi GUI.


### 3. Commit Github
![TP_SC_SS](/03_GUI_Builder_dan_GitHub/img/gui-tp3.png)
    <br>
