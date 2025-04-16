<div align="center">
JURNAL <br>
KONSTRUKSI PERANGKAT LUNAK <br>
<br>
MODUL VIII <br>
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
## Jurnal Modul 8
---

1. Source Code

Runtime Configuration (Program.cs):

![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/SCJurnal.png)
<br>

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_2211104027
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          BANK TRANSFER SERVICE         ");
            Console.WriteLine("========================================");

            // Load config
            BankTransferConfig config = new BankTransferConfig();

            // Menampilkan pilihan bahasa
            Console.WriteLine("\nSelect Language:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Bahasa Indonesia");
            Console.Write("Enter your choice [Press Enter to use default: " + (config.lang == "id" ? "Bahasa Indonesia" : "English") + "]: ");

            string langChoice = Console.ReadLine().Trim();
            if (langChoice == "1")
            {
                config.lang = "en";
            }
            else if (langChoice == "2")
            {
                config.lang = "id";
            }
            // Else: use default from JSON config

            Console.WriteLine();

            // Input nominal transfer
            if (config.lang == "en")
                Console.Write("Please insert the amount of money to transfer: ");
            else
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");

            int amount;
            while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                if (config.lang == "en")
                    Console.Write("Invalid input. Please enter a positive number: ");
                else
                    Console.Write("Input tidak valid. Masukkan angka yang benar: ");
            }

            // Hitung biaya
            int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
            int total = amount + fee;

            Console.WriteLine();
            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee  : " + fee);
                Console.WriteLine("Total amount  : " + total);
            }
            else
            {
                Console.WriteLine("Biaya transfer: " + fee);
                Console.WriteLine("Total biaya   : " + total);
            }

            // Pilih metode transfer
            Console.WriteLine();
            if (config.lang == "en")
                Console.WriteLine("Select transfer method:");
            else
                Console.WriteLine("Pilih metode transfer:");

            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

            int methodIndex = 0;
            while (true)
            {
                Console.Write(config.lang == "en" ? "Enter your choice (1-" + config.methods.Count + "): " : "Masukkan pilihan Anda (1-" + config.methods.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out methodIndex) && methodIndex >= 1 && methodIndex <= config.methods.Count)
                {
                    break;
                }

                if (config.lang == "en")
                    Console.WriteLine("Invalid choice. Please try again.");
                else
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }

            // Konfirmasi
            Console.WriteLine();
            string confirmKeyword = config.lang == "en" ? config.confirmation.en : config.confirmation.id;
            string confirmMessage = config.lang == "en"
                ? $"Please type \"{confirmKeyword}\" to confirm the transaction: "
                : $"Ketik \"{confirmKeyword}\" untuk mengkonfirmasi transaksi: ";
            Console.Write(confirmMessage);
            string confirmationInput = Console.ReadLine().Trim();

            bool isConfirmed = confirmationInput.Equals(confirmKeyword, StringComparison.OrdinalIgnoreCase);

            Console.WriteLine();
            if (isConfirmed)
            {
                Console.WriteLine(config.lang == "en" ? "The transfer is completed." : "Proses transfer berhasil.");
            }
            else
            {
                Console.WriteLine(config.lang == "en" ? "Transfer is cancelled." : "Transfer dibatalkan.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
```
<br>

Runtime Configuration (BankTransferConfig.cs):

![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/SCJurnal2.png)
<br>

```c#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_2211104027
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        private const string configFile = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);

                // Deserialize ke struct/temp object, bukan class ini langsung
                var loadedConfig = JsonSerializer.Deserialize<BankTransferConfigDTO>(json);

                lang = loadedConfig.lang;
                transfer = loadedConfig.transfer;
                methods = loadedConfig.methods;
                confirmation = loadedConfig.confirmation;
            }
            else
            {
                // Default config
                lang = "en";
                transfer = new Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                };
                methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
                confirmation = new Confirmation { en = "yes", id = "ya" };

                SaveDefaultConfig();
            }
        }

        private void SaveDefaultConfig()
        {
            var dto = new BankTransferConfigDTO
            {
                lang = this.lang,
                transfer = this.transfer,
                methods = this.methods,
                confirmation = this.confirmation
            };

            string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);
        }

        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        // DTO class untuk parsing JSON agar tidak stack overflow
        private class BankTransferConfigDTO
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
        }
    }
}
```
<br>

bank_transfer_config.json :
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/SCJurnal3.png)
<br>

```json
{
  "lang": "en",
  "transfer": {
    "threshold": 25000000,
    "low_fee": 6500,
    "high_fee": 15000
  },
  "methods": [ "RTO (real-time)", "SKN", "RTGS", "BI FAST" ],
  "confirmation": {
    "en": "yes",
    "id": "ya"
  }
}
```
<br>


Output :
Indonesia : 
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/indo.png)
<br>

Inggris : 
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/eng.png)
<br>

Failed :
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/failed.png)
<br>

Penjelasan Program :
Saya mengerjakan tugas yang beroutput simulasi transfer bank berbasis konfigurasi runtime, di mana pengaturan seperti bahasa, biaya transfer, dan metode transfer dibaca dari file bank_transfer_config.json. Program memanfaatkan teknik Runtime Configuration melalui class BankTransferConfig, yang akan membaca file konfigurasi tersebut atau menggunakan nilai default jika file belum ada. Saat dijalankan, program menyesuaikan seluruh tampilan teks (seperti instruksi, biaya transfer, metode transfer, dan konfirmasi) berdasarkan bahasa yang ditentukan di konfigurasi (en atau id). Program juga secara dinamis menentukan biaya transfer tergantung dari jumlah yang dimasukkan, apakah di bawah atau di atas ambang (threshold) yang telah ditentukan. Pengguna kemudian memilih metode transfer dan harus mengetik kata konfirmasi sesuai bahasa untuk menyelesaikan transaksi. Jika input konfirmasi sesuai, maka transaksi dianggap berhasil; jika tidak, transaksi dibatalkan.
<br>

