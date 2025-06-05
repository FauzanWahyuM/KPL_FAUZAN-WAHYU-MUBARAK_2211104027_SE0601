<div align="center">
TUGAS JURNAL <br>
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
Tugas Jurnal
---

### 1.  MEMBUAT GUI SEDERHANA

#### a. Tampilan GUI 

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/GUI.png)
<br>

#### b. Method CariNilaiPangkat

```csharp
public int CariNilaiPangkat(int a, int b)
{
    if (b == 0) return 1;
    if (b < 0) return -1;
    if (b > 10 || a > 100) return -2;

    try
    {
        checked
        {
            int hasil = 1;
            for (int i = 0; i < b; i++)
            {
                hasil *= a;
            }
            return hasil;
        }
    }
    catch (OverflowException)
    {
        return -3;
    }
}
```
<br>

#### c. Method button Hitung

```csharp
private void button1_Click(object sender, EventArgs e)
{
    int a, b;
    if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
    {
        int hasil = CariNilaiPangkat(a, b);
        label1.Text = $"Hasil: {hasil}";
    }
    else
    {
        label1.Text = "Input tidak valid!";
    }
}
```
<br>

#### d. Output

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/output-GUI.png)
<br>

### 2.  MELAKUKAN SOFTWARE PROFILING

#### a. Pada saat program berjalan, catat dan amati CPU usage dari aplikasi yang sedang berjalan tanpa melakukan input apapun. 

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/idle.png)
<br>

#### b. Pada saat program berjalan, catat dan amati memory usage dari aplikasi yang sedang berjalan melakukan input apapun.

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/running.png)

Dalam hal ini memory usage naik +39

<br>

#### c. Tambahkan input “3” pada textbox pertama dan “19” pada textbox ketiga, dan tekan tombol button dan catat dan amati memory usage dari aplikasi. 

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/3,19.png)

Dalam hal ini yang naik adalah memory usage +2

<br>

#### d. Laporkan apakah terdapat perubahan pada CPU usage dan memory (apabila tidak ada perubahan juga perlu dilaporkan di file docx).

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/idle2.png)

Dalam hal ini tanpa melakukan apapun memory usage naik sendiri +5 dan CPU berapa pada 30%

<br>

#### e. Lakukan lagi experimen dengan input pertama yaitu “9” dan angka kedua yaitu “30”, laporkan apakah terdapat perubahan di CPU usage dan memory.

![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/9,30.png)

Dalam hal ini hanya memory usage naik +1

<br>

### 3.  MENAMBAHKAN UNIT TESTING 

#### a. Code Unit Testing

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace modul12_2211104027.Tests
{
    [TestClass]
    public class Form1Tests
    {
        Form1 form = new Form1();

        [TestMethod]
        public void TestPangkat_Normal()
        {
            Assert.AreEqual(8, form.CariNilaiPangkat(2, 3));
        }

        [TestMethod]
        public void TestPangkat_BZero()
        {
            Assert.AreEqual(1, form.CariNilaiPangkat(5, 0));
        }

        [TestMethod]
        public void TestPangkat_Negatif()
        {
            Assert.AreEqual(-1, form.CariNilaiPangkat(2, -2));
        }

        [TestMethod]
        public void TestPangkat_Limit()
        {
            Assert.AreEqual(-2, form.CariNilaiPangkat(101, 2));
        }

        [TestMethod]
        public void TestPangkat_Overflow()
        {
            Assert.AreEqual(-3, form.CariNilaiPangkat(50, 10));
        }
    }
}
```
<br>

#### b. Hasil Unit Testing
![Jurnal_SC_SS](/12_Performance_Analysis_Unit_Testing_dan_Debugging/img/test.png)