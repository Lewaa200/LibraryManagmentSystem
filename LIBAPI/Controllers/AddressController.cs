using LIBAPI.Services;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIBAPI.DTOs;

namespace LIBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddresses()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            var addressDTOs = _mapper.Map<IEnumerable<AddressDTO>>(addresses);
            return Ok(addressDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            var addressDTO = _mapper.Map<AddressDTO>(address);
            return Ok(addressDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDTO>> PostAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            await _addressService.AddAddressAsync(address);
            var createdAddressDTO = _mapper.Map<AddressDTO>(address);
            return CreatedAtAction(nameof(GetAddress), new { id = createdAddressDTO.ID }, createdAddressDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, AddressDTO addressDTO)
        {
            if (id != addressDTO.ID)
            {
                return BadRequest();
            }

            var address = _mapper.Map<Address>(addressDTO);
            await _addressService.UpdateAddressAsync(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }
    }
}
