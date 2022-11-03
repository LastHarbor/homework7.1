using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7._1
{
    struct Worker
    {

        #region Конструктор

        /// <summary>
        /// Конструктор сотрудника
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="Date">Дата добавления</param>
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Height">Рост</param>
        /// <param name="Birthday">Дата рождения</param>
        /// <param name="Locate">Место рождения</param>
        public Worker(int ID, DateTime Date, string Name, byte Age, byte Height, DateTime Birthday,
            string Locate) : this()
        {
            this.id = ID;
            this.date = Date;
            this.name = Name;
            this.age = Age;
            this.height = Height;
            this.birthday = Birthday;
            this.locate = Locate;
        }
        #endregion

        #region Свойства

        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public byte Height { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Место Рождения
        /// </summary>
        public string Locate { get; set; }
        #endregion

        #region Поля
        /// <summary>
        /// Поле "ID"
        /// </summary>
        private int id;
        /// <summary>
        ///Поле "Время создания"
        /// </summary>
        private DateTime date;
        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private string name;
        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private byte age;
        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private byte height;
        /// <summary>
        /// Поле "Дата рождения"
        /// </summary>
        private DateTime birthday;
        /// <summary>
        /// Поле "Место рождения"
        /// </summary>
        private string locate;
        #endregion

        #region Методы

        public string  Print()
        {
            return $"{id,15} {date,15} {name,15} {age,15} {height,15} {birthday,15} {locate,10}";
        }
        #endregion
    }
}