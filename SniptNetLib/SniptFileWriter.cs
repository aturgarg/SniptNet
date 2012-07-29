using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SniptNetLib
{
    public class SniptFileWriter
    {
        public void SniptsToWrite(List<SniptObject> sniptCollection)
        {
            foreach (SniptObject snipt in sniptCollection)
            {
                WriteSniptToFile(snipt);
            }
        }

        /// <summary>
        /// This method write snipt to a file
        /// Format in file
        /// Title:
        /// Lexer:
        /// IsPublic:
        /// Code: (new new line)        
        /// </summary>
        /// <param name="snipt"></param>
        private static void WriteSniptToFile(SniptObject snipt)
        {
            try
            {
                // Write the data to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\SniptsFiles\\" + snipt.Slug + ".txt", false);

                StringBuilder dataToWrite = new StringBuilder();

                dataToWrite.Append("Title: " + snipt.Title);
                dataToWrite.Append("\n");
                dataToWrite.Append("Lexer: " + snipt.Lexer);
                dataToWrite.Append("\n");
                dataToWrite.Append("IsPublic: " + snipt.IsPublic);
                dataToWrite.Append("\n");
                dataToWrite.Append("Code: \n" + snipt.Code);

                file.WriteLine(dataToWrite.ToString());

                file.Close();
            }
            catch (IOException ioException)
            {
                // log/print message - 
            }
        }
    }
}
