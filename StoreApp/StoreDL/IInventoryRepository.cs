using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IInventoryRepository
    {
        List<Inventory> GetInventories();

        Inventory UpdateInventory(Inventory inventory2bupdated);

        int GetQuantity(int prodId, int locId);

        Inventory GetInventoryById(int prodId, int locId);

        Inventory AddInventory(Inventory newInventory);

        List<Inventory> GetInventoriesAtLocation(int locId);
    }
}