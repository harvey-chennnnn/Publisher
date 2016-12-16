using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM.Ajax
{
    public partial class ColumnShow : ECommerce.Web.UI.WebPage
    {
        ECommerce.CM.DAL.CMColumn colDAL = new ECommerce.CM.DAL.CMColumn();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var ds = colDAL.GetDateList(" ParentId='" + id + "' ");
                var str = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = ds.Tables[0].Rows.Cast<DataRow>()
                                      .Aggregate(str,
                                                 (current, dr) =>
                                                 current + ("," + dr["ColId"]));
                }
                Response.Write(str);
                Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                throw ex;
            }
            catch
            {
                Response.Write("");
                Response.End();
            }
        }
    }
}