using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private IAction m_Action;
        public ActionMenuItem(string i_Name, IAction i_Action) : base(i_Name)
        {
            m_Action = i_Action;
        }

        public ActionMenuItem(string i_Name) : base(i_Name)
        {
            m_Action = null;
        }

        public override void Select()
        {
            if(m_Action != null)
            {
                m_Action.Execute();
            }
        }
    }
}
