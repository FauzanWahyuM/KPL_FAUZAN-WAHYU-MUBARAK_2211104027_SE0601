<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL X <br>
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
## Jurnal Modul 10
---

1. Source Code

    - Class Library (RumusMatematika.cs):

    ```c#
    namespace MatematikaLibraries
    {
        public class RumusMatematika
        {
            public static int FPB(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return Math.Abs(a);
            }

            public static int KPK(int a, int b)
            {
                return Math.Abs(a * b) / FPB(a, b);
            }

            public static string Turunan(int[] koefisien)
            {
                List<string> hasil = new();
                int pangkat = koefisien.Length - 1;

                for (int i = 0; i < koefisien.Length - 1; i++)
                {
                    int koef = koefisien[i] * pangkat;

                    if (koef == 0)
                    {
                        pangkat--;
                        continue;
                    }

                    string bagian = "";

                    // Tanda positif/negatif
                    if (koef > 0 && hasil.Count > 0)
                        bagian += "+ ";
                    else if (koef < 0)
                        bagian += "- ";

                    int nilai = Math.Abs(koef);

                    // Format bagian turunan sesuai pangkat
                    if (pangkat - 1 > 1)
                        bagian += $"{nilai}x{pangkat - 1}";
                    else if (pangkat - 1 == 1)
                        bagian += $"{nilai}x";
                    else
                        bagian += $"{nilai}";

                    hasil.Add(bagian);
                    pangkat--;
                }

                return string.Join(" ", hasil);
            }


            public static string Integral(int[] koefisien)
            {
                List<string> hasil = new();
                int pangkat = koefisien.Length;
                for (int i = 0; i < koefisien.Length; i++)
                {
                    double koef = (double)koefisien[i] / (pangkat - i);
                    string bagian = $"{(koef > 0 && i > 0 ? "+ " : (koef < 0 ? "- " : ""))}{Math.Abs(koef)}x";
                    if (pangkat - i > 1)
                        bagian += $"{pangkat - i}";
                    hasil.Add(bagian);
                }
                hasil.Add("+ C");
                return string.Join(" ", hasil);
            }
        }
    }
    ```
    <br>

    - Matematika Main (Program.cs):

    ```c#
    using System;
    using MatematikaLibraries;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("FPB(60, 45): " + RumusMatematika.FPB(60, 45));
            Console.WriteLine("KPK(12, 8): " + RumusMatematika.KPK(12, 8));
            Console.WriteLine("Turunan({1, 4, -12, 9}): " + RumusMatematika.Turunan(new int[] { 1, 4, -12, 9 }));
            Console.WriteLine("Integral({4, 6, -12, 9}): " + RumusMatematika.Integral(new int[] { 4, 6, -12, 9 }));
        }
    }
    ```
     <br>


2. Output :
    ![TP_SC_SS](/10_Library_Construction/img/outputjurnal.png)
    <br>

3. Penjelasan Program :
    Program yang dibuat merupakan implementasi pustaka matematika dalam bentuk Class Library bernama MatematikaLibraries yang berisi fungsi-fungsi untuk menghitung FPB, KPK, turunan, dan integral dari suatu persamaan. Fungsi FPB dan KPK menggunakan logika aritmetika dasar, sedangkan fungsi Turunan dan Integral mengolah array koefisien untuk menghasilkan bentuk polinomial hasil turunan maupun integral dengan format notasi umum seperti 3x2 + 8x - 12 dan x4 + 2x3 - 6x2 + 9x + C. Semua fungsi tersebut dipanggil dari aplikasi Console App untuk menampilkan hasil ke layar. Program disusun secara modular, di mana logika matematika dipisah dari antarmuka utama. Pendekatan ini memudahkan pemeliharaan dan pengujian fungsi secara terpisah.
    <br>

