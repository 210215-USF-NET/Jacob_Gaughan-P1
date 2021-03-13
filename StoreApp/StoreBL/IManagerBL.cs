using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IManagerBL
    {
        Manager AddManager(Manager newManager);

        Manager DeleteManager(Manager manager2BDeleted);

        Manager GetManagerByEmail(string email);

        List<Manager> GetManagers();

        Manager CheckManagerLoginInfo(string email, string password);

        Manager UpdateManager(Manager manager2Bupdated);
    }
}