using System;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Diagnostics;

namespace Apple.Web.Admin.CSV
{
    /// <summary>
    /// Summary description for CsvHelper
    /// </summary>
    public class CsvHelper
    {
        public CsvHelper()
        {
        }

		StringBuilder sb;
        /// <summary>
        /// Writes to response generated csv file
        /// </summary>
        /// <param name="data">DataTable, or DataView, or Generic List &lt;&gt;</param>
        /// <param name="columnNames">Comma separated list of columns</param>
        /// <param name="fileName">File name to return to user</param>
        public void WriteToCSV(object data, ReportOptions o)
        {
			sb = new StringBuilder();
            if (String.IsNullOrEmpty(o.FileName))
                throw new InvalidOperationException("Parameter fileName is not valid!");

            string attachment = String.Format("attachment; filename={0}.csv", o.FileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv; charset=utf-8";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
			
            if (data is DataTable)
            {
                DataTable t = (DataTable)data;
                WriteTable(o.Columns, t, o);
            }
            else if (data is DataView)
            {
                DataTable t = ((DataView)data).Table;
                WriteTable(o.Columns, t, o);
            }
            else if (data is IEnumerable)
            {
                IEnumerator en = ((IEnumerable)data).GetEnumerator();
                WriteHeader(o.HeaderText, o);
                while (en.MoveNext())
                {
                    ProcessListItem(en.Current, o.Columns, o);
                }
            }
            else
            {
                throw new InvalidOperationException("Parameter data is not DataTable, or DataView, or Generic List<>!");
            }
			var Response = HttpContext.Current.Response;
			string result = sb.ToString();
			Encoding enc2 = Encoding.UTF8;
			var bytes = enc2.GetBytes(result);
			var enc = Encoding.UTF8;
			
			Response.Write(enc2.GetString(Encoding.Convert(enc, enc2, bytes)));
			Response.Flush();			
            HttpContext.Current.Response.End();
        }

        private void WriteTable(string columns, DataTable t, ReportOptions o)
        {
            WriteHeader(columns, o);
            foreach (DataRow r in t.Rows)
            {
                ProcessDataRow(r, columns,o );
            }
        }

        private void WriteHeader(string columns, ReportOptions o)
        {
            if (!String.IsNullOrEmpty(columns))
            {
				foreach (string c in columns.Split(','))
				{
					sb.Append(c);
					sb.Append(o.Splitter);
				}
				sb.Append(Environment.NewLine);
            }
        }

        private void ProcessDataRow(DataRow r, string columns, ReportOptions o)
        {
            StringBuilder sb1 = new StringBuilder();

            if (String.IsNullOrEmpty(columns))
            {
                foreach (DataColumn c in r.Table.Columns)
                {
                    AddWithComma(r[c.ColumnName], sb1, o.Splitter);
                }
            }
            else
            {
                foreach (string c in columns.Split(','))
                {
                    AddWithComma(r[c], sb1, o.Splitter);
                }
            }

            sb.Append(sb1.ToString().TrimEnd(o.Splitter[0]));
            sb.Append(Environment.NewLine);
        }

        private void AddWithComma(object value, StringBuilder stringBuilder, string splitter)
        {
            if (value != null)
            {
                string v = String.Format(FormatHelper.GetFormat(value.GetType()), value);

                if (!String.IsNullOrEmpty(v))
                    stringBuilder.Append(v);
            }
			stringBuilder.Append(splitter);
        }

        private void ProcessListItem(object p, string colums, ReportOptions opt)
        {
            StringBuilder sb1 = new StringBuilder();

            foreach (string c in colums.Split(','))
            {

                PropertyInfo info = p.GetType().GetProperty(c);

                if (info == null)
                    throw new Exception(String.Format("No such field: {0}", c));

                if (info.CanRead)
                {
                    object o = info.GetValue(p, null);

                    AddWithComma(o, sb1, opt.Splitter);
                }
            }

            sb.Append(sb1.ToString().TrimEnd(opt.Splitter[0]));
            sb.Append(Environment.NewLine);

        }
    }
}