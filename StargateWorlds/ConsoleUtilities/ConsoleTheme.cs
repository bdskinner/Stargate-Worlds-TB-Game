using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StargateWorlds
{
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //
        //public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkRed; -- original
        //public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Yellow;

        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkCyan;  // -- new
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.White;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.White;

        //
        // console window header colors
        //
        //public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkRed; -- original
        //public static ConsoleColor HeaderForegroundColor = ConsoleColor.Gray;

        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkCyan;  // -- new
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.White;

        //
        // console window footer colors
        //
        //public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkRed; -- original
        //public static ConsoleColor FooterForegroundColor = ConsoleColor.Gray;

        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkCyan; // -- new
        public static ConsoleColor FooterForegroundColor = ConsoleColor.White;


        //
        // menu box colors
        //
        //public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black; -- original
        //public static ConsoleColor MenuForegroundColor = ConsoleColor.Gray;
        //public static ConsoleColor MenuBorderColor = ConsoleColor.DarkRed;

        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black; // -- new
        public static ConsoleColor MenuForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuBorderColor = ConsoleColor.Blue;

        //
        // message box colors
        //
        //public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;  -- original
        //public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.Gray;
        //public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkRed;
        //public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        //public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.Gray;

        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;  // -- new
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.Blue;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // input box colors
        //
        //public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black; -- original
        //public static ConsoleColor InputBoxForegroundColor = ConsoleColor.Gray;
        //public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        //public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkRed;
        //public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        //public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.Gray;

        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black; // -- new
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.Blue;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.White;
    }
}
