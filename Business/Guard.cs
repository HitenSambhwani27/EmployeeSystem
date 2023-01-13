using EmployeeSystem.Dtos;
using EmployeeSystem.Models;
using EmployeeSystem.Repository;

namespace EmployeeSystem.Business
{
    public class Guard : IGuard
    {
        private readonly IGuardRep _guard;

        public  Guard(IGuardRep guard)
        {
            _guard = guard;
        }

        public Models.Guard Addvalue(Models.Guard guard)
        {
            return _guard.Addvalue(guard);
        }
        public IEnumerable<Models.Guard> BadgeQueue()
        {
            
            return _guard.BadgeQueuePage();
        }
        public int temp()
        {
            return _guard.temp();
        }
        public int SignOut(int TemporaryBadge)
        {
            return _guard.SignOut(TemporaryBadge);
        }
        public IEnumerable<Models.Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate)
        {
            return _guard.BadgeReportPage(employeefirstname, employeelastname, StartDate, EndDate);
        }
        public IEnumerable<BadgeOut> BadgeOutPag()
        {
            return _guard.BadgeOutPage();
        }
        public Models.Guard GetServerError()
        {
            return _guard.GetServerError();
        }
    }

}
