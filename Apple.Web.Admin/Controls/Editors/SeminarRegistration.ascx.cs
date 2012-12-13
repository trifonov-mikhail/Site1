using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class SeminarRegistration : System.Web.UI.UserControl
    {
        SeminarRegistrations seminarRegistrations = new SeminarRegistrations();
        public int SentEmailType
        {
            get { return Session["emailType"] == null ? 0 :(int) Session["emailType"]; }
            set { Session["emailType"] = value; }
        }
        public string  Datasource
        {
            get
            {
                return ObjectDataSourceItemsList.ClientID;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCountOfSuccesfullyEmail();
            csv.Options.FileName = "SeminarRequests(Approved)";
            csv.Options.HeaderText = "ФИО,Название компании,Должность,Email,Сайт,Тип";
            csv.Options.Columns = "FIO,CompanyName,JobTitle,Email,Site,TypeString";
        }

        private void UpdateCountOfSuccesfullyEmail()
        {
            var list = seminarRegistrations.GetByType(Convert.ToInt32(dllSeminars.SelectedValue), 1);
            ltCount.Text = list.Count(p=>p.SentEmailType == 1 || p.SentEmailType == 3).ToString();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            GetCheckedItems("chkSelected", GridViewItemsList);
            ArrayList ar = Session["CheckedItems"] as ArrayList;
            if (ar != null && ar.Count > 0)
            {
                
                string[] IDs = ar.Cast<string>().ToArray();
                var list = seminarRegistrations.GetByIds(IDs);
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    try
                    {
                        SentNotification(item, Convert.ToInt32(EmailType.SelectedValue));
                    }
                    catch (Exception exc)
                    {
                        Logger.LogException(exc, "SeminarRegistration email:" + item.Email);
                    }
                    
                }
                seminarRegistrations.UpdateEmailStatus(IDs, Convert.ToInt32(EmailType.SelectedValue));
                Session["CheckedItems"] = null;
            }
            UpdateCountOfSuccesfullyEmail();
            ObjectDataSourceItemsList.Select();
            GridViewItemsList.DataBind();
        }

        private void SentNotification(Erc.Apple.Data.SeminarRegistration item, int type)
        {
            MailDefinition md = new MailDefinition();
            switch (type)
            {
                case 1:
                    md.BodyFileName = "~/Templates/SeminarRegistration_1.htm";
                    break;
                case 2:
                    md.BodyFileName = "~/Templates/SeminarRegistration_2.htm";
                    break;
                case 3:
                    md.BodyFileName = "~/Templates/SeminarRegistration_3.htm";
                    break;
            }
            md.IsBodyHtml = true;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("<%LOGO%>", "cid:companylogo");
            md.Subject = "Cеминар \"Секреты успешного бизнеса от Apple и HansaWorld\"";
            
            md.EmbeddedObjects.Add(new EmbeddedMailObject("companylogo", Server.MapPath("~/Templates/logo.png")));
            MailMessage message = md.CreateMailMessage(item.Email, d, this);

            SmtpClient sc = new SmtpClient();
            sc.Send(message);
            
            
        }
        private void GetCheckedItems(string crtl, GridView grdView)
        {
            //instantiate new ArrayList to hold our checked items
            ArrayList checkedItems = new ArrayList();
            CheckBox chk;
            string chkBoxIndex = string.Empty;
            //loop through each row in the GridView
            foreach (GridViewRow row in grdView.Rows)
            {
                //get the index of the current CheckBox
                chkBoxIndex = (string)grdView.DataKeys[row.RowIndex].Value.ToString();
                chk = (CheckBox)row.FindControl(crtl);
                //add ArrayList to Session is if doesnt already exist
                if (!(Session["CheckedItems"] == null))
                {
                    checkedItems = (ArrayList)Session["CheckedItems"];
                }

                //now see if the current CheckBox is checked
                if (chk.Checked)
                {
                    //see if the current value is in the Session, if not add it
                    if (!(checkedItems.Contains(chkBoxIndex)))
                    {
                        //add to the list
                        checkedItems.Add(chkBoxIndex);
                    }
                    else
                    {
                        //remove from list since it's unchecked
                        checkedItems.Remove(chkBoxIndex);
                    }
                }

            }
            //update Session with the list of checked items
            Session["CheckedItems"] = checkedItems;
        }

        public void GridViewItemsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                var ddl = e.Row.FindControl("ddlJobAction") as DropDownList;
                if(ddl == null) return;
                int jobAction = (e.Row.DataItem as Erc.Apple.Data.SeminarRegistration).JobAction;
                var listItem = ddl.Items.FindByValue(jobAction.ToString()) as ListItem;
                if (listItem != null)
                    ddl.SelectedValue = jobAction.ToString();

            }

        }

        
        protected void ddl_OnDataBinding(object sender, EventArgs e)
        {
            
        }
    }
}