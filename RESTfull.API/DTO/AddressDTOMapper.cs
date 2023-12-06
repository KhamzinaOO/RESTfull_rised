using RESRTfull.Domain;
using System.Net;

namespace RESTfull.API.DTO
{
    public class AddressDTOMapper
    {
        public static AddressDTO ToDto(Address address)
        {
            var addressDTO = new AddressDTO
            {
                ID = address.ID,
                AddressPermanentRegistration = address.AddressPermanentRegistration,
                AddressTemporaryRegistration = address.AddressTemporaryRegistration

            };
            return addressDTO;
        }

        public static Address ToEntity(AddressDTO addressDTO)
        {
            var address = new Address
            {
                ID = addressDTO.ID,
                AddressPermanentRegistration = addressDTO.AddressPermanentRegistration,
                AddressTemporaryRegistration = addressDTO.AddressTemporaryRegistration
            };
            return address;
        }
    }
}
