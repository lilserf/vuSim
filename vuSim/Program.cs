
using vuSim;
using vuSim.Factories;
using vuSim.Scheduler;
using vuSim.Services;

ServiceProvider sp = new ServiceProvider();

// TODO this is temp code
var subjectService = new SubjectService();
subjectService.AddSubject(new Subject("Math", "MAT"));
subjectService.AddSubject(new Subject("English", "ENG"));
subjectService.AddSubject(new Subject("Science", "SCI"));
subjectService.AddSubject(new Subject("Social Studies", "SOC"));
sp.AddService<ISubjectService>(subjectService);

// TODO this is stupid, needs its own service and not to be hardcoded
DegreeRequirements.General = new DegreeRequirements(sp);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(0), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(1), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(2), 4);
DegreeRequirements.General.AddRequirement(subjectService.GetSubjectById(3), 4);


StudentFactory stuFac = new StudentFactory();

List<Student> students = new List<Student> ();
for(int i =0; i < 100; i++)
{
    var s = stuFac.CreateStudent();
    students.Add(s);
}

List<Teacher> teachers = new List<Teacher> ();
for(int i =0;i < 13; i++)
{
    teachers.Add(new Teacher(NameService.Instance.GetRandomFirstName(), NameService.Instance.GetRandomLastName(), subjectService.GetRandomSubject()));
}

List<Room> rooms = new List<Room> ();
for(int i=0; i < 11; i++)
{
    rooms.Add(new Room("Classroom", subjectService.GetRandomSubject(), (i + 1)));
}

var sections = Scheduler.CreateSections(rooms, teachers).ToList();

foreach(var student in students)
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
foreach(var student in students.Where(x => x.Schedule.IsEmpty()))
{
    Console.WriteLine($"{student}");
}