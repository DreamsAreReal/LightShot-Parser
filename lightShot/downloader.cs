﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace lightShot
{
    class downloader
    {
        List<string> links { get; set; } = new List<string> { };
        static public bool isWork { get; set; } = true;
        static public int minLenth { get; set; }
        static public int maxLenth { get; set; }
        public void GetImageToFloader()
        {
            string[] Agents = new string[]{
"Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
"Mozilla/5.0 (Linux; U; Android 4.0.3; de-ch; HTC Sensation Build/IML74K) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
"Mozilla/5.0 (Linux; U; Android 2.3; en-us) AppleWebKit/999+ (KHTML, like Gecko) Safari/999.9",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_7; en-us) AppleWebKit/531.2+ (KHTML, like Gecko) Version/4.0.1 Safari/530.18",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_8; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.197 Safari/532.0",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_8; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.198 Safari/532.0",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_8; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/4.0.202.0 Safari/532.0",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_8; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/4.0.203.0 Safari/532.0",
"Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_8; en-us) AppleWebKit/531.21.8 (KHTML, like Gecko) Version/4.0.3 Safari/531.21.10",
  "Mozilla/1.1 (compatible; MSPIE 2.0; Windows CE)",
  "Mozilla/1.10 [en] (Compatible; RISC OS 3.70; Oregano 1.10)",
  "Mozilla/1.22 (compatible; MSIE 1.5; Windows NT)",
  "Mozilla/1.22 (compatible; MSIE 2.0; Windows 95)",
  "Mozilla/1.22 (compatible; MSIE 2.0d; Windows NT)",
  "Mozilla/1.22 (compatible; MSIE 5.01; PalmOS 3.0) EudoraWeb 2",
  "Mozilla/2.0 (compatible; MSIE 3.01; Windows 98)",
  "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)",
  "Mozilla/4.0 (compatible; MSIE 5.0; Mac_PowerPC) Opera 6.0 [en]",
  "Mozilla/4.0 (compatible; MSIE 5.0; SunOS 5.9 sun4u; X11)",
  "Mozilla/4.0 (compatible; MSIE 5.0; Windows 2000) Opera 6.03 [ru]",
  "Mozilla/4.0 (compatible; MSIE 5.17; Mac_PowerPC)",
  "Mozilla/4.0 (compatible; MSIE 5.23; Mac_PowerPC)",
  "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)",
  "Mozilla/4.0 (compatible; MSIE 6.0; ; Linux armv5tejl; U) Opera 8.02 [en_US] Maemo browser 0.4.31 N770/SU-18",
  "Mozilla/4.0 (compatible; MSIE 6.0; MSN 2.5; Windows 98)",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [de]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [en]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [es]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [fr]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [it]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Nitro) Opera 8.50 [ja]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 1657) Opera 8.60 [ru]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 1665) Opera 8.60 [en]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 1665) Opera 8.60 [fr]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 6329) Opera 8.00 [it]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 6936) Opera 8.50 [zw]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 9399) Opera 8.65 [ja]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6600/5.27.0; 9424) Opera 8.65 [ch]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Symbian OS; Nokia 6630/4.03.38; 6937) Opera 8.50 [es]",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.0.3705; .NET CLR 1.1.4322; Media Center PC 4.0; .NET CLR 2.0.50727)",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322)",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 8.50",
  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322)",
  "Mozilla/4.0 (compatible; MSIE 6.0; X11; Linux x86_64; ru) Opera 10.10",
  "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; SV1; Arcor 5.005; .NET CLR 1.0.3705; .NET CLR 1.1.4322)",
  "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; YPC 3.0.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)",
  "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)",
  "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; WOW64; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 3.5.21022)",
  "Mozilla/4.0 (compatible; MSIE 7.0b; Win32)",
  "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 5.1)",
  "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0)",
  "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 3.5.21022)",
  "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; Trident/4.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET CLR 3.0.30618)",
  "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)",
  "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Win64; x64; Trident/4.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0)",
  "Mozilla/4.1 (compatible; MSIE 5.0; Symbian OS; Nokia 6600;452) Opera 6.20 [ru]",
  "Mozilla/5.0 (Macintosh; U; Intel Mac OS X; en-US; rv:1.8.0.7) Gecko/20060909 Firefox/1.5.0.7",
  "Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.7.12) Gecko/20050915 Firefox/1.0.7",
  "Mozilla/5.0 (Windows NT 5.1; U; en) Opera 8.50",
  "Mozilla/5.0 (Windows NT 5.1; rv:2.0.1) Gecko/20100101 Firefox/4.0.1",
  "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/534.36 (KHTML, like Gecko) Chrome/12.0.742.53 Safari/534.36 QQBrowser/6.3.8908.201",
  "Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.3a) Gecko/20030105 Phoenix/0.5",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-GB; rv:1.8.0.1) Gecko/20060111 Firefox/1.5.0.1",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US)",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.13 (KHTML, like Gecko) Chrome/0.2.149.27 Safari/525.13",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/0.4.154.25 Safari/525.19",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Chrome/3.0.195.10 Safari/532.0",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.6b) Gecko/20031215 Firebird/0.7+",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.10) Gecko/20050716 Firefox/1.0.6",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060516 SeaMonkey/1.0.2",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.6) Gecko/20060728 SeaMonkey/1.0.4",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.1) Gecko/20061204 Firefox/2.0.0.1",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1) Gecko/20090624 Firefox/3.5",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.22) Gecko/20110902 Firefox/3.6.22",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; nl-NL; rv:1.7.5) Gecko/20041202 Firefox/1.0",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; nl; rv:1.8) Gecko/20051107 Firefox/1.5",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.17) Gecko/20080829 Firefox/2.0.0.17",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.19) Gecko/20081201 Firefox/2.0.0.19",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.20) Gecko/20081217 Firefox/2.0.0.20",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9) Gecko/2008052906 Firefox/3.0",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9.0.2) Gecko/2008091620 Firefox/3.0.2",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9.0.3) Gecko/2008092417 Firefox/3.0.3",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9.0.3) Gecko/2008092417 Firefox/3.0.3 (.NET CLR 3.5.30729)",
  "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.9.0.7) Gecko/2009021910 Firefox/3.0.7",
  "Mozilla/5.0 (Windows; U; Windows NT 5.2; ru; rv:1.9.0.5) Gecko/2008120122 Firefox/3.0.5",
  "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4",
  "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.10) Gecko/2009042316 Firefox/3.0.10",
  "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.1) Gecko/20090715 Firefox/3.5.1",
  "Mozilla/5.0 (Windows; U; Windows NT 6.0; ru; rv:1.9.0.3) Gecko/2008092417 Firefox/3.0.3",
  "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/1.0.154.65 Safari/525.19",
  "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Chrome/4.0.249.89 Safari/532.5",
  "Mozilla/5.0 (X11; U; FreeBSD i386; en-US; rv:1.7.8) Gecko/20050609",
  "Mozilla/5.0 (X11; U; FreeBSD i386; en-US; rv:1.7.8) Gecko/20050609 Firefox/1.0.4",
  "Mozilla/5.0 (X11; U; Linux i686 (x86_64); en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9",
  "Mozilla/5.0 (X11; U; Linux i686 (x86_64); en-US; rv:1.9a1) Gecko/20061204 GranParadiso/3.0a1",
  "Mozilla/5.0 (X11; U; Linux i686; en-US) AppleWebKit/532.9 (KHTML, like Gecko) Chrome/5.0.307.9 Safari/532.9",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.7.9) Gecko/20050711 Firefox/1.0.5",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.0.2) Gecko/20060308 Firefox/1.5.0.2",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.0.3) Gecko/20060426 Firefox/1.5.0.3",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.0.6) Gecko/20060808 Fedora/1.5.0.6-2.fc5 Firefox/1.5.0.6 pango-text",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.2) Gecko/20070220 Firefox/2.0.0.2",
  "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.2) Gecko/20070221 SUSE/2.0.0.2-6.1 Firefox/2.0.0.2",
  "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1) Gecko/20060601 Firefox/2.0 (Ubuntu-edgy)",
  "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.1.1) Gecko/20090716 Ubuntu/9.04 (jaunty) Shiretoko/3.5.1",
  "Mozilla/5.0 (X11; U; Linux x86_64; ru; rv:1.9.0.2) Gecko/2008092702 Gentoo Firefox/3.0.2",
  "Mozilla/5.0 (X11; U; Linux x86_64; ru; rv:1.9.0.4) Gecko/2008111611 Gentoo Iceweasel/3.0.4",
  "Mozilla/5.0 (X11; U; Linux x86_64; ru; rv:1.9.1.1) Gecko/20090730 Gentoo Firefox/3.5.1",
  "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 5.0)",
  "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 5.1)",
  "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 5.2)",
  "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 6.0)",
  "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 6.1)",
  "Opera/10.00 (Windows NT 6.0; U; en) Presto/2.2.0",
  "Opera/7.23 (Windows 98; U) [en]",
  "Opera/7.51 (Windows NT 5.0; U) [en]",
  "Opera/7.51 (Windows NT 5.1; U) [ru]",
  "Opera/7.51 (Windows NT 5.2; U) [ch]",
  "Opera/7.51 (Windows NT 6.0; U) [zw]",
  "Opera/7.51 (Windows NT 6.1; U) [ua]",
  "Opera/8.0 (X11; Linux i686; U; cs)",
  "Opera/8.51 (Windows NT 5.1; U; en)",
  "Opera/9.0 (Windows NT 5.1; U; en)",
  "Opera/9.00 (Nintendo Wii; U; ; 1309-9; en)",
  "Opera/9.00 (Wii; U; ; 1038-58; Wii Shop Channel/1.0; en)",
  "Opera/9.01 (X11; Linux i686; U; en)",
  "Opera/9.02 (Windows NT 5.1; U; en)",
  "Opera/9.10 (Windows NT 5.1; U; en)",
  "Opera/9.23 (Windows NT 5.1; U; ru)",
  "Opera/9.50 (Windows NT 5.1; U; ru)",
  "Opera/9.50 (Windows NT 6.0; U; en)",
  "Opera/9.60 (Windows NT 5.1; U; en) Presto/2.1.1",
  "Opera/9.80 (Windows NT 5.1; U; en) Presto/2.5.18 Version/10.50",
  "Opera/9.80 (Windows NT 5.1; U; ru) Presto/2.2.15 Version/10.20",
  "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.2.15 Version/10.00",
  "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.9.168 Version/11.51",
  "Opera/9.80 (X11; Linux x86_64; U; en) Presto/2.2.15 Version/10.10",
  "Opera/9.80 (X11; Linux x86_64; U; ru) Presto/2.2.15 Version/10.10",
           };
            Random random = new Random();
            WebClient web = new WebClient { Encoding = Encoding.UTF8 }; ;
            Regex rgx = new Regex("<img\\W+class=\".+\"\\W+src=\"(.+)\"\\W+cr");
            while (isWork)
            {
                string link = GenerateString(random.Next(minLenth, maxLenth));
                if (link != "")
                {
                    try
                    {
                        web.Headers["User-Agent"] = Agents[random.Next(1, Agents.Length)];
                        string html = web.DownloadString(link);
                        string result = rgx.Match(html).Groups[1].Value;
                        if (result.Trim() != "")
                        {
                            Console.WriteLine("Качаем фото " + result);
                            web.DownloadFile(result, "images/" + Path.GetFileName(result).Replace('/', ' '));
                            Thread.Sleep(500);
                        }

                    }
                    catch (Exception ex)
                    {
                    }

                }
                Thread.Sleep(100);
            }
        }

        public string GenerateString(int lenth)
        {
            Random random = new Random();
            string link = @"https://prnt.sc/";
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
            int numChars = chars.Length;
            for (int i = 0; i < lenth; i++)
            {
                link += chars.Substring(random.Next(1, numChars), 1);
            }
            if (!links.Contains(link))
            {
                links.Add(link);
                return link;
            }
            else
            {
                return "";
            }
        }




    }
}
