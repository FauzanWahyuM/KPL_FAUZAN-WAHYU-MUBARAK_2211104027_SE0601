<div align="center">
JURNAL <br>
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
## Tugas Jurnal
---

1. MENAMBAHKAN METHOD DENGAN GENERIC 
Tanpa membuat file baru (gunakan file yang dibuat saat membuat project): 
    A. Buatlah sebuah class bernama “Penjumlahan”. 
    B. Pada class tersebut, tambahkan sebuah method dengan nama “JumlahTigaAngka” yang memiliki tiga parameter generic yang sama yaitu “T”  
    C. Method tersebut dapat melakukan penjumalahan dari tiga input/argument yang diberikan pada method tersebut.  
    D. Hint: gunakan variable sementara dengan tipe data dynamic untuk memungkinkan operasi matematis misalnya penjumlahan. 
    E. Panggil method tersebut pada fungsi/method utama dengan tiga input angka yaitu 2-digit dari NIM. Misalnya NIM 12345678, maka tiga input angka yaitu “12”, “34” dan “56” dengan tipe data sebagai berikut: 
    - NIM berakhiran 1 atau 2: tipe data input float 
    - NIM berakhiran 3, 4 atau 5: tipe data input double 
    - NIM berakhiran 6, 7 atau 8: tipe data input int 
    - NIM berakhiran 9 atau 0: tipe data input long 

2. MENAMBAHKAN METHOD DENGAN GENERIC 
Tanpa membuat file baru (gunakan file yang dibuat saat membuat project dan pastikan branch aktif adalah pada branch implementasi-generic-class): 
    A. Buatlah sebuah class bernama “SimpleDataBase” dengan mengikuti class model yang ditunjukkan pada gambar/tabel di bawah ini.
    | SimpleDataBase            |
    |---------------------------|
    | - storedData: List<T>     |
    | - inputDates: List<Date>  |
    | + SimpleDataBase()        |
    | + AddNewData(T)           |
    | + PrintAllData(): void    |

    B. Class tersebut memiliki dua property yaitu:  
    - Property “storedData” yang merupakan suatu List (struktur data bawaan/default) yang berisi data bertipe generic “T”. 
    - Property “inputDates” yang bertipe List<Date> (atau tipe data List<DateTime> di C#) yang akan list dari waktu input. 

    C. Class tersebut juga memiliki beberapa method yaitu:  
    - Konstruktor SimpleDataBase() yang akan membuat property “storedData” berisi List kosong. 
    - Method AddNewData(T) yang akan menambahkan data baru bertipe T ke dalam list “storedData” dan waktu saat itu (Now) ke dalam list “inputDates”. 
    - Method PrintAllData() yang akan memberikan output console berupa teks yang menampilkan seluruh data yang tersimpan pada “storedData” dan “inputDates”, contohnya: 
        - Data 1 berisi: 12, yang disimpan pada waktu UTC: 3/10/2022 5:32:01 AM 
        - Data 2 berisi: 34, yang disimpan pada waktu UTC: 3/10/2022 5:32:02 AM 
        - Data 2 berisi: 56, yang disimpan pada waktu UTC: 3/10/2022 5:32:02 AM 

    D. Panggil method PrintAllData() pada fungsi/method utama setelah menambahkan tiga data yang berisi dan bertipe dua-digit NIM seperti pada bagian 4E. 

---
## Jawaban
---

1. Source Code 
    ```c#
    
    class Penjumlahan
    {
        public T JumlahTigaAngka<T>(T a, T b, T c)
        {
            dynamic tempA = a;
            dynamic tempB = b;
            dynamic tempC = c;
            return (T)(tempA + tempB + tempC);
        }
    }



    class Program
    {
        static void Main()
        {
            // Tugas No. 4 - Implementasi Generic Method
            Penjumlahan penjumlahan = new Penjumlahan();
            int angka1 = 22;
            int angka2 = 40;
            int angka3 = 27;
            int hasil = penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);
            Console.WriteLine("Hasil Penjumlahan: " + hasil);

        }
    }
    ```
    <br>

    Output : 
    ![TP_SC_SS](/05_Generics/img/Jurnal1.png)
    <br>

    Penjelasan Program :
    Program di atas mendefinisikan kelas `Penjumlahan` yang memiliki metode generik `JumlahTigaAngka<T>`, yang dapat menjumlahkan tiga nilai dengan tipe data yang sama menggunakan `dynamic`. Dalam metode ini, tiga parameter generik dikonversi ke `dynamic` agar dapat dilakukan operasi penjumlahan, lalu hasilnya dikembalikan dalam tipe data `T`. Di dalam kelas `Program`, objek `Penjumlahan` dibuat, dan metode `JumlahTigaAngka` dipanggil dengan tiga angka bertipe `int` (22, 40, dan 27), sesuai dengan aturan NIM berakhiran 7 yang menggunakan `int`. Hasil penjumlahan ketiga angka tersebut ditampilkan di konsol menggunakan `Console.WriteLine()`. Program ini menunjukkan bagaimana metode generik dapat digunakan untuk menangani berbagai tipe data dalam operasi matematika tanpa mendefinisikan metode tambahan untuk setiap tipe data.
    <br>

2. Source Code

    ```c#
     class Penjumlahan
    {
        public T JumlahTigaAngka<T>(T a, T b, T c)
        {
            dynamic tempA = a;
            dynamic tempB = b;
            dynamic tempC = c;
            return (T)(tempA + tempB + tempC);
        }
    }

    class SimpleDataBase<T>
    {
        private List<T> storedData;
        private List<DateTime> inputDates;

        public SimpleDataBase()
        {
            storedData = new List<T>();
            inputDates = new List<DateTime>();
        }

        public void AddNewData(T data)
        {
            storedData.Add(data);
            inputDates.Add(DateTime.UtcNow);
        }

        public void PrintAllData()
        {
            for (int i = 0; i < storedData.Count; i++)
            {
                Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
            }
        }
    }


    class Program
    {
        static void Main()
        {
            // Tugas No. 4 - Implementasi Generic Method
            Penjumlahan penjumlahan = new Penjumlahan();
            int angka1 = 22;
            int angka2 = 40;
            int angka3 = 27;
            int hasil = penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);
            Console.WriteLine("Hasil Penjumlahan: " + hasil);

            // Implementasi database generik
            SimpleDataBase<int> database = new SimpleDataBase<int>();
            database.AddNewData(22);
            database.AddNewData(40);
            database.AddNewData(27);
            database.PrintAllData();
        }
    }
    ```
    <br>

    Output : 
    ![TP_SC_SS](/05_Generics/img/Jurnal2.png)
    <br>

    Penjelasan Program :
    Program di atas menggunakan konsep **generic method** dan **generic class** dalam C#. Kelas `Penjumlahan` memiliki metode generik `JumlahTigaAngka<T>`, yang menggunakan `dynamic` untuk menjumlahkan tiga angka dengan tipe data yang sama. Kelas `SimpleDataBase<T>` berfungsi sebagai penyimpanan data generik, menggunakan `List<T>` untuk menyimpan data dan `List<DateTime>` untuk mencatat waktu saat data dimasukkan. Di dalam `Main()`, program pertama-tama menjumlahkan tiga angka (22, 40, dan 27) menggunakan metode generik dan mencetak hasilnya. Setelah itu, angka-angka tersebut disimpan dalam objek `SimpleDataBase<int>`, dan kemudian ditampilkan beserta waktu penyimpanannya.
    <br>