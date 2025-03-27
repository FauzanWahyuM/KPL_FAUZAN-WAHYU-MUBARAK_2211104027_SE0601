<div align="center">
TUGAS PENDAHULUAN <br>
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
## Tugas Pendahuluan Modul 8
---

1. Source Code 

RUNTIME CONFIGURATION :

![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/SC.png)
<br>

```c#
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace tpmodul8_2211104027
{
    class CovidConfig
    {
        private const string ConfigFile = "covid_config.json";
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDemam { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig()
        {
            if (File.Exists(ConfigFile))
            {
                LoadConfig();
            }
            else
            {
                SaveConfig();
            }
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigFile))
                {
                    string json = File.ReadAllText(ConfigFile);
                    var config = JsonConvert.DeserializeObject<CovidConfig>(json);

                    if (config != null)
                    {
                        SatuanSuhu = config.SatuanSuhu;
                        BatasHariDemam = config.BatasHariDemam;
                        PesanDitolak = config.PesanDitolak;
                        PesanDiterima = config.PesanDiterima;
                    }
                }
                else
                {
                    SaveConfig();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat membaca konfigurasi: {ex.Message}");
            }
        }


        public void SaveConfig()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saat menyimpan konfigurasi: " + ex.Message);
            }
        }

        public void UbahSatuan()
        {
            SatuanSuhu = (SatuanSuhu == "celcius") ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }

    class Program
    {
        static void Main()
        {
            CovidConfig config = new CovidConfig();

            // Tambahkan opsi mengubah satuan suhu
            Console.WriteLine("Apakah Anda ingin mengubah satuan suhu? (y/n)");
            string pilihan = Console.ReadLine().ToLower();

            if (pilihan == "y")
            {
                config.UbahSatuan();
                Console.WriteLine($"Satuan suhu telah diubah ke {config.SatuanSuhu}.\n");
            }

            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hariDemam = Convert.ToInt32(Console.ReadLine());

            // Debugging Info
            Console.WriteLine("\n--- Info ---");
            Console.WriteLine($"Satuan Suhu: {config.SatuanSuhu}");
            Console.WriteLine($"Input Suhu: {suhu}");
            Console.WriteLine($"Batas Hari Demam: {config.BatasHariDemam}");
            Console.WriteLine($"Input Hari Demam: {hariDemam}\n");

            bool suhuValid = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                              (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);

            bool hariValid = hariDemam <= config.BatasHariDemam;

            Console.WriteLine("\nOUTPUT: " + (suhuValid && hariValid ? config.PesanDiterima : config.PesanDitolak));

          
            HapusKonfigurasi();
        }

        static void HapusKonfigurasi()
        {
            string configFile = "covid_config.json";
            if (File.Exists(configFile))
            {
                try
                {
                    File.Delete(configFile);
                    Console.WriteLine("\nKonfigurasi dihapus sebelum keluar.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nGagal menghapus konfigurasi: " + ex.Message);
                }
            }
        }
    }
}
```
<br>

Output :

Output PesanDiterima : 
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/Output=1.png)
<br>

Output PesanDitolak : 
![TP_SC_SS](/08_Runtime_Configuration_dan_Internationalization/img/Output!1.png)
<br>

Penjelasan Program :
1. Program ini mengelola konfigurasi COVID-19 menggunakan file **JSON** untuk menyimpan **satuan suhu**, **batas hari demam**, serta **pesan diterima/ditolak**.  
2. Saat program dijalankan, pengguna dapat memilih untuk **mengubah satuan suhu** antara **Celsius** dan **Fahrenheit**, yang kemudian disimpan dalam file **`covid_config.json`**.  
3. Program meminta input suhu tubuh dan jumlah hari sejak terakhir mengalami demam, lalu mengevaluasi apakah pengguna **diizinkan masuk atau tidak** berdasarkan konfigurasi yang tersimpan.  
4. Setelah program selesai, file **`covid_config.json`** akan **dihapus secara otomatis** untuk memastikan konfigurasi tidak tersimpan setelah aplikasi ditutup.  
5. Program menggunakan **Newtonsoft.Json** untuk membaca dan menulis file JSON, serta menangani error dengan **try-catch** saat membaca atau menghapus file.
<br>
