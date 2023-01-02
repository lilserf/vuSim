using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class NameService : INameService
    {
        internal static NameService Instance;

        static NameService()
        {
            Instance = new NameService();
        }

        List<string> m_firstNames;
        List<string> m_lastNames;
        Random m_rand = new Random();

        public string GetRandomFirstName()
        {
            return m_firstNames[m_rand.Next(m_firstNames.Count)];
        }

        public string GetRandomLastName()
        {
            return m_lastNames[m_rand.Next(m_lastNames.Count)];
        }

        public NameService()
        {
            m_firstNames = new List<string>();
            m_lastNames = new List<string>();

            using (StreamReader sr = new StreamReader("Factories/firstnames.txt"))
            {
                while (!sr.EndOfStream)
                {
                    m_firstNames.Add(sr.ReadLine()!);
                }
            }

            using (StreamReader sr = new StreamReader("Factories/lastnames.txt"))
            {
                while (!sr.EndOfStream)
                {
                    m_lastNames.Add(sr.ReadLine()!);
                }
            }
        }

    }
}
