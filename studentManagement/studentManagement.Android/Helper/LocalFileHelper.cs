using studentManagement.Business.Interfaces;
using studentManagement.Droid.Helper;
using System;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(LocalFileHelper))]
namespace studentManagement.Droid.Helper
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetAsyncConnection(string filename)
        {
            //Database Path in Android
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
            // return Path.Combine(docFolder, filename);
        }
    }
}