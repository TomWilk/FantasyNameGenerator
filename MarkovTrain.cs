using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FantasyNameGenerator
{
    internal class MarkovTrain
    {
        string path = "namesRaw.txt",
               trainedFile = "trainedData.json";

        Dictionary<char, Dictionary<char, int>> markov = new Dictionary<char, Dictionary<char, int>>();
        public MarkovTrain()
        {
            if(!File.Exists(path)) 
            {
                Console.WriteLine("File does not exist");
            } 
            else
            {
                var lines = File.ReadLines(path);
                foreach(var line in lines)
                {
                    string name = "^" + line.ToString().Trim().ToLower() + "$";
                    for(int i = 0, length = name.Length - 1; i < length; i++)
                    {
                        char current = name[i];
                        char next = name[i + 1];

                        if (!markov.ContainsKey(current))
                        {
                            markov[current] = new Dictionary<char, int>();
                        }
                        if (!markov[current].ContainsKey(next))
                        {
                            markov[current][next] = 1;
                        }
                        else
                        {
                            markov[current][next]++;
                        }
                        
                    }
                }

                SaveToJson();

            }
        }

        public void SaveToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(markov, options);
            File.WriteAllText(trainedFile, jsonString);
        }

    }
}
