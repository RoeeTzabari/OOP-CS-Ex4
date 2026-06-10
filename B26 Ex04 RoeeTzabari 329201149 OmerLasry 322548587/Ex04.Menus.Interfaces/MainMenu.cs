using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private string m_MenuTitle;
        public string MenuTitle
        {
            get
            {
                return m_MenuTitle;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("MainMenu must have a title.");
                }
                if (value == string.Empty)
                {
                    throw new ArgumentException("MainMenu must have a non-empty title.");
                }

                m_MenuTitle = value;
            }
        }
        
        private SubMenuMenuItem m_MenuItems;
        public SubMenuMenuItem MenuItems
        {
            get
            {
                return m_MenuItems;
            }
        }

        public MainMenu(string i_Title)
        {
            m_MenuTitle = i_Title;
            m_MenuItems = new SubMenuMenuItem(m_MenuTitle, SubMenuMenuItem.eNavigationType.Exit);
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.AddMenuItem(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.RemoveMenuItem(i_MenuItem);
        }

        public void Show()
        {
            m_MenuItems.Select();
        }

        public override string ToString()
        {
            return m_MenuItems.ToString();
        }
    }
}
