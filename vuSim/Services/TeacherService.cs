﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuSim.Services
{
    internal class TeacherService : ITeacherService
    {
        List<Teacher> m_teachers = new List<Teacher>();
        public IEnumerable<Teacher> Teachers => m_teachers;

        private INameService m_nameService;
        private ISubjectService m_subjectService;
        public TeacherService(IServiceProvider services)
        {
            services.Inject(out m_nameService);
            services.Inject(out m_subjectService);
        }

        public Teacher CreateNewTeacher()
        {
            Teacher t = new Teacher(m_nameService.GetRandomFirstName(), m_nameService.GetRandomLastName(), m_subjectService.GetRandomSubject());
            m_teachers.Add(t);
            return t;
        }
    }
}
