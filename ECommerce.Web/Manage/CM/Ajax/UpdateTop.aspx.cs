using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM.Ajax
{
    public partial class UpdateTop : ECommerce.Web.UI.WebPage
    {
        ECommerce.CM.DAL.CMArticle aDAL = new ECommerce.CM.DAL.CMArticle();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                string aid = Request.QueryString["aid"];
                string top = Request.QueryString["top"];
                bool rs;
                if (!string.IsNullOrEmpty(aid) && !string.IsNullOrEmpty(top))
                {
                    if (top == "1")
                    {
                        rs = aDAL.UpdateTop(Convert.ToInt32(aid), 0);
                    }
                    else
                    {
                        rs = aDAL.UpdateTop(Convert.ToInt32(aid), 1);
                    }
                    if (rs)
                    {
                        Response.Write("修改成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("网络出错，请稍候再试");
                        Response.End();
                    }
                }
            }
            catch
            {
                Response.Write("网络出错，请稍候再试");
                Response.End();
            }
        }
    }
}