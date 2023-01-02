
using vuSim;
using vuSim.Scheduler;
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

TeacherService teachFac = new TeacherService(sp);
sp.AddService<ITeacherService>(teachFac);
StudentService stuFac = new StudentService(sp);
sp.AddService<IStudentService>(stuFac);

// TODO this is stupid, needs its own service and not to be hardcoded
DegreeRequirements.General = new DegreeRequirements(sp);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(0), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(1), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(2), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(3), 4);

for(int i =0; i < 100; i++)
{
    stuFac.CreateNewStudent();
}

for(int i =0;i < 13; i++)
{
    teachFac.CreateNewTeacher();
}

List<Room> rooms = new List<Room> ();
for(int i=0; i < 11; i++)
{
    rooms.Add(new Room("Classroom", subjectService.GetRandomSubject(), (i + 1)));
}

var sections = Scheduler.CreateSections(rooms, teachFac.Teachers).ToList();

foreach(var student in stuFac.Students)
{
    Scheduler.TryScheduleStudent(student, sections);
}


foreach(Section sec in sections)
{
    Console.WriteLine("======================");
    Console.WriteLine($"Section {sec}:");
    foreach(var student in sec.Students)
        Console.WriteLine($"{student.Name}");
}

Console.WriteLine("Students with empty schedules:");
foreach(var student in stuFac.Students.Where(x => x.Schedule.IsEmpty()))
{
    Console.WriteLine($"{student}");
}