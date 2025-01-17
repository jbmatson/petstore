using Petstore.Server.Data;

namespace Petstore.Server.Models
{
    public class PetRepository : IPetRepository
    {
        private readonly PetstoreContext _petstoreContext;

        public PetRepository(PetstoreContext petstoreContext)
        {
            _petstoreContext = petstoreContext;
        }
    }
}
