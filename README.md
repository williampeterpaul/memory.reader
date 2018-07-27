# memory.reader
Tiny project to help me learn about memory allocation in windows and kernel32.DLL

## Problem domain

The problem with reading memory in Windows is that it does not store allocated memory contiguously. When a process starts, the system allocates enough memory for its regions, heap, and stack, however due to 'user mode' the process must delegate to system APIs for access to memory.

![Example protection ring architecture on an x86 CPU](https://blog.codinghorror.com/content/images/uploads/2008/01/6a0120a85dcdae970b0120a86db3ea970b-pi.png)

## Solution

The current solution (at-least in c#) is to repeatedly read every available memory address. This project will seek to find a more efficient way to identify the memory addresses of a given process. Similar to how this is possible using an assembler level debugger such as [OllyDbg](http://www.ollydbg.de/).


## Contribute

If you have any idea for an improvement or found a bug, do not hesitate to open an issue. 
And if you have time clone this repo and submit a pull request and help me make this project kickass!
