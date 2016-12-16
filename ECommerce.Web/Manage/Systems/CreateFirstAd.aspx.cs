﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems
{
    public partial class CreateFirstAd : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        readonly Infos _infosDal = new Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                var spid = Request.QueryString["spid"];
                if (!string.IsNullOrEmpty(spid))
                {
                    #region 导航

                    var ptiid = Request.QueryString["ptiid"];
                    if (!string.IsNullOrEmpty(ptiid))
                    {
                        litStaName.Text = "<div class=\"backup\"><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn backfirst\">返回首页</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                                          "&tiid=" + ptiid + "&itid=" + Request.QueryString["itid"] +
                                          "\" class=\"back_btn\">返回上级</a> </div>";
                    }
                    else
                    {
                        #region 分站名称

                        var spmodel = _staPackageDal.GetModel(Convert.ToInt32(spid));
                        if (null != spmodel)
                        {
                            var orgmodel = _orgOrganizeDal.GetModel(Convert.ToInt64(spmodel.OrgId));
                            if (null != orgmodel)
                            {
                                litStaName.Text =
                                    "<div class=\"logo\"><img src=\"/images/LOGO-yt.png\" style=\"display: block; width: 50px; height: 50px;\" alt=\"沿途\" /></div><div class=\"title\"><strong>" +
                                    orgmodel.OrgName + "</strong><span>" + orgmodel.EnName + "</span></div>";
                            }
                        }

                        #endregion
                    }

                    #endregion

                    var itid = Request.QueryString["itid"];//分类id
                    if (!string.IsNullOrEmpty(itid))
                    {
                        var model = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                        if (null != model)
                        {

                            litType.Text = ECommerce.Lib.Service.GetType(Convert.ToInt32(model.ITID), spid);
                        }
                    }
                    else
                    {
                        litType.Text = ECommerce.Lib.Service.GetType(0, spid);
                    }
                }
            }
        }
    }
}