using System;
using System.Runtime.InteropServices;

namespace AsmFunc
{

    public class Func
    {
        [DllImport("kernel32.dll")]
        static extern bool VirtualProtect(IntPtr lpAddress, uint size, uint flNewProtect, out uint lpflOldProtect);
        delegate int asmdeleg(int a, int b);

        public int GetFunc(int a, int b)
        {
            byte[] codeasm = { 0x8B, 0x44, 0x24, 0x04, 0x8B, 0x54, 0x24, 0x08, 0x09, 0xD0, 0xC2, 0x08, 0x00 };
            IntPtr adresasm = Marshal.AllocHGlobal(codeasm.Length);
            uint oldprotect;
            VirtualProtect(adresasm, (uint)codeasm.Length, 0x40, out oldprotect);
            Marshal.Copy(codeasm, 0, adresasm, codeasm.Length);
            asmdeleg injectcall = (asmdeleg)Marshal.GetDelegateForFunctionPointer(adresasm, typeof(asmdeleg));
            return injectcall(a,b);
        } 
    }
}
    


