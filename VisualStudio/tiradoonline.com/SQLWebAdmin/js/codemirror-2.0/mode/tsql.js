/*
   MS T-SQL Mode
   Based on PL/SQL mode by Peter Raganitsch
   Adapted by Elian Chrebor http://mylittletools.net
   May 2011
*/

CodeMirror.defineMode("tsql", function(config, parserConfig) {
  var indentUnit       = config.indentUnit,
      keywords         = parserConfig.keywords,
      functions        = parserConfig.functions,
      types            = parserConfig.types,
	  batchSeparators   = parserConfig.batchSeparators,
      multiLineStrings = parserConfig.multiLineStrings;
  var isOperatorChar   = /[+\-*&%=<>!?:\/|]/;
  function chain(stream, state, f) {
    state.tokenize = f;
    return f(stream, state);
  }

  var type;
  function ret(tp, style) {
    type = tp;
    return style;
  }

  function tokenBase(stream, state) {
    var ch = stream.next();
    // start of string?
    if (ch == '"' || ch == "'")
      return chain(stream, state, tokenString(ch));
    // is it one of the special signs []{}().,;? Seperator?
    else if (/[\[\]{}\(\),;\.]/.test(ch))
      return ret(ch);
    // start of a number value?
    else if (/\d/.test(ch)) {
      stream.eatWhile(/[\w\.]/)
      return ret("number", "tsql-number");
    }
    // multi line comment or simple operator?
    else if (ch == "/") {
      if (stream.eat("*")) {
        return chain(stream, state, tokenComment);
      }
      else {
        stream.eatWhile(isOperatorChar);
        return ret("operator", "tsql-operator");
      }
    }
    // single line comment or simple operator?
    else if (ch == "-") {
      if (stream.eat("-")) {
        stream.skipToEnd();
        return ret("comment", "tsql-comment");
      }
      else {
        stream.eatWhile(isOperatorChar);
        return ret("operator", "tsql-operator");
      }
    }
    // tsql variable?
    else if (ch == "@" || ch == "$") {
      stream.eatWhile(/[\w\d\$_]/);
      return ret("word", "tsql-var");
    }
    // is it a operator?
    else if (isOperatorChar.test(ch)) {
      stream.eatWhile(isOperatorChar);
      return ret("operator", "tsql-operator");
    }
    else {
      // get the whole word
      stream.eatWhile(/[\w\$_]/);
      // is it one of the listed keywords?
      if (keywords && keywords.propertyIsEnumerable(stream.current().toLowerCase())) return ret("keyword", "tsql-keyword");
      // is it one of the listed functions?
      if (functions && functions.propertyIsEnumerable(stream.current().toLowerCase())) return ret("keyword", "tsql-function");
      // is it one of the listed types?
      if (types && types.propertyIsEnumerable(stream.current().toLowerCase())) return ret("keyword", "tsql-type");
	  // is it one of the batch separators?
      if (batchSeparators && batchSeparators.propertyIsEnumerable(stream.current().toLowerCase())) return ret("keyword", "tsql-batchseparator");
      // default: just a "word"
      return ret("word", "tsql-word");
    }
  }

  function tokenString(quote) {
    return function(stream, state) {
      var escaped = false, next, end = false;
      while ((next = stream.next()) != null) {
        if (next == quote && !escaped) {end = true; break;}
        escaped = !escaped && next == "\\";
      }
      if (end || !(escaped || multiLineStrings))
        state.tokenize = tokenBase;
      return ret("string", "tsql-string");
    };
  }

  function tokenComment(stream, state) {
    var maybeEnd = false, ch;
    while (ch = stream.next()) {
      if (ch == "/" && maybeEnd) {
        state.tokenize = tokenBase;
        break;
      }
      maybeEnd = (ch == "*");
    }
    return ret("comment", "tsql-comment");
  }

  // Interface

  return {
    startState: function(basecolumn) {
      return {
        tokenize: tokenBase,
        indented: 0,
        startOfLine: true
      };
    },

    token: function(stream, state) {
      if (stream.eatSpace()) return null;
      var style = state.tokenize(stream, state);
      return style;
    }
  };
});

