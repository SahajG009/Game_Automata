using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using WindowsInput;

namespace Game_Automata
{
    class Program
    {
        // import the function of your class
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        
        static void Main(string[] args)
        {
            Process[] ps = Process.GetProcessesByName("hl2");
            //Console.WriteLine(ps.Length);
            //foreach (var p in ps)
            //{
            //   Console.WriteLine(p);
            //}
            Process TF2Process = ps.FirstOrDefault();
            Console.WriteLine(TF2Process);

            if (TF2Process != null)
            {
                Console.WriteLine("Bringing TF2 on focus");
                IntPtr h = TF2Process.MainWindowHandle;
                SetForegroundWindow(h);

                ///Thread.Sleep(3000);
                //Console.WriteLine("Sending Keystroke");
                //Sendkeys.SendWait("W");

                Thread.Sleep(1000);
                Console.WriteLine("Escaping Advanced Settings");
                InputSimulator isim = new InputSimulator();
                isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);

                Console.WriteLine("Starting Bouncing routine....");
                for (int i =0; i < 10; i++)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("Sending Forward Bouncing....");
                    isim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
                    Thread.Sleep(50);
                    isim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
                   
                    isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
              
                    // Simulate right-click
                    isim.Mouse.RightButtonClick();
                }
            }



            Console.WriteLine("Press a key to exit.....");
            Console.ReadKey();
        }
    }
}
