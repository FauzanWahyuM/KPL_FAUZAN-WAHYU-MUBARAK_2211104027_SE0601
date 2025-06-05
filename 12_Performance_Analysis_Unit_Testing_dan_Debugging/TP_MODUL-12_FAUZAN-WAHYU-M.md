<div align="center">
TUGAS PENDAHULUAN <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL XII <br>
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
Tugas Pendahuluan
---

### 1. MEMBUAT GUI SEDERHANA

#### a. Tampilan GUI

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/GUI-TP.png)
<br>

#### b. Method CariTandaBilangan

```csharp
public string CariTandaBilangan(int a)
{
    if (a < 0)
        return "Negatif";
    else if (a > 0)
        return "Positif";
    else
        return "Nol";
}
```
<br>

#### c. Method Button Tanda

```csharp
private void button1_Click(object sender, EventArgs e)
{
    if (int.TryParse(txtinput.Text, out int angka))
    {
        lblhasil.Text = "Hasil: " + CariTandaBilangan(angka);
    }
    else
    {
        lblhasil.Text = "Input tidak valid!";
    }
}
```
<br>

#### d. Output

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/output-TP.png)
<br>

### 2. MELAKUKAN SOFTWARE PROFILING

#### a. Pada saat program berjalan, catat dan amati CPU usage dari aplikasi yang sedang berjalan tanpa melakukan input apapun.

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/idle-TP.png)
<br>

#### b. Pada saat program berjalan, catat dan amati memory usage dari aplikasi yang sedang berjalan tanpa melakukan input apapun. 

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/run-TP.png)
<br>

#### c. Coba masukkan beberapa angka pada textbox dan tekan tombol button.

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/run2-TP.png)
<br>

#### d. Laporkan apakah terdapat perubahan pada CPU usage dan memory (apabila tidak ada perubahan juga perlu dilaporkan di file docx).

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/cpu-usage.png)
<br>

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/memory-usage.png)

Pada saat running terjadi kenaikan pada memory usage.

<br>

### 3. MENAMBAHKAN UNIT TESTING 

#### a. Source Code

```csharp
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace tpmodul12_2211104027.Tests
{
    [TestClass]
    public class TandaBilanganTests
    {
        Form1 form = new Form1(); 

        [TestMethod]
        public void TestNegatif()
        {
            Assert.AreEqual("Negatif", form.CariTandaBilangan(-5));
        }

        [TestMethod]
        public void TestNol()
        {
            Assert.AreEqual("Nol", form.CariTandaBilangan(0));
        }

        [TestMethod]
        public void TestPositif()
        {
            Assert.AreEqual("Positif", form.CariTandaBilangan(100));
        }
    }

}
```
<br>

#### b. Hasil Unit Testing

![TP_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/test-TP.png)