/* Что сделать (через объект, т.к. только так можно проверять значения)
 1 - Единую функцию проверки введённых значений (int/string), вместо try\catch
 2 - Cделать функцию проверки диапазона введённого значения
 */

/* Общий план
 1 - Сделать обе функции проверок
 2 - Проверить на работу всего
 3 - По возможности ещё улучшить
 4 - пойти делать новый To-Do лист, но уже в виде норм приложения
*/

using _8._To_Do_List;

string[] tasks = new string[99]; // Пока не знаю List, т.ч. придётся сделать фиксированный размер
string name; 
bool chooseOfTask = true; 
int lastTaskOfListTasks = 0; // Номер последнего элемента НЕ (не по коду)
int chooseOfNewPlaceOfTaskInNewTask; // Номер, куда нужно вставить новый элемент НЕ 

// ------------------------------------------------------ Вступительное
Console.WriteLine("Добро пожаловать в To-Do List!");
Console.WriteLine();

Console.Write("Введите своё имя: ");
name = Console.ReadLine();
Console.WriteLine($"Здравствуйте, {name}");
Console.WriteLine();

// ------------------------------------------------------ Выбор задачи

while (chooseOfTask)
{
    Console.WriteLine("1. Добавить задачу");
    Console.WriteLine("2. Показать все задачи");
    Console.WriteLine("3. Выход");
    Console.Write("Выберите, что сделать с задачей: ");
    var answer = Console.ReadLine();
    switch (answer) 
    {
        case "1":
            Console.WriteLine();
            Console.Write("Введите новую задачу: ");
            string newTask = Console.ReadLine();
            AddTask(tasks, newTask);
            break;
        case "2":
            ShowTasks(tasks);
            break;
        case "3":
            chooseOfTask = false;
            break;
        default:
            Console.WriteLine("Ошибка! Вы не выбрали, что сделать с задачей");
            break;
    }
       
}

void AddTask(string[] tasks, string task) 
{
    bool IsAddTaskGetTrueValues = true;

    while (IsAddTaskGetTrueValues) 
    {
        // Если у нас вообще нет задач, то естественно, новая будет первой
        if (string.IsNullOrEmpty(tasks[0])) // Была проблема, что не считывал не null, не ""
        {
            tasks[0] = task;
            lastTaskOfListTasks += 1;
            Console.WriteLine("Это будет первой задачей");
            Console.WriteLine();
            break;
        }
        // Если есть другие задачи, то на каком месте среди других она должна быть?
        else
        {
            // Если у нас всего 1 задача
            if (lastTaskOfListTasks == 1) 
            {
                Console.WriteLine("У вас всего 1 задача");
                Console.Write("Вы хотите сделать её первой или второй? Укажите число: ");

                // Проверка, что введено число
                try 
                {
                    chooseOfNewPlaceOfTaskInNewTask = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Ошибка! Ввели не число (1)");
                    continue;
                }

                // Проверка, что введено 1 или 2
                if (chooseOfNewPlaceOfTaskInNewTask == 1)
                {
                    lastTaskOfListTasks += 1;
                    tasks[0] = tasks[1];
                    tasks[0] = task;
                    Console.WriteLine("Задача на 1 месте");
                    Console.WriteLine();
                    break;
                }
                else if (chooseOfNewPlaceOfTaskInNewTask == 2)
                {
                    lastTaskOfListTasks += 1;
                    tasks[1] = task;
                    Console.WriteLine("Задача на 2 месте");
                    Console.WriteLine();
                    break;
                }    
                else
                {
                    Console.WriteLine("Ошибка! Ввели число, выходящее за диапазон");
                }
            }
            // Если у нас более 1 задачи
            else 
            {
                Console.Write("На каком месте хотите, чтобы была эта задача: ");
                Console.WriteLine();

                chooseOfNewPlaceOfTaskInNewTask = Convert.ToInt32(Console.ReadLine());

                // Проверка, что введено в размере от 0 до последней задачи
                if (chooseOfNewPlaceOfTaskInNewTask > 0 && chooseOfNewPlaceOfTaskInNewTask <= lastTaskOfListTasks)
                {
                    int LastTask = lastTaskOfListTasks - 1;
                        
                    for (int i = 0; i < lastTaskOfListTasks; i++)
                    {
                        tasks[LastTask + 1] = tasks[LastTask];
                        LastTask -= 1;
                    }

                    lastTaskOfListTasks += 1;
                    tasks[chooseOfNewPlaceOfTaskInNewTask - 1] = task;
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! На этом месте ещё нет задачи");
                    continue;
                }
            }
        }
        
    }

}

void ShowTasks(string[] tasks) 
{
    if (string.IsNullOrEmpty(tasks[0]))
    {
        Console.WriteLine("Задач нет");
        Console.WriteLine();
    }
    else 
    {
        for (int i = 0; i < lastTaskOfListTasks; i++)
        {
            Console.WriteLine($"Задача {i + 1}: {tasks[i]}");
        }
        Console.WriteLine();
    }
}

// Скорее всего удалю
//void isValidType(var inputValue, )
//{

//}

//void isValidRange() 
//{

//}