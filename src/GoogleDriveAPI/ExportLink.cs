using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace GoogleDriveAPI
{
    public class ExportLink
    {
        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Drive API .NET Quickstart";
        //static string folderId = "0B9T8P5iPr7rDdmNVWFBkOFFPaW8";

        public List<string> connector(List<string> listLink, String folderId)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetEnvironmentVariable(
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "LocalAppData" : "Home");
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            PrintFilesInFolder(service, folderId, listLink);
            return listLink;


        }

        public void PrintFilesInFolder(DriveService service,
    String folderId, List<string> listLink)
        {
            ChildrenResource.ListRequest request = service.Children.List(folderId);
            int i = 0;
            do
            {
                try
                {
                    ChildList children = request.Execute();

                    foreach (ChildReference child in children.Items)
                    {
                        i++;
                        //DrawProgressBar(2, 1,(i*100)/ children.Items.Count, 2, ConsoleColor.Red);
                        //Console.WriteLine("File Link: " + child.SelfLink);
                        Google.Apis.Drive.v2.Data.File file = service.Files.Get(child.Id).Execute();
                        //Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nFile Link (" + i + "/" + children.Items.Count + "): " + file.WebContentLink);
                        listLink.Add(file.WebContentLink);
                        /*ThumbnailLink = 220 pixel
                        AlternateLink = return view link ---- tag: View
                        EmbedLink =return preview link
                        */
                    }
                    request.PageToken = children.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    request.PageToken = null;
                }
            } while (!String.IsNullOrEmpty(request.PageToken));


        }
        public void DrawProgressBar(int left, int top, int value, int symbolType, ConsoleColor color)
        {
            char[] symbol = new char[5] { '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };

            int maxBarSize = Console.BufferWidth - 1;
            int barSize = value;
            decimal f = 1;

            if (barSize + left > maxBarSize)
            {
                barSize = maxBarSize - (left + 5); // first 5 character "%100 "
                f = (decimal)value / (decimal)barSize;
            }

            Console.CursorVisible = false;
            Console.ForegroundColor = color;

            Console.SetCursorPosition(left + 5, top);

            for (int i = 0; i < barSize + 1; i++)
            {
                System.Threading.Thread.Sleep(10);
                Console.Write(symbol[symbolType]);
                Console.SetCursorPosition(left, top);
                Console.Write("%" + (i * f).ToString("0,0"));
                Console.SetCursorPosition(left + 5 + i, top);
            }

            Console.ResetColor();
            if (value == 100)
            {
                return;
            }
        }
    }
}
