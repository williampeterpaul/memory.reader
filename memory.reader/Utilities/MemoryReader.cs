using memory.reader.Enumerations;
using memory.reader.Services;
using memory.reader.Structures;
using memory.reader.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.reader.Utilities
{
    public class MemoryReader : IMemoryReader
    {
        private IntPtr _processHandle;

        private MemoryInformation _memoryInformation;
        private SystemInformation _systemInformation;

        public MemoryReader()
        {
            _processHandle = new IntPtr();

            _memoryInformation = new MemoryInformation();
            _systemInformation = new SystemInformation();
        }

        public List<byte[]> ReadFromEntireProcessRange(Process process)
        {
            _processHandle = Native.OpenProcess(ProcessAccess.AllAccess, false, process.Id);

            Native.GetSystemInfo(out _systemInformation);

            return ReadFromMemoryAddressRange(_systemInformation.minimumApplicationAddress, _systemInformation.maximumApplicationAddress);
        }

        public List<byte[]> ReadFromMemoryAddressRange(IntPtr start, IntPtr end)
        {
            var A = (long)start;
            var B = (long)end;

            var current = start;
            var result = new List<byte[]>();

            while (A < B)
            {
                result.Add(ReadFromMemoryAddress(current));

                A += _memoryInformation.RegionSize;

                current = new IntPtr(A);
            }

            return result;
        }

        public byte[] ReadFromMemoryAddress(IntPtr address)
        {
            var bytesRead = 0;
            var buffer = default(byte[]);

            Native.VirtualQueryEx(_processHandle, address, out _memoryInformation, 28);

            if (Equals(_memoryInformation.Protect, AllocationProtectEnum.PAGE_READWRITE) && Equals(_memoryInformation.State, StateEnum.MEM_COMMIT))
            {
                buffer = new byte[_memoryInformation.RegionSize];

                Native.ReadProcessMemory(_processHandle, _memoryInformation.BaseAddress, buffer, _memoryInformation.RegionSize, ref bytesRead);

                return buffer;
            }

            return default(byte[]);
        }

    }
}
