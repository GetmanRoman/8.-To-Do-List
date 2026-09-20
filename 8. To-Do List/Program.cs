/* Что сделать в целом
 1 - Единую функцию проверки введённых значений (int/string), вместо try\catch
 2 - Cделать функцию проверки диапазона введённого значения
 */

/* Общий план
 1 - Сделать функцию добавления задач
 2 - Сделать обе функции проверок
 3 - Сделать вывод всех задач
 */

/* На завтра
 1 - почему последняя задача перезаписывает остальные
 2 - убрать линии слева или они сломаны
 3 - как мне повторить в этом проекте всё пройденное
 */

string[] tasks = new string[99]; // Пока не знаю List, т.ч. придётся сделать фиксированный размер
string name;
bool chooseOfTask = true;
int lastTaskOfListTasks = 0;
int chooseOfNewPlaceOfTaskInNewTask;

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
            // Функция для показа всех задач
            break;
        case "3":
            chooseOfTask = false;
            break;
        default:
            Console.WriteLine("Ошибка! Вы не выбрали, что сделать с задачей");
            break;

        //    Console.WriteLine("Неправельный ввод! Попробуйте снова");
    }
       
}

string AddTask(string[] tasks, string task) 
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
            Console.WriteLine($"{tasks[0]}"); // Временно
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
                    Console.WriteLine($"{tasks[0]}"); // Временно
                    Console.WriteLine($"{tasks[1]}"); // Временно
                    Console.WriteLine();
                    break;
                }
                else if (chooseOfNewPlaceOfTaskInNewTask == 2)
                {
                    lastTaskOfListTasks += 1;
                    tasks[1] = task;
                    Console.WriteLine("Задача на 2 месте");
                    Console.WriteLine($"{tasks[0]}"); // Временно
                    Console.WriteLine($"{tasks[1]}"); // Временно
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

                // Проверка, что введено число
               
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
                        // Временно
                        Console.WriteLine("Вывод смещённого массива");
                        for (int i = 0; i < task.Length; i++)
                        {
                            Console.WriteLine($"Задача {i}: {task[i]}");
                        }
                        Console.WriteLine();

                        tasks[chooseOfNewPlaceOfTaskInNewTask - 1] = task;

                        // Временно
                        Console.WriteLine("Вывод итогового массива");
                        for (int i = 0; i < task.Length; i++) 
                        {
                            Console.WriteLine($"Задача {i}: {task[i]}");
                        }
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! На этом месте ещё нет задачи");
                        continue;
                    }

            }
            // Сделать функцию вывода всех задач
            //tasks[lastTaskOfListTasks] = task;
        }
        
    }

    return "";
}

Console.WriteLine("Конец");
Console.ReadKey(); // Не трогать. Должно быть в самом конце