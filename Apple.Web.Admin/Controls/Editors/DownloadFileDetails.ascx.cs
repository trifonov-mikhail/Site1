using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data;
using System.Web.Configuration;
using System.IO;
using Erc.Apple.Data.BussinesModels;
using Apple.Web.Admin.CSV;
using Apple.Web.Admin.Tools;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class DownloadFileDetails : EditorBase, Apple.Web.Admin.Interfaces.IAddControl
    {
        public Control addButton;
        #region IAddControl Members

        public bool NeedAddButton
        {
            get { return true; }
        }

        public Control AddButton
        {
            get
            {
                return addButton;
            }
            set
            {
                addButton = value;
            }
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            GridViewItemsList.SelectedIndex = -1;
            MvEditor.ActiveViewIndex = 1;

            if (DetailsViewEditItem.CurrentMode != DetailsViewMode.Insert)
            {
                DetailsViewEditItem.ChangeMode(DetailsViewMode.Insert);
            }
            var txtName = DetailsViewEditItem.FindControl("txtName") as TextBox;
            if (txtName != null)
            {
                txtName.Text = "";
            }
            var txtDescription = DetailsViewEditItem.FindControl("txtDescription") as TextBox;
            if (txtDescription != null)
            {
                txtDescription.Text = "";
            }
            var ddl = DetailsViewEditItem.FindControl("ddlCategory") as DropDownList;
            if (ddl != null)
            {
                ddl.SelectedValue = "0";
            }
            AddButton.Visible = false;
        }

        #endregion

		public int ID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
			DetailsViewEditItem.PreRender += new EventHandler(DetailsViewEditItem_PreRender);
			
        }

		void DetailsViewEditItem_PreRender(object sender, EventArgs e)
		{
			FillID();
		}

		private void FillID()
		{
			try
			{
				ID = System.Convert.ToInt32(DetailsViewEditItem.DataKey.Value);
			}
			catch (Exception)
			{
				ID = -1;
			}
			//if (ID > 0)
			//    dwnImagePanel.Visible = true;
			//else
			//    dwnImagePanel.Visible = false;
		}

		protected void btnDeleteImage_Click(object sender, EventArgs e)
		{
			FillID();
			if (ID <= 0) return;

			string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			string filename = Path.Combine(path, ID + ".jpg");
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}			
		}

		protected string GetImagePath()
		{
			FillID();
			if (ID <= 0) return VirtualPathUtility.ToAbsolute("~/images/test.jpeg");
			string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			string filename = Path.Combine(path, ID + ".jpg");
			if (File.Exists(filename))
			{
				return VirtualPathUtility.ToAbsolute(string.Format("~/virtualimages/{0}.jpg", ID));
			}
			return VirtualPathUtility.ToAbsolute("~/images/test.jpeg");
		}

		protected void btnDwnImage_Click(object sender, EventArgs e)
		{
			if (!fuImage.HasFile) return;
			FillID();
			if (ID <= 0) return;

			var image = ImageResizer.ByteArrayToImage(fuImage.FileBytes);
			var newimage = ImageResizer.ResizeByMax(image, 80);
			string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			string filename = Path.Combine(path, ID + ".jpg");
			if(File.Exists(filename))
			{
				File.Delete(filename);
			}
			newimage.Save(filename);
		}

        protected override GridView ItemsList
        {
            get { return GridViewItemsList; }
        }

        protected override DetailsView ItemDetails
        {
            get { return DetailsViewEditItem; }
        }

        protected void GridViewItemsList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            MvEditor.ActiveViewIndex = 1;
            AddButton.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Close();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }
        private void Save()
        {
            if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Insert)
            {
				Logger.LogInfo("DetailsViewEditItem.CurrentMode == DetailsViewMode.Insert", "DownloadFiles");
                try
                {
                    //DetailsViewEditItem.InsertItem(false);
                    DownloadFile downloadFile = new DownloadFile();
                    var fu = DetailsViewEditItem.FindControl("fuFile") as FileUpload;
                    if (fu != null && fu.HasFile)
                    {
                        downloadFile.FileName = fu.PostedFile.FileName;
                        downloadFile.MimeType = fu.PostedFile.ContentType;
                        string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
                        string filePath = Path.Combine(path, downloadFile.FileName);
						Logger.LogInfo("FileUpload exists", "DownloadFiles");
                        fu.PostedFile.SaveAs(filePath);
						Logger.LogInfo("File was saved " + filePath, "DownloadFiles");
                    }
                    var txtName = DetailsViewEditItem.FindControl("txtName") as TextBox;
                    if (txtName != null)
                    {
						Logger.LogInfo("txtName exists ", "DownloadFiles");
                        downloadFile.Name = txtName.Text;
                    }
                    var txtDescription = DetailsViewEditItem.FindControl("txtDescription") as TextBox;
                    if (txtDescription != null)
                    {
                        downloadFile.Description = txtDescription.Text;
                    }
                    var ddl = DetailsViewEditItem.FindControl("ddlCategory") as DropDownList;
                    if (ddl != null)
                    {
                        downloadFile.TypeId = Convert.ToInt32(ddl.SelectedValue);
                    }
                    DownloadFiles m = new DownloadFiles();
					Logger.LogInfo("Saving DownloadFiles ", "DownloadFiles");
                    m.Add(downloadFile);
					Logger.LogInfo("Saved DownloadFiles ", "DownloadFiles");
					ID = downloadFile.ID;
					uploadImage();
					
                    //    DetailsViewEditItem.ChangeMode(DetailsViewMode.Edit);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex, "DownloadFiles");
                    ShowError(ex);
                }
                
                
            }
            else if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Edit)
            {
				Logger.LogInfo("DetailsViewEditItem.CurrentMode == DetailsViewMode.Edit", "DownloadFiles");
                DetailsViewEditItem.UpdateItem(false);
            }
            
        }

		private void uploadImage()
		{
			if (!fuImage.HasFile) return;
			if (ID <= 0) return;
			var image = ImageResizer.ByteArrayToImage(fuImage.FileBytes);
			var newimage = ImageResizer.ResizeByMax(image, 80);
			string rootPath = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			string filename = Path.Combine(rootPath, ID + ".jpg");
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			newimage.Save(filename);
		}

        protected void DownloadFileDetails_PreRender(object sender, EventArgs e)
        {
            
        }
        private void Close()
        {
            MvEditor.ActiveViewIndex = 0;
            AddButton.Visible = true;
			GridViewItemsList.DataBind();
        }

		protected void GridViewItemsList_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Download")
			{
				int id = int.Parse(e.CommandArgument.ToString());
				DownloadUserForms duf = new DownloadUserForms();
				List<DownloadUserForm> list = duf.GetByFileID(id);
				DownloadFiles df = new DownloadFiles();
				var file = df.GetById(id);

				ReportOptions ro = new ReportOptions();
				ro.Columns = "Email,FirstName,LastName";
				ro.HeaderText = "Email,Имя,Фамилия";				
				ro.FileName = string.Format("csvreport_{0}_file.csv",file.FileName);
				new CsvHelper().WriteToCSV(list, ro);
			}
		}

        protected void ObjectDataSourceEditItem_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {

        }

        protected void DetailsViewEditItem_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
			
        }

		protected void ObjectDataSourceItemsList_OnDeleting(object sender, ObjectDataSourceMethodEventArgs e)
		{
			string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			DownloadFile d = e.InputParameters[0] as DownloadFile;
			DownloadFiles ds = new DownloadFiles();
			DownloadFile f = d != null? ds.GetById(d.ID) : d ;
			if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(f.FileName) && f != null && d != null)
			{
				string rootpath = Path.Combine(path, f.FileName);
				if (File.Exists(rootpath))
				{
					File.Delete(rootpath);
				}
				rootpath = Path.Combine(path, d.ID + ".jpg");
				if (File.Exists(rootpath))
				{
					File.Delete(rootpath);
				}
			}
		}

        protected void DetailsViewEditItem_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            var fu = DetailsViewEditItem.FindControl("fuFile") as FileUpload;
            if(fu != null && fu.HasFile)
            {
                e.Values["FileName"] = fu.PostedFile.FileName;
                e.Values["MimeType"] = fu.PostedFile.ContentType;
            }
            //
         //   e.Values["Date"] = CaseStudyDate;
        }


    }
}