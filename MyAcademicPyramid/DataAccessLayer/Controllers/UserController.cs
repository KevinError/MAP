using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Controllers
{
    public static class UserController
    {
        public static IEnumerable<User> Get()
        {
            MyAcademicPyramidEntities entities = new MyAcademicPyramidEntities();
            return entities.Users.ToList();
        }

        public static User Get(string email)
        {
            MyAcademicPyramidEntities entities = new MyAcademicPyramidEntities();
            return entities.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
