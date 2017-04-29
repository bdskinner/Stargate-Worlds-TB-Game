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
    public static class ConsoleThemeOLD
    {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkRed;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Yellow;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.White;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkRed;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.Gray;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkRed;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.Gray;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor MenuBorderColor = ConsoleColor.DarkRed;

        //
        // message box colors
        //
        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkRed;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.Gray;

        //
        // status box colors
        //
        public static ConsoleColor StatusBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor StatusBoxBorderColor = ConsoleColor.DarkRed;
        public static ConsoleColor StatusBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxHeaderForegroundColor = ConsoleColor.Gray;

        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkRed;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.Gray;
    }

    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //

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

        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkCyan;  // -- new
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.White;

        //
        // console window footer colors
        //

        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkCyan; // -- new
        public static ConsoleColor FooterForegroundColor = ConsoleColor.White;


        //
        // menu box colors
        //

        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black; // -- new
        public static ConsoleColor MenuForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuBorderColor = ConsoleColor.Blue;

        //
        // message box colors
        //

        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;  // -- new
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.Blue;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // status box colors
        //

        public static ConsoleColor StatusBoxBackgroundColor = ConsoleColor.Black;  // -- new
        public static ConsoleColor StatusBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor StatusBoxBorderColor = ConsoleColor.Blue;
        public static ConsoleColor StatusBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor StatusBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // input box colors
        //

        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black; // -- new
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.Blue;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.White;
    }
}
