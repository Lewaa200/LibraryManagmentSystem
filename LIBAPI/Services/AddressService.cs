using Data.Models;
using LIBAPI.Services;

namespace LIBAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Address> _addressRepository;

        public AddressService(IGenericRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        public async Task AddAddressAsync(Address address)
        {
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _addressRepository.DeleteAsync(id);
        }
    }

}
