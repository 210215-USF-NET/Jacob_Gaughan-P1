﻿using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IManagerRepository
    {
        List<Manager> GetManagers();

        Manager AddManager(Manager newManager);

        Manager DeleteManager(Manager manager2BDeleted);

        Manager GetManagerByEmail(string email);

        Manager CheckManagerLoginInfo(string email, string password);

        Manager UpdateManager(Manager manager2Bupdated);
    }
}