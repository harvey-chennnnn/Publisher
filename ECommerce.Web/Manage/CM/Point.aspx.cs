using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM
{
    public partial class Point : ECommerce.Web.UI.WebPage
    {
        protected string RxValue = "";
        protected string RyValue = "";
        protected int RID;
        ECommerce.CM.DAL.PointRule rDAL = new ECommerce.CM.DAL.PointRule();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            var rModel = rDAL.GetModel(1);
            RID = 1;
            RxValue = rModel.RxValue;
            RyValue = rModel.RyValue;
        }
    }
}