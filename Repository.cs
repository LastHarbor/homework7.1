using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic;




namespace HomeWork7._1
{
    class Repository
    {
        private string[] titles;//Массив заголовков
        private Worker[] Workers; //Массив сотрудников
        int index; // индекс сотрудника
        /// <summary>
        /// Конструктор Repository
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public Repository(string path)
        {
            this.path = path;
            this.titles = new string[0];
            this.Workers = new Worker[1];
            this.index = 0;
        }
        private string path;

        
        #region MainMehtods
        /// <summary>
        /// Метод, создающий сотрудника вручную
        /// </summary>
        /// <param name="worker">Объект структуры Worker</param>
        public void CreateWorker(Worker worker)
        {

            using (StreamWriter sw = new StreamWriter(this.path, true, Encoding.Unicode))
            {
                worker.ID = Count++;
                worker.Date = DateTime.Now;
                Console.WriteLine("Введите имя - ");
                worker.Name = Console.ReadLine();
                Console.WriteLine("Введите возраст - ");
                worker.Age = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Введите рост - ");
                worker.Height = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Введите дату рождения ");
                worker.Birthday = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите место рождения - ");
                worker.Locate = Console.ReadLine();
                sw.WriteLine($"{worker.ID}#\t{worker.Date}#\t{worker.Name}#\t{worker.Age}#\t{worker.Height}#\t{worker.Birthday}#\t{worker.Locate}#\t");
            }
        }
        /// <summary>
        /// Метод получения списка Workers
        /// </summary>
        public void GetWorkers()
        {
            Console.WriteLine($"{this.titles[0],15} {this.titles[1],15} {this.titles[2],15} {this.titles[3],15} {this.titles[4],15} {this.titles[5],15} {this.titles[6],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.Workers[i].Print());
            }
        }
       /// <summary>
       /// Проверка существования файла
       /// </summary>
        public void IsFileExist()
        {
            if (!File.Exists(this.path))
            {
                string title = "ID, Дата создания, ФИО, Возраст, Рост, Дата рождения, Место рождения ";
                File.AppendAllText(path, title, Encoding.Unicode);
            }
        }
       
       public Worker GetWorkerByID()
        {
            Console.Write("Введите ID сотрудника, которого вы хотите найти: ");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Workers.Length; i++)
            {

            }

        }
        #endregion
       
        #region Other methods
        /// <summary>
        /// Загрузка БД
        /// </summary>
        public void LoadDB()
        {
            using (StreamReader sr = new StreamReader(this.path, Encoding.Unicode))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    AddWorker(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2],
                        Convert.ToByte(args[3]), Convert.ToByte(args[4]), Convert.ToDateTime(args[5]), args[6]));
                }
                sr.Close();
            }
        }

        /// <summary>
        /// МЕтод расширения места для Workers
        /// </summary>
        /// <param name="flag"></param>
        private void GetMoreSpace(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.Workers, this.Workers.Length * 2);
            }
        }
        public void AddWorker(Worker worker)
        {
            this.GetMoreSpace(index >= this.Workers.Length);
            this.Workers[index] = worker;
            this.index++;
        }

        /// <summary>
        /// Счётчик кол-ва сотрудников
        /// </summary>
        public int Count
        {
            get { return this.index; }
            set { this.index = value; }
        }
        /// <summary>
        /// Создание n-ного кол-ва сотрудниуков
        /// </summary>
        /// <param name="workerTest"></param>
        public void CreateTestWorkers(Worker workerTest)
        {
            Random r = new Random();
            Console.WriteLine("Сколько тестовых сотрудников вы хотите создать?");
            int test1 = Convert.ToInt32(Console.ReadLine());
            string[] names =
            {
                "Александр", "Алексей", "Анатолий", "Андрей", "Антон", "Аркадий", "Артем", "Борислав", "Вадим",
                "Валентин", "Валерий", "Василий", "Виктор",
                "Виталий", "Владимир", "Вячеслав", "Геннадий", "Георгий", "Григорий", "Даниил", "Денис", "Дмитpий",
                "Евгений"
            };
            string[] city = { "Абакан", "Азов", "Александров", "Алексин", "Альметьевск", "Анапа", "Ангарск", "Анжеро-Судженск",
                "Апатиты", "Арзамас", "Армавир", "Арсеньев", "Артем", "Архангельск", "Асбест", "Астрахань", "Ачинск", "Великие Луки"};

            for (int i = 0; i < test1; i++)
            {
                using (StreamWriter sw = new StreamWriter(this.path, true, Encoding.Unicode))
                {
                    workerTest.ID = i;
                    workerTest.Date = DateTime.Now;
                    workerTest.Name = names[new Random().Next(0, names.Length)];
                    workerTest.Age = Convert.ToByte(r.Next(21, 65));
                    workerTest.Height = Convert.ToByte(r.Next(120, 210));
                    workerTest.Birthday = GetRandomeDate();
                    workerTest.Locate = city[new Random().Next(0, city.Length)];
                    sw.WriteLine($"{workerTest.ID}#\t{workerTest.Date}#\t{workerTest.Name}#\t{workerTest.Age}#\t{workerTest.Height}#\t{workerTest.Birthday}#\t{workerTest.Locate}#\t");
                }
                AddWorker(new Worker());
            }
        }
        /// <summary>
        /// Генератор рандомной даты
        /// </summary>
        /// <returns></returns>
        private DateTime GetRandomeDate()
        {
            var rnd = new Random();
            var startDate = new DateTime(2001, 1, 1);
            Console.WriteLine(startDate.ToString("yyyy.dd.MM"));
            var newDate = startDate.AddDays(rnd.Next(366));
            Console.WriteLine(newDate.ToString("yyyy.dd.MM"));
            return newDate;
        }
        #endregion
        
    }
}
#region Shit
//List<Worker> Workers = new List<Worker>();
// Workers.Append(new Worker(Convert.ToInt32(employers[0]), Convert.ToDateTime(employers[1]),
//    employers[2], Convert.ToByte(employers[3]), Convert.ToByte(employers[4]), Convert.ToDateTime(employers[5]), 
//    employers[6]));
//using (StreamWriter sw = new StreamWriter(path, true))
//{
//    //var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
//    //{
//    //    Delimiter = "#"// указываем разделитель, который будет использоваться в файле                           НЕ РАБОЧИЙ МЕТОД
//    //};
//    //using (var csv = new CsvWriter(sw,csvConfig))
//    //{
//    //    foreach (var employeers in Workers)
//    //    {
//    //        csv.WriteRecord(employeers);
//    //    }

//    //}
//}
//for (int i = 0; i < countofworkers; i++)
//    sw.WriteLine(workers[i].ID + "#" + workers[i].Date + "#" + workers[i].Name + "#" + workers[i].Age +           ТОЖЕ НЕ РАБОЧИЙ МЕТОД
//    "#" + workers[i].Height + "#" + workers[i].Birthday + "#"
//    + workers[i].Locate);

//StringBuilder scv = new StringBuilder();
//for (int i = 0; i <countofworkers; i++)
//{
//    scv.AppendLine(workers[i].ID + workers[i].Name + workers[i].Date + workers[i].Age + workers[i].Height + workers[i].Birthday + workers[i].Locate);
//    File.AppendAllText(path, scv.ToString());
//}

#endregion