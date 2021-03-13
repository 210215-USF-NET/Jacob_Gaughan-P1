using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IInventoryBL
    {
        List<Inventory> GetInventories();

        Inventory UpdateInventory(Inventory inventory2Bupdated);

        int GetQuantity(int prodId, int locId);

        Inventory GetInventoryById(int prodId, int locId);

        Inventory AddInventory(Inventory newInventory);

        List<Inventory> GetInventoriesAtLocation(int locId);
    }
}