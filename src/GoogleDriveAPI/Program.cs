using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleDriveAPI
{
    public class Program
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static List<string> listLink = new List<string>();
        static void Main(string[] args)
        {
            ExportLink ex = new ExportLink();
            listLink = ex.connector(listLink, "0B7Ak3NL3lRnTRV9PejVwd2I1bXc");
            Console.WriteLine("count list " + listLink.Count);
            Console.ReadKey();
        }
    }
}


