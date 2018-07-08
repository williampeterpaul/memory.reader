using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.reader.Enumerations
{
    public enum ProcessAccess : uint
    {
        CreateThread = 0x2,
        SetSessionId = 0x4,
        VmOperation = 0x8,
        VmRead = 0x10,
        VmWrite = 0x20,
        DupHandle = 0x40,
        CreateProcess = 0x80,
        SetQuota = 0x100,
        SetInformation = 0x200,
        QueryInformation = 0x400,
        SuspendResume = 0x800,
        QueryLimitedInformation = 0x1000,
        Synchronize = 0x100000,
        Delete = 0x10000,
        ReadControl = 0x20000,
        WriteDac = 0x40000,
        WriteOwner = 0x80000,
        StandardRightsRequired = 0xF0000,
        AllAccess = 0x1FFFFF
    }

    public enum StateEnum : uint
    {
        MEM_COMMIT = 0x1000,
        MEM_FREE = 0x10000,
        MEM_RESERVE = 0x2000
    }

    public enum AllocationProtectEnum : uint
    {
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_NOACCESS = 1u,
        PAGE_READONLY = 2u,
        PAGE_READWRITE = 4u,
        PAGE_WRITECOPY = 8u,
        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

    public enum TypeEnum : uint
    {
        MEM_IMAGE = 0x1000000,
        MEM_MAPPED = 0x40000,
        MEM_PRIVATE = 0x20000
    }
}
