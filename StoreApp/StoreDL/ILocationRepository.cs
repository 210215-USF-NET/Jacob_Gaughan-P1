using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface ILocationRepository
    {
        List<Location> GetLocations();

        Location AddLocation(Location newLocation);

        Location GetLocationById(int locId);

        Location DeleteLocation(Location location2BDeleted);

        Location UpdateLocation(Location location2Bupdated);
    }
}