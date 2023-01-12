using December_Project.Dtos;
using December_Project.Models;
using December_Project.Repository;

namespace December_Project.Business
{
    public class GuardService : IGuardService
    {
        private readonly IGuardRepository _guard;

        public  GuardService(IGuardRepository guard)
        {
            _guard = guard;
        }

        public Guard Addvalue(Guard guard)
        {
            return _guard.Addvalue(guard);
        }
        public IEnumerable<Guard> BadgeQueue()
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
        public IEnumerable<Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate)
        {
            return _guard.BadgeReportPage(employeefirstname, employeelastname, StartDate, EndDate);
        }
        public IEnumerable<BdgOut> BadgeOutPag()
        {
            return _guard.BadgeOutPage();
        }
        public Guard GetServerError()
        {
            return _guard.GetServerError();
        }
    }

}
