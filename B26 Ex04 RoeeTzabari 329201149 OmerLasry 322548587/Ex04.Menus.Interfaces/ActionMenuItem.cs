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

        public void ExecuteAction()
        {
            m_Action.Execute();
        }
    }
}
