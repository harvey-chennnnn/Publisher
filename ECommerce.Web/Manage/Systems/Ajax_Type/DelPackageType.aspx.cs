using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems.Ajax_Type
{
    public partial class DelPackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var itid = Request.QueryString["itid"];

                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != itmodel)
                    {
                        var upres = _infoTypeDal.DelPackType(itmodel);
                        if (upres)
                        {
                            Response.Write("0|~|" + itid);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("1|~|操作失败");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }

    }

}