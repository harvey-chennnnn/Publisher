﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace ECommerce.Area.DAL
{
    /// <summary>
    /// 数据访问类:LandAttributeValue
    /// </summary>
    public partial class LandAttributeValue
    {
        public LandAttributeValue()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(LAVId)+1 from LandAttributeValue";
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
        public bool Exists(int LAVId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LandAttributeValue where LAVId=@LAVId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LAVId", DbType.Int32, LAVId);
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
        public int Add(ECommerce.Area.Model.LandAttributeValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LandAttributeValue(");
            strSql.Append("LId,LAId,EmplId,LAValue,Addtime)");

            strSql.Append(" values (");
            strSql.Append("@LId,@LAId,@EmplId,@LAValue,@Addtime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, model.LId);
            db.AddInParameter(dbCommand, "LAId", DbType.Int32, model.LAId);
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "LAValue", DbType.String, model.LAValue);
            db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
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
        public bool Update(ECommerce.Area.Model.LandAttributeValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LandAttributeValue set ");
            strSql.Append("LId=@LId,");
            strSql.Append("LAId=@LAId,");
            strSql.Append("EmplId=@EmplId,");
            strSql.Append("LAValue=@LAValue,");
            strSql.Append("Addtime=@Addtime");
            strSql.Append(" where LAVId=@LAVId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LAVId", DbType.Int32, model.LAVId);
            db.AddInParameter(dbCommand, "LId", DbType.Int32, model.LId);
            db.AddInParameter(dbCommand, "LAId", DbType.Int32, model.LAId);
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "LAValue", DbType.String, model.LAValue);
            db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
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
        public bool Delete(int LAVId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandAttributeValue ");
            strSql.Append(" where LAVId=@LAVId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LAVId", DbType.Int32, LAVId);
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
        public bool DeleteList(string LAVIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandAttributeValue ");
            strSql.Append(" where LAVId in (" + LAVIdlist + ")  ");
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
        public ECommerce.Area.Model.LandAttributeValue GetModel(int LAVId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LAVId,LId,LAId,EmplId,LAValue,Addtime from LandAttributeValue ");
            strSql.Append(" where LAVId=@LAVId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LAVId", DbType.Int32, LAVId);
            ECommerce.Area.Model.LandAttributeValue model = null;
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
        public ECommerce.Area.Model.LandAttributeValue DataRowToModel(DataRow row)
        {
            ECommerce.Area.Model.LandAttributeValue model = new ECommerce.Area.Model.LandAttributeValue();
            if (row != null)
            {
                if (row["LAVId"] != null && row["LAVId"].ToString() != "")
                {
                    model.LAVId = Convert.ToInt32(row["LAVId"].ToString());
                }
                if (row["LId"] != null && row["LId"].ToString() != "")
                {
                    model.LId = Convert.ToInt32(row["LId"].ToString());
                }
                if (row["LAId"] != null && row["LAId"].ToString() != "")
                {
                    model.LAId = Convert.ToInt32(row["LAId"].ToString());
                }
                if (row["EmplId"] != null && row["EmplId"].ToString() != "")
                {
                    model.EmplId = Convert.ToInt32(row["EmplId"].ToString());
                }
                if (row["LAValue"] != null)
                {
                    model.LAValue = row["LAValue"].ToString();
                }
                if (row["Addtime"] != null && row["Addtime"].ToString() != "")
                {
                    model.Addtime = Convert.ToDateTime(row["Addtime"].ToString());
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
            strSql.Append("select LAVId,LId,LAId,EmplId,LAValue,Addtime ");
            strSql.Append(" FROM LandAttributeValue ");
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
            strSql.Append(" LAVId,LId,LAId,EmplId,LAValue,Addtime ");
            strSql.Append(" FROM LandAttributeValue ");
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
            strSql.Append("select count(1) FROM LandAttributeValue ");
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
                strSql.Append("order by T.LAVId desc");
            }
            strSql.Append(")AS Row, T.*  from LandAttributeValue T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "LandAttributeValue");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LAVId");
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
        public List<ECommerce.Area.Model.LandAttributeValue> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LAVId,LId,LAId,EmplId,LAValue,Addtime ");
            strSql.Append(" FROM LandAttributeValue ");
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
            List<ECommerce.Area.Model.LandAttributeValue> list = new List<ECommerce.Area.Model.LandAttributeValue>();
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
        public ECommerce.Area.Model.LandAttributeValue ReaderBind(IDataReader dataReader)
        {
            ECommerce.Area.Model.LandAttributeValue model = new ECommerce.Area.Model.LandAttributeValue();
            object ojb;
            ojb = dataReader["LAVId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LAVId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["LId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["LAId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LAId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["EmplId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmplId = Convert.ToInt32(ojb);
            }
            model.LAValue = dataReader["LAValue"].ToString();
            ojb = dataReader["Addtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Addtime = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region ExMethod
        /// <summary>
        /// 获得商品信息
        /// </summary>
        public DataSet GetDateInfo(int lid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select lav.*,la.LAName from LandAttributeValue lav ");
            strSql.Append(" join LandAttribute la on la.LAId=lav.LAId ");
            strSql.Append(" where lav.LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int32, lid);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}

