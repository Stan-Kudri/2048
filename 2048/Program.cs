namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeField = 4;
            var game = new Game(sizeField);
            game.Run();
        }
    }
}
