using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ExportSQLObjectsNameSpace.classes
{
    public class clsTables
    {
        string ColumnName = string.Empty;
        string DataType = string.Empty;
        string Nullable = string.Empty;
        string Default = string.Empty;
        private bool identityExists = false;

        public string GenerateTable(string table_name, SqlConnection objSQLConnection, DataTable dataTable)
        {
            try
            {
                string sql = @"select  	TableName = a.name, 	ColumnName = b.name,  	'DataType' =  	      	CASE  			WHEN (b.xtype = 167 OR b.xtype = 175 OR b.xtype = 231 OR b.xtype = 239) AND b.length = -1 THEN UPPER(c.name) + '(MAX)' 			WHEN b.xtype = 167 OR b.xtype = 175 OR b.xtype = 231 OR b.xtype = 239 THEN UPPER(c.name) + '(' + CONVERT(VARCHAR, b.length) + ')' 			WHEN b.xtype = 106 OR b.xtype = 108 THEN UPPER(c.name) + '(' + CONVERT(VARCHAR, b.xprec) + ',' + CONVERT(VARCHAR, b.xscale) + ')' 		ELSE          		UPPER(c.name) 		END, 	'Nullable' =  	      	CASE  			WHEN b.isnullable = 1 THEN 'NULL' 		ELSE          		'NOT NULL' 		END FROM  	sysobjects a, 	syscolumns b, 	systypes c WHERE  	a.name = '" + table_name + "' AND 	a.id = b.id AND 	b.xtype = c.xtype ORDER BY  	a.name, 	b.COLID";
                SqlCommand objSQLCommand = new SqlCommand(sql, objSQLConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                objSQLCommand.CommandType = CommandType.Text;

                SqlParameter parameterUserID = new SqlParameter("@table_name", SqlDbType.NVarChar, 384);
                parameterUserID.Value = table_name;
                objSQLCommand.Parameters.Add(parameterUserID);

                DataTable objColumnNames = new DataTable();
                objSqlDataAdapter.Fill(objColumnNames);
                
                StringBuilder objStringBuilder = new StringBuilder();
                objStringBuilder.AppendLine("IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = '" + table_name + "' AND TYPE = 'U')");
                objStringBuilder.AppendLine("\tDROP TABLE " + table_name + ";");
                objStringBuilder.AppendLine("GO");
                objStringBuilder.AppendLine("");
                objStringBuilder.AppendLine("CREATE TABLE " + table_name);
                objStringBuilder.AppendLine("(");
                identityExists = false;
                
                for (int y = 0; y < objColumnNames.Rows.Count; y++)
                {
                    DataType = objColumnNames.Rows[y]["DataType"].ToString();
                    ColumnName = objColumnNames.Rows[y]["ColumnName"].ToString();
                    Nullable = objColumnNames.Rows[y]["Nullable"].ToString();
                    //objStringBuilder.Append("y:" + y.ToString() + " objColumnNames.Rows.Count:" + objColumnNames.Rows.Count.ToString() + "\t" + ColumnName + "\t\t" + GetIdentity(objSQLConnection, table_name) + " " + DataType + " " + GetDefault(objSQLConnection, table_name, ColumnName) + " " + Nullable);
                    objStringBuilder.Append("\t" + ColumnName + "\t\t" + GetIdentity(objSQLConnection, table_name) + " " + DataType + " " + GetDefault(objSQLConnection, table_name, ColumnName) + " " + Nullable);

                    if (y < objColumnNames.Rows.Count - 1)
                        objStringBuilder.AppendLine(",");
                }
                objStringBuilder.AppendLine("");

                objStringBuilder.AppendLine("\n);");
                objStringBuilder.AppendLine("GO");

                string tableText = objStringBuilder.ToString();

                return objStringBuilder.ToString();
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.Errors[0].ToString();
                return null;
            }
            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }
        }
        private string GetDefault(SqlConnection objSQLConnection, string table_name, string column_name)
        {
            string SQL = "select c.text AS DefaultText from sysobjects a, syscolumns b, syscomments c where a.id = b.id AND b.cdefault = c.id and a.name = '" + table_name + "' and b.name = '" + column_name + "'";

            SqlCommand objSQLCommand = new SqlCommand(SQL, objSQLConnection);
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
            DataTable objTableNames = new DataTable();
            objSqlDataAdapter.Fill(objTableNames);

            if (objTableNames != null)
            {
                if (objTableNames.Rows.Count > 0)
                {
                    return "DEFAULT " + objTableNames.Rows[0]["DefaultText"].ToString();
                }
                else
                    return "";
            }
            else
                return "";
        }

        private string GetIdentity(SqlConnection objSQLConnection, string tablename)
        {
            if (identityExists == false)
            {
                identityExists = true;
                string SQL = "SELECT SEED = (SELECT IDENT_SEED('" + tablename + "')), INCREMENT = (SELECT IDENT_INCR('" + tablename + "'))";
                SqlCommand objSQLCommand = new SqlCommand(SQL, objSQLConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objTableNames = new DataTable();
                objSqlDataAdapter.Fill(objTableNames);

                if (objTableNames != null)
                {
                    if (objTableNames.Rows.Count > 0)
                    {
                        if (objTableNames.Rows[0]["SEED"] != DBNull.Value)
                        {
                                string SEED = objTableNames.Rows[0]["SEED"].ToString();
                                string INCREMENT = objTableNames.Rows[0]["INCREMENT"].ToString();
                                return "IDENTITY (" + SEED + "," + INCREMENT + ")";
                        }
                        else
                            return "";
                    }
                    else
                    return "";
                }
                else
                    return "";
            }
            else
               return "";
        }
	}
}
