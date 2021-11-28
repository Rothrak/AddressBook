using System;
using System.Collections.Generic;
using System.Text;
using AddressBook.App.Common;
using AddressBook.Domain.Entity;

namespace AddressBook.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Addresses)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddAddress(new MenuAction(1, "Add Address", "Main"));
            AddAddress(new MenuAction(2, "Remove Address", "Main"));
            AddAddress(new MenuAction(3, "Show Addresses By Contact Type", "Main"));
            AddAddress(new MenuAction(4, "Show Addresses By Id", "Main"));
            AddAddress(new MenuAction(5, "Edit Address", "Main"));
            AddAddress(new MenuAction(6, "Exit", "Main"));

            AddAddress(new MenuAction(1, "Family", "AddNewAddressMenu"));
            AddAddress(new MenuAction(2, "Friend", "AddNewAddressMenu"));
            AddAddress(new MenuAction(3, "Coworker", "AddNewAddressMenu"));
            AddAddress(new MenuAction(4, "Stranger", "AddNewAddressMenu"));
        }
    }
}
