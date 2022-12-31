
using vuSim;
using vuSim.Scheduler;


List<Student> students = new List<Student> ();
for(int i =0; i < 10; i++)
{
    var s = new Student($"First{i}", $"Last{i}");
    students.Add(s);
    Console.WriteLine(s);
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

var sections = Scheduler.CreateSections(rooms, teachers);

foreach(var sec in sections)
{
    Console.WriteLine(sec);
}

foreach(Student student in students)
{
    var success = Scheduler.TryScheduleStudent(student, sections);
    Console.WriteLine($"  {success} - {student.Schedule}");
}

