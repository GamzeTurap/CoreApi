using DataLayer.InterfacesOfRepo;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ImplementationsRepo
{
    public class StudentRepo : Repository<Student, int>, IStudentRepo
    {
        public StudentRepo(MyContext context) : base(context)
        {

        }
    }
}
