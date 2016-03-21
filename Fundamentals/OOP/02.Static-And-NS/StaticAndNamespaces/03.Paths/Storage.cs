using System;
using System.IO;

namespace _03.Paths
{
    static class Storage
    {
        const string FileName = "Path3D.txt";
        const string FilePath = "../../" + FileName;

        public static void Save(Path3D path)
        {
            File.WriteAllText(FilePath, path.ToString());
            Console.WriteLine("File ({0}) saved.", FileName);
        }

        public static void Load()
        {
            try
            {
                var text = File.ReadAllText(FilePath);
                Console.WriteLine("The content of '{0}' is: {1}", FileName, text);
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}