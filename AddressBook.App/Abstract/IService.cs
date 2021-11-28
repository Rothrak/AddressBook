using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.App.Abstract
{
    public interface IService<T>
    {
        List<T> Addresses { get; set; }
        List<T> GetAllAddresses();
        int GetLastId();
        int AddAddress(T address);
        void RemoveAddress(T address);

    }
}