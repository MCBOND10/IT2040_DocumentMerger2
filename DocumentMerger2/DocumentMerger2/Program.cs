using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3) //if wrong num of files, do this
            {
                Console.WriteLine("");
                Console.WriteLine("DOCUMENT MERGER 2 \n\nFormat: <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
                Console.WriteLine("Supply at least 2 text files to merge. Following the input files, include a name for the resulting merged text file.");
                Console.WriteLine("NOTE: Dont forget to add file extensions! ex file1.txt");
                Console.WriteLine("");
            }
            else //if files exist, do this
            {
                string[] files = new string[args.Length - 1];
                Array.Copy(args, 0, files, 0, args.Length - 1);
                var mfile = args[args.Length - 1];
                StreamWriter createfile = null;
                createfile = new StreamWriter(mfile);

                long count = 0;
                string newfilepath = null;
                StreamReader readfile = null;

                foreach(string filepath in files)
                {
                    newfilepath = filepath;
                    readfile = new StreamReader(newfilepath);
                    string text = null;
                    while((text = readfile.ReadLine()) != null)
                    {
                        createfile.WriteLine(text);
                        count = count + (long)text.Length;
                    }
                    readfile.Close();
                }

                Console.WriteLine("Your file '{0}' was saved. The document contains {1} characters", mfile, count);
            }
        }
    }
}
