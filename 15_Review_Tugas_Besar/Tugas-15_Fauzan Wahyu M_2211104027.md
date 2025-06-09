<div align="center">
TUGAS JURNAL    <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL XV <br>
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
## Tugas Jurnal Modul 15
---

### 1. MEMBUAT	PROJECT	MODUL

![Modul_SC_SS](/15_Review_Tugas_Besar/img/awal.png)
    <br>

### 2. PENGEMBANGAN	DENGAN	SECURE	CODING	PRACTICES

Dalam modul 15 ini saya menggunakan console app yang beroutput CLI (Command Line Interface) yang menerapkan secure code yang akan saya jelaskan dibawah ini:

#### a. Registrasi user dengan input username dan password

- Source Code

    ```csharp
    public void Register()
    {
        Console.Write("Masukkan username: ");
        string username = Console.ReadLine();

        if (!IsValidUsername(username))
        {
            Console.WriteLine("Username tidak valid. Hanya huruf dan panjang 4-20 karakter.");
            return;
        }

        Console.Write("Masukkan password: ");
        string password = Program.ReadPassword();

        if (!IsValidPassword(password, username))
        {
            Console.WriteLine("Password tidak valid. Panjang 8-20, harus ada simbol khusus (!@#$%^&*), dan tidak mengandung username.");
            return;
        }

        if (users.Any(u => u.Username == username))
        {
            Console.WriteLine("Username sudah terdaftar.");
            return;
        }

        users.Add(new User
        {
            Username = username,
            PasswordHash = HashPassword(password)
        });

        SaveUsers();
        Console.WriteLine("Registrasi berhasil!");
    }
    ```
    <br>

- Output
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-reg.png)
    <br>

- Penjelasan Program
Metode `Register()` digunakan untuk mendaftarkan pengguna baru ke sistem. Program meminta input username dan password dari pengguna, lalu memvalidasinya menggunakan metode `IsValidUsername()` dan `IsValidPassword()`. Jika username tidak sesuai kriteria (hanya huruf, 4–20 karakter) atau password tidak memenuhi aturan (8–20 karakter, mengandung simbol khusus, tidak mengandung username), maka proses akan dibatalkan. Selain itu, program juga memeriksa apakah username sudah terdaftar sebelumnya. Jika semua validasi berhasil, data pengguna akan disimpan ke file JSON melalui metode `SaveUsers()`, dan pesan keberhasilan ditampilkan.



#### b. Login user

- Source Code

    ```csharp
    public void Login()
    {
        Console.Write("Masukkan username: ");
        string username = Console.ReadLine();

        Console.Write("Masukkan password: ");
        string password = Program.ReadPassword();

        string hashed = HashPassword(password);

        if (users.Any(u => u.Username == username && u.PasswordHash == hashed))
            Console.WriteLine("Login berhasil!");
        else
            Console.WriteLine("Username atau password salah.");
    }
    ```
    <br>

- Output
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-log.png)
    <br>

- Penjelasan Program
Metode `Login()` digunakan untuk proses masuk (autentikasi) pengguna ke sistem. Program meminta input username dan password dari pengguna, kemudian mengenkripsi password menggunakan metode `HashPassword()`. Setelah itu, program mencocokkan username dan hash password tersebut dengan data yang tersimpan di list `users`. Jika ditemukan kecocokan, maka login dinyatakan berhasil. Jika tidak cocok, program akan menampilkan pesan bahwa username atau password salah.


#### c. Penyimpanan	data user pada file json

- Source Code
    - Untuk Menyimpan

        ```csharp
        private void SaveUsers()
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        ```
        <br>

    - Untuk Membaca

        ```csharp
        private readonly string filePath = "users.json";
        private List<User> users;

        public UserService()
        {
            users = LoadUsers();
        }

        private List<User> LoadUsers()
        {
            if (!File.Exists(filePath))
                return new List<User>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        ```
        <br>

- Output
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-json.png)
    <br>

- Penjelasan Program
Code ini digunakan untuk menyimpan dan membaca data pengguna dalam format file JSON. Metode SaveUsers() akan mengubah list users menjadi JSON menggunakan JsonSerializer, lalu menyimpannya ke file users.json. Sedangkan LoadUsers() digunakan untuk membaca file users.json, kemudian mengubah isinya kembali menjadi list objek User. Jika file tidak ditemukan, maka akan dikembalikan list kosong sebagai default. Fungsi LoadUsers() ini dipanggil dalam konstruktor UserService saat inisialisasi, agar data pengguna dapat langsung dimuat saat program dijalankan.

### 3. Penerapan Secure Coding

#### a. Input Validation (wajib mengimplementasikan salah satu, diizinkan lebih)

- Source Code
    - Validasi Username
        ```csharp
        private bool IsValidUsername(string username)
        {
            return username.Length >= 4 && username.Length <= 20 && Regex.IsMatch(username, @"^[a-zA-Z]+$");
        }
        ```
        <br>

    - Validasi Password
         ```csharp
        private bool IsValidPassword(string password, string username)
        {
            return password.Length >= 8 &&
                password.Length <= 20 &&
                Regex.IsMatch(password, @"[!@#$%^&*]") &&
                !password.Contains(username);
        }
        ```
        <br>
        
    - Uniqueness Check
         ```csharp
        if (users.Any(u => u.Username == username))
        {
            Console.WriteLine("Username sudah terdaftar.");
            return;
        }
        ```
        <br>
        
- Output
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-reg.png)
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-log.png)
    <br>

- Penjelasan Program
Dalam code ini digunakan untuk melakukan validasi input saat proses registrasi pengguna. Metode IsValidUsername() memastikan bahwa username hanya terdiri dari huruf dengan panjang antara 4 hingga 20 karakter. Metode IsValidPassword() memvalidasi password agar memiliki panjang 8–20 karakter, mengandung simbol khusus (!@#$%^&*), dan tidak mengandung username demi alasan keamanan. Selain itu, ada pengecekan keunikan username menggunakan users.Any(...) untuk memastikan bahwa username belum pernah didaftarkan sebelumnya. Validasi ini penting untuk menjaga konsistensi data dan mencegah kesalahan atau potensi keamanan.

#### b. Sistem mengenkripsi password dengan metode hash SHA256	

- Source Code
    ```csharp
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
    ```
    <br>

- Output
![Modul_SC_SS](/15_Review_Tugas_Besar/img/output-hash.png)
    <br>

- Penjelasan Program
Metode `HashPassword()` digunakan untuk mengamankan password dengan cara mengenkripsinya sebelum disimpan. Program menggunakan algoritma hash SHA-256 untuk mengubah password menjadi bentuk yang tidak bisa dibaca langsung. Password terlebih dahulu diubah menjadi byte menggunakan `Encoding.UTF8.GetBytes()`, lalu diproses oleh `sha256.ComputeHash()`. Hasil hash tersebut kemudian dikonversi menjadi string menggunakan `Convert.ToBase64String()` agar dapat disimpan dalam file JSON. Dengan cara ini, password asli tidak pernah disimpan, sehingga meningkatkan keamanan data pengguna.
