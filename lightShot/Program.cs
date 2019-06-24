using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lightShot
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("images");
            downloader downloader = new downloader();
            Console.Title = "LightShot Downloader";
            var path = "logo.jpg";
            ImageToConsole(path);
            Console.WriteLine("Разработчик:\n\n\ttelegram: @unlcode\n\tСофт под заказ\n\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
            ImageToConsole(path);


            int threadCount;
            int time;
            
            try
            {
                Console.Write("Введите кол-во потоков (должно быть целое число): ");
                threadCount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Максимальное и минимальное значение длины ссылки (5-7 (5 - минимальное, 7 - максимальное)): ");
                string maxminLenth = Console.ReadLine();
                downloader.minLenth = Convert.ToInt32(maxminLenth.Split('-')[0]);
                downloader.maxLenth = Convert.ToInt32(maxminLenth.Split('-')[1]);
                Console.Write(@"
=========================================================
            1 час = 3600 с || 1 минута = 60 с
=========================================================

Введите огранечение по времени (0 - бесконечная работа): ");
                time = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат строки\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            if(threadCount<1)
            {
                Console.WriteLine("\nКол-во потоков не может быть равно нулю\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            Console.Clear();

        

            Console.WriteLine("Запускаю потоки");
            Thread thread = new Thread(downloader.GetImageToFloader);
            thread.IsBackground = true;
            for (int i = 0; i<threadCount;i++)
            {
                new Thread(downloader.GetImageToFloader).Start();
            }

            if (time != 0)
            {   
                Thread.Sleep(TimeSpan.FromSeconds(time));
                downloader.isWork = false;
                return;
            }
            else
            {
                while(true)
                {
                    Thread.Sleep(TimeSpan.FromDays(10));
                }
            }

        }

        static void ImageToConsole(string imagePath)
        {
            Image Picture = Image.FromFile(imagePath);
            FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
            int FrameCount = Picture.GetFrameCount(Dimension);
            int Left = Console.WindowLeft, Top = Console.WindowTop;
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            Picture.SelectActiveFrame(Dimension, 0x0);
            for (int i = 0x0; i < Picture.Height; i++)
            {
                for (int x = 0x0; x < Picture.Width; x++)
                {
                    Color Color = ((Bitmap)Picture).GetPixel(x, i);
                    int Gray = (Color.R + Color.G + Color.B) / 0x3;
                    int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
            }
           
        }
    }
}
