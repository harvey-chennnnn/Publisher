using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ECommerce.Web.Manage.Template
{
    public partial class Ajax_DelTempInfo : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Infos _infosDal = new Infos();
        private DataTable dtAttList = new DataTable();
        private DataTable dtInfos = new DataTable();
        private DataTable dtTempInfo = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var tiid = Request.QueryString["tiid"];
            var rtiid = Request.QueryString["rtiid"];
            var tipage = Request.QueryString["tipage"];
            var delad = Request.QueryString["delad"];
            try
            {
                #region 删除页面

                if (!string.IsNullOrEmpty(tiid))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null != timodel)
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                DelTemplate(db, trans, Convert.ToInt32(timodel.TIID));
                                StringBuilder strSql3 = new StringBuilder();
                                strSql3.Append("select * from  TempInfo where ParentID=" + timodel.ParentID + " and ITID=" + timodel.ITID + " and TIPage>" +
                                               timodel.TIPage);
                                DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        var sql = "update TempInfo set TIPage=TIPage-1 where TIID=" +
                                                  dt.Rows[i]["TIID"];
                                        DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                        db.ExecuteNonQuery(dbCommand2, trans);
                                    }
                                }
                                trans.Commit();
                                conn.Close();
                                #region delete files

                                if (dtAttList.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtAttList.Rows.Count; i++)
                                    {
                                        try
                                        {
                                            var oldbpic =
                                                new FileInfo(
                                                    HttpContext.Current.Server.MapPath("/UploadFiles/" + dtAttList.Rows[i]["AttID"]));
                                            if (!string.IsNullOrEmpty(dtAttList.Rows[i]["AttID"].ToString()) && oldbpic.Exists)
                                            {
                                                oldbpic.Delete();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }

                                if (dtInfos.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtInfos.Rows.Count; i++)
                                    {
                                        try
                                        {
                                            var oldbpic =
                                                new FileInfo(
                                                    HttpContext.Current.Server.MapPath("/UploadFiles/" + dtInfos.Rows[i]["PicAttID"]));
                                            if (!string.IsNullOrEmpty(dtInfos.Rows[i]["PicAttID"].ToString()) && oldbpic.Exists)
                                            {
                                                oldbpic.Delete();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            var oldbpic1 =
                                                new FileInfo(
                                                    HttpContext.Current.Server.MapPath("/UploadFiles/" +
                                                                                       dtInfos.Rows[i]["VideoAttID"]));
                                            if (!string.IsNullOrEmpty(dtInfos.Rows[i]["VideoAttID"].ToString()) && oldbpic1.Exists)
                                            {
                                                oldbpic1.Delete();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            var oldbpic2 =
                                                new FileInfo(
                                                    HttpContext.Current.Server.MapPath("/UploadFiles/" + dtInfos.Rows[i]["ADPic"]));
                                            if (!string.IsNullOrEmpty(dtInfos.Rows[i]["ADPic"].ToString()) && oldbpic2.Exists)
                                            {
                                                oldbpic2.Delete();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }

                                    }
                                }

                                if (dtTempInfo.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtTempInfo.Rows.Count; i++)
                                    {
                                        try
                                        {
                                            var oldbpic =
                                                new FileInfo(
                                                    HttpContext.Current.Server.MapPath("/UploadFiles/" + dtTempInfo.Rows[i]["AttID"]));
                                            if (!string.IsNullOrEmpty(dtTempInfo.Rows[i]["AttID"].ToString()) && oldbpic.Exists)
                                            {
                                                oldbpic.Delete();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }

                                #endregion
                                Response.Write("0|~|" + (timodel.ParentID.ToString() == "0" ? "" : timodel.ParentID.ToString()));
                                Response.End();
                            }
                            catch (ThreadAbortException ex)
                            {
                            }
                            catch (Exception ee)
                            {
                                trans.Rollback();
                                conn.Close();
                                Response.Write("1|~|" + ee.Message);
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

                #endregion

                #region 修改页码

                if (!string.IsNullOrEmpty(rtiid) && !string.IsNullOrEmpty(tipage))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(rtiid));
                    if (null != timodel)
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                StringBuilder strSql4 = new StringBuilder();
                                strSql4.Append("select * from  TempInfo where ITID=" + timodel.ITID + " and ParentID=" +
                                               timodel.ParentID);
                                DbCommand dbCommand4 = db.GetSqlStringCommand(strSql4.ToString());
                                var dt4 = db.ExecuteDataSet(dbCommand4, trans).Tables[0];
                                if (dt4.Rows.Count < Convert.ToInt32(tipage))
                                {
                                    conn.Close();
                                    Response.Write("1|~|页码必须小于总页数");
                                    Response.End();
                                }
                                if (Convert.ToInt32(tipage) == timodel.TIPage)
                                {
                                    conn.Close();
                                    Response.Write("0|~|");
                                    Response.End();
                                }
                                if (Convert.ToInt32(tipage) > timodel.TIPage)
                                {
                                    StringBuilder strSql3 = new StringBuilder();
                                    strSql3.Append("select * from  TempInfo where ITID=" + timodel.ITID +
                                                   " and ParentID=" +
                                                   timodel.ParentID + " and TIPage>" +
                                                   timodel.TIPage + " and TIPage<=" + Convert.ToInt32(tipage));
                                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                    var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            var sql = "update TempInfo set TIPage=TIPage-1 where TIID=" +
                                                      dt.Rows[i]["TIID"];
                                            DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                            db.ExecuteNonQuery(dbCommand2, trans);
                                        }
                                    }
                                    var osql = "update TempInfo set TIPage=" + Convert.ToInt32(tipage) + " where TIID=" +
                                                      timodel.TIID;
                                    DbCommand dbCommando = db.GetSqlStringCommand(osql.ToString());
                                    db.ExecuteNonQuery(dbCommando, trans);
                                }
                                else
                                {
                                    StringBuilder strSql3 = new StringBuilder();
                                    strSql3.Append("select * from  TempInfo where ITID=" + timodel.ITID + " and ParentID=" +
                                                   timodel.ParentID + " and TIPage>=" +
                                                   Convert.ToInt32(tipage) + " and TIPage<" + timodel.TIPage);
                                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                    var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            var sql = "update TempInfo set TIPage=TIPage+1 where TIID=" +
                                                      dt.Rows[i]["TIID"];
                                            DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                            db.ExecuteNonQuery(dbCommand2, trans);
                                        }
                                    }
                                    var osql = "update TempInfo set TIPage=" + Convert.ToInt32(tipage) + " where TIID=" +
                                                      timodel.TIID;
                                    DbCommand dbCommando = db.GetSqlStringCommand(osql.ToString());
                                    db.ExecuteNonQuery(dbCommando, trans);
                                }

                                trans.Commit();
                                conn.Close();
                                Response.Write("0|~|");
                                Response.End();
                            }
                            catch (ThreadAbortException ex)
                            {
                            }
                            catch (Exception ee)
                            {
                                trans.Rollback();
                                conn.Close();
                                Response.Write("1|~|" + ee.Message);
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

                #endregion

                #region 删除广告

                if (!string.IsNullOrEmpty(delad))
                {
                    Database db = DatabaseFactory.CreateDatabase();
                    using (DbConnection conn = db.CreateConnection())
                    {
                        conn.Open();
                        DbTransaction trans = conn.BeginTransaction();
                        try
                        {
                            DelTemplate(db, trans, Convert.ToInt32(delad));

                            trans.Commit();
                            conn.Close();
                            Response.Write("0|~|");
                            Response.End();
                        }
                        catch (ThreadAbortException ex)
                        {
                        }
                        catch (Exception ee)
                        {
                            trans.Rollback();
                            conn.Close();
                            Response.Write("1|~|" + ee.Message);
                            Response.End();
                        }
                    }
                }

                #endregion
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
        protected void DelTemplate(Database db, DbTransaction trans, int tiid)
        {
            var infosql = "select IID from Infos where TIID=" + tiid;
            DbCommand dbComInfo = db.GetSqlStringCommand(infosql);
            var dtInfo = db.ExecuteDataSet(dbComInfo, trans).Tables[0];
            for (int j = 0; j < dtInfo.Rows.Count; j++)
            {
                var templatesql = "select TIID from TempInfo where ParentID=" + dtInfo.Rows[j]["IID"];
                DbCommand dbComTemplate = db.GetSqlStringCommand(templatesql);
                var dt = db.ExecuteDataSet(dbComTemplate, trans).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DelTemplate(db, trans, Convert.ToInt32(dt.Rows[i]["TIID"]));
                    }
                }
                #region

                var Attas = new StringBuilder();
                Attas.Append(" select * from AttaList where IID=" + dtInfo.Rows[j]["IID"]);
                DbCommand dbComAttList = db.GetSqlStringCommand(Attas.ToString());
                var dtAttList1 = db.ExecuteDataSet(dbComAttList, trans).Tables[0];
                dtAttList.Merge(dtAttList1);

                var Infos = new StringBuilder();
                Infos.Append(" select * from Infos where IID=" + dtInfo.Rows[j]["IID"]);
                DbCommand dbComInfos = db.GetSqlStringCommand(Infos.ToString());
                var dtInfos1 = db.ExecuteDataSet(dbComInfos, trans).Tables[0];
                dtInfos.Merge(dtInfos1);

                #endregion
                var delinfo = "delete from InfoLabel where IID=" + dtInfo.Rows[j]["IID"] +
                              ";delete from AttaList where IID=" + dtInfo.Rows[j]["IID"] + ";delete from AdInfos where Inf_IID=" + dtInfo.Rows[j]["IID"] + ";delete from AdInfos where IID=" + dtInfo.Rows[j]["IID"] + ";delete from Infos where IID=" + dtInfo.Rows[j]["IID"];
                DbCommand dbComDelInfo = db.GetSqlStringCommand(delinfo);
                db.ExecuteNonQuery(dbComDelInfo, trans);

            }
            var TempInfo = new StringBuilder();
            TempInfo.Append(" select * from TempInfo where TIID=" + tiid);
            DbCommand dbComTempInfo = db.GetSqlStringCommand(TempInfo.ToString());
            var dtTempInfo1 = db.ExecuteDataSet(dbComTempInfo, trans).Tables[0];
            dtTempInfo.Merge(dtTempInfo1);

            var delTemplate = "delete from TempInfo where TIID=" + tiid;
            DbCommand dbComDelTemplate = db.GetSqlStringCommand(delTemplate);
            db.ExecuteNonQuery(dbComDelTemplate, trans);
        }
    }

}