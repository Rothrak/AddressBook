using AddressBook.App.Concrete;
using AddressBook.App.Managers;
using System;
using AddressBook.Domain.Entity;
using AddressBook.App.Abstract;
using System.Linq;
using AddressBook.App.Common;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your AddressBook App!");
            MenuActionService actionService = new MenuActionService();
            AddressService addressService = new AddressService();
            AddressManager addressManager = new AddressManager(actionService, addressService);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Please let me know what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                foreach (var menuAction in mainMenu)
                {
                    Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
                }
                var operation = Console.ReadKey();
                Console.WriteLine("");

                switch (operation.KeyChar)
                {
                    case '1':
                        var newId = addressManager.AddNewAddress();
                        break;
                    case '2':
                        var removeId = addressManager.RemoveAddress();
                        break;
                    case '3':
                        var typeId = addressManager.GetAddressByType();
                        addressManager.ShowAddress(typeId);
                        break;
                    case '4':
                        var id = addressManager.GetAddressById();
                        addressManager.ShowAddress(id);
                        break;
                    case '5':
                        addressManager.EditAddress();
                        break;
                    case '6':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
        }

    }
}
