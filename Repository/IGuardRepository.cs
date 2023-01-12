using December_Project.Dtos;
using December_Project.Models;

namespace December_Project.Repository
{
    public interface IGuardRepository
    {
        public IEnumerable<Guard> BadgeQueuePage();
        public IEnumerable<BdgOut> BadgeOutPage();
        public IEnumerable<Guard> BadgeReportPage(string employeefirstname, string employeelastname, DateTime StartDate, DateTime EndDate);
        public Guard Addvalue(Guard guard);
        public int temp();
        public int SignOut(int TemporaryBadge);
        public Guard GetServerError();

    }
}
