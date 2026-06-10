using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenuMenuItem : MenuItem
    {
        public enum eNavigationItem
        {
            Exit,
            Back,
        }

        private List<MenuItem> m_SubItems;

        private ActionMenuItem m_NavigationItem;
        public ActionMenuItem NavigationItem
        {
            get
            {
                return m_NavigationItem;
            }
        }
        public SubMenuMenuItem(string i_Name, eNavigationItem i_NavigationItem) : base(i_Name)
        {
            m_SubItems = new List<MenuItem>();
            m_SubItems.Add(i_NavigationItem);
            m_NavigationItem = i_NavigationItem;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentNullException("Exit Item must have an action.");
            }
            m_SubItems.Add(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            m_SubItems.Remove(i_MenuItem);
        }

        public override void Select()
        {
            string choice;
            bool isValid = false, shouldExit = false;

            while(!shouldExit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("** {0} **", ItemName);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("---------------------------");

                Console.WriteLine(ToString());
                Console.WriteLine($"Please enter you choice (1-{m_SubItems.Count} or 0 to exit):");

                choice = Console.ReadLine();
                isValid = TryParseItemChoice(choice, out int choiceInt);
                while (!isValid)
                {
                    Console.WriteLine("Invalid choice, Please try again:");
                    choice = Console.ReadLine();
                    isValid = TryParseItemChoice(choice, out choiceInt);
                }

                MenuItem item = m_SubItems.ElementAt(choiceInt);
                item.Select();   
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < m_SubItems.Count; i++)
            {
                sb.Append(string.Format("{0}. {1}\n", i, m_SubItems.ElementAt(i).ItemName));
            }

            sb.Append(string.Format("0. {0}\n", m_NavigationItem.ItemName));

            return sb.ToString();
        }

        private bool TryParseItemChoice(string i_Input, out int i_ItemIndex)
        {
            bool isValid = false;

            i_ItemIndex = 0;
            if (int.TryParse(i_Input, out int result))
            {
                isValid = result >= 0 && result <= m_SubItems.Count;
                i_ItemIndex = result;
            }

            return isValid;
        }
    }
}
