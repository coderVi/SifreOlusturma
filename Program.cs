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
                return "Geçersiz şifre uzunluğu girdiniz.";
            }

            Console.Write("Kaç Tane Büyük Harf Olacak: ");
            int.TryParse(Console.ReadLine(), out int buyukHarf);

            Console.Write("Kaç Tane Küçük Harf Olacak: ");
            int.TryParse(Console.ReadLine(), out int kucukHarf);

            Console.Write("Kaç Tane Rakam Olacak: ");
            int.TryParse(Console.ReadLine(), out int rakam);

            Console.Write("Kaç Tane Sembol Olacak: ");
            int.TryParse(Console.ReadLine(), out int ozel);

            if (buyukHarf + kucukHarf + rakam + ozel > uzunluk)
            {
                return "Toplam karakter sayısı şifre uzunluğundan fazla olamaz.";
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
                sifre.Add((char)r.Next(33, 123));
            }

            sifre = sifre.OrderBy(x => r.Next()).ToList(); //Linq aracılığı ile karıştırma

            //Char olan Listeyi bu şekilde String Tür olan bir listeye çeviriyoruz.
            return new string(sifre.ToArray());
        }

        static void Main(string[] args)
        {
            Menu();
            string sifre = SifreOlusturma();
            Console.Write("Oluşturulan Şifre: {0} " , sifre);
            Console.Read();
        }

    }
}
