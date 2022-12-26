using Kursach_TP_Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_TP_Core.Forms.Admin
{
    internal class Admin_
    {
        public string CheckDepartment()
        {
            string result = "", operators = "\n\nОператоры:\n", postmans = "\n\nПочтальоны:\n";

            using (KursachDbContext db = new())
            {
                //Основная информация об отделении
                var departments = db.Departments.ToList();
                foreach (var department in departments)
                {
                    if (department.Index == index)
                    {
                        result += "Индекс отделения: " + department.Index +
                            "\nКоличество операторов: " + department.Operators +
                            "\nКоличество почтальонов: " + department.Postmans +
                            "\nКоличество рабочих в целом: " + department.Workers;
                        if (department.IsOpen)
                            result += "\nСтатус отделения: открыто";
                        else
                            result += "\nСтатус отделения: закрыто";

                        //Ищем место расположения отделения
                        var places = db.Places.ToList();
                        foreach (var place in places)
                        {
                            if (department.IdPlace == place.Id)
                            {
                                result += "\nРасположение отделения: страна: " + place.Country +
                                    " город: " + place.Town;
                                break;
                            }
                        }
                        break;
                    }
                }

                //Информация о работниках в отделении
                var workers = db.Workers.ToList();
                foreach (var worker in workers)
                {
                    if (worker.Index == index)
                    {
                        if (worker.Role == 2)
                            operators += worker.Login + '\n';
                        else if (worker.Role == 3)
                            postmans += worker.Login + '\n';
                    }
                }

                result += operators + postmans;
                return result;
            }
        }

        public bool OpenCloseDep()
        {
            using(KursachDbContext db = new())
            {
                var departments = db.Departments.ToList();

                foreach (var department in departments)
                {
                    if (department.Index == index)
                    {
                        department.IsOpen = !department.IsOpen;
                        db.Update(department);
                        db.SaveChanges();
                        return department.IsOpen;
                    }
                }

                //Недостижимо
                return false;
            }
        }

        public bool CreateOperator(string login, string password)
        {
            using (KursachDbContext db = new())
            {
                var workers = db.Workers.ToList();

                //Поиск уже существующего работника
                foreach (var worker in workers)
                {
                    if (worker.Login == login)
                        return false;
                }

                //Создание работника
                var worker_ = new Worker() { Index = index, Login = login, Password = password, Role = 2};
                db.Workers.Add(worker_);

                //Инкремент количества операторов и работников в отделении
                var departments = db.Departments.ToList();
                foreach (var department in departments)
                {
                    if (department.Index == index)
                    {
                        department.Operators++;
                        department.Workers++;
                        db.Update(department);
                        break;
                    }
                }

                db.SaveChanges();
                return true;
            }
        }

        public bool CreatePostman(string login, string password)
        {
            using (KursachDbContext db = new())
            {
                var workers = db.Workers.ToList();

                //Поиск уже существующего работника
                foreach (var worker in workers)
                {
                    if (worker.Login == login)
                        return false;
                }

                //Создание работника
                var worker_ = new Worker() { Index = index, Login = login, Password = password, Role = 3 };
                db.Workers.Add(worker_);

                //Инкремент количества почтальонов и работников в отделении
                var departments = db.Departments.ToList();
                foreach (var department in departments)
                {
                    if (department.Index == index)
                    {
                        department.Postmans++;
                        department.Workers++;
                        db.Update(department);
                        break;
                    }
                }

                db.SaveChanges();
                return true;
            }
        }

        public int DeleteWorker(string login)
        {
            using (KursachDbContext db = new())
            {
                var workers = db.Workers.ToList();

                //Находим нужного работника
                foreach (var worker in workers)
                {
                    if (worker.Login == login)
                    {
                        //Проверка на отделение
                        if (worker.Index != index)
                            return 2;

                        db.Workers.Remove(worker);

                        //Декрементируем в отделении количество работников
                        var departments = db.Departments.ToList();

                        foreach (var department in departments)
                        {
                            if (department.Index == index)
                            {
                                department.Workers--;
                                if (worker.Role == 2)
                                    department.Operators--;
                                else
                                    department.Postmans--;

                                db.Update(department);
                                db.SaveChanges();
                                return 1;
                            }
                        }
                    }
                }

                return 0;
            }
        }

        public static int index;
    }
}