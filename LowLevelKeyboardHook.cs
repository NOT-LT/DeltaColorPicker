using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DeltaColorPicker
{
    public class LowLevelKeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private IntPtr hookId = IntPtr.Zero;
        private HookProc hookCallback;
        private bool isInstalled = false;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Install()
        {
            if (isInstalled)
                return;

            hookCallback = KeyboardHookCallback;
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
            {
                hookId = SetWindowsHookEx(WH_KEYBOARD_LL, hookCallback, GetModuleHandle(module.ModuleName), 0);
            }

            isInstalled = true;
        }

        public void Uninstall()
        {
            if (!isInstalled)
                return;

            UnhookWindowsHookEx(hookId);

            isInstalled = false;
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                var key = KeyInterop.KeyFromVirtualKey(vkCode);

                KeyPressed?.Invoke(this, new KeyPressedEventArgs(key));
            }

            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        #region Native Methods and Structures

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }

    public class KeyPressedEventArgs : EventArgs
    {
        public Key Key { get; }

        public KeyPressedEventArgs(Key key)
        {
            Key = key;
        }
    }
}