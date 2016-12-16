﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web.Manage.CM
{
    public partial class CMAuditArticle : ECommerce.Web.UI.WebPage
    {
        protected DataTable dataTable = new DataTable();// 创建dataTable对象
        ECommerce.CM.DAL.CMArticle aDAL = new ECommerce.CM.DAL.CMArticle(); //创建商品分类DAL对象
        ECommerce.CM.DAL.CMArea cmAreaDAL = new ECommerce.CM.DAL.CMArea(); //内容区域关系表
        ECommerce.Admin.DAL.SYS_RoleInfo sysRoleDal = new ECommerce.Admin.DAL.SYS_RoleInfo();          //用户角色关系表
        ECommerce.CM.DAL.CMArticleType cmTypeDal = new ECommerce.CM.DAL.CMArticleType();
        ECommerce.CM.DAL.CMColumn cDAL = new ECommerce.CM.DAL.CMColumn();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BingData();       //绑定文章类型
                DBindLm();//绑定栏目
                if (!string.IsNullOrEmpty(Request.QueryString["Status"]))
                {
                    ddlStatus.SelectedValue = Request.QueryString["Status"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ATId"]))
                {
                    ddlType.SelectedValue = Request.QueryString["ATId"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["Column"]))
                {
                    ddlColumn.SelectedValue = Request.QueryString["Column"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ProName"]))
                {
                    txtProName.Value = Request.QueryString["ProName"];
                }
                DataBingList(false);       //绑定商品分类列表信息
            }
        }
        /// <summary>
        /// 绑定文章类型
        /// </summary>
        private void BingData()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            ddlType.DataSource = cmTypeDal.GetList("", parameters);
            ddlType.DataTextField = "ATName";
            ddlType.DataValueField = "ATId";
            ddlType.DataBind();
            this.ddlType.Items.Insert(0, "文章类型");
            ddlType.SelectedIndex = 0;

        }
        /// <summary>
        /// 绑定栏目
        /// </summary>
        private void DBindLm()
        {
            ddlColumn.Items.Add(new ListItem("栏目", "0"));
            var dataTable = cDAL.GetDateList().Tables[0];
            var table1 = GetNewDataTable(dataTable, " Level=1 ", " ColId ");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ddlColumn.Items.Add(new ListItem(table1.Rows[i]["ColName"].ToString(),//绑定父类
                                                 table1.Rows[i]["ColID"].ToString()));
                var table2 = GetNewDataTable(dataTable, " ParentID='" + table1.Rows[i]["ColID"] + "'", " ColId ");
                if (table2.Rows.Count > 0)
                {
                    for (int k = 0; k < table2.Rows.Count; k++)
                    {
                        ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄" + table2.Rows[k]["ColName"]),//绑定子类
                                                         table2.Rows[k]["ColID"].ToString()));
                        var table3 = GetNewDataTable(dataTable, " ParentID='" + table2.Rows[k]["ColID"] + "'",
                                                 " ColId");
                        if (table3.Rows.Count > 0)
                        {

                            for (int j = 0; j < table3.Rows.Count; j++)
                            {
                                ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄┄┄" + table3.Rows[j]["ColName"]),//绑定二级子类
                                                         table3.Rows[j]["ColID"].ToString()));
                            }
                        }
                    }
                }
            }
        }
        public DataTable GetNewDataTable(DataTable dt, string condition, string sortOrder)
        {
            var newdt = dt.Clone();
            var dr = dt.Select(condition, sortOrder);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;
        }
        /// <summary>
        /// 绑定商品信息列表方法
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void DataBingList(bool isFirstPage)
        {
            #region 分页
            //当前页码
            int pageNum = 1;
            string sqlWhere = " b.Status!=2 ";        //查询条件
            var name = string.Empty;
            var status = string.Empty;
            var type = string.Empty;
            var column = string.Empty;
            //if (!string.IsNullOrEmpty(hidPtid2.Value))
            //{
            //    ptid = Convert.ToInt32(hidPtid2.Value);
            //    sqlWhere += " and a.PTId=" + ptid;
            //}

            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && ddlStatus.SelectedValue != "4")
            {
                status = ddlStatus.SelectedValue;
                sqlWhere += " and b.Status =" + status;
            }

            if (!string.IsNullOrEmpty(ddlType.SelectedValue) && ddlType.SelectedValue != "文章类型")
            {
                type = ddlType.SelectedValue;
                sqlWhere += " and b.ATId =" + type;
            }


            if (!string.IsNullOrEmpty(ddlColumn.SelectedValue) && ddlColumn.SelectedValue != "0")
            {
                column = ddlColumn.SelectedValue;
                sqlWhere += " and d.ColId =" + column;
            }

            if (!string.IsNullOrEmpty(txtProName.Value))
            {
                name = txtProName.Value;
                sqlWhere += " and Title like '%" + name.Trim() + "%'";
            }

            if (!isFirstPage)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Page"]))             //页数判断
                    {
                        pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            string sql = aDAL.GetDateListForTop(sqlWhere);          //查询商品sql方法
            //分页方法
            Pager.GetDataBind("Repeater", "rptArticle", sql, pageNum, 10, " ", "rownum", "CMAuditArticle.aspx?ProName=" + name + "&Status=" + status + "&ATId=" + type + "&Column=" + column + "&");
            #endregion
        }
        /// <summary>
        /// 审核商品数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = false;
                #region 获取审核商品Id
                int i = 0;
                string delStr = "";
                foreach (RepeaterItem item in rptArticle.Items)
                {
                    CheckBox cb = (CheckBox)item.FindControl("cbSelect");
                    if (cb == null || !cb.Checked) continue;
                    i++;
                    var litId = cb.ToolTip;
                    if (litId != null)
                    {
                        delStr += litId + ",";      //将Id拼接在一起形成字符串
                    }
                }
                #endregion
                if (delStr != "")
                {
                    VerifyPage("", false);
                    var user = Session["CurrentUser"] as ECommerce.Admin.Model.OrgUsers;
                    if (user != null)
                    {
                        res = aDAL.CheckList(delStr.Substring(0, delStr.Length - 1), 1, Convert.ToInt32(user.EmplId));       //审核商品方法
                    }
                }
                if (i == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
                }
                if (res)
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('审核成功！');</script>");
                    DataBingList(false);               //商品列表绑定方法参数商品名称
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('审核失败！');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('审核失败！');</script>");
            }
        }
        /// <summary>
        /// 取消审核商品数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBackCheck_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = false;
                #region 获取取消审核商品Id
                int i = 0;
                string delStr = "";
                foreach (RepeaterItem item in rptArticle.Items)
                {
                    CheckBox cb = (CheckBox)item.FindControl("cbSelect");
                    if (cb == null || !cb.Checked) continue;
                    i++;
                    var litId = cb.ToolTip;
                    if (litId != null)
                    {
                        delStr += litId + ",";      //将Id拼接在一起形成字符串
                    }
                }
                #endregion
                if (delStr != "")
                {
                    VerifyPage("", false);
                    var user = Session["CurrentUser"] as ECommerce.Admin.Model.OrgUsers;
                    if (user != null)
                    {
                        res = aDAL.CheckList(delStr.Substring(0, delStr.Length - 1), 0, Convert.ToInt32(user.EmplId));       //审核商品方法
                    }
                }
                if (i == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
                }
                if (res)
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消审核成功！');</script>");
                    DataBingList(false);               //商品列表绑定方法参数商品名称
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消审核失败！');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('取消审核失败！');</script>");
            }
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataBingList(true);               //商品列表绑定方法参数商品名称
        }



        /// <summary>
        /// 通过内容Id获取所属区域
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public string GetArea(string aid)
        {
            string area = "";
            string sqlWhere = " AId= @AId";
            List<SqlParameter> parameters = new List<SqlParameter>();
            var parameter = new SqlParameter("@AId", DbType.AnsiString);
            parameter.Value = aid;
            parameters.Add(parameter);
            DataSet dts = cmAreaDAL.GetListArea(sqlWhere, parameters);
            if (dts != null)
            {
                if (dts.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                    {
                        area += dts.Tables[0].Rows[i]["AreaName"] + ",";
                    }
                }
            }
            if (!string.IsNullOrEmpty(area))
            {
                return area.Substring(0, area.Length - 1);
            }
            else
            {
                return area;
            }
        }
        /// <summary>
        /// 文章类型筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBingList(true);
        }

        /// <summary>
        /// 栏目搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBingList(true);
        }
    }
}