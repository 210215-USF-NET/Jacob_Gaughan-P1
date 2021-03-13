using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ILocationBL
    {
        List<Location> GetLocations();

        Location AddLocation(Location newLocation);

        Location DeleteLocation(Location newLocation);

        Location GetLocationById(int locId);

        Location UpdateLocation(Location location2Bupdated);
    }
}