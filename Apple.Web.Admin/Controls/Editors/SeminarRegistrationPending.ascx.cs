﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class SeminarRegistrationPending : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            SeminarRegistration1.SentEmailType = 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SeminarRegistration1.SentEmailType = 0;
        }
    }
}