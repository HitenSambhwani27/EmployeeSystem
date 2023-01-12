using December_Project.DBContext;
using December_Project.Dtos;
using December_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace December_Project.Repository
{
    public class GuardRepository : IGuardRepository
    {
        private readonly AppDBContext _con;

        public GuardRepository(AppDBContext con)
        {
            _con = con;
        }
        public IEnumerable<BdgOut> BadgeOutPage()
        {
            var q = (from gd in _con.Guard
                     join ep in _con.Employee on gd.e_id equals ep.e_id
                     select new BdgOut
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
            IQueryable<Guard> query = _con.Guard.Where(x => x.employeefirstname != null);
            if(!string.IsNullOrEmpty(employeefirstname))
            {
                query = query.Where(e => e.employeefirstname.Contains(employeefirstname));
            }
            if (!string.IsNullOrEmpty(employeelastname))
            {
                query = query.Where(e => e.employeelastname.Contains(employeelastname));
            }
            //if (!(Sign==DateTime.MinValue))
            //{
            //    query = query.Where(e => e.SignIn >= SignOut);
            //}
            //if (!(EndDate == DateTime.MinValue))
            //{
            //    return _con.Guard.Where(e => e.SignOut == EndDate);
            //}

          return query; 
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
