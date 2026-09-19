/* Что сделать в целом
 1 - Единую функцию проверки введённых значений (int/string), вместо try\catch
 2 - Cделать функцию проверки диапазона введённого значения
 */

/* Общий план
 1 - Сделать функцию добавления задач
 2 - Сделать обе функции проверок
 3 - Сделать вывод всех задач
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
        if (tasks[0] == null)
        {
            tasks[0] = task;
            lastTaskOfListTasks += 1; ;
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
                    Console.WriteLine("Ошибка! Ввели не число");
                    continue;
                }

                // Проверка, что введено 1 или 2
                if (chooseOfNewPlaceOfTaskInNewTask == 1)
                {
                    tasks[0] = tasks[1];
                    tasks[0] = task;
                }
                else if (chooseOfNewPlaceOfTaskInNewTask == 2) Console.WriteLine("Оставим на втором месте");
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
                try
                {
                    chooseOfNewPlaceOfTaskInNewTask = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка! Ввели не число");
                    continue;
                }

                // Проверка, что введено в размере от 0 до последней задачи
                if (chooseOfNewPlaceOfTaskInNewTask > 0 && chooseOfNewPlaceOfTaskInNewTask < lastTaskOfListTasks)
                {
                    
                }
                else 
                {
                    Console.WriteLine("Ошибка! ");
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