using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SniptNetLib;

namespace SniptNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Handler handler = new Handler();
                int sniptsLimit = 30;

                // Get private snipts
                List<SniptObject> sniptsCollection = handler.GetSnipts(sniptsLimit);

                // write snipts to a file
                // This is a crude way of doing so.
                // Ideally I intended to write these snipts to "Gist.github.com" or a similar site.
                SniptFileWriter sniptFileWriter = new SniptFileWriter();
                sniptFileWriter.SniptsToWrite(sniptsCollection);

                Console.ReadLine();
            }
            catch (Exception exception)
            {
                // log message
            }
        }
    }
}
