using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace FuckBuggers
{
    internal class Program
    {
        /*
         * El código es bastante malo

         * Tuve que rehacerlo varias veces, el código es malo, lo sé, pero lo importante
         * es que cumple su función, lo hice en unas 5 horas.
         * 
         * Seguramente no lo actualice más por el código de mierda que tiene
         */

        static List<string> request = new List<string>(),
            response = new List<string>(),
            unsignedExes = new List<string>();

        static int foundExes = 0,
            unsigFoundExes = 0,
            checkResult = 0;

        static string folder = @"C:\";
        static bool status;

        static void Main(string[] args)
        {
            status = true;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("         .'(()) - (())('.         |          |\r\n         / ))\\     /((  \\         | " + response[0] + "  \r\n ______/  /(   \\_/   ) \\  \\______/  " + response[1] + " \r\n ________(      :       )_________| " + response[2] + "    \r\n          \\____._._____/          |__________|\r\n            )===[]===(\r\n           /          \\");
            SearchTask(args);
        }

        static void SearchTask(string[] args)
        {
            var searchTask = Task.Run(() => searchForExeFiles(folder));
            Console.WriteLine("Press enter to stop the search");
            Console.ReadLine();
            Console.WriteLine("Checking files....");
            status = false;
            strFucker();
            Console.ReadLine();
        }

        public static void strFucker()
        {
            string outputFileName = Path.Combine(Path.GetTempPath()) + "fb3-antipiracyapps.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFileName, false, Encoding.UTF8))
                {
                    writer.WriteLine("Potential suspicious executables: ");
                    if (Directory.Exists(folder))
                    {
                        foreach (string unsigned in unsignedExes)
                        {
                            foreach (string rrr in urmom)
                            {
                                if (ContainsStr(unsigned, rrr))
                                {
                                    checkResult++;
                                    Console.Write($"\rPotential suspicious executables " +checkResult);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error.Add("Error: " + ex.Message);
            }
        }

        static bool ContainsStr(string filePath, string searchString)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath, Encoding.Default);

                if (fileContent.Contains(searchString))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                error.Add("Error: " + ex.Message);
            }
            return false;
        }

        static void searchForExeFiles(string directory)
        {
            if (!status)
            {
                return;
            }
            try
            {
                string[] exeFiles = Directory.GetFiles(directory, "*.exe");
                foreach (string exeFile in exeFiles)
                {
                    foundExes++;
                    if (!hasDigitalSignature(exeFile))
                    {
                        unsignedExes.Add(exeFile);
                        unsigFoundExes++;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    foundExes++;
                    Console.Write($"\rNumber of .exe found: " + foundExes + $"    Unsigned .exe found: " + unsigFoundExes);  
                }
                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                    searchForExeFiles(subdirectory);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                error.Add("No permission to: " + ex.Message);
            }
        }

        static bool hasDigitalSignature(string filePath)
        {
            try
            {
                X509Certificate cert = X509Certificate.CreateFromSignedFile(filePath);
                return cert != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static void WriteToTemp(string name, List<string> unsignedExesList)
        {
            try
            {
                string tempFolder = Path.GetTempPath();
                string filePath = Path.Combine(tempFolder, name);
                File.WriteAllLines(filePath, unsignedExesList);
            }
        }
    }
}
