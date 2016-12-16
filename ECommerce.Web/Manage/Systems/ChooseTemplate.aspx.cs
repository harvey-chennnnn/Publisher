﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems
{
    public partial class ChooseTemplate : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly ECommerce.Admin.DAL.Templates _templatesDal = new Templates();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindData();
                var spid = Request.QueryString["spid"];
                if (!string.IsNullOrEmpty(spid))
                {

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

        private void BindData()
        {
            List<SqlParameter> pars1 = new List<SqlParameter>();
            var dt = _templatesDal.GetList(" Status=1 and TType=1 ", pars1).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }
}