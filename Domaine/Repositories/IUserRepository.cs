using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> Handle();


    }
}
