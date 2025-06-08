<div align="center">
TUGAS PENDAHULUAN <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL XIV <br>
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
## Tugas Pendahuluan Modul 14
---

### 1. MEMBUAT PROJECT MODUL

Saya mengambil referensi dari Modul 5: 

![TP_SC_SS](/14_Clean_Code/img/awal-tp.png)
    <br>

### 2. REFACTORING DENGAN STANDAR CODE

#### a. Tujuan
Menyesuaikan struktur, penamaan, dan gaya penulisan kode agar mengikuti standar penulisan yang rapi dan profesional sesuai .NET C# Coding Convention.

#### b. Naming Convention

##### i. Variable / Property / Attribute

- Sebelumnya (kurang tepat):

    ```csharp
    int angka1;
    List<T> storedData;
    ```
- Setelah refactor (sesuai .NET):

    ```csharp
    int firstNumber;
    private List<T> _storedData;
    ```

- Penjelasan:
    - Gunakan camelCase untuk parameter dan variabel lokal.
    - Gunakan PascalCase untuk public property.
    - Gunakan prefix _ untuk private field (misalnya _storedData).

##### ii. Method / Function / Procedure

- Sebelumnya:
    ```csharp
    public T JumlahTigaAngka<T>(T a, T b, T c) { ... }
    ```
- Setelah refactor:

    ```csharp
    public T SumThreeNumbers<T>(T a, T b, T c) { ... }
    ```

- Penjelasan:
    - Gunakan PascalCase untuk nama method (awali huruf kapital).
    - Gunakan nama method deskriptif dan dalam Bahasa Inggris.

#### c. White Space dan Indentation

- Sebelumnya (rapat, susah dibaca):
    ```csharp
    public void AddNewData(T data){
    storedData.Add(data);
    inputDates.Add(DateTime.UtcNow);}
    ```

- Setelah refactor:

    ```csharp
    public void AddNewData(T data)
    {
        _storedData.Add(data);
        _inputDates.Add(DateTime.UtcNow);
    }
    ```

- Penjelasan:
    - Gunakan 4 spasi untuk indentasi.
    - Tambahkan jarak antar blok kode untuk meningkatkan keterbacaan.
    - Blok {} selalu diletakkan di baris baru.

#### d. Variable / Attribute Declarations

- Sebelumnya:
    ```csharp
    dynamic tempA = a;
    dynamic tempB = b;
    ```

- Setelah refactor:
    ```csharp
    dynamic x = a, y = b, z = c;
    ```

- Penjelasan:
    - Gunakan deklarasi ringkas dan efisien.
    - Gunakan var jika tipe dapat diketahui, tapi hindari berlebihan.

#### e. Comments

- Sebelumnya:
Kode tanpa penjelasan sama sekali.
<br>

- Setelah refactor (ditambahkan komentar):

    ```csharp
    // Melakukan penjumlahan terhadap tiga angka bertipe generic
    public T SumThreeNumbers<T>(T a, T b, T c)
    ```
    ```csharp
    // Menyimpan data beserta waktu inputnya
    public void AddNewData(T data)
    ```

- Penjelasan:
    - Tambahkan komentar pendek sebelum method atau logika penting.
    - Gunakan komentar untuk menjelaskan tujuan dari bagian kode, bukan isi teknis per baris.

### 3. Hasil Refactoring Code

- Source Code
    ```csharp
    using System;
    using System.Collections.Generic;

    namespace TpModul14_2211104027
    {
        public class Calculator
        {
            public T SumThreeNumbers<T>(T a, T b, T c)
            {
                dynamic x = a, y = b, z = c;
                return (T)(x + y + z);
            }
        }

        public class SimpleDatabase<T>
        {
            private readonly List<T> _storedData;
            private readonly List<DateTime> _inputDates;

            public SimpleDatabase()
            {
                _storedData = new List<T>();
                _inputDates = new List<DateTime>();
            }

            public void AddNewData(T data)
            {
                _storedData.Add(data);
                _inputDates.Add(DateTime.UtcNow);
            }

            public void PrintAllData()
            {
                for (int i = 0; i < _storedData.Count; i++)
                {
                    Console.WriteLine($"Data {i + 1}: {_storedData[i]}, saved at UTC: {_inputDates[i]}");
                }
            }
        }

        public class Program
        {
            public static void Main()
            {
                // Implementasi Generic Method
                var calculator = new Calculator();
                int a = 22, b = 40, c = 27;
                int result = calculator.SumThreeNumbers(a, b, c);
                Console.WriteLine($"Sum Result: {result}");

                // Implementasi Generic Class
                var database = new SimpleDatabase<int>();
                database.AddNewData(a);
                database.AddNewData(b);
                database.AddNewData(c);
                database.PrintAllData();
            }
        }
    }
    ```

- Tampilan di Visual Studio 2022
![TP_SC_SS](/14_Clean_Code/img/output-vs.png)
    <br>

- Output
![TP_SC_SS](/14_Clean_Code/img/output-tp1.png)
    <br>