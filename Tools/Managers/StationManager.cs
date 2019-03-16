using System;
using System.Windows;
using Lab03.Models;

namespace Lab03.Tools.Managers
{
    internal static class StationManager
    {
        

        internal static Person CurrentUser { get; set; }


        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
