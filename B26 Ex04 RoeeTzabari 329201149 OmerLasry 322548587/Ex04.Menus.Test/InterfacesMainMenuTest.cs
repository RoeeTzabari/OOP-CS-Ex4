using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public static class InterfacesMainMenuTest
    {
        private class ShowCurrentDateAction : IAction
        {
            public void Execute()
            {
                string date = DateTime.Now.ToShortDateString();

                Console.WriteLine("Current Date is " + date);
                Console.ReadLine();
            }
        }


        private class ShowCurrentTimeAction : IAction
        {
            public void Execute()
            {
                string date = DateTime.Now.ToShortTimeString();

                Console.WriteLine("Current Time is " + date);
                Console.ReadLine();
            }
        }


        private class ShowNumOfCapitalsAction : IAction
        {
            private static int countCapitals(string i_Text)
            {
                int count = 0;

                foreach (char c in i_Text)
                {
                    if (char.IsUpper(c))
                    {
                        count++;
                    }
                }

                return count;
            }

            public void Execute()
            {
                Console.WriteLine("Please enter a sentence.");

                string sentence = Console.ReadLine();
                int numOfCapitals = countCapitals(sentence);

                Console.WriteLine($"This sentence has {numOfCapitals} capital letters.");
                Console.ReadLine();
            }
        }


        private class ShowVersionAction : IAction
        {
            public void Execute()
            {
                Console.WriteLine("App Version: 26.2.4.7310");
                Console.ReadLine();
            }
        }


        public static void Run()
        {
            MainMenu menu = new MainMenu("Interfaces Main Menu");

            // Current Date/Time sub-menu initialization.
            SubMenuMenuItem currentDateOrTimeSubMenu = new SubMenuMenuItem("Show Current Date/Time", SubMenuMenuItem.eNavigationType.Back);
            MenuItem currentDateItem = new ActionMenuItem("Show Current Date", new ShowCurrentDateAction());
            MenuItem currentTimeItem = new ActionMenuItem("Show Current Time", new ShowCurrentTimeAction());

            currentDateOrTimeSubMenu.AddMenuItem(currentDateItem);
            currentDateOrTimeSubMenu.AddMenuItem(currentTimeItem);

            // Version And Capitals sub-menu initialization.
            SubMenuMenuItem versionAndCapitalsSubMenu = new SubMenuMenuItem("Version and Capitals", SubMenuMenuItem.eNavigationType.Back);
            MenuItem countCapitalsItem = new ActionMenuItem("Count Capitals", new ShowNumOfCapitalsAction());
            MenuItem showVersionItem = new ActionMenuItem("Show Version", new ShowVersionAction());

            versionAndCapitalsSubMenu.AddMenuItem(countCapitalsItem);
            versionAndCapitalsSubMenu.AddMenuItem(showVersionItem);

            // Adding both sub-menus to the main menu.
            menu.AddMenuItem(currentDateOrTimeSubMenu);
            menu.AddMenuItem(versionAndCapitalsSubMenu);

            // Displaying the main menu:
            menu.Show();
        }
    }
}
