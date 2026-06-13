using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public static class EventsMainMenuTest
    {
        private static void showCurrentDate()
        {
            Console.WriteLine("Current Date is " + DateTime.Now.ToShortDateString());
            Console.ReadLine();
        }

        private static void showCurrentTime()
        {
            Console.WriteLine("Current Time is " + DateTime.Now.ToShortTimeString());
            Console.ReadLine();
        }

        private static void countCapitals()
        {
            Console.WriteLine("Please enter a sentence.");
            string sentence = Console.ReadLine();
            int count = 0;

            foreach (char c in sentence)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"This sentence has {count} capital letters.");
            Console.ReadLine();
        }

        private static void showVersion()
        {
            Console.WriteLine("App Version: 26.2.4.7310");
            Console.ReadLine();
        }

        public static void Run()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");

            // Current Date/Time sub-menu initialization.
            SubMenuItem currentDateOrTimeSubMenu = new SubMenuItem("Show Current Date/Time", SubMenuItem.eNavigationType.Back);
            ActionMenuItem currentDateItem = new ActionMenuItem("Show Current Date");
            ActionMenuItem currentTimeItem = new ActionMenuItem("Show Current Time");
            currentDateItem.Selected += showCurrentDate;
            currentTimeItem.Selected += showCurrentTime;
            currentDateOrTimeSubMenu.AddMenuItem(currentDateItem);
            currentDateOrTimeSubMenu.AddMenuItem(currentTimeItem);

            // Version and Capitals sub-menu initialization.
            SubMenuItem versionAndCapitalsSubMenu = new SubMenuItem("Version and Capitals", SubMenuItem.eNavigationType.Back);
            ActionMenuItem countCapitalsItem = new ActionMenuItem("Count Capitals");
            ActionMenuItem showVersionItem = new ActionMenuItem("Show Version");
            countCapitalsItem.Selected += countCapitals;
            showVersionItem.Selected += showVersion;
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
