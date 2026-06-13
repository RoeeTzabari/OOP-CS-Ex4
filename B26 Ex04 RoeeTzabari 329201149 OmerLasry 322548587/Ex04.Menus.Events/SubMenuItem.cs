using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Events
{
    public class SubMenuItem : MenuItem
    {
        public enum eNavigationType
        {
            Exit,
            Back,
        }

        private readonly List<MenuItem> r_SubItems;
        private readonly ActionMenuItem r_NavigationItem;

        public ActionMenuItem NavigationItem
        {
            get
            {
                return r_NavigationItem;
            }
        }

        public SubMenuItem(string i_Name, eNavigationType i_NavigationType) : base(i_Name)
        {
            r_SubItems = new List<MenuItem>();
            r_NavigationItem = new ActionMenuItem(i_NavigationType.ToString());
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentNullException("Menu item cannot be null.");
            }
            r_SubItems.Add(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_SubItems.Remove(i_MenuItem);
        }

        public override void Select()
        {
            bool shouldExit = false;
            string navigationSuffix = r_NavigationItem.ItemName == "Exit" ? "exit" : "go back";

            while (!shouldExit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("** {0} **", ItemName);
                Console.ResetColor();
                Console.WriteLine("---------------------------");

                Console.WriteLine(ToString());
                if (r_SubItems.Count <= 0)
                {
                    Console.WriteLine($"Please enter 0 to {navigationSuffix}.");
                }
                else
                {
                    Console.WriteLine($"Please enter your choice (1-{r_SubItems.Count} or 0 to {navigationSuffix}):");
                }

                string choice = Console.ReadLine();
                bool isValid = tryParseItemChoice(choice, out int choiceInt);

                while (!isValid)
                {
                    Console.WriteLine("Invalid choice, Please try again:");
                    choice = Console.ReadLine();
                    isValid = tryParseItemChoice(choice, out choiceInt);
                }

                if (choiceInt == 0)
                {
                    shouldExit = true;
                }
                else
                {
                    MenuItem item = r_SubItems.ElementAt(choiceInt - 1);
                    item.Select();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < r_SubItems.Count; i++)
            {
                sb.Append(string.Format("{0}. {1}\n", i + 1, r_SubItems.ElementAt(i).ItemName));
            }

            sb.Append(string.Format("0. {0}\n", r_NavigationItem.ItemName));

            return sb.ToString();
        }

        private bool tryParseItemChoice(string i_Input, out int i_ItemIndex)
        {
            bool isValid = false;

            i_ItemIndex = 0;
            if (int.TryParse(i_Input, out int result))
            {
                isValid = result >= 0 && result <= r_SubItems.Count;
                i_ItemIndex = result;
            }

            return isValid;
        }
    }
}
