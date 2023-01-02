
using vuSim;
using vuSim.Services;

ServiceProvider sp = new ServiceProvider();

sp.AddService<INameService>(new NameService());

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
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(2), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(3), 4);

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

for (int i = 0; i < 10; i++)
{
    var term = gl.ExecuteStartOfTerm();
    stats.PrintBasicStats(term);

    gl.ExecuteEndOfTerm();

}


