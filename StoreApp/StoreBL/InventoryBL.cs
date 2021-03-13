using StoreDL;
using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private IInventoryRepository _repo;

        public InventoryBL(IInventoryRepository repo)
        {
            _repo = repo;
        }

        public int GetQuantity(int prodId, int locId)
        {
            return _repo.GetQuantity(prodId, locId);
        }

        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }

        public Inventory GetInventoryById(int prodId, int locId)
        {
            return _repo.GetInventoryById(prodId, locId);
        }

        public Inventory UpdateInventory(Inventory inventory2Bupdated)
        {
            return _repo.UpdateInventory(inventory2Bupdated);
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            return _repo.AddInventory(newInventory);
        }

        public List<Inventory> GetInventoriesAtLocation(int locId)
        {
            return _repo.GetInventoriesAtLocation(locId);
        }
    }
}