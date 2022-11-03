using HomeWork7._1;

namespace homework7._1
{
    internal class Programm
    {
        static void Main()
        {
            string path = "DateBase.csv";
            Console.WriteLine("Нажмите 1 - для записи");
            Console.WriteLine("Нажмите 2 - для удаления");
            Console.WriteLine("Нажмите 3 - для просмотра списка сотрудников");
            Console.WriteLine("Нажмите 4 - для создания списка тестовых сотрудников");
            Console.WriteLine("Нажмите 5 - для вывода сотрудника по ID");
            sbyte switcher = Convert.ToSByte(Console.ReadLine());
            switch (switcher)
            {
                case 1:
                    Repository rep = new Repository(path);
                    rep.IsFileExist();
                    Console.Clear();
                    rep.LoadDB();
                    rep.CreateWorker(new Worker());
                    //rep.AddWorker(new Worker());
                    //Console.WriteLine("Продолжить?");
                    break;
                case 2:
                    File.Delete(path);
                    Main();
                    break;

                case 3:
                    Console.Clear();
                    Repository rep2 = new Repository(path);
                    rep2.LoadDB();
                    rep2.GetWorkers();
                    //Console.WriteLine(repo.Count); обозначить свойство Count как публичное, чтобы узнать количество сотрудников
                    Console.WriteLine(rep2.Count);
                    break;
                case 4:
                    var rep3 = new Repository(path);
                    rep3.IsFileExist();
                    rep3.LoadDB();
                    rep3.CreateTestWorkers(new Worker());
                    Console.Clear();
                    Main();
                    break;
                case 5:
                    var rep4 = new Repository(path);
                    rep4.LoadDB();
                    rep4.GetWorkerByID(new Worker());
                    Console.ReadLine();
                    break;
                    

            }
        }
    }
}