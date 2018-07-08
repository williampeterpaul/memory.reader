using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.reader.Services
{
    public interface IMemoryReader
    {
        byte[] ReadFromMemoryAddress(IntPtr address);
        List<byte[]> ReadFromMemoryAddressRange(IntPtr start, IntPtr end);
        List<byte[]> ReadFromEntireProcessRange(Process process);
    }
}
