using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul5_2211104027
{
    class Program
    {
        static void Main()
        {
            // Memanggil metode generic SapaUser
            HaloGeneric.SapaUser("Fauzan");

            // Menggunakan kelas DataGeneric
            DataGeneric<string> dataGeneric = new DataGeneric<string>("NIM : 2211104027");
            dataGeneric.PrintData();
        }
    }

    // HaloGeneric.cs
    class HaloGeneric
    {
        public static void SapaUser<T>(T user)
        {
            Console.WriteLine($"Halo user {user}");
        }
    }

    // DataGeneric.cs
    class DataGeneric<T>
    {
        private T data;

        public DataGeneric(T data)
        {
            this.data = data;
        }

        public void PrintData()
        {
            Console.WriteLine($"Data yang tersimpan adalah {data}");
        }
    }

}
