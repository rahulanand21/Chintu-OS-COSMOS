using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sys = Cosmos.System;
using Cosmos.Hardware;

namespace Chintu_OS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Chintu is Waking Up!\nPlease Wait");
        }

        protected override void Run()
        {
            GUI.setup();
            GUI.show();
        }
    }
    public static class GUI
    {
        #region declerations
        private static Cosmos.Hardware.VGAScreen screen;
        private static Cosmos.Hardware.Mouse mouse;
        private static uint oldx, oldy;
        #endregion

        public static void setup()
        {
            screen = new Cosmos.Hardware.VGAScreen();
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            for (int i = 0; i <= 255; i++)
            {
                screen.SetPaletteEntry(i, (byte)i, (byte)i, (byte)i);
            }
            screen.Clear(255);

            mouse = new Cosmos.Hardware.Mouse();
            mouse.Initialize(320, 200);
        }
        public static void show()
        {
            int X = 0;
            while (true)
            {
                X++;
                screen.Clear(X % 255);
                uint curX = (uint)mouse.X; ;
                uint curY = (uint)mouse.Y;
                if (curX != oldx || curY != oldy)
                    WipeMouse();
                DrawMouse(curX, curY);
            }
        }
        public static void DrawMouse(uint __x, uint __y)
        {
            //          Draw the Mouse pixel by pixel
            // -----------------------------------------------
            if (__x <= 1)
                __x = __x + 1;
            if (__y <= 1)
                __y = __y + 1;
            if (__x >= 319)
                __x = __x - 1;
            if (__y >= 199)
                __y = __y - 1;
            screen.SetPixel320x200x8(__x, __y, 0);

            screen.SetPixel320x200x8(__x + 1, __y, 25);
            screen.SetPixel320x200x8(__x + 2, __y, 25);
            screen.SetPixel320x200x8(__x + 3, __y, 25);
            screen.SetPixel320x200x8(__x + 4, __y, 25);

            screen.SetPixel320x200x8(__x, __y + 1, 25);
            screen.SetPixel320x200x8(__x, __y + 2, 25);
            screen.SetPixel320x200x8(__x, __y + 3, 25);
            screen.SetPixel320x200x8(__x, __y + 4, 25);

            screen.SetPixel320x200x8(__x + 1, __y + 2, 25);
            screen.SetPixel320x200x8(__x + 2, __y + 1, 25);

            screen.SetPixel320x200x8(__x + 1, __y + 1, 60);
            screen.SetPixel320x200x8(__x + 2, __y + 2, 60);
            screen.SetPixel320x200x8(__x + 3, __y + 3, 60);
            screen.SetPixel320x200x8(__x + 4, __y + 4, 60);
            screen.SetPixel320x200x8(__x + 5, __y + 5, 60);
            screen.SetPixel320x200x8(__x + 6, __y + 6, 60);
            // -----------------------------------------------

            oldx = (uint)__x;
            oldy = (uint)__y;
        }
        public static void WipeMouse()
        {
            //        Destroy the Mouse pixel by pixel      =)
            // -----------------------------------------------
            screen.SetPixel320x200x8(oldx, oldy, 255);

            screen.SetPixel320x200x8(oldx + 1, oldy, 255);
            screen.SetPixel320x200x8(oldx + 2, oldy, 255);
            screen.SetPixel320x200x8(oldx + 3, oldy, 255);
            screen.SetPixel320x200x8(oldx + 4, oldy, 255);

            screen.SetPixel320x200x8(oldx, oldy + 1, 255);
            screen.SetPixel320x200x8(oldx, oldy + 2, 255);
            screen.SetPixel320x200x8(oldx, oldy + 3, 255);
            screen.SetPixel320x200x8(oldx, oldy + 4, 255);

            screen.SetPixel320x200x8(oldx + 1, oldy + 2, 255);
            screen.SetPixel320x200x8(oldx + 2, oldy + 1, 255);

            screen.SetPixel320x200x8(oldx + 1, oldy + 1, 255);
            screen.SetPixel320x200x8(oldx + 2, oldy + 2, 255);
            screen.SetPixel320x200x8(oldx + 3, oldy + 3, 255);
            screen.SetPixel320x200x8(oldx + 4, oldy + 4, 255);
            screen.SetPixel320x200x8(oldx + 5, oldy + 5, 255);
            screen.SetPixel320x200x8(oldx + 6, oldy + 6, 255);
            // -----------------------------------------------
        }
    }
}
