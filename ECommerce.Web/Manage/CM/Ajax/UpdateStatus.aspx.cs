﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM.Ajax
{
    public partial class UpdateStatus : ECommerce.Web.UI.WebPage
    {
        ECommerce.CM.DAL.CMArticle aDAL = new ECommerce.CM.DAL.CMArticle();
        ECommerce.Admin.DAL.OrgCustomer ocDAL = new Admin.DAL.OrgCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                string aid = Request.QueryString["aid"];//文章id
                string status = Request.QueryString["status"];
                string cid = Request.QueryString["cid"];//注册会员id
                string cid2 = Request.QueryString["cid2"];//认证会员id
                bool rs;
                if (!string.IsNullOrEmpty(aid) && !string.IsNullOrEmpty(status))
                {
                    if (status == "1")
                    {
                        rs = aDAL.UpdateState(Convert.ToInt32(aid), 0);
                    }
                    else
                    {
                        rs = aDAL.UpdateState(Convert.ToInt32(aid), 1);
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
                else
                {
                    if (!string.IsNullOrEmpty(cid) && !string.IsNullOrEmpty(status))
                    {
                        if (status == "1")
                        {
                            rs = ocDAL.UpdateState(Convert.ToInt32(cid), 0);
                        }
                        else
                        {
                            rs = ocDAL.UpdateState(Convert.ToInt32(cid), 1);
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
                    else
                    {
                        if (status == "4")
                        {
                            rs = ocDAL.UpdateState(Convert.ToInt32(cid2), 3);
                        }
                        else
                        {
                            rs = ocDAL.UpdateState(Convert.ToInt32(cid2), 4);
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
            }
            catch
            {
                Response.Write("网络出错，请稍候再试");
                Response.End();
            }
        }
    }
}