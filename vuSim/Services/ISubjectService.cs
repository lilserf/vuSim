using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal interface ISubjectService
    {
        public void AddSubject(Subject subject);
        public Subject GetSubjectById(int id);
        public Subject GetRandomSubject();

    }
}
