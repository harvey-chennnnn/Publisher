using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ECommerce.Web.Manage.Systems
{
    public partial class PackageAdmit : WebPage
    {
        readonly ECommerce.Admin.DAL.RootPackage rootPackageDal = new ECommerce.Admin.DAL.RootPackage();
        ECommerce.Admin.DAL.OrgPkgList orgPkgListDal = new ECommerce.Admin.DAL.OrgPkgList();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
                {
                    var model = rootPackageDal.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
                    if (null != model)
                    {
                        try
                        {
                            litPackage.Text = "总站资源包:" + model.RPName;
                            List<SqlParameter> parameters = new List<SqlParameter>();
                            var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["empId"] };
                            parameters.Add(parameter);
                            var str = "select OrgOrganize.*,StaPackage.Status as spstatus ,StaPackage.SPID,StaPackage.RPID from OrgOrganize left join StaPackage on OrgOrganize.OrgId=StaPackage.OrgId and StaPackage.RPID=@RPID and PkgType=0 where OrgOrganize.OrgType=1 ";
                            Database db = DatabaseFactory.CreateDatabase();
                            DbCommand dbCommand = db.GetSqlStringCommand(str);
                            dbCommand.Parameters.Add(new SqlParameter("@RPID", DbType.AnsiString) { Value = Request.QueryString["empId"] });
                            var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                            rptListWork.DataSource = dt;
                            rptListWork.DataBind();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
        }


        protected string GetStatus(object eval)
        {
            if ("" == eval.ToString())
            {
                return "<span class=\"label label-important\">未开始</span>";
            }
            if ("0" == eval.ToString())
            {
                return "<span class=\"label label-warning\">未完稿</span>";
            }
            if ("1" == eval.ToString())
            {
                return "<span class=\"label label-success\">已完稿</span>";
            }
            if ("2" == eval.ToString())
            {
                return "<span class=\"label label-success\">待审核</span>";
            }
            if ("3" == eval.ToString())
            {
                return "<span class=\"label label-success\">已发布</span>";
            }
            return "错误";
        }

        protected string GetCBStatus(object spstatus, object orgid, object rpid)
        {
            var str = "disabled=\"disabled\"";
            if ("" != spstatus.ToString())
            {
                Database db = DatabaseFactory.CreateDatabase();
                var sql = "select StaPackage.* from StaPackage join OrgOrganize  on OrgOrganize.OrgId=StaPackage.OrgId join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID where OrgPkgList.RPID=" + rpid + " and OrgOrganize.OrgId=" + orgid;
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    str = "";
                }
            }
            return str;
        }
    }
}