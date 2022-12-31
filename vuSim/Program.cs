
using vuSim;
using vuSim.Scheduler;

List<Student> students = new List<Student> ();
for(int i =0; i < 10; i++)
{
    students.Add(new Student($"First{i}", $"Last{i}"));
}

List<Teacher> teachers = new List<Teacher> ();
for(int i =0;i < 4; i++)
{
    teachers.Add(new Teacher($"Teach{i}", $"TeachLast{i}", $"Subject{i}"));
}

List<Room> rooms = new List<Room> ();
for(int i=0; i < 4; i++)
{
    rooms.Add(new Room("Classroom", $"Subject{i}", (i + 1) * 20));
    rooms.Add(new Room("Classroom", $"Subject{i}", (i + 1) * 10));
}

var sections = Scheduler.CreateSections(rooms, teachers);

foreach(var sec in sections)
{
    Console.WriteLine(sec);
}