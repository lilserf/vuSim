
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
for(int i =0;i < 5; i++)
{
    teachers.Add(new Teacher($"Teach{i}", $"TeachLast{i}", Subject.Names[i%Subject.Count]));
}

List<Room> rooms = new List<Room> ();
for(int i=0; i < 7; i++)
{
    rooms.Add(new Room("Classroom", Subject.Names[i % Subject.Count], (i + 1)));
}

var sections = Scheduler.CreateSections(rooms, teachers).ToList();

foreach(var sec in sections)
{
    Console.WriteLine(sec);
}

foreach(Student student in students)
{
    var success = Scheduler.TryScheduleStudent(student, sections);
    Console.WriteLine($"  {success} - {student.Schedule}");
}

foreach(Section sec in sections)
{
    Console.WriteLine($"Section {sec} - {sec.OpenSeats} open seats!");
}