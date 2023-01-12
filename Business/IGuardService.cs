using December_Project.Dtos;
using December_Project.Models;

namespace December_Project.Business
{
    public interface IGuardService
    {
        public Guard Addvalue(Guard guard);
        public IEnumerable<Guard> BadgeQueue();
        public int temp();
        public int SignOut(int TemporaryBadge);
        public IEnumerable<Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate);
        public IEnumerable<BdgOut> BadgeOutPag();
        public Guard GetServerError();
    }
}
