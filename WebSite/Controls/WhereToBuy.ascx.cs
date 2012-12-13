using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Erc.Apple.Data;

namespace Apple.Web.Controls
{
    public partial class WhereToBuy : UserControlBase
    {
        int specializationID = -1;
        int regionID = -1;
        int cityID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            map1.DdlRegionsID = ddlRegions.ClientID;
            map1.BtnShowID = btnShowPartners.ClientID;
        }
        protected void btnShowPartners_Click(object sender, EventArgs e)
        {
            int.TryParse(ddlSpecializations.SelectedValue, out specializationID);
            int.TryParse(ddlRegions.SelectedValue, out regionID);
            int.TryParse(ddlCities.SelectedValue, out cityID);

            rItems.DataBind();
        }

        protected void odsPartners_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (specializationID == -1)
            {
                e.Cancel = true;
            }
            e.InputParameters["specializationID"] = specializationID;
            e.InputParameters["regionID"] = regionID;
            e.InputParameters["cityID"] = cityID;
            e.InputParameters["language"] = this.CurrentLanguage;
        }

        protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Partner p = (Partner)e.Item.DataItem;
                Label spec = (Label)e.Item.FindControl("lblSpecialization");

                List<string> all = (new PartnerSpecializations()).GetListSpecializationByPartner(p);

                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (string name in all)
                {
                    sb.Append(name);
                    if (i++ != all.Count - 1)
                        sb.Append(", ");
                }

                spec.Text = sb.ToString();
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                PlaceHolder ph = (PlaceHolder)e.Item.FindControl("phNoData");
                ph.Visible = rItems.Items.Count == 0;
            }
        }

        protected void rItems_PreRender(object sender, EventArgs e)
        {
            if (rItems.Items.Count > 0)
            {
                phDetails.Visible = true;
            }else{
                phDetails.Visible = false;
            }
        }

        protected void odsSpecializations_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["language"] = this.CurrentLanguage;
        }

        protected void odsRegions_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["language"] = this.CurrentLanguage;
        }

        protected void odsCities_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            int region = (int)e.InputParameters["regionID"];
            if (region == 0)
            {
                e.Cancel = true;
            }
            e.InputParameters["language"] = this.CurrentLanguage;
        }

        protected void ddlCities_DataBinding(object sender, EventArgs e)
        {
            if (ddlCities.Items.Count > 1)
            {
                ListItem init = ddlCities.Items[0];
                string text = init.Text;
                string value = init.Value;

                ddlCities.Items.Clear();
                ddlCities.Items.Add(new ListItem(text,value));
            }
        }
    }
}