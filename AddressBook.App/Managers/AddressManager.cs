using AddressBook.App.Abstract;
using AddressBook.App.Common;
using AddressBook.App.Concrete;
using AddressBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBook.App.Managers
{
    public class AddressManager
    {
        private readonly MenuActionService _actionService;
        private IService<Address> _addressService;
        public AddressManager(MenuActionService actionService, IService<Address> addressService)
        {
            _addressService = addressService;
            _actionService = actionService;
        }

        public int AddNewAddress()
        {
            var addNewAddressMenu = _actionService.GetMenuActionsByMenuName("AddNewAddressMenu");
            Console.WriteLine("\r\nPlease select type of contact");
            for (int i = 0; i < addNewAddressMenu.Count; i++)
            {
                Console.WriteLine($"{addNewAddressMenu[i].Id}. {addNewAddressMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Console.WriteLine("");
            int contactTypeId;
            Int32.TryParse(operation.KeyChar.ToString(), out contactTypeId);
            Console.WriteLine("Please enter name for your contact:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter surname for your contact:");
            var surname = Console.ReadLine();
            Console.WriteLine("Please enter location for your contact:");
            var location = Console.ReadLine();
            var lastId = _addressService.GetLastId();
            Address address = new Address(lastId + 1, name, surname, location, contactTypeId);

            _addressService.AddAddress(address);
            return address.Id;
        }
        public int RemoveAddress()
        {
            bool isNotEmpty = ListIsNotEmpty();
            if (isNotEmpty)
            {
                foreach (var address in _addressService.Addresses)
                {
                    Console.WriteLine($"{address.Id}. {address.Name}. {address.Surname}. {address.Location}");
                }
                Console.WriteLine("Please enter id contact you want to remove:");
                var operation = Console.ReadKey();
                Console.WriteLine("");
                int id;
                Int32.TryParse(operation.KeyChar.ToString(), out id);
                Address contactToRemove = new Address();
                foreach (var address in _addressService.Addresses)
                {
                    if (address.Id == id)
                    {
                        contactToRemove = address;
                        break;
                    }
                }
                Console.WriteLine("\r\nIf you want to confirm please write YES");
                string confirm = Console.ReadLine();

                if (confirm == "yes" || confirm == "YES" || confirm == "Yes" || confirm == "y")
                {
                    _addressService.RemoveAddress(contactToRemove);
                    Console.WriteLine($"Address id {contactToRemove.Id} has been removed");
                    return contactToRemove.Id;
                }
                else
                {
                    Console.WriteLine("You did not confirm, list contact not deleted\r\n");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("List is empty!!!");
                return 0;
            }
        }
        public List<Address> GetAddressByType()
        {
            Console.WriteLine("Please enter Contact Type Id you want to show:");
            Console.WriteLine("1.Family 2.Friend 3.Coworker 4.Stranger");
            var operation = Console.ReadKey();
            Console.WriteLine("");
            int id;
            Int32.TryParse(operation.KeyChar.ToString(), out id);
            List<Address> toShow = new List<Address>();
            foreach (var address in _addressService.Addresses)
            {
                if (address.ContactId == id)
                {
                    toShow.Add(address);
                }
            }
            return toShow;
        }
        public List<Address> GetAddressById()
        {
            Console.WriteLine("Please enter Id you want to show:");
            var operation = Console.ReadKey();
            Console.WriteLine("");
            int id;
            Int32.TryParse(operation.KeyChar.ToString(), out id);
            List<Address> toShow = new List<Address>();
            foreach (var address in _addressService.Addresses)
            {
                if (address.Id == id)
                {
                    toShow.Add(address);
                }
            }
            return toShow;
        }
        public void ShowAddress(List<Address> toShow)
        {
            for (int i = 0; i < toShow.Count; i++)
            {
                Console.WriteLine($"Address id: {toShow[i].Id}");
                Console.WriteLine($"Address name: {toShow[i].Name}");
                Console.WriteLine($"Address surname: {toShow[i].Surname}");
                Console.WriteLine($"Address contact type: {toShow[i].ContactId}");
                Console.WriteLine($"Address location: {toShow[i].Location}");
                Console.WriteLine("\r\n");
            }
        }

        public void EditAddress()
        {
            Console.WriteLine("Please enter Address Id for contact you want to edit location:");
            var operation = Console.ReadKey();
            Console.WriteLine("");
            int id;
            Int32.TryParse(operation.KeyChar.ToString(), out id);

            Address contactToEdit = new Address();
            foreach (var address in _addressService.Addresses)
            {
                if (address.Id == id)
                {
                    contactToEdit = address;
                    Console.WriteLine($"Actual name: { contactToEdit.Name}");
                    Console.WriteLine("Enter new name:");
                    var newName = Console.ReadLine();
                    contactToEdit.Name = newName;
                    Console.WriteLine($"Actual surname: { contactToEdit.Surname}");
                    Console.WriteLine("Enter new surname:");
                    var newSurname = Console.ReadLine();
                    contactToEdit.Surname = newSurname;
                    Console.WriteLine($"Actual location: { contactToEdit.Location}");
                    Console.WriteLine("Enter new location:");
                    var newLocation = Console.ReadLine();
                    contactToEdit.Location = newLocation;
                    break;
                }
            }
        }
        public bool ListIsNotEmpty()
        {
            if (_addressService.Addresses.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}