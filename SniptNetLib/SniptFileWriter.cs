using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SniptNetLib
{
    /// <summary>
    /// Class to handle file writing for the snipts
    /// </summary>
    public class SniptFileWriter
    {
        #region Methods

        /// <summary>
        /// Method to iterate through the snipts collection to write to the file
        /// </summary>
        /// <param name="sniptCollection"></param>
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
                // TODO : log/print message - 
            }
        }

        #endregion Methods
    }
}
