using EmployeeSystem.DBContext;
using EmployeeSystem.Dtos;
using EmployeeSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Repository
{
    public class GuardRep : IGuardRep
    {
        private readonly AppDBContext _con;

        public GuardRep(AppDBContext con)
        {
            _con = con;
        }
        public IEnumerable<BadgeOut> BadgeOutPage()
        {
            var q = (from gd in _con.Guard
                     join ep in _con.Employee on gd.e_id equals ep.e_id
                     select new BadgeOut
                     {
                         employeefirstname = gd.employeefirstname,
                         employeelastname = gd.employeelastname,
                         TemporaryBadge = gd.TemporaryBadge,
                         SignIn = gd.SignIn,
                         SignOut = gd.SignOut,
                         AssignTime = gd.AssignTime,
                         PhotoUrl = ep.PhotoUrl,
                     });
            return q;

        }

        public IEnumerable<Guard> tempbdge(Guard guard)
        {
            //_con.Guard.Add(guard);
            throw new NotImplementedException();

        }

        public IEnumerable<Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate)
        {
            DateTime myDate = DateTime.ParseExact("01-01-0001 00:00:00", "dd-MM-yyyy HH:mm:ss",
            System.Globalization.CultureInfo.InvariantCulture);
            IQueryable<Guard> a = _con.Guard.Where(e => e.employeefirstname != null);
            if (!string.IsNullOrEmpty(employeefirstname))
            {
                a = a.Where(e => e.employeefirstname.Contains(employeefirstname));
            }

            if (!string.IsNullOrEmpty(employeelastname))
            {
                a = a.Where(e => e.employeelastname.Contains(employeelastname));
            }
            if (EndDate != myDate && StartDate == myDate)
            {
                a = a.Where(e => e.SignIn <= EndDate);
            }
            if (StartDate != myDate && EndDate == myDate)
            {
                a = a.Where(e => e.SignIn >= StartDate);
            }
            if (StartDate != myDate && EndDate != myDate)
            {
                a = a.Where(e => e.SignIn >= StartDate && e.SignIn <= EndDate);
            }

            return a.ToList();

        }

        public IEnumerable<Guard> BadgeQueuePage()
        {
            return _con.Guard.ToList();
        }

        public int temp()
        {
            var c = _con.Guard.OrderByDescending(x => x.TemporaryBadge).FirstOrDefault();

            return c.TemporaryBadge;
         }
        public Guard Addvalue(Guard guard)
        {
            _con.Guard.Add(guard);
            _con.SaveChanges();
            return guard;
        }
        public int SignOut(int TemporaryBadge)
        {
            var a = _con.Guard.Where(x => x.TemporaryBadge == TemporaryBadge).FirstOrDefault();
            a.SignOut = DateTime.Now;
            _con.Guard.Update(a);
            return _con.SaveChanges();
        }
        public Guard GetServerError()
        {
            var thing = _con.Guard.Find(-1);
            return thing;
        }
    }
}
