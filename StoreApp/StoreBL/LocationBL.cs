using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationRepository _repo;
        public LocationBL(ILocationRepository repo){
            _repo = repo;
        }

        public Location AddLocation(Location newLocation)
        {
            return _repo.AddLocation(newLocation);
        }
        public Location DeleteLocation(Location location2BDeleted)
        {
            return _repo.DeleteLocation(location2BDeleted);
        }
        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }
        public Location GetLocationById(int locId){
            return _repo.GetLocationById(locId);
        }
        public Location UpdateLocation(Location location2Bupdated)
        {
            return _repo.UpdateLocation(location2Bupdated);
        }
    }
}
