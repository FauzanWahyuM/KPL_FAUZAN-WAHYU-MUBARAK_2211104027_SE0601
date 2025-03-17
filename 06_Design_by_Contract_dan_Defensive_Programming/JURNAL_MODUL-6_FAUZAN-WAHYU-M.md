<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL VI <br>
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

1. MENAMBAHKAN KODE AWAL SAYATUBEVIDEO 
Buatlah dua file class baru yang berisi detail sebagai berikut: 
    A. Class bernama “SayaTubeUser” dan “SayaTubeVideo”. 
    B. Struktur dari class tersebut dapat dilihat pada gambar di bawah ini: 
    ![TP_SC_SS](/06_Design_by_Contract_dan_Defensive_Programming/img/Soal.png)
    C. Konstruktor pada kelas `“SayaTubeVideo”` menerima dua parameter yaitu judul video. Pada saat objek dibuat, nilai `“id”` akan di-generate secara random sepanjang 5 digit (bisa coba gunakan class Random bawaan bahasa pemrograman yang digunakan) dan nilai `“playCount”` akan diisi dengan 0. 
    D. Pada class `“SayaTubeVideo”`, tambahkan sebuah method dengan nama `“IncreasePlayCount”` yang menerima jumlah angka yang akan ditambahkan ke `“playCount”`. 
    E. Class `“SayaTubeVideo”` juga mempunyai method `“PrintVideoDetails”` yang melakukan print baik dari id, title dan playCount dengan format bebas. 
    F. Konstruktor kelas `“SayaTubeUser”` mirip dengan kelas `“SayaTubeVideo”`, bedanya adalah property Username dan list kosong dari uploadedVideos. 
    G. Pada kelas `“SayaTubeUser”`, terdapat method `GetTotalVideoPlayCount()` yang mengembalikan jumlah playCount dari semua video yang ada di list uploadedVideos. Selain itu, juga terdapat method AddVideo yang dapat menambahkan elemen baru ke list uploadedVideos. 
    H. Method terakhir di kelas tersebut adalah `PrintAllVideoPlaycount()` yang melakukan print terhadap semua judul video yang ditambahkan dengan format: 
    `“User: <username>”` 
    `“Video 1 judul: <judul_video1>”` 
    `“Video 2 judul: <judul_video2>”`
    dst. 
    I. Panggil semua method yang dibuat dari kedua kelas pada fungsi/method utama dengan membuat. Gunakan nama panggilan praktikan untuk username dan judul video dengan format “Review Film `<judul_film>` oleh `<nama_praktikan>`”. Tambahkan minimal 10 judul film yang menurut praktikan bagus untuk ditonton.

2.  MENAMBAHKAN IMPLEMENTASI DESIGN BY CONTRACT 
Pada class yang dibuat sebelumnya tambahkan implementasi design by contract dengan: 
    A. Precondition sebagai berikut ini: 
        i. Judul video memiliki panjang maksimal 200 karakter.
        ii. Judul video tidak berupa null.
        iii. Input penambahan play count maksimal 25.000.000 per panggilan method-nya 
        iv. Input play count tidak berupa bilangan negatif.
        v. Nama username memiliki panjang maksimal 100 karakter.
        vi. Nama username tidak berupa null.
        vii. Video yang ditambahkan tidak berupa null.
        viii. Video yang ditambahkan punya playCount yang kurang dari bilangan integer maksimum.
    B. Exception (tambahkan juga blok try-catch sehingga program tidak berhenti): 
        i. Dengan menggunakan “checked” keyword pada C# atau operator sepadan pada bahasa pemrograman lain, pastikan jumlah penambahan play count tidak melebihi batas tertinggi integer (overflow). 
    C. Postcondition sebagai berikut: 
        i. Jumlah video maksimal yang di-print adalah 8 pada method PrintAllVideoPlaycount() 
    D. Panggil object dari class SayaTubeVideo dan SayaTubeUser yang menguji prekondisi, exception dan postcondition. (Catatan: untuk exception boleh digunakan for loop sehingga proses overflow dapat dipercepat).

---
## Jawaban
---

1. Source Code
    ```c#
    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;
        
        public SayaTubeVideo(string title)
        {
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }
        
        public void IncreasePlayCount(int count)
        {
            playCount += count;
        }
        
        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}\n");
        }
        
        public int GetPlayCount()
        {
            return playCount;
        }
        
        public string GetTitle()
        {
            return title;
        }
    }

    class SayaTubeUser
    {
        private int id;
        private string Username;
        private List<SayaTubeVideo> uploadedVideos;
        
        public SayaTubeUser(string username)
        {
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }
        
        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }
        
        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }
        
        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            SayaTubeUser user = new SayaTubeUser("Fauzan Wahyu M");

            List<string> filmTitles = new List<string>
            {
                "Review Film Black Panther oleh Fauzan Wahyu M",
                "Review Film Avengers: Endgame oleh Fauzan Wahyu M",
                "Review Film Iron Man oleh Fauzan Wahyu M",
                "Review Film Thor: Ragnarok oleh Fauzan Wahyu M",
                "Review Film Spider-Man: No Way Home oleh Fauzan Wahyu M",
                "Review Film Spider-Man: Homecoming oleh Fauzan Wahyu M",
                "Review Film Guardians of the Galaxy oleh Fauzan Wahyu M",
                "Review Film Spider-Man: Far from Home oleh Fauzan Wahyu M",
                "Review Film Marvel's the Avengers oleh Fauzan Wahyu M",
                "Review Film Shang-Chi and the Legend of the Ten Rings oleh Fauzan Wahyu M"
            };
            
            foreach (var title in filmTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
                video.IncreasePlayCount(new Random().Next(1000, 5000));
            }
            
            user.PrintAllVideoPlaycount();
            Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");
        }
    ```
    <br>

    Output :

    <br>

    Penjelasan Program : 

    <br>

2. Source Code 
    ```c#
    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;
        
        public SayaTubeVideo(string title)
        {
            if (title == null) throw new ArgumentNullException("Title tidak boleh null.");
            if (title.Length > 200) throw new ArgumentException("Title tidak boleh lebih dari 200 karakter.");
            
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }
        
        public void IncreasePlayCount(int count)
        {
            if (count < 0) throw new ArgumentException("Play count tidak boleh negatif.");
            if (count > 25000000) throw new ArgumentException("Play count maksimal 25.000.000 per panggilan.");
            
            checked
            {
                try
                {
                    playCount += count;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Play count melebihi batas maksimum integer.");
                }
            }
        }
        
        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}\n");
        }
        
        public int GetPlayCount()
        {
            return playCount;
        }
        
        public string GetTitle()
        {
            return title;
        }
    }

    class SayaTubeUser
    {
        private int id;
        private string Username;
        private List<SayaTubeVideo> uploadedVideos;
        
        public SayaTubeUser(string username)
        {
            if (username == null) throw new ArgumentNullException("Username tidak boleh null.");
            if (username.Length > 100) throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.");
            
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }
        
        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null) throw new ArgumentNullException("Video tidak boleh null.");
            if (video.GetPlayCount() >= int.MaxValue) throw new ArgumentException("Play count video terlalu besar.");
            
            uploadedVideos.Add(video);
        }
        
        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }
        
        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                SayaTubeUser user = new SayaTubeUser("Fauzan Wahyu M");

                List<string> filmTitles = new List<string>
                {
                    "Review Film Black Panther oleh Fauzan Wahyu M",
                    "Review Film Avengers: Endgame oleh Fauzan Wahyu M",
                    "Review Film Iron Man oleh Fauzan Wahyu M",
                    "Review Film Thor: Ragnarok oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: No Way Home oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: Homecoming oleh Fauzan Wahyu M",
                    "Review Film Guardians of the Galaxy oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: Far from Home oleh Fauzan Wahyu M",
                    "Review Film Marvel's the Avengers oleh Fauzan Wahyu M",
                    "Review Film Shang-Chi and the Legend of the Ten Rings oleh Fauzan Wahyu M"
                };
                
                foreach (var title in filmTitles)
                {
                    SayaTubeVideo video = new SayaTubeVideo(title);
                    user.AddVideo(video);
                    try
                    {
                        video.IncreasePlayCount(25000000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
                
                user.PrintAllVideoPlaycount();
                Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");
                
                // Uji overflow
                SayaTubeVideo testVideo = new SayaTubeVideo("Test Overflow Video");
                try
                {
                    for (int i = 0; i < 100; i++)
                    {
                        testVideo.IncreasePlayCount(int.MaxValue / 10);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unhandled Exception: {e.Message}");
            }
        }
    ```
    <br>

    Output :

    <br>

    Penjelasan Program :
    
    <br>