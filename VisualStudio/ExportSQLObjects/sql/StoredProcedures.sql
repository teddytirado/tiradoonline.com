SELECT TableName = a.name, ColumnName = B.NAME, DataType = (SELECT TOP 1 NAME FROM SYSTYPES WHERE XTYPE = B.XTYPE), PrecisionLength = xprec, PrecisionScale = xscale from sysobjects a, syscolumns b where a.id = b.id and a.type = 'p' order by a.name, b.name, b.colorder

