using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using Apple.Web.Admin.Library.Models;
using Erc.Apple.Data.Repositories;
using System.Configuration;

namespace Apple.Web.Admin.Controls.Editors
{
	public partial class SerialNumbersUpload : UserControlBase
	{
		private SerialNumbersUploadModel _model;

		protected List<string> PendingFilesWithSerialNumbers
		{
			get { return (List<string>) Session["PendingFilesWithSerialNumbers"]; }
			set { Session["PendingFilesWithSerialNumbers"] = value; }
		}

		protected string UploadPath
		{
			get { return ConfigurationManager.AppSettings["SerialNumbersUploadPath"]; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			btnUploadFile.Click += btnUploadFile_Click;
			btnConfirmUpload.Click += btnConfirmUpload_Click;
			btnCancelUpload.Click += btnCancelUpload_Click;

			if (User != null)
				_model = new SerialNumbersUploadModel(User.ID, UploadPath);
		}

		void btnCancelUpload_Click(object sender, EventArgs e)
		{
			phConfirmationDialog.Visible = false;
			phUploadDialog.Visible = true;

			if (_model.IsValid())
			{
				try { _model.RollbackChanges(PendingFilesWithSerialNumbers); }
				catch { }
			}
			
			PendingFilesWithSerialNumbers = new List<string>();
		}

		private void btnConfirmUpload_Click(object sender, EventArgs e)
		{
			phConfirmationDialog.Visible = false;
			phUploadDialog.Visible = true;

			if (_model.IsValid())
			{
				try
				{
					int numberOfCommitedSerialNumbers = _model.CommitChanges(PendingFilesWithSerialNumbers);
					ShowMessage(((string) GetLocalResourceObject("lNumberOfCommitedSerialNumbersResource1.Text")).Replace("%X%", numberOfCommitedSerialNumbers.ToString()));
				}
				catch  (Exception ex)
				{
					Logger.LogException(ex, "SerialNumbersUpload.btnConfirmUpload_Click");
					ShowError((string)GetLocalResourceObject("genericError"));
				}
			}
			
			PendingFilesWithSerialNumbers = new List<string>();
		}

		private void btnUploadFile_Click(object sender, EventArgs e)
		{
			try
			{
				if (fileUpload.HasFile && _model.IsValid())
				{
					IDictionary<string, int> fileNamesWithCount = _model.UploadSerialNumbers(new List<byte[]> {fileUpload.FileBytes});
					int numberOfSerialNumbers = fileNamesWithCount.Sum(x => x.Value);

					if (numberOfSerialNumbers > 0)
					{
						PendingFilesWithSerialNumbers = fileNamesWithCount.Keys.ToList();
						ShowMessage(((string) GetLocalResourceObject("lNumberOfNewSerialNumbersResource1.Text")).Replace("%X%", numberOfSerialNumbers.ToString()));

						phUploadDialog.Visible = false;
						phConfirmationDialog.Visible = true;
					}
					else
					{
						ShowMessage((string)GetLocalResourceObject("thereAreNoSerialNumbers"));
					}
				}
				else
					throw new Exception(String.Format("SerialNumbersUploadModel isn't valid. UploadPath: {0} ; UserID: {1} ", _model.UploadPath, _model.UserID));
			}
			catch (Exception exception)
			{
				Logger.LogException(exception, "SerialNumbersUpload.btnUploadFile_Click");
				ShowError((string)GetLocalResourceObject("genericError"));
			}
		}
	}
}