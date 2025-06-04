using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyNameGenerator
{
    internal class NameGenerator
    {
        string trainedFile = "trainedData.json";
        Dictionary<char, Dictionary<char, int>> markov;
        public NameGenerator()
        {
            if (!File.Exists(trainedFile))
            {
                throw new FileNotFoundException("File with trained data doesn't exist!\n" +
                                                "Run this program with --train parameter first!");
            }
            string jsonFile = File.ReadAllText(trainedFile);
            markov = JsonSerializer.Deserialize<Dictionary<char, Dictionary<char, int>>>(jsonFile)
                        ?? throw new Exception("Something went wrong with getting values from trained data!\n" +
                                            "Check if you trained data correctly!");

        }
    }
}
