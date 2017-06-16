using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManager
{
    public class AddressTranslator
    {
        /// <summary>
        /// Translate AddressDE to AddressBE
        /// </summary>
        /// <param name="addressDE">Address DataEntiy</param>
        /// <returns>Address Business Entity</returns>
        public AddressBE Translate(Address addressDE)
        {
            if (addressDE != null)
            {
                return new AddressBE()
                {
                    AddressId = addressDE.AddressId,
                    Country = addressDE.Country,
                    Province = addressDE.Province,
                    DetailAddress = addressDE.Address1,
                    City = addressDE.City,
                };
            }
            else
                return null;
        }
    }
}
