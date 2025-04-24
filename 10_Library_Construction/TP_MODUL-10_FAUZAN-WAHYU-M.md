<div align="center">
TUGAS PENDAHULUAN <br>
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
## Tugas Pendahuluan Modul 10
---

1. Source Code 

    - CLASS LIBRARY (Project: LibraryAljabar (Aljabar.cs)):

        ```c#
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

        namespace LibraryAljabar
        {
            public class Aljabar
            {
                public static double[] AkarPersamaanKuadrat(double[] persamaan)
                {
                    double a = persamaan[0];
                    double b = persamaan[1];
                    double c = persamaan[2];

                    double diskriminan = b * b - 4 * a * c;

                    if (diskriminan < 0)
                    {
                        throw new Exception("Persamaan tidak memiliki akar real");
                    }

                    double akar1 = (-b + Math.Sqrt(diskriminan)) / (2 * a);
                    double akar2 = (-b - Math.Sqrt(diskriminan)) / (2 * a);

                    return new double[] { akar1, akar2 };
                }

                public static double[] HasilKuadrat(double[] persamaan)
                {
                    double a = persamaan[0];
                    double b = persamaan[1];

                    double a2 = a * a;
                    double _2ab = 2 * a * b;
                    double b2 = b * b;

                    return new double[] { a2, _2ab, b2 };
                }
            }
        }
        ```
        <br>

    - CLASS LIBRARY (Project: tp10_aljabar (Program.cs)):

        ```c#
        using LibraryAljabar;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

        namespace tp10_aljabar
        {
            internal class Program
            {
                static void Main(string[] args)
                {
                    double[] persamaan1 = { 1, -3, -10 };
                    double[] akar = Aljabar.AkarPersamaanKuadrat(persamaan1);
                    Console.WriteLine("Akar persamaan x² - 3x - 10 = 0 adalah:");
                    Console.WriteLine($"x1 = {akar[0]}, x2 = {akar[1]}");
                    Console.WriteLine();

                    double[] persamaan2 = { 2, -3 };
                    double[] hasilKuadrat = Aljabar.HasilKuadrat(persamaan2);
                    Console.WriteLine("Hasil kuadrat dari (2x - 3) adalah:");
                    Console.WriteLine($"{hasilKuadrat[0]}x² + {hasilKuadrat[1]}x + {hasilKuadrat[2]}");
                }
            }
        }
        ```
        <br>


2. Output :
    ![TP_SC_SS](/10_Library_Construction/img/outputTP.png)
    <br>



3. Penjelasan Program :
    - LibraryAljabar:
        1. AkarPersamaanKuadrat(double[] persamaan)
            - Menghitung akar-akar dari persamaan kuadrat bentuk ax² + bx + c = 0.
            - Input berupa array double[] dengan tiga elemen: a, b, dan c.
            - Mengembalikan dua akar real jika diskriminan (b² - 4ac) ≥ 0, dan melempar Exception jika akar tidak real.
        2. HasilKuadrat(double[] persamaan)
            - Menghitung hasil kuadrat dari ekspresi (ax + b)².
            - Input berupa array double[] dengan dua elemen: a dan b.
            - Output adalah koefisien a², 2ab, dan b² untuk membentuk bentuk kuadrat sempurna.
    - tp10_aljabar:
    Program ini menggunakan library LibraryAljabar:
        1. Menghitung akar dari persamaan x² - 3x - 10 = 0 menggunakan fungsi AkarPersamaanKuadrat.
        2. Menghitung kuadrat dari (2x - 3) menggunakan fungsi HasilKuadrat.
    <br>