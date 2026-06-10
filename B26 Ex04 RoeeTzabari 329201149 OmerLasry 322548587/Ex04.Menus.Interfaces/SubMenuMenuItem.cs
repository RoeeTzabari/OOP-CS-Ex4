using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenuMenuItem : MenuItem
    {
        private List<MenuItem> m_SubItems;

        public SubMenuMenuItem(string i_Name) : base(i_Name)
        {
            m_SubItems = null;
        }

        public void AddItemMenu(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentNullException("Exit Item must have an action.");
            }
            m_SubItems.Add(i_MenuItem);
        }

        public void RemoveItemMenu(MenuItem i_MenuItem)
        {
            m_SubItems.Remove(i_MenuItem);
        }
    }
}
