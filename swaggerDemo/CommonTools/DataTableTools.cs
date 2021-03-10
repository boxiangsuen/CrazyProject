using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommonTools
{
    public class DataTableTools
    {
        /// <summary>
        /// 把Datatable通过GroupBy汇总数据
        /// </summary>
        /// <returns></returns>
        public DataTable DataTableGroupBy() {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("name", typeof(string)),
                                         new DataColumn("sex", typeof(string)),
                                         new DataColumn("score", typeof(int)) });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            DataTable dtResult = dt.Clone();
            DataTable dtName = dt.DefaultView.ToTable(true, "name", "sex");
            try
            {
                for (int i = 0; i < dtName.Rows.Count; i++)
                {
                    DataRow[] rows = dt.Select("name='" + dtName.Rows[i][0] + "' and sex='" + dtName.Rows[i][1] + "'");
                    //temp用来存储筛选出来的数据
                    DataTable temp = dtResult.Clone();
                    foreach (DataRow row in rows)
                    {
                        temp.Rows.Add(row.ItemArray);
                    }

                    DataRow dr = dtResult.NewRow();
                    dr[0] = dtName.Rows[i][0].ToString();
                    dr[1] = temp.Compute("sum(score)", "");
                    dtResult.Rows.Add(dr);

                }
                return dtResult.Clone();
            }
            catch (Exception)
            {
                return null;
            }
            finally {
                dt.Dispose();
                dtResult.Dispose();
                dtName.Dispose();
                GC.Collect();
            }


        }
    }
}
