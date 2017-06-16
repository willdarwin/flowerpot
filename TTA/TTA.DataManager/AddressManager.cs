using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

namespace TTA.DataManager
{
    public class AddressManager
    {
        /// <summary>
        /// Get all the addresses
        /// </summary>
        /// <returns>Get all the customers in a list</returns>
        public List<AddressBE> GetAllAddresses()
        {
            TTAEntityContainer _entity = new TTAEntityContainer();
            List<AddressBE> listAddressBE = new List<AddressBE>();
            List<Address> listAddressDE = (from Address in _entity.Addresses select Address).ToList<Address>();
            foreach (Address address in listAddressDE)
            {
                AddressBE addressBE = new AddressTranslator().Translate(address);
                listAddressBE.Add(addressBE);
            }
            return listAddressBE;
        }
    }
}
