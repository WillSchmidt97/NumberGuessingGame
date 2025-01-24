using NumberGuessingGame.GameLogic;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game();
            //game.GameStart();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopPath, "test.txt");

            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Here will be the JSON!");
                }
            }
        }
    }
}