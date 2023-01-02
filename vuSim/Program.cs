
using vuSim;
using vuSim.Services;

ServiceProvider sp = new ServiceProvider();

sp.AddService<INameService>(new NameService());
var timeService = new TimeService();
sp.AddService<ITimeService>(timeService);

// TODO this is temp code
var subjectService = new SubjectService();
subjectService.AddSubject(new Subject("Math", "MAT"));
subjectService.AddSubject(new Subject("English", "ENG"));
subjectService.AddSubject(new Subject("Science", "SCI"));
subjectService.AddSubject(new Subject("Social Studies", "SOC"));
sp.AddService<ISubjectService>(subjectService);

TeacherService teacherService = new TeacherService(sp);
sp.AddService<ITeacherService>(teacherService);
StudentService studentService = new StudentService(sp);
sp.AddService<IStudentService>(studentService);
RoomService roomService = new RoomService(sp);
sp.AddService<IRoomService>(roomService);
SectionService sectionService = new SectionService(sp);
sp.AddService<ISectionService>(sectionService);

StatPrinter stats = new StatPrinter(sp);

// TODO this is stupid, needs its own service and not to be hardcoded
DegreeRequirements.General = new DegreeRequirements(sp);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(0), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(1), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(2), 3);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(3), 2);

for(int i =0; i < 100; i++)
{
    studentService.CreateNewStudent();
}

for(int i =0;i < 13; i++)
{
    teacherService.CreateNewTeacher();
}

for(int i=0; i < 11; i++)
{
    roomService.AddRoom(new Room("Classroom", subjectService.GetRandomSubject(), (i + 1)));
}

GameLoop gl = new GameLoop(sp);

while(studentService.Students.Count() > 0)
{
    gl.ExecuteStartOfTerm();
    stats.PrintBasicStats(timeService.Term);

    gl.ExecuteEndOfTerm();
    stats.PrintStudentTermHistogram();
}

using (StreamWriter sw = new StreamWriter("student-events.log"))
{
    sw.WriteLine("Graduates:\n");
    foreach(var student in studentService.Graduates)
    {
        sw.WriteLine(student.ToString());
        foreach(var (term, tick, line) in student.Events.Events)
        {
            sw.WriteLine($"{term}:{tick} {line}");
        }
        sw.WriteLine();
    }

    sw.WriteLine("Students:\n");
    foreach (var student in studentService.Students)
    {
        sw.WriteLine(student.ToString());
        foreach (var (term, tick, line) in student.Events.Events)
        {
            sw.WriteLine($"{term}:{tick} {line}");
        }
        sw.WriteLine();
    }

}
