using System;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Systems
{
    public partial class ResetPassword : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
            }
        }

    }
}