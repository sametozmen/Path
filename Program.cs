using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                ArrayList test = dizinIcerigiListele(line);
                for (int i = 0; i < test.Count; i++)
                {
                    Console.WriteLine((i+1)+ " " + test[i]);
                }
            }
        }
        static ArrayList dizinIcerigiListele(string dizin)
        {
            ArrayList ary = new ArrayList();
            ArrayList are = new ArrayList();
            string[] dizinKlasorler;
            try
            {
                dizinKlasorler = Directory.GetDirectories(dizin);
            }
            catch (NotSupportedException)
            {
                are.Add(dizin + " desteklenmiyor.");
                return are;
            }
            catch (DirectoryNotFoundException)
            {
                are.Add(dizin + " is not a valid path.");
                return are;
            }
            catch (IOException)
            {
                are.Add(dizin + " device is not ready.");
                return are;
            }
            catch (ArgumentException)
            {
                are.Add(dizin + " is not a valid path.");
                return are;

            }
            catch (UnauthorizedAccessException)
            {
                are.Add(dizin + " access can not be provided");
                return are;
            }
            string[] dizinDosyalar = Directory.GetFiles(dizin);
            foreach (string klasor in dizinKlasorler)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(klasor);
                string klasorAdi = directoryInfo.Name;
                DateTime olusturmaTarihi = directoryInfo.CreationTime;
                ary.Add(klasorAdi+"              "+ olusturmaTarihi.ToShortDateString());
             }
            foreach (string dosya in dizinDosyalar)
            {
                FileInfo fileInfo = new FileInfo(dosya);
                string dosyaAdi = fileInfo.Name;
                long boyut = fileInfo.Length;
                DateTime olusturulmaTarihi = fileInfo.CreationTime;
                ary.Add(dosyaAdi+"                "+boyut+"KB" + "              "+olusturulmaTarihi.ToShortDateString());
            }

            return ary;

        }

        

    }
}

