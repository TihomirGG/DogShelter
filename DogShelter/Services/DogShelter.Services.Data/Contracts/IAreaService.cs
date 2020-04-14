namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IAreaService
    {
        IEnumerable<string> GetAreasName();
    }
}
