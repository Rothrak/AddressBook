using AddressBook.App.Abstract;
using AddressBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBook.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Addresses { get; set; }
        public BaseService()
        {
            Addresses = new List<T>();
        }

        public int AddAddress(T address)
        {
            Addresses.Add(address);
            return address.Id;
        }

        public List<T> GetAllAddresses()
        {
            return Addresses;
        }

        public int GetLastId()
        {
            int lastId;
            if (Addresses.Any())
            {
                lastId = Addresses.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public void RemoveAddress(T address)
        {
            Addresses.Remove(address);
        }
    }
}
