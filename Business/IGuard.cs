using EmployeeSystem.Dtos;
using EmployeeSystem.Models;

namespace EmployeeSystem.Business
{
    public interface IGuard
    {
        public Models.Guard Addvalue(Models.Guard guard);
        public IEnumerable<Models.Guard> BadgeQueue();
        public int temp();
        public int SignOut(int TemporaryBadge);
        public IEnumerable<Models.Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate);
        public IEnumerable<BadgeOut> BadgeOutPag();
        public Models.Guard GetServerError();
    }
}
