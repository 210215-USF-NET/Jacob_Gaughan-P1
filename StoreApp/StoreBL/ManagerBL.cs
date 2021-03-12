using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class ManagerBL : IManagerBL
    {
        private IManagerRepository _repo;
        public ManagerBL(IManagerRepository repo)
        {
            _repo = repo;
        }
        public Manager AddManager(Manager newManager)
        {
            return _repo.AddManager(newManager);
        }

        public List<Manager> GetManagers()
        {
            return _repo.GetManagers();
        }

        public Manager GetManagerByEmail(string email)
        {
            return _repo.GetManagerByEmail(email);
        }

        public Manager DeleteManager(Manager manager2BDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
