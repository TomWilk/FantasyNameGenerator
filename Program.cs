namespace FantasyNameGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                _ = new NameGenerator();
            } else if (args.Length == 1) 
            {
                if (args[0].ToLower() == "--generate")
                {
                    _ = new NameGenerator();
                } else if (args[0].ToLower() == "--train")
                {
                    _ = new MarkovTrain();
                }
                else
                {
                    Console.Error.WriteLine("Error. Błędne użycie");
                }
            }
            else
            {
                Console.Error.WriteLine("Error. Błędne użycie");
            }
        }
    }
}
