using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data;

namespace Apple.Web.Controls
{
    public partial class AllSuccessStories : UserControlBase
    {
        protected int GroupID { get; set; }
        List<SuccessStory> ssList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Erc.Apple.Data.SuccessStories ss = new Erc.Apple.Data.SuccessStories();
                ssList = ss.GetByLang(this.CurrentLanguage);
                if (ssList != null && ssList.Count > 0)
                {
                    //rptSuccessStories.DataBinding += new EventHandler(rptSuccessStories_DataBinding);
                    gvSS.DataSource = ssList;
                    
                    gvSS.DataBind();
                }
            }
            gvSS.PageIndexChanging += new GridViewPageEventHandler(gvSS_PageIndexChanging);
        }

        void gvSS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSS.PageIndex = e.NewPageIndex;
            Erc.Apple.Data.SuccessStories ss = new Erc.Apple.Data.SuccessStories();
            ssList = ss.GetByLang(this.CurrentLanguage);
            if (ssList != null && ssList.Count > 0)
            {
                gvSS.DataSource = ssList;
                gvSS.DataBind();
            }
        }

        void rptSuccessStories_DataBinding(object sender, EventArgs e)
        {
            
        }
        //protected void rptSuccessStories_DataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        SuccessStory s = e.Item.DataItem as SuccessStory;
        //        if (s != null)
        //        {
        //            if (s.HasPdfFile)
        //            {
        //                HyperLink b = rptSuccessStories.FindControl("hlPdfFile") as HyperLink;
        //                if (b != null)
        //                {
        //                    b.Visible = true;
        //                    b.Text = s.PdfFileName;                            
        //                }
        //            }
        //        }
        //    }
        //}
        protected void GetPdfFile(object sender, EventArgs e)
        {

            Erc.Apple.Data.SuccessStories ss = new Erc.Apple.Data.SuccessStories();
            SuccessStory sstory = ss.GetPdfFile(this.CurrentLanguage, this.GroupID);
            if (sstory != null && sstory.PdfFile != null && sstory.PdfFile.Length > 0 && !string.IsNullOrEmpty(sstory.PdfFileName))
            {
                Response.Clear();
                Response.AppendHeader("content-disposition", "attachment; filename=" + sstory.PdfFileName);
                Response.BinaryWrite(sstory.PdfFile);
                Response.Flush();
            }
        }
    }
}