using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using MySql.Data;
using System.Data.OleDb;

namespace Data_acquisition
{
    public class DbManager
    {
        //连接用的字符串
        private string connStr;
        public string ConnStr
        {
            get { return this.connStr; }
            set { this.connStr = value; }
        }

        public DbManager() { }

        ////DbManager单实例
        //private static DbManager _instance = null;
        //public static DbManager Ins
        //{
        //    get { if (_instance == null) { _instance = new DbManager(); } return _instance; }
        //}




        /// <summary>
        /// 需要获得多个结果集的时候用该方法，返回DataSet对象。
        /// </summary>
        /// <param name="sql语句"></param>
        /// <returns></returns>

        public DataSet ExecuteDataSet(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                //数据适配器
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con);
                sqlda.SelectCommand.Parameters.AddRange(paras);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                return ds;
                //不需要打开和关闭链接.
            }
        }

        /// <summary>
        /// 获得单个结果集时使用该方法，返回DataTable对象。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>

        public DataTable ExcuteDataTable(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con);
                sqlda.SelectCommand.Parameters.AddRange(paras);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                return dt;
            }
        }
        public DataTable ExcuteDataTable(string sql)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                return dt;
            }
        }

        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public object ExecuteScalar(string SQLString, params MySqlParameter[] paras)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddRange(paras);
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行Update,Delete,Insert操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonquery(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddRange(paras);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 调用存储过程 无返回值
        /// </summary>
        /// <param name="procname">存储过程名</param>
        /// <param name="paras">sql语句中的参数数组</param>
        /// <returns></returns>
        public int ExecuteProcNonQuery(string procname, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(procname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paras);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 存储过程 返回Datatable
        /// </summary>
        /// <param name="procname"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataTable ExecuteProcQuery(string procname, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlCommand cmd = new MySqlCommand(procname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter sqlda = new MySqlDataAdapter(procname, con);
                sqlda.SelectCommand.Parameters.AddRange(paras);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 多语句的事物管理
        /// </summary>
        /// <param name="cmds">命令数组</param>
        /// <returns></returns>
        public bool ExcuteCommandByTran(params MySqlCommand[] cmds)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                con.Open();
                MySqlTransaction tran = con.BeginTransaction();
                foreach (MySqlCommand cmd in cmds)
                {
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
        }

        ///分页
        public DataTable ExcuteDataWithPage(string sql, ref int totalCount, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                MySqlDataAdapter dap = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                dap.SelectCommand.Parameters.AddRange(paras);
                dap.Fill(dt);
                MySqlParameter ttc = dap.SelectCommand.Parameters["@totalCount"];
                if (ttc != null)
                {
                    totalCount = Convert.ToInt32(ttc.Value);
                }
                return dt;
            }
        }

        //0830添加，根据表名返回datatable
        public DataTable ExcutebyPara(string tbname, string[] paraname)
        {
            //字符串处理
            string para = "";
            foreach (string str in paraname)
            {
                para += "," + str.Split('*')[0];
            }
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                string sql = "select time" + para + " from " + tbname;
                MySqlDataAdapter dap = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }

        }
        //返回schema下的所有表名
        public Dictionary<int,string> Get_TbName()
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {

                Dictionary<int,string> retNameList = new Dictionary<int,string>();
                string sql = "   SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'monitor_value' and table_type='base table'";
                MySqlDataAdapter dap = new MySqlDataAdapter(sql, this.ConnStr);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                int index=0;
                foreach (DataRow dr in dt.Rows)
                {
                    retNameList.Add(index,dr[0].ToString());
                    index++;

                }
                return retNameList;


            }


        }

        //1117新增，添加对excel的读取oledb方式
    public static    DataTable GetDataFromExcelByConn(bool hasTitle = false)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel) return null;
            var filePath = openFile.FileName;
            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType)) return null;

            using (DataSet ds = new DataSet())
            {
                string strCon = string.Format("Provider=Microsoft.Jet.OLEDB.{0}.0;" +
                                "Extended Properties=\"Excel {1}.0;HDR={2};IMEX=1;\";" +
                                "data source={3};",
                                (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), (hasTitle ? "Yes" : "NO"), filePath);
                string strCom = " SELECT * FROM [Sheet1$]";
                using (OleDbConnection myConn = new OleDbConnection(strCon))
                using (OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn))
                {
                    myConn.Open();
                    myCommand.Fill(ds);
                }
                if (ds == null || ds.Tables.Count <= 0) return null;
                return ds.Tables[0];
            }
        }}}
        //1117新增，添加对excel的读取com组件方式

   
        /// <summary>  
        /// 使用COM读取Excel  
        /// </summary>  
        /// <param name="excelFilePath">路径</param>  
        /// <returns>DataTabel</returns>  
//        public System.Data.DataTable GetExcelData(string excelFilePath)  
//        {  using(Microsoft.Office.Interop.Excel){
//            Excel.Application app = new Excel.Application();  
//            Excel.Sheets sheets;  
//            Excel.Workbook workbook = null;  
//            object oMissiong = System.Reflection.Missing.Value;  
//            System.Data.DataTable dt = new System.Data.DataTable();  
   
//            wath.Start();  
   
//            try 
//            {  
//                if (app == null)  
//                {  
//                    return null;  
//                }  
   
//                workbook = app.Workbooks.Open(excelFilePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);  
   
//                //将数据读入到DataTable中——Start    
   
//                sheets = workbook.Worksheets;  
//                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
//                if (worksheet == null)  
//                    return null;  
   
//                string cellContent;  
//                int iRowCount = worksheet.UsedRange.Rows.Count;  
//                int iColCount = worksheet.UsedRange.Columns.Count;  
//                Excel.Range range;  
   
//                //负责列头Start  
//                DataColumn dc;  
//                int ColumnID = 1;  
//                range = (Excel.Range)worksheet.Cells[1, 1];  
//                while (range.Text.ToString().Trim() != "")  
//                {  
//                    dc = new DataColumn();  
//                    dc.DataType = System.Type.GetType("System.String");  
//                    dc.ColumnName = range.Text.ToString().Trim();  
//                    dt.Columns.Add(dc);  
   
//                    range = (Excel.Range)worksheet.Cells[1, ++ColumnID];  
//                }  
//                //End  
   
//                for (int iRow = 2; iRow <= iRowCount; iRow++)  
//                {  
//                    DataRow dr = dt.NewRow();  
   
//                    for (int iCol = 1; iCol <= iColCount; iCol++)  
//                    {  
//                        range = (Excel.Range)worksheet.Cells[iRow, iCol];  
   
//                        cellContent = (range.Value2 == null) ? "" : range.Text.ToString();  
   
//                        //if (iRow == 1)  
//                        //{  
//                        //    dt.Columns.Add(cellContent);  
//                        //}  
//                        //else  
//                        //{  
//                            dr[iCol - 1] = cellContent;  
//                        //}  
//                    }  
   
//                    //if (iRow != 1)  
//                    dt.Rows.Add(dr);  
//                }  
   
//                wath.Stop();  
//                TimeSpan ts = wath.Elapsed;  
   
//                //将数据读入到DataTable中——End  
//                return dt;  
//            }  
//            catch 
//            {  
                   
//                return null;  
//            }  
//            finally 
//            {  
//                workbook.Close(false, oMissiong, oMissiong);  
//                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);  
//                workbook = null;  
//                app.Workbooks.Close();  
//                app.Quit();  
//                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);  
//                app = null;  
//                GC.Collect();  
//                GC.WaitForPendingFinalizers();  
//            }  

//    }
//}}}
