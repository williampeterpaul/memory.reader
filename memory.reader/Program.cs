using memory.reader.Enumerations;
using memory.reader.Services;
using memory.reader.Structures;
using memory.reader.Utilities;
using memory.reader.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace memory.reader
{
    public class Program
    {
        public IMemoryReader Reader { get; }

        public Program(IMemoryReader reader)
        {
            Reader = reader;
        }

        public string ReadFromProcess(string processName)
        {
            var process = Process.GetProcessesByName(processName).First();

            var result = Reader.ReadFromEntireProcessRange(process);

            var builder = new StringBuilder();

            foreach (var array in result)
            {
                if (array != null)
                {
                    foreach (var element in array)
                    {
                        if (element != 0)
                        {
                            builder.Append((char)element);
                        }
                    }
                }
            }

            return builder.ToString();
        }

        public static void Main()
        {
            Program p = new Program(new MemoryReader());

            while (true)
            {
                var memory = p.ReadFromProcess("notepad");
            }
        }

    }
}