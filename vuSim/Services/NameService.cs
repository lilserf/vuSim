using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class NameService : INameService
    {
        List<string> m_firstNames;
        List<string> m_lastNames;
        List<string> m_nouns;
        Random m_rand = new Random();

        const int NOUN_CHANCE = 20;

        public (string, string) GetRandomName()
        {
            bool firstIsNoun = m_rand.Next(100) <= NOUN_CHANCE;
            bool lastIsNoun = m_rand.Next(100) <= NOUN_CHANCE;

            string first = firstIsNoun ? GetRandomNoun() : GetRandomFirstName();
            string last = lastIsNoun ? GetRandomNoun() : GetRandomLastName();

            return (first, last);
        }

        public string GetRandomNoun()
        {
            return m_nouns[m_rand.Next(m_nouns.Count())];
        }

        public string GetRandomFirstName()
        {
            return m_firstNames[m_rand.Next(m_firstNames.Count)];
        }

        public string GetRandomLastName()
        {
            return m_lastNames[m_rand.Next(m_lastNames.Count)];
        }

        List<string> GetFileAsList(string path)
        {
            List<string> list = new();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine()!);
                }
            }
            return list;
        }

        public NameService()
        {
            m_firstNames = GetFileAsList("Factories/firstnames.txt");
            m_lastNames = GetFileAsList("Factories/lastnames.txt");
            m_nouns = GetFileAsList("Factories/nouns.txt");
        }

    }
}
