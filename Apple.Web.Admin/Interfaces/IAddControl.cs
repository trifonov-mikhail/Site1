using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Text;

namespace Apple.Web.Admin.Interfaces
{
    interface IAddControl
    {
        bool NeedAddButton
        {
            get;
        }

        Control AddButton
        {
            get;
            set;
        }

        void AddButton_Click(object sender, EventArgs e);
    }
}
