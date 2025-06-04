namespace FantasyNameGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    _ = new NameGenerator();
                }
                else if (args.Length == 1)
                {
                    switch (args[0].ToLower())
                    {
                        case "--generate":
                            _ = new NameGenerator();
                            break;
                        case "--train":
                            _ = new MarkovTrain();
                            break;
                        default:
                            throw new Exception("Error: Invalid argument. Use --train or --generate.");
                    };
                }
                else
                {
                    throw new Exception("Error: Invalid number of argument.");
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
