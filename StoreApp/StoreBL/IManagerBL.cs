﻿using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IManagerBL
    {
        void AddManager(Manager newManager);
        Manager DeleteManager(Manager manager2BDeleted);
        Manager GetManagerByEmail(string email);
        List<Manager> GetManagers();
    }
}