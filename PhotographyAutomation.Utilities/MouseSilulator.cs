using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace PhotographyAutomation.Utilities
{
    public static class MouseSilulator
    {
        //To move the cursor where you want:

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public static void MoveCursorToPoint(int x, int y)
        {
            SetCursorPos(x, y);
        }



        //To perform a mouse click:

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
