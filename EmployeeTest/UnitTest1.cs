
using EmployeeSystem.Business;
using EmployeeSystem.Models;
using EmployeeSystem.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeTest
{

    public class UnitTest1
    {
        private readonly Mock<IGuardRep> _guard;

        public UnitTest1()
        {
            _guard = new Mock<IGuardRep>();

        }
   
        public List<EmployeeSystem.Models.Guard> newRec1()
        {
            List<EmployeeSystem.Models.Guard> newRec = new List<EmployeeSystem.Models.Guard>
            {
                new EmployeeSystem.Models.Guard()
                {
                    employeefirstname = "Hiten",
                    employeelastname = "Sam",
                    TemporaryBadge = 201,
                    SignIn = DateTime.Now,
                    e_id = 1
                },
                 new EmployeeSystem.Models.Guard()
                {
                    employeefirstname = "Raj",
                    employeelastname = "Sam",
                    TemporaryBadge = 202,
                    SignIn = DateTime.Now,
                    e_id = 2
                }

            };
            return newRec;
        }
        //hhh


        [Fact]
        public void queue_req_Test1()
        {
            var data1 = newRec1();
            _guard.Setup(e => e.Addvalue(data1[0])).Returns(data1[0]);

            var q = new EmployeeSystem.Business.Guard(_guard.Object);

            var result = q.Addvalue(data1[0]);


            Assert.IsType<EmployeeSystem.Models.Guard>(result);
            Assert.True(result == data1[0]);

        }





    }
}

