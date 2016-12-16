/**  版本信息模板在安装目录下，可自行修改。
* RootPackage.cs
*
* 功 能： N/A
* 类 名： RootPackage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  3/6/2015 3:20:33 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.IO;
using System.Web;

namespace ECommerce.Admin.DAL
{
    /// <summary>
    /// 数据访问类:RootPackage
    /// </summary>
    public partial class RootPackage
    {
        public RootPackage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(RPID)+1 from RootPackage";
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RPID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RootPackage where RPID=@RPID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RPID", DbType.Int32, RPID);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ECommerce.Admin.Model.RootPackage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RootPackage(");
            strSql.Append("ORPID,Status,RPName,CreateDate)");

            strSql.Append(" values (");
            strSql.Append("@ORPID,@Status,@RPName,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ORPID", DbType.Int32, model.ORPID);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "RPName", DbType.String, model.RPName);
            db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ECommerce.Admin.Model.RootPackage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RootPackage set ");
            strSql.Append("ORPID=@ORPID,");
            strSql.Append("Status=@Status,");
            strSql.Append("RPName=@RPName,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where RPID=@RPID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RPID", DbType.Int32, model.RPID);
            db.AddInParameter(dbCommand, "ORPID", DbType.Int32, model.ORPID);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "RPName", DbType.String, model.RPName);
            db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RootPackage ");
            strSql.Append(" where RPID=@RPID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RPID", DbType.Int32, RPID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RPIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RootPackage ");
            strSql.Append(" where RPID in (" + RPIDlist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ECommerce.Admin.Model.RootPackage GetModel(int RPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RPID,ORPID,Status,RPName,CreateDate from RootPackage ");
            strSql.Append(" where RPID=@RPID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RPID", DbType.Int32, RPID);
            ECommerce.Admin.Model.RootPackage model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ECommerce.Admin.Model.RootPackage DataRowToModel(DataRow row)
        {
            ECommerce.Admin.Model.RootPackage model = new ECommerce.Admin.Model.RootPackage();
            if (row != null)
            {
                if (row["RPID"] != null && row["RPID"].ToString() != "")
                {
                    model.RPID = Convert.ToInt32(row["RPID"].ToString());
                }
                if (row["ORPID"] != null && row["ORPID"].ToString() != "")
                {
                    model.ORPID = Convert.ToInt32(row["ORPID"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["RPName"] != null)
                {
                    model.RPName = row["RPName"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RPID,ORPID,Status,RPName,CreateDate ");
            strSql.Append(" FROM RootPackage ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="Top">int Top</param>
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(int Top, string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RPID,ORPID,Status,RPName,CreateDate ");
            strSql.Append(" FROM RootPackage ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM RootPackage ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where "+strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }*/
        /// <summary>
        /// 分页获取数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell  like写法:'%'+@Cell+'%' </param>
        /// <param name="orderby">string orderby</param>
        /// <param name="startIndex">开始页码</param>
        /// <param name="endIndex">结束页码</param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.RPID desc");
            }
            strSql.Append(")AS Row, T.*  from RootPackage T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "RootPackage");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "RPID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public List<ECommerce.Admin.Model.RootPackage> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RPID,ORPID,Status,RPName,CreateDate ");
            strSql.Append(" FROM RootPackage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            List<ECommerce.Admin.Model.RootPackage> list = new List<ECommerce.Admin.Model.RootPackage>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public ECommerce.Admin.Model.RootPackage ReaderBind(IDataReader dataReader)
        {
            ECommerce.Admin.Model.RootPackage model = new ECommerce.Admin.Model.RootPackage();
            object ojb;
            ojb = dataReader["RPID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RPID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["ORPID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ORPID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            model.RPName = dataReader["RPName"].ToString();
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CreateDate = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ALID, string LName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RootPackage where RPName=@RPName ");
            if (ALID != 0)
            {
                strSql.Append(" and RPID!=" + ALID);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RPName", DbType.String, LName);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DelOrgWorStaTran(string rpid)
        {
            Database db = DatabaseFactory.CreateDatabase();

            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    var AttaList = new StringBuilder();
                    AttaList.Append("select * from AttaList where ");
                    AttaList.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) )); ");
                    DbCommand dbComAttList = db.GetSqlStringCommand(AttaList.ToString());
                    var dtAttList = db.ExecuteDataSet(dbComAttList, trans).Tables[0];

                    var Infos = new StringBuilder();
                    Infos.Append(" select * from Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) );");
                    DbCommand dbComInfos = db.GetSqlStringCommand(Infos.ToString());
                    var dtInfos = db.ExecuteDataSet(dbComInfos, trans).Tables[0];

                    var TempInfo = new StringBuilder();
                    TempInfo.Append(" select * from TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + ")));");
                    DbCommand dbComTempInfo = db.GetSqlStringCommand(TempInfo.ToString());
                    var dtTempInfo = db.ExecuteDataSet(dbComTempInfo, trans).Tables[0];

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from AdInfos where ");
                    strSql.Append(
                        " Inf_IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) )); ");
                    strSql.Append("delete from AdInfos where ");
                    strSql.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) )); ");
                    strSql.Append("delete from InfoLabel where ");
                    strSql.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) )); ");

                    strSql.Append("delete from AttaList where ");
                    strSql.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) )); ");

                    //strSql.Append(" delete from TmpInfoList where TIID in (select TIID from dbo.TempInfo where ITID=@ITID );");
                    strSql.Append(" delete from Infos where TIID in (select TIID from dbo.TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + "))) );");
                    strSql.Append(" delete from TempInfo where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + ")));");
                    strSql.Append(" delete from InfoType where ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage where RPID in(" + rpid + ")));");
                    strSql.Append(" delete from StaPackage  where RPID in(" + rpid + ");");
                    strSql.Append(" delete from OrgPkgList  where RPID in(" + rpid + ");");
                    strSql.Append(" delete from RootPackage where RPID in(" + rpid + ");");

                    DbCommand dbCommanditid = db.GetSqlStringCommand(strSql.ToString());
                    object obj = db.ExecuteNonQuery(dbCommanditid, trans);
                    
                    trans.Commit();
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
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        #endregion
    }
}

