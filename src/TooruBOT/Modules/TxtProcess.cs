using System;
using System.Collections.Generic;
using System.IO;

namespace TooruBot.Modules
{
    public class TxtProcess
    {
        public void printTxt(List<string> listLink, string pathTxt)
        {
            if (!File.Exists(pathTxt))
            {
                using (TextWriter writer = File.CreateText(pathTxt))
                {

                    foreach (String s in listLink)
                        writer.WriteLine(s);

                    writer.Write(writer.NewLine);
                }
            }
            else
            {

                using (StreamWriter writer = File.AppendText(pathTxt))
                {
                    writer.WriteLine();
                    foreach (String s in listLink)
                        writer.WriteLine(s);

                    writer.Write(writer.NewLine);
                }

            }
            
            //'E:\log\0BxA8bBq0U61jUjBGUHdCWkZpeXM.txt'.


        }
        public List<string> readTxt(List<string> listLinkCurrent, string pathTxt)
        {
            //  ExportLink ex = new ExportLink();
            try
            {
                using (var fs = new FileStream(pathTxt, FileMode.Open, FileAccess.Read))
                {

                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        Console.WriteLine("Please wait a moment...");
                        while ((line = sr.ReadLine()) != null)
                        {
                            listLinkCurrent.Add(line);
                        }
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: ");
                Console.WriteLine(e.Message);
            }
            return listLinkCurrent;
        }
    }
}
