using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSifreOlusturma
{
    internal class Program
    {
        static Random r = new Random();

        static void Menu()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("\tŞifre Oluşturma Programı");
            Console.WriteLine("***********************************************");

        }
        static string SifreOlusturma()
        {
            Console.Write("Kaç Karakterli Şifre Oluşturmak istersiniz: ");
            if (!int.TryParse(Console.ReadLine(), out int uzunluk) || uzunluk < 1)
            {
                Console.WriteLine("Geçersiz şifre uzunluğu girdiniz.");
                return "";
            }

            Console.Write("Kaç Tane Büyük Harf Olacak: ");
            if (!int.TryParse(Console.ReadLine(), out int buyukHarf) || buyukHarf < 0)
            {
                Console.WriteLine("Geçersiz büyük harf sayısı girdiniz.");
                return "";
            }

            Console.Write("Kaç Tane Küçük Harf Olacak: ");
            if (!int.TryParse(Console.ReadLine(), out int kucukHarf) || kucukHarf < 0)
            {
                Console.WriteLine("Geçersiz küçük harf sayısı girdiniz.");
                return "";
            }

            Console.Write("Kaç Tane Rakam Olacak: ");
            if (!int.TryParse(Console.ReadLine(), out int rakam) || rakam < 0)
            {
                Console.WriteLine("Geçersiz rakam sayısı girdiniz.");
                return "";
            }

            Console.Write("Kaç Tane Sembol Olacak: ");
            if (!int.TryParse(Console.ReadLine(), out int ozel) || ozel < 0)
            {
                Console.WriteLine("Geçersiz sembol sayısı girdiniz.");
                return "";
            }

            if (buyukHarf + kucukHarf + rakam + ozel > uzunluk)
            {
                Console.WriteLine("Toplam karakter sayısı şifre uzunluğundan fazla olamaz.");
                return "Fazla Giriş";
            }

            List<char> sifre = new List<char>();

            Random r = new Random();

            for (int i = 0; i < buyukHarf; i++)
            {
                sifre.Add((char)r.Next(65, 91));
            }

            for (int i = 0; i < kucukHarf; i++)
            {
                sifre.Add((char)r.Next(97, 123));
            }

            for (int i = 0; i < rakam; i++)
            {
                sifre.Add((char)r.Next(48, 58));
            }

            for (int i = 0; i < ozel; i++)
            {
                sifre.Add((char)r.Next(33, 48));
            }

            while (sifre.Count < uzunluk)
            {
                sifre.Add((char)r.Next(97, 123));
            }

            sifre = sifre.OrderBy(x => r.Next()).ToList(); //Linq aracılığı ile karıştırma

            //Char olan Listeyi bu şekilde String Tür olan bir listeye çeviriyoruz.
            return new string(sifre.ToArray());
        }

        static void Main(string[] args)
        {
            Menu();
            string sifre = SifreOlusturma();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Oluşturulan Şifre: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sifre);
                System.Threading.Thread.Sleep(500); // 500 milisaniye bekler (yarım saniye)
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Oluşturulan Şifre: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(sifre);
                System.Threading.Thread.Sleep(500);


            } while (true);
        }

    }
}
