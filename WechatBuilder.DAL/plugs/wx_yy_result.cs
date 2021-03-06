﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WechatBuilder.DBUtility;//Please add references
namespace WechatBuilder.DAL
{
	/// <summary>
	/// 数据访问类:wx_yy_result
	/// </summary>
	public partial class wx_yy_result
	{
		public wx_yy_result()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wx_yy_result"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wx_yy_result");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(WechatBuilder.Model.wx_yy_result model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wx_yy_result(");
			strSql.Append("formId,openid,cName,cId,userResult,createDate)");
			strSql.Append(" values (");
			strSql.Append("@formId,@openid,@cName,@cId,@userResult,@createDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@formId", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@cName", SqlDbType.VarChar,100),
					new SqlParameter("@cId", SqlDbType.Int,4),
					new SqlParameter("@userResult", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.formId;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.cName;
			parameters[3].Value = model.cId;
			parameters[4].Value = model.userResult;
			parameters[5].Value = model.createDate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WechatBuilder.Model.wx_yy_result model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wx_yy_result set ");
			strSql.Append("formId=@formId,");
			strSql.Append("openid=@openid,");
			strSql.Append("cName=@cName,");
			strSql.Append("cId=@cId,");
			strSql.Append("userResult=@userResult,");
			strSql.Append("createDate=@createDate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@formId", SqlDbType.Int,4),
					new SqlParameter("@openid", SqlDbType.VarChar,100),
					new SqlParameter("@cName", SqlDbType.VarChar,100),
					new SqlParameter("@cId", SqlDbType.Int,4),
					new SqlParameter("@userResult", SqlDbType.VarChar,2000),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.formId;
			parameters[1].Value = model.openid;
			parameters[2].Value = model.cName;
			parameters[3].Value = model.cId;
			parameters[4].Value = model.userResult;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_yy_result ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wx_yy_result ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public WechatBuilder.Model.wx_yy_result GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,formId,openid,cName,cId,userResult,createDate from wx_yy_result ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			WechatBuilder.Model.wx_yy_result model=new WechatBuilder.Model.wx_yy_result();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WechatBuilder.Model.wx_yy_result DataRowToModel(DataRow row)
		{
			WechatBuilder.Model.wx_yy_result model=new WechatBuilder.Model.wx_yy_result();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["formId"]!=null && row["formId"].ToString()!="")
				{
					model.formId=int.Parse(row["formId"].ToString());
				}
				if(row["openid"]!=null)
				{
					model.openid=row["openid"].ToString();
				}
				if(row["cName"]!=null)
				{
					model.cName=row["cName"].ToString();
				}
				if(row["cId"]!=null && row["cId"].ToString()!="")
				{
					model.cId=int.Parse(row["cId"].ToString());
				}
				if(row["userResult"]!=null)
				{
					model.userResult=row["userResult"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,formId,openid,cName,cId,userResult,createDate ");
			strSql.Append(" FROM wx_yy_result ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,formId,openid,cName,cId,userResult,createDate ");
			strSql.Append(" FROM wx_yy_result ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wx_yy_result ");
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
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wx_yy_result T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "wx_yy_result";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 删除该用户发的信息
        /// </summary>
        public bool DeleteByOpenid(string openid, int formId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wx_yy_result ");
            strSql.Append(" where openid=@openid and formId=@formId");
            SqlParameter[] parameters = {
					new SqlParameter("@openid", SqlDbType.VarChar,100),
                    new SqlParameter("@formId", SqlDbType.Int)
			};
            parameters[0].Value = openid;
            parameters[1].Value = formId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 获取用户提交的信息
        /// </summary>
        /// <param name="formid"></param>
        /// <returns></returns>
        public DataSet GetResultInfo(int formid)
        {
            DataSet ds = new DataSet();

            SqlParameter[] parameters = {
                    new SqlParameter("@formId", SqlDbType.Int)
			};
            parameters[0].Value = formid;

            ds = DbHelperSQL.RunProcedure("p_yuyue", parameters, "ds");
            return ds;
        }
		#endregion  ExtensionMethod
	}
}

