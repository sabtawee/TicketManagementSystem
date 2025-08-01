using System;
using System.Windows.Forms;
using TicketManagementSystem.Views;


namespace TicketManagementSystem;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Application.EnableVisualStyles();
        ApplicationConfiguration.Initialize();
        Application.Run(new TicketForm());
    }
}