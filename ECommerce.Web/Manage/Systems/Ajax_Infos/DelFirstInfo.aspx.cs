using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ECommerce.Web.Manage.Systems.Ajax_Infos
{
    public partial class DelFirstInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Infos _infosDal = new Infos();
        private DataTable dtAttList = new DataTable();
        private DataTable dtInfos = new DataTable();
        private DataTable dtTempInfo = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var iid = Request.QueryString["iid"];
            if (!string.IsNullOrEmpty(iid))
            {
                try
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                var templatesql = "select TIID from TempInfo where ParentID=" + iid;
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
                                Attas.Append(" select * from AttaList where IID=" + iid);
                                DbCommand dbComAttList = db.GetSqlStringCommand(Attas.ToString());
                                var dtAttList1 = db.ExecuteDataSet(dbComAttList, trans).Tables[0];
                                dtAttList.Merge(dtAttList1);

                                var Infos = new StringBuilder();
                                Infos.Append(" select * from Infos where IID=" + iid);
                                DbCommand dbComInfos = db.GetSqlStringCommand(Infos.ToString());
                                var dtInfos1 = db.ExecuteDataSet(dbComInfos, trans).Tables[0];
                                dtInfos.Merge(dtInfos1);

                                #endregion
                                var delinfo = "delete from InfoLabel where IID=" + iid + ";delete from AdInfos where Inf_IID=" + iid + ";delete from AdInfos where IID=" + iid + ";delete from AttaList where IID=" + iid + ";delete from Infos where IID=" + iid;
                                DbCommand dbComDelInfo = db.GetSqlStringCommand(delinfo);
                                db.ExecuteNonQuery(dbComDelInfo, trans);
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
                                Response.Write("0|~|");
                                Response.End();
                            }
                            catch (System.Threading.ThreadAbortException ex)
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