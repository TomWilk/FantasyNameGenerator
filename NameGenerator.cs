﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FantasyNameGenerator
{
    internal class NameGenerator
    {
        const string trainedFile = "trainedData.json";
        const string startingCharacter = "^^";
        const char endingCharacter = '$';
        Dictionary<string, Dictionary<char, int>> markov;
        public NameGenerator()
        {
            if (!File.Exists(trainedFile))
            {
                throw new FileNotFoundException("File with trained data doesn't exist!\n" +
                                                "Run this program with --train parameter first!");
            }
            string jsonFile = File.ReadAllText(trainedFile);
            markov = JsonSerializer.Deserialize<Dictionary<string, Dictionary<char, int>>>(jsonFile)
                        ?? throw new Exception("Something went wrong with getting values from trained data!\n" +
                                               "Check if you trained data correctly!");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(generateName());
            }
        }

        string generateName()
        {
            string name = "";
            char character = '\0';
            string nextKey = startingCharacter;
            var options = markov[nextKey];
            int total, choice, cumulative;
            Random rand = new Random();
            while (true)
            {
                total = options.Values.Sum();
                choice = rand.Next(0, total);
                cumulative = 0;
                foreach (var pair in options)
                {
                    cumulative += pair.Value
                        ;
                    if (choice < cumulative)
                    {
                        if (pair.Key == endingCharacter && name.Length < 3)
                        {
                            continue;
                        }
                        character = pair.Key;
                        break;
                    }
                }
                if (character == endingCharacter)
                {
                    break;
                }
                if (name.Length < 1)
                {
                    name += Char.ToUpper(character);
                }
                else
                {
                    name += character;
                }
                nextKey = nextKey[1].ToString() + character.ToString();
                if (markov.ContainsKey(nextKey))
                {
                    options = markov[nextKey];
                }
                else
                {
                    options = markov[character.ToString()];
                }
            }

            return name;
        }
    }
}
