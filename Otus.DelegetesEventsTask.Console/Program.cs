//// See https://aka.ms/new-console-template for more information

//found maks value
using Otus.DelegetesEventsTask;

namespace DelegetesEventsTask
{
    public static class Program
    {
        public static bool CancelSearch { get; private set; } = false;

        public static void Main()
        {
            var searcher = new FileSearcher();
            searcher.FileFound += OnFileFound;

            string directoryPath = @"D:\Edu";
            searcher.Search(directoryPath);


            List<string> collection = new()
            {
               "23","23","1231"
            };

            var maxValue = collection.GetMax(x => Convert.ToInt32(x));


            Console.WriteLine("Max value: " + maxValue);
            Console.ReadKey();
        }

        private static void OnFileFound(object sender, FileArgs e)
        {
            Console.WriteLine($"Найден файл: {e.FileName}");
            if (e.FileName.Contains("stop.txt"))
            {
                CancelSearch = true;
            }
        }
    }
}




