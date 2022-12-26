using Kursach_TP_Core.Context;
using Kursach_TP_Core.Models;
using Kursach_TP_Core.Forms;

namespace Kursach_TP_Core
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Start());

            //using (KursachDbContext db = new())
            //{
            //    //var Workers = db.Workers.ToList();
            //    Place place = new Place() { Id = 1, Country = "Russia", Town = "Vladimir", Index = 600000};
            //    db.Places.Add(place);

            //    Department dep0 = new Department() { Index = 600000, Operators = 0, Postmans = 0, Workers = 0, IsOpen = true, IdPlace = 1};
            //    db.Departments.Add(dep0);

            //    Worker worker0 = new Worker() { Login = "mainAdmin", Password = "123", Index = 600000, Role = 1 };
            //    db.Workers.Add(worker0);

            //    db.SaveChanges();
            //}
        }
    }
}