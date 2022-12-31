using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Factories
{
    internal class NameFactory
    {
        internal static NameFactory Instance;

        static NameFactory()
        {
            Instance = new NameFactory();
        }

        List<string> m_firstNames;
        List<string> m_lastNames;
        Random m_rand = new Random();

        internal string GetRandomFirstName()
        {
            return m_firstNames[m_rand.Next(m_firstNames.Count)];
        }

        internal string GetRandomLastName()
        {
            return m_lastNames[m_rand.Next(m_lastNames.Count)];
        }

        public NameFactory()
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
