using System;

namespace ECommerce.Web.Manage.Adver
{
    public partial class AddAd : UI.WebPage
    {
        private readonly Admin.DAL.Advertisement _infosDal = new Admin.DAL.Advertisement();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var iid = Request.QueryString["aid"];
                if (!string.IsNullOrEmpty(iid))
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        txtName.Value = imodel.AName;

                        litPic.Text =
                            "<div class=\"upatta\" title=\"\" data-file=\"" + imodel.AImg + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"100\" height=\"100\" id=\"at-img\" src=\"/UploadFiles/" + imodel.AImg + "\"><span class=\"at-name\">" + imodel.AImg.Substring(36) + "</span></div></div></div>";
                    }
                }
            }
        }
    }
}