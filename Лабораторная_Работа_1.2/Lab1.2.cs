using System;
using System.Collections.Generic;

/// <summary>
/// Базовый стандартный класс для студентов
/// </summary>
class Student
{
    /// <summary>
    /// Получаем или устанавливаем имя студента
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Получаем или устанавливаем фамилию студента
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Получаем или устанавливаем возраст студента
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Конструктор для создания экземпляра нового студента
    /// </summary>
    /// <param name="firstName">Имя студента</param>
    /// <param name="lastName">Фамилия студента</param>
    /// <param name="age">Возраст студента</param>
    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    /// <summary>
    /// Отображение информации о данном студенте
    /// </summary>
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName}, возраст: {Age} лет");
    }

    /// <summary>
    /// Редактирование информации о данном студенте
    /// </summary>
    public virtual void EditInfo()
    {
        Console.Write("Введите новое имя: ");
        FirstName = Console.ReadLine();
        Console.Write("Введите новую фамилию: ");
        LastName = Console.ReadLine();
        Console.Write("Введите новый возраст: ");
        Age = int.Parse(Console.ReadLine());
    }
}

/// <summary>
/// Класс для старосты группы, наследующий от базового класса данного студента
/// </summary>
class HeadStudent : Student
{
    /// <summary>
    /// Конструктор для создания экземпляра старосты.
    /// </summary>
    /// <param name="firstName">Имя старосты</param>
    /// <param name="lastName">Фамилия старосты</param>
    /// <param name="age">Возраст старосты</param>
    public HeadStudent(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
    }

    /// <summary>
    /// Переопределенный метод для отображения информации о данном старосте
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"Староста: {FirstName} {LastName}, возраст: {Age} лет");
    }

    /// <summary>
    /// Переопределенный метод для редактирования информации о данном старосте
    /// </summary>
    public override void EditInfo()
    {
        Console.Write("Введите новое имя старосты: ");
        FirstName = Console.ReadLine();
        Console.Write("Введите новую фамилию старосты: ");
        LastName = Console.ReadLine();
        Console.Write("Введите новый возраст старосты: ");
        Age = int.Parse(Console.ReadLine());
    }
}

/// <summary>
/// Класс для представления данной студенческой группы
/// </summary>
class StudentGroup
{
    /// <summary>
    /// Получает или устанавливает название данной группы
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// Получает или устанавливает список студентов в этой группе
    /// </summary>
    public List<Student> Students { get; set; }

    /// <summary>
    /// Получает или устанавливает старосту этой группы
    /// </summary>
    public HeadStudent GroupHead { get; set; }

    /// <summary>
    /// Конструктор для создания экземпляра данной группы
    /// </summary>
    /// <param name="groupName">Название группы</param>
    public StudentGroup(string groupName)
    {
        GroupName = groupName;
        Students = new List<Student>();
    }

    /// <summary>
    /// Отображение информации о данной группе
    /// </summary>
    public void DisplayGroupInfo()
    {
        Console.WriteLine($"Группа: {GroupName}");
        Console.WriteLine("Список студентов:");

        foreach (var student in Students)
        {
            student.DisplayInfo();
        }

        if (GroupHead != null)
        {
            GroupHead.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Нет информации о старосте");
        }
    }

    /// <summary>
    /// Редактирование информации о данной группе, включая старосту
    /// </summary>
    public void EditGroupInfo()
    {
        Console.Write("Введите новое название группы: ");
        GroupName = Console.ReadLine();

        if (GroupHead != null)
        {
            Console.WriteLine("Редактирование данных старосты:");
            GroupHead.EditInfo();
        }
        else
        {
            Console.WriteLine("Старосты нет. Добавьте старосту.");

            GroupHead = new HeadStudent("", "", 0);
            Console.WriteLine("Редактирование данных старосты:");
            GroupHead.EditInfo();

            Students.Add(GroupHead);
        }
    }
}

/// <summary>
/// Основной класс программы
/// </summary>
class Lab1_2
{
    static void Main(string[] args)
    {
        /// Пример использования классов и методов ///
        Student student1 = new Student("Никита", "Турда", 18);
        Student student2 = new Student("Кирилл", "Кукса", 19);
        HeadStudent headStudent = new HeadStudent("Антон", "Закопайло", 17);

        StudentGroup group = new StudentGroup("Группа 1");
        group.Students.Add(student1);
        group.Students.Add(student2);
        group.GroupHead = headStudent;

        /// Вывод всей полученной информации в консоль ///
        Console.WriteLine("Режим отображения данных:\n");
        group.DisplayGroupInfo();

        Console.WriteLine("\nРежим редактирования данных:\n");
        group.EditGroupInfo();

        Console.WriteLine("\nПосле редактирования:\n");
        group.DisplayGroupInfo();
    }
}