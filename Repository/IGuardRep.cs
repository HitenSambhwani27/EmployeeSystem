using EmployeeSystem.Dtos;
using EmployeeSystem.Models;

namespace EmployeeSystem.Repository
{
    public interface IGuardRep
    {
        public IEnumerable<Guard> BadgeQueuePage();
        public IEnumerable<BadgeOut> BadgeOutPage();
        public IEnumerable<Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate);
        public Guard Addvalue(Guard guard);
        public int temp();
        public int SignOut(int TemporaryBadge);
        public Guard GetServerError();

    }
}
