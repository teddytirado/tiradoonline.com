using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using objFileIO = System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassLibraryNameSpace
{
    public class ClassLibrarySQLServer
    {
        public string SQLServerName { get; set; }
        public string SQLServerDatabaseName { get; set; }
        public string SQLUserName { get; set; }
        public string SQLPassword { get; set; }
        public string OutputDirectory { get; set; }
        public Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();
        public object misValue = System.Reflection.Missing.Value;
        public Excel.Workbook excelWorkBook;
        public Excel.Worksheet excelWorkSheet;
        public string strDebugger;

        public ClassLibrarySQLServer()  
        {
        }

        public string SQLGetStoredProdedures()
        {
            StringBuilder objStringBuilder = new StringBuilder();
            objStringBuilder.AppendLine("SELECT ");
	        objStringBuilder.AppendLine("    StoredProcedureName = a.name, ");
       	    objStringBuilder.AppendLine("    ParameterName = b.name, ");
       	    objStringBuilder.AppendLine("    DataType = UPPER(c.name), ");
	        objStringBuilder.AppendLine("    DataTypeLength = b.length,");
	        objStringBuilder.AppendLine("    DataTypePrecision = b.xprec, ");
	        objStringBuilder.AppendLine("    DataTypeScale = b.xscale, ");
	        objStringBuilder.AppendLine("    Nullable = b.isnullable, ");
	        objStringBuilder.AppendLine("    OutputParameter = b.isoutparam, ");
            objStringBuilder.AppendLine("    TotalParameters = (SELECT COUNT(*) FROM SYSOBJECTS, SYSCOLUMNS WHERE SYSOBJECTS.id = a.id and SYSCOLUMNS.id = b.id) ");
            objStringBuilder.AppendLine("FROM  ");
	        objStringBuilder.AppendLine("    SYSOBJECTS a, ");
	        objStringBuilder.AppendLine("    SYSCOLUMNS b, ");
	        objStringBuilder.AppendLine("    SYS.TYPES c ");
            objStringBuilder.AppendLine("WHERE ");
	        objStringBuilder.AppendLine("    a.id = b.id ");
	        objStringBuilder.AppendLine("    AND b.xtype = c.user_type_id "); 
            objStringBuilder.AppendLine("    AND a.type ='p' ");
            objStringBuilder.AppendLine("    AND a.name NOT LIKE '%sourcecontrol%' ");
	        objStringBuilder.AppendLine("    AND a.name NOT LIKE '%diagram%' ");
	        objStringBuilder.AppendLine("    AND UPPER(LEFT(a.name, 3)) <> 'DT_' ");
            objStringBuilder.AppendLine("ORDER BY  ");
	        objStringBuilder.AppendLine("    a.name, ");
	        objStringBuilder.AppendLine("    b.colorder;");

            return objStringBuilder.ToString();
        }

        private string SQLGetTables()
        {
            StringBuilder objStringBuilder = new StringBuilder();

            objStringBuilder.AppendLine("	SELECT ");
            objStringBuilder.AppendLine("		TableName = TABLE_NAME, ");
            objStringBuilder.AppendLine("		ColumnName = COLUMN_NAME, ");
            objStringBuilder.AppendLine("		DataType = UPPER(DATA_TYPE), ");
            objStringBuilder.AppendLine("		DataTypeLength = CHARACTER_MAXIMUM_LENGTH, ");
            objStringBuilder.AppendLine("		NumericPrecision = NUMERIC_PRECISION,");
            objStringBuilder.AppendLine("		NumericScale = NUMERIC_SCALE,");
            objStringBuilder.AppendLine("		Nullable = IS_NULLABLE,");
            objStringBuilder.AppendLine("		Position = ORDINAL_POSITION");
            objStringBuilder.AppendLine("	INTO");
            objStringBuilder.AppendLine("		#TABLES");
            objStringBuilder.AppendLine("	FROM ");
            objStringBuilder.AppendLine("		INFORMATION_SCHEMA.COLUMNS");
            objStringBuilder.AppendLine("	WHERE");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 2)) != 'DT' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != 'SYS' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != '_WA' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != 'UDX' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != 'UK_'");
            objStringBuilder.AppendLine("	ORDER BY ");
            objStringBuilder.AppendLine("		TableName,");
            objStringBuilder.AppendLine("		ORDINAL_POSITION;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	/***********************************************");
            objStringBuilder.AppendLine("	PRIMARY KEYS");
            objStringBuilder.AppendLine("	************************************************/");
            objStringBuilder.AppendLine("	SELECT ");
            objStringBuilder.AppendLine("		TableName = tc.TABLE_NAME,");
            objStringBuilder.AppendLine("		ColumnName = COLUMN_NAME");
            objStringBuilder.AppendLine("	INTO");
            objStringBuilder.AppendLine("		#PRIMARY_KEYS");
            objStringBuilder.AppendLine("	FROM");
            objStringBuilder.AppendLine("		INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc");
            objStringBuilder.AppendLine("	        JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON tc.CONSTRAINT_NAME = ccu.Constraint_name");
            objStringBuilder.AppendLine("	WHERE ");
            objStringBuilder.AppendLine("		UPPER(tc.CONSTRAINT_TYPE) = 'PRIMARY KEY' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(tc.TABLE_NAME, 3)) != 'SYS' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(tc.TABLE_NAME, 3)) != '_WA' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(tc.TABLE_NAME, 3)) != 'UDX' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(tc.TABLE_NAME, 3)) != 'UK_'");
            objStringBuilder.AppendLine("	ORDER BY");
            objStringBuilder.AppendLine("		TableName,");
            objStringBuilder.AppendLine("		ColumnName;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CREATE INDEX PRIMARY_KEYS_TableName_ColumnName ON #PRIMARY_KEYS(TableName, ColumnName);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	/***********************************************");
            objStringBuilder.AppendLine("	FOREIGN KEYS");
            objStringBuilder.AppendLine("	************************************************/");
            objStringBuilder.AppendLine("	SELECT");
            objStringBuilder.AppendLine("		TableName = FK.TABLE_NAME,");
            objStringBuilder.AppendLine("		ColumnName = CU.COLUMN_NAME,");
            objStringBuilder.AppendLine("		ForeignKeyTableName = PK.TABLE_NAME,");
            objStringBuilder.AppendLine("		ForeignKeyColumnName = PT.COLUMN_NAME");
            objStringBuilder.AppendLine("	INTO");
            objStringBuilder.AppendLine("		#FOREIGN_KEYS");
            objStringBuilder.AppendLine("	FROM ");
            objStringBuilder.AppendLine("		INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C");
            objStringBuilder.AppendLine("		INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME");
            objStringBuilder.AppendLine("		INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME");
            objStringBuilder.AppendLine("		INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME");
            objStringBuilder.AppendLine("		INNER JOIN (");
            objStringBuilder.AppendLine("			SELECT ");
            objStringBuilder.AppendLine("				i1.TABLE_NAME, ");
            objStringBuilder.AppendLine("				i2.COLUMN_NAME");
            objStringBuilder.AppendLine("			FROM ");
            objStringBuilder.AppendLine("				INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1");
            objStringBuilder.AppendLine("				INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME");
            objStringBuilder.AppendLine("				WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'");
            objStringBuilder.AppendLine("			) ");
            objStringBuilder.AppendLine("		PT ON PT.TABLE_NAME = PK.TABLE_NAME");
            objStringBuilder.AppendLine("	ORDER BY");
            objStringBuilder.AppendLine("		TableName,	");
            objStringBuilder.AppendLine("		ColumnName;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CREATE INDEX FOREIGN_KEYS_TableName_ColumnName ON #FOREIGN_KEYS(TableName, ColumnName);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	SELECT ");
            objStringBuilder.AppendLine("		TableName = TABLE_NAME,");
            objStringBuilder.AppendLine("		Seed = IDENT_SEED(TABLE_NAME),");
            objStringBuilder.AppendLine("		Increment = IDENT_INCR(TABLE_NAME)");
            objStringBuilder.AppendLine(" 	INTO ");
            objStringBuilder.AppendLine(" 		#IDENTITY");
            objStringBuilder.AppendLine("	FROM ");
            objStringBuilder.AppendLine("		INFORMATION_SCHEMA.TABLES");
            objStringBuilder.AppendLine("	WHERE ");
            objStringBuilder.AppendLine("		OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'TableHasIdentity') = 1");
            objStringBuilder.AppendLine("		AND TABLE_TYPE = 'BASE TABLE' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != 'SYS' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != '_WA' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 3)) != 'UK_' AND");
            objStringBuilder.AppendLine("		UPPER(LEFT(TABLE_NAME, 2)) != 'DT'");
            objStringBuilder.AppendLine("	ORDER BY");
            objStringBuilder.AppendLine("		TableName;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CREATE INDEX IDENTITY_TableName ON #IDENTITY(TableName);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	/***********************************************");
            objStringBuilder.AppendLine("	INDEXES");
            objStringBuilder.AppendLine("	************************************************/");
            objStringBuilder.AppendLine("	SELECT ");
            objStringBuilder.AppendLine("	     	TableName = t.name,");
            objStringBuilder.AppendLine("	     	ColumnName = col.name");
            objStringBuilder.AppendLine("	INTO");
            objStringBuilder.AppendLine("		#INDEXES");
            objStringBuilder.AppendLine("	FROM ");
            objStringBuilder.AppendLine("	     	sys.indexes ind ");
            objStringBuilder.AppendLine("		INNER JOIN ");
            objStringBuilder.AppendLine("	     		sys.index_columns ic ON  ind.object_id = ic.object_id and ind.index_id = ic.index_id ");
            objStringBuilder.AppendLine("		INNER JOIN ");
            objStringBuilder.AppendLine("	     		sys.columns col ON ic.object_id = col.object_id and ic.column_id = col.column_id ");
            objStringBuilder.AppendLine("		INNER JOIN ");
            objStringBuilder.AppendLine("	     		sys.tables t ON ind.object_id = t.object_id ");
            objStringBuilder.AppendLine("		WHERE ");
            objStringBuilder.AppendLine("	     		ind.is_primary_key = 0 ");
            objStringBuilder.AppendLine("	     		AND ind.is_unique = 0 ");
            objStringBuilder.AppendLine("	     		AND ind.is_unique_constraint = 0 ");
            objStringBuilder.AppendLine("	     		AND t.is_ms_shipped = 0 ");
            objStringBuilder.AppendLine("	ORDER BY ");
            objStringBuilder.AppendLine("	     	TableName, ");
            objStringBuilder.AppendLine("		ColumnName;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CREATE INDEX INDEXES_TableName_ColumnName ON #INDEXES(TableName, ColumnName);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	/***********************************************");
            objStringBuilder.AppendLine("	DEFAULTS");
            objStringBuilder.AppendLine("	************************************************/");
            objStringBuilder.AppendLine("	SELECT ");
            objStringBuilder.AppendLine("		TableName = (SELECT NAME FROM SYSOBJECTS WHERE ID = a.parent_obj),");
            objStringBuilder.AppendLine("		ColumnName = (SELECT NAME FROM SYSCOLUMNS WHERE cdefault = a.ID),");
            objStringBuilder.AppendLine("		DefaultValue = (SELECT TEXT FROM SYSCOMMENTS WHERE ID = a.ID)");
            objStringBuilder.AppendLine("	INTO");
            objStringBuilder.AppendLine("		#DEFAULTS");
            objStringBuilder.AppendLine("	FROM ");
            objStringBuilder.AppendLine("		SYSOBJECTS a");
            objStringBuilder.AppendLine("	WHERE ");
            objStringBuilder.AppendLine("		a.XTYPE = 'D'");
            objStringBuilder.AppendLine("	ORDER BY");
            objStringBuilder.AppendLine("		TableName,	");
            objStringBuilder.AppendLine("		ColumnName;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CREATE INDEX DEFAULTS_TableName_ColumnName ON #DEFAULTS(TableName, ColumnName);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	/***********************************************");
            objStringBuilder.AppendLine("	LOOP THRU ALL TABLES");
            objStringBuilder.AppendLine("	************************************************/");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	DECLARE @TableName	VARCHAR(100);");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	DECLARE TABLE_CURSOR CURSOR FOR ");
            objStringBuilder.AppendLine("		SELECT NAME FROM SYSOBJECTS WHERE TYPE = 'U' ORDER BY NAME DESC;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	OPEN TABLE_CURSOR");
            objStringBuilder.AppendLine("	FETCH NEXT FROM TABLE_CURSOR INTO @TableName");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	WHILE @@FETCH_STATUS = 0");
            objStringBuilder.AppendLine("		BEGIN");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("			SELECT ");
            objStringBuilder.AppendLine("				PrimaryKey = (SELECT '(PK)' FROM #PRIMARY_KEYS WHERE TableName = tables.TableName AND ColumnName = tables.ColumnName),");
            objStringBuilder.AppendLine("				ForeignKey = (SELECT '(FK) ' + ForeignKeyTableName + '(' + ForeignKeyColumnName + ')' FROM #FOREIGN_KEYS WHERE TableName = tables.TableName AND ColumnName = tables.ColumnName),");
            objStringBuilder.AppendLine("				TableName = tables.TableName,");
            objStringBuilder.AppendLine("				ColumnName = tables.ColumnName, ");
            objStringBuilder.AppendLine("				DataType, ");
            //objStringBuilder.AppendLine("				DataType = ");
            //objStringBuilder.AppendLine("				      	CASE ");
            //objStringBuilder.AppendLine("						WHEN DataTypeLength != NULL THEN DataType + '(' + CONVERT(VARCHAR, DataTypeLength) + ')'");
            //objStringBuilder.AppendLine("					ELSE");
            //objStringBuilder.AppendLine("			         		DataType");
            //objStringBuilder.AppendLine("					END,");
            objStringBuilder.AppendLine("				DataTypeLength, ");
            objStringBuilder.AppendLine("				NumericPrecision = tables.NumericPrecision, ");
            objStringBuilder.AppendLine("				NumericScale = tables.NumericScale, ");
            objStringBuilder.AppendLine("				IdentityField = (SELECT 'IDENTITY(' + CONVERT(VARCHAR, ident.Seed) + ', ' + CONVERT(VARCHAR, ident.Increment) + ')' FROM #IDENTITY ident, #PRIMARY_KEYS pk WHERE ident.TableName = pk.TableName AND ident.TableName = tables.TableName AND pk.ColumnName = tables.ColumnName),");
            objStringBuilder.AppendLine("				'Nullable' = ");
            objStringBuilder.AppendLine("				      	CASE ");
            objStringBuilder.AppendLine("						WHEN NULLABLE = 'YES' THEN 'NULL'");
            objStringBuilder.AppendLine("					ELSE");
            objStringBuilder.AppendLine("			         		'NOT NULL'");
            objStringBuilder.AppendLine("					END,");
            objStringBuilder.AppendLine("				DefaultValue = (SELECT DefaultValue FROM #DEFAULTS WHERE TableName = tables.TableName AND ColumnName = tables.ColumnName),");
            objStringBuilder.AppendLine("				Indexed  = (SELECT 'YES' FROM #INDEXES WHERE TableName = tables.TableName AND ColumnName = tables.ColumnName)");
            objStringBuilder.AppendLine("			FROM ");
            objStringBuilder.AppendLine("				#Tables tables");
            objStringBuilder.AppendLine("			WHERE ");
            objStringBuilder.AppendLine("				TableName = @TableName");
            objStringBuilder.AppendLine("			ORDER BY ");
            objStringBuilder.AppendLine("				TableName,");
            objStringBuilder.AppendLine("				Position;");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("			FETCH NEXT FROM TABLE_CURSOR INTO @TableName");
            objStringBuilder.AppendLine("		END");
            objStringBuilder.AppendLine("");
            objStringBuilder.AppendLine("	CLOSE TABLE_CURSOR");
            objStringBuilder.AppendLine("	DEALLOCATE TABLE_CURSOR");
            return objStringBuilder.ToString();

        }

        public void ExportTablesToExcel()
        {
            SqlDataAdapter objDatadapter = new SqlDataAdapter();
            string connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", this.SQLServerName, this.SQLServerDatabaseName, this.SQLUserName, this.SQLPassword);
            SqlConnection oConn = new SqlConnection(connectionString);
            oConn.Open();

            string sql = SQLGetTables();

            SqlCommand objCommand = oConn.CreateCommand();
            objCommand.CommandType = System.Data.CommandType.Text;
            objCommand.CommandText = sql;

            DataSet ds = new DataSet();
            objDatadapter.SelectCommand = objCommand;
            objDatadapter.Fill(ds);

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);

            int startRow = 6;
            int tableCounter = 0;
            foreach (DataTable table in ds.Tables)
            {

                if (table.Rows.Count > 0)
                {
                    string TableName = table.Rows[0][2].ToString();
                    string excelTableName = "Table" + tableCounter.ToString();

                    Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                    string worksheetName = excelTableName;
                    excelWorkSheet.Name = "Table" + tableCounter.ToString();
                    int totalRows = table.Rows.Count;
                    int endRow = startRow + totalRows;

                    for (int y = 0; y < totalRows; y++)
                    {
                        string PrimaryKey = table.Rows[y][0].ToString();
                        string ForeignKey = table.Rows[y][1].ToString();
                        string ColumnName = table.Rows[y][3].ToString();
                        string DataType = table.Rows[y][4].ToString();
                        string DataTypeLength = table.Rows[y][5].ToString();
                        string NumericPrecision = table.Rows[y][6].ToString();
                        string NumericScale = table.Rows[y][7].ToString();
                        string Identity = table.Rows[y][8].ToString();
                        string Nullable = table.Rows[y][9].ToString();
                        string DefaultValue = table.Rows[y][10].ToString();
                        string Indexed = table.Rows[y][11].ToString();

                        if (DataType.ToUpper() == "VARCHAR" || DataType.ToUpper() == "NVARCHAR" || DataType.ToUpper() == "CHAR")
                        {
                            if (DataTypeLength == "-1")
                                DataType += "(MAX)";
                            else
                                DataType += "(" + DataTypeLength.ToString() + ")";
                        }

                        if (DataType.ToUpper() == "NUMERIC" || DataType.ToUpper() == "DECIMAL")
                            DataType += "(" + NumericPrecision.ToString() + ", " + NumericScale.ToString() + ")";

                        int currentRow = y + startRow;
                        excelWorkSheet.Cells[currentRow, 1] = PrimaryKey + ForeignKey;
                        excelWorkSheet.Cells[currentRow, 2] = ColumnName;
                        excelWorkSheet.Cells[currentRow, 3] = DataType;
                        excelWorkSheet.Cells[currentRow, 4] = Identity;
                        excelWorkSheet.Cells[currentRow, 5] = Nullable;
                        excelWorkSheet.Cells[currentRow, 6] = DefaultValue;
                        excelWorkSheet.Cells[currentRow, 7] = Indexed;
                    }

                    Excel.Range aRange = excelWorkSheet.get_Range("A1:G3");
                    aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                    aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                    aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                    aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
                    aRange.Merge();
                    aRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    aRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    aRange.Font.Bold = true;
                    //aRange.Font.Name = "Engravers MT";
                    //aRange.Font.Size = 20;
                    aRange.Font.Name = "Cambria";
                    aRange.Font.Size = 20;
                    excelWorkSheet.Cells[1, 1] = TableName;

                    Excel.Range aRangeHeaders = excelWorkSheet.get_Range("A5:G5");
                    aRangeHeaders.Font.Bold = true;

                    excelWorkSheet.Cells[5, 1] = "PK/FK";
                    excelWorkSheet.Cells[5, 2] = "COLUMN NAME";
                    excelWorkSheet.Cells[5, 3] = "DATA TYPE";
                    excelWorkSheet.Cells[5, 4] = "IDENTITY";
                    excelWorkSheet.Cells[5, 5] = "NULLABLE";
                    excelWorkSheet.Cells[5, 6] = "DEFAULT";
                    excelWorkSheet.Cells[5, 7] = "INDEXED";

                    Excel.Range bRange = excelWorkSheet.get_Range("A1:C" + endRow.ToString());
                    //bRange.EntireColumn.AutoFit();

                    aRange.EntireColumn.AutoFit();
                    tableCounter--;
                }

                if (this.OutputDirectory.Substring(this.OutputDirectory.Length - 1, 1) == @"\")
                    this.OutputDirectory = this.OutputDirectory.Substring(0, this.OutputDirectory.Length - 1);

                if (!objFileIO.Directory.Exists(this.OutputDirectory))
                    objFileIO.Directory.CreateDirectory(this.OutputDirectory);

                string excelFileName = this.OutputDirectory + @"\" + this.SQLServerDatabaseName + "-Tables.xlsx";

                excelWorkBook.SaveCopyAs(excelFileName);
                excelWorkBook.Close();

                excelWorkBook = null;
                excelApp.Quit();

                excelApp = null;
            }
        }


        public void ExportStoredProceduresToExcel()
        {
            
            SqlDataAdapter objDatadapter = new SqlDataAdapter();
            string connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", this.SQLServerName, this.SQLServerDatabaseName, this.SQLUserName, this.SQLPassword);
            SqlConnection oConn = new SqlConnection(connectionString);
            oConn.Open();

            string sql = SQLGetStoredProdedures();

            SqlCommand objCommand = oConn.CreateCommand();
            objCommand.CommandType = System.Data.CommandType.Text;
            objCommand.CommandText = sql;

            DataTable ors = new DataTable();
            objDatadapter.SelectCommand = objCommand;
            objDatadapter.Fill(ors);


            int startRow = 6;
            int tableCounter = 0;
            string StoredProcedureName = string.Empty;
            string excelTableName = string.Empty;
            string tempStoredProcedureName = string.Empty;
            int totalRows = 0;

            excelWorkBook = excelApplication.Workbooks.Add(misValue);
            
            for (int x = 0; x < ors.Rows.Count; x++)
            {
                StoredProcedureName = ors.Rows[x][0].ToString();
                excelTableName = "StoredProcedure" + x.ToString();

                totalRows = 1;

                int endRow = startRow + totalRows;
                for (int y = 1; y < totalRows; y++)
                {
                    if (StoredProcedureName != tempStoredProcedureName)
                    {
                        totalRows = Convert.ToInt32(ors.Rows[x][8]);
                        tempStoredProcedureName = StoredProcedureName;
                        strDebugger = "StoredProcedureName:" + StoredProcedureName;
                        Debug.WriteLine(strDebugger);
                        strDebugger = "******************************************************************";
                        Debug.WriteLine(strDebugger);
                        Excel.Worksheet excelWorksheet;
                        //excelWorkSheet.Name = "SP-" + x.ToString();
                        excelWorksheet = (Excel.Worksheet)excelApplication.Worksheets.Add();
                        tableCounter++;
                    }
                    string ParameterName = ors.Rows[y][1].ToString();
                    string DataType = ors.Rows[y][2].ToString();
                    string DataTypeLength = ors.Rows[y][3].ToString();
                    string DataTypePrecision = ors.Rows[y][4].ToString();
                    string DataTypeScale = ors.Rows[y][5].ToString();
                    string Nullable = ors.Rows[y][6].ToString();
                    string OutputParameter = ors.Rows[y][7].ToString();
                    if (OutputParameter == "1")
                        OutputParameter = "OUTPUT";
                    else
                        OutputParameter = "";

                    if (DataType.ToUpper() == "VARCHAR" || DataType.ToUpper() == "NVARCHAR" || DataType.ToUpper() == "CHAR")
                    {
                        if (DataTypeLength == "-1")
                            DataType += "(MAX)";
                        else
                            DataType += "(" + DataTypeLength.ToString() + ")";
                    }

                    if (DataType.ToUpper() == "NUMERIC" || DataType.ToUpper() == "DECIMAL")
                        DataType += "(" + DataTypePrecision.ToString() + ", " + DataTypeScale.ToString() + ")";

                    int currentRow = y + startRow;
                    excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(tableCounter);
                    excelWorkSheet.Cells[currentRow, 1].Value = ParameterName.ToString();
                    excelWorkSheet.Cells[currentRow, 2].Value = DataType.ToString();
                    excelWorkSheet.Cells[currentRow, 3].Value = OutputParameter.ToString();
                        
                }

                Excel.Range aRange = excelWorkSheet.get_Range("A1:G3");
                aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                aRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
                aRange.Merge();
                aRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                aRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                aRange.Font.Bold = true;
                aRange.Font.Name = "Engravers MT";
                aRange.Font.Size = 20;
                aRange.Font.Name = "Cambria";
                aRange.Font.Size = 20;
                excelWorkSheet.Cells[1, 1] = StoredProcedureName;

                Excel.Range aRangeHeaders = excelWorkSheet.get_Range("A5:G5");
                aRangeHeaders.Font.Bold = true;

                excelWorkSheet.Cells[5,1].Value = "PARAMETER";
                excelWorkSheet.Cells[5,2].Value = "DATA TYPE";
                excelWorkSheet.Cells[5,3].Value = "NULLABLE";
                excelWorkSheet.Cells[5,4].Value = "OUTPUT";

                Excel.Range bRange = excelWorkSheet.get_Range("A1:G" + totalRows.ToString());
                bRange.EntireColumn.AutoFit();

                aRange.EntireColumn.AutoFit();
                //tableCounter--;
            }

            if (this.OutputDirectory.Substring(this.OutputDirectory.Length - 1, 1) == @"\")
                this.OutputDirectory = this.OutputDirectory.Substring(0, this.OutputDirectory.Length - 1);

            if (!objFileIO.Directory.Exists(this.OutputDirectory))
                objFileIO.Directory.CreateDirectory(this.OutputDirectory);

            string excelFileName = this.OutputDirectory + @"\" + this.SQLServerDatabaseName + "-StoredProcedures.xlsx";

            excelWorkBook.SaveAs(excelFileName);
            excelWorkBook.Close(true, misValue, misValue);
            excelApplication.Quit();

            releaseObject(excelWorkSheet);
            releaseObject(excelWorkBook);
            releaseObject(excelApplication);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                string msg = ex.ToString();
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
