using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Apple.Web.Admin.Library.Models;
using System.IO;

namespace Apple.Tests
{
	[TestFixture]
	public class SerialNumbersUploadModelTest
	{
		[Test]
		public void Constructor_Assigns_UserID_And_UploadPath()
		{ 
			string uploadPath = @"C:\test\path\";
			int userID = 1;

			SerialNumbersUploadModel model = new SerialNumbersUploadModel(userID, uploadPath);

			Assert.AreEqual(uploadPath, model.UploadPath);
			Assert.AreEqual(userID, model.UserID);
		}

		[Test]
		public void Model_With_UserID_Less_Than_1_Is_Not_Valid()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(0, "test path");
			Assert.IsFalse(model.IsValid());
		}

		[Test]
		public void Model_With_UserID_Greater_Than_0_Is_Valid()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, "test path");
			Assert.IsTrue(model.IsValid());
		}

		[Test]
		public void Model_With_Empty_UploadPath_Is_Not_Valid()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, "");
			Assert.IsFalse(model.IsValid());
		}

		[Test]
		public void Model_With_UploadPath_Is_Valid()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, "test path");
			Assert.IsTrue(model.IsValid());
		}

		[Test]
		public void GetNextFileName_Returns_String_That_Starts_With_UploadPath()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, @"c:\test\");
			var GetNextFileName = (Func<String>) Delegate.CreateDelegate(typeof(Func<String>), model, "GetNextFileName");
			Assert.IsTrue(GetNextFileName().StartsWith(@"c:\test\"));
		}

		[Test]
		public void GetNextFileName_Returns_String_That_Ends_With_XLS()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, @"c:\test\");
			var GetNextFileName = (Func<String>) Delegate.CreateDelegate(typeof(Func<String>), model, "GetNextFileName");
			Assert.IsTrue(GetNextFileName().EndsWith(@".xls"));
		}

		[Test]
		public void GetNextFileName_Returns_Not_Null_Or_Empty_String()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, @"c:\test\");
			var GetNextFileName = (Func<String>)Delegate.CreateDelegate(typeof(Func<String>), model, "GetNextFileName");
			Assert.IsNotNullOrEmpty(GetNextFileName());
		}

		[Test]
		public void GetNextFileName_Returns_Unique_FileNames()
		{
			SerialNumbersUploadModel model = new SerialNumbersUploadModel(1, @"c:\test\");
			var GetNextFileName = (Func<String>)Delegate.CreateDelegate(typeof(Func<String>), model, "GetNextFileName");
			Assert.AreNotEqual(GetNextFileName(), GetNextFileName());
		}
	}
}
