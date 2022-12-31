
using vuSim;
using vuSim.Factories;
using vuSim.Scheduler;

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
    teachers.Add(new Teacher(NameFactory.Instance.GetRandomFirstName(), NameFactory.Instance.GetRandomLastName(), SubjectListing.Instance.GetRandomSubject()));
}

List<Room> rooms = new List<Room> ();
for(int i=0; i < 11; i++)
{
    rooms.Add(new Room("Classroom", SubjectListing.Instance.GetRandomSubject(), (i + 1)));
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