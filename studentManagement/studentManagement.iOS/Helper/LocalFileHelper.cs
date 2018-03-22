using studentManagement.Business.Interfaces;
using studentManagement.iOS.Helper;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace studentManagement.iOS.Helper
{
    public class LocalFileHelper : ILocalFileHelper
    {
        //Database Path in iOS
        public string GetAsyncConnection(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
