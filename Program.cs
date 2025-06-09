using System;
using System.Windows.Forms;
using CommandRunner.UI;
using CommandRunner.Core;
namespace CommandRunner;

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
        ApplicationConfiguration.Initialize();
        var mainForm = new MainForm();
        mainForm.Hide();
        Application.Run(mainForm);
    }    
}