using System.Collections.Generic;
using System.IO;
using System.Linq;
using Erc.Apple.Data.Models;
using Erc.Apple.Data.Repositories;
using LinqToExcel;
using System;

namespace Apple.Web.Admin.Library.Models
{
	public class SerialNumbersUploadModel
	{
		#region Properties

		public string UploadPath { get; set; }
		public int UserID { get; set; }

		#endregion

		#region Constructors

		public SerialNumbersUploadModel(int userID, string uploadPath)
		{
			UserID = userID;
			UploadPath = uploadPath;
		}

		#endregion

		#region Methods

		public bool IsValid()
		{
			if (string.IsNullOrEmpty(UploadPath))
				return false;

			if (UserID < 1)
				return false;

			return true;
		}

		public IDictionary<string, int> UploadSerialNumbers(List<byte[]> filesWithSerialNumbers)
		{
			IDictionary<string, int> results = new Dictionary<string, int>();

			foreach (var bytes in filesWithSerialNumbers)
			{
				string fileName = GetNextFileName();

				using (var writer = new BinaryWriter(GetNextOutputStream(fileName)))
				{
					writer.Write(bytes);
					writer.Close();
				}

				int serialNumbersCount = GetSerialNumbersFromFile(fileName).Count;

				if (serialNumbersCount > 0)
					results.Add(new KeyValuePair<string, int>(fileName, serialNumbersCount));
				else
					File.Delete(fileName);
			}

			return results;
		}

		public int CommitChanges(List<string> fileNames)
		{
			int numberOfCommitedSerialNumbers = 0;

			foreach (string fileName in fileNames)
			{
				List<SerialNumber> serialNumbers = GetSerialNumbersFromFile(fileName);
				SerialNumberRepository repository = new SerialNumberRepository();
				serialNumbers.ForEach(s =>
				                      	{
				                      		s.AdminID = this.UserID;
				                      		s.CreatedDate = DateTime.Now;
											repository.Add(s);
				                      	});
				repository.Save();
				numberOfCommitedSerialNumbers = serialNumbers.Count;
			}

			return numberOfCommitedSerialNumbers;
		}

		public void RollbackChanges(List<string> fileNames)
		{
			foreach (string fileName in fileNames)
				File.Delete(fileName);
		}

		#endregion

		#region Protected methods

		protected List<SerialNumber> GetSerialNumbersFromFile(string fileName)
		{
			List<SerialNumber> newSerialNumbers = (from s in new ExcelQueryFactory(fileName).Worksheet<SerialNumber>()
			                                       select s).ToList();

			return (from p in newSerialNumbers
			        where !((from s in new SerialNumberRepository().GetAll() select s).Any(s => s.Number == p.Number))
			        select p)
					.GroupBy(x => x.Number)
					.Select(x => x.First())
					.ToList();
		}


		protected string GetNextFileName()
		{
			return UploadPath + "SerialNumbers_" + Path.GetRandomFileName() + ".xls";
		}

		protected Stream GetNextOutputStream(string fileName)
		{
			return File.Create(fileName);
		}

		#endregion
	}
}