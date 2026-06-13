using System;

namespace Ex04.Menus.Events
{
    public class ActionMenuItem : MenuItem
    {
        public event Action Selected;

        public ActionMenuItem(string i_Name) : base(i_Name) { }

        public override void Select()
        {
            if (Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}