(function() {
  function keywords(str) {
    var obj = {}, words = str.split(" ");
    for (var i = 0; i < words.length; ++i) obj[words[i]] = true;
    return obj;
  }
  var cKeywords = "add all alter and any as asc authorization backup begin between break browse bulk by cascade case check checkpoint close clustered coalesce collate column commit compute constraint contains containstable continue convert create cross current current_date current_time current_timestamp current_user cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exists exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if in index inner insert intersect into is join key kill left like lineno load merge national nocheck nonclustered not null nullif of off offsets on open opendatasource openquery openrowset openxml option or order outer over percent pivot plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return returns revert revoke right rollback rowcount rowguidcol rule save schema securityaudit select session_user set setuser shutdown some statistics system_user table tablesample textsize then to top tran transaction trigger truncate tsequal union unique unpivot update updatetext use user values varying view waitfor when where while with writetext " +
  "datefirst dateformat deadlock_priority lock_timeout concat_null_yields_null cursor_close_on_commit fips_flagger identity_insert language offsets quoted_identifier arithabort arithignore fmtonly nocount noexec numeric_roundabort parseonly query_governor_cost_limit rowcount textsize ansi_defaults ansi_null_dflt_off ansi_null_dflt_on ansi_nulls ansi_padding ansi_warnings forceplan showplan_all showplan_text showplan_xml statistics io statistics xml statistics profile statistics time implicit_transactions remote_proc_transactions transaction isolation level xact_abort path";

 var cFunctions = "avg min checksum_agg sum count stdev count_big stdevp grouping var max varp " +
	"collationproperty tertiary_weights " + 
	"@@datefirst @@options@@dbts @@remserver@@langid @@servername@@language @@servicename@@lock_timeout @@spid@@max_connections @@textsize@@max_precision @@version@@nestlevel " +
	"encryptbykey decryptbykey encryptbypassphrase decryptbypassphrase key_id key_guid encryptbyasmkey decryptbyasmkey encryptbycert decryptbycert cert_id asymkey_id certproperty signbyasymkey verifysignedbyasmkey signbycert verifysignedbycert decryptbykeyautocert " +
	"@@cursor_rows cursor_status @@fetch_status " +
	"datalength ident_seed ident_current identity ident_incr sql_variant_property " +
	"sysdatetime sysdatetimeoffset sysutcdatetime current_timestamp getdate getutcdate datename datepart day month year datediff dateadd switchoffset todatetimeoffset @@datefirst datefirst dateformat @@language language sp_helplanguage isdate " +
	"abs degrees rand acos exp round asin floor sign atan log sin atn2 log10 sqrt ceiling pi square cos power tan cot radians  " +
	"@@procid fulltextcatalogproperty asymkey_id fulltextserviceproperty asymkeyproperty index_col assemblyproperty indexkey_property cert_id indexproperty col_length key_id col_name key_guid columnproperty key_name database_principal_id object_definition databaseproperty object_id databasepropertyex object_name db_id object_schema_name db_name objectproperty file_id objectpropertyex file_idex schema_id file_name schema_name filegroup_id sql_variant_property filegroup_name symkeyproperty filegroupproperty type_id fileproperty type_name fn_listextendedproperty typeproperty  " +
	"bit_length concat octet_length truncate current_date current_time dayname dayofmonth dayofweek hour minute monthname quarter week " +
	"rank ntile dense_rank row_number " +
	"publishingservername " +
	"containstable openquery freetexttable openrowset opendatasource openxml current_user schema_id database_principal_id schema_name sys.fn_builtin_permissions session_user sys.fn_my_permissions setuser has_perms_by_name suser_id is_member suser_sid is_srvrolemember suser_sname original_login system_user permissions suser_name pwdcompare user_id pwdencrypt user_name  " +
	"ascii nchar soundex char patindex space charindex quotename str difference replace stuff left replicate substring len reverse unicode lower right upper ltrim rtrim " + 
	"app_name case cast convert coalesce collationproperty columns_updated current_timestamp current_user datalength @@error error_line error_message error_number error_procedure error_severity error_state fn_helpcollations fn_servershareddrives fn_virtualfilestats formatmessage getansinull host_id host_name ident_current ident_incr ident_seed @@identity identity isdate isnull isnumeric newid nullif parsename original_login @@rowcount rowcount_big scope_identity serverproperty sessionproperty session_user stats_date sys.dm_db_index_physical_stats system_user @@trancount update user_name xact_state " +
	"@@connections @@pack_received @@cpu_busy @@pack_sent fn_virtualfilestats @@timeticks @@idle @@total_errors @@io_busy @@total_read @@packet_errors @@total_write " +
	"patindex textvalid textptr " +
	"columns_updated eventdata trigger_nestlevel update ";

  var cTypes = "bigint numeric bit smallint decimal smallmoney int tinyint money " +
	"float real " +
	"date datetimeoffset datetime2 smalldatetime datetime time " +
	"char varchar text nchar nvarchar ntext " +
	"binary varbinary image " +
	"cursor timestamp hierarchyid uniqueidentifier sql_variant xml table " +
	"geography geometry";
	
  var cBatchSeparators = "go";

  CodeMirror.defineMIME("text/x-tsql", {
    name: "tsql",
    keywords: keywords(cKeywords),
    functions: keywords(cFunctions),
    types: keywords(cTypes),
	batchSeparators: keywords(cBatchSeparators)
  });
}());
