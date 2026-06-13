using System;

namespace Ex04.Menus.Events
{
    public abstract class MenuItem
    {
        private string m_ItemName;
        public string ItemName
        {
            get
            {
                return m_ItemName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("MenuItem must have a title.");
                }
                if (value == string.Empty)
                {
                    throw new ArgumentException("MenuItem must have a non-empty title.");
                }

                m_ItemName = value;
            }
        }

        protected MenuItem(string i_Name)
        {
            ItemName = i_Name;
        }

        public abstract void Select();
    }
}
