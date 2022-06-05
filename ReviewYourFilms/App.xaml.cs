using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ReviewYourFilms
{
    public class BaseColor
    {
        public static SolidColorBrush highHas = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#21D07A"));
        public static SolidColorBrush highNo = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#204529"));
        public static SolidColorBrush midHas = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#D2D531"));
        public static SolidColorBrush midNo = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#423D0F"));
        public static SolidColorBrush lowHas = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#DB2360"));
        public static SolidColorBrush lowNo = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#571435"));


        public static SolidColorBrush defaultBrush = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#B2B3B5"));
        public static SolidColorBrush blueBrush = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#669DF6"));
        public static SolidColorBrush greyBrush = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#373737"));
        public static SolidColorBrush redBrush = (SolidColorBrush)
            (new BrushConverter().ConvertFrom("#FF6054"));       
    }

    public class Client
    {
        public static string uid;
        public static string userName;
        public static string imageURL;
        public static string bio;
        public static string email;
        public static List<string> watchlist;
        public static List<string> followed;
        public static string token;
        public static string refreshToken;
    }
    public partial class App : Application
    {
        public App()
        {
            
        }
    }
}
