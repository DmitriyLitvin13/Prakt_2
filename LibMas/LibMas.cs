using System.Data;

namespace Prakt2_Var7
{
    public static class VisualArray
    {
        // матрицу в таблицу
        public static DataTable ToDataTable(int[,] a)
        {
            DataTable t = new DataTable();
            for (int j = 0; j < a.GetLength(1); j++)
                t.Columns.Add("C" + (j + 1), typeof(int));

            for (int i = 0; i < a.GetLength(0); i++)
            {
                DataRow r = t.NewRow();
                for (int j = 0; j < a.GetLength(1); j++)
                    r[j] = a[i, j];
                t.Rows.Add(r);
            }
            return t;
        }
        // ответ в таблицу
        public static DataTable ToDataTable(int[] a)
        {
            DataTable t = new DataTable();
            t.Columns.Add("Min", typeof(int));
            for (int i = 0; i < a.Length; i++)
            {
                DataRow r = t.NewRow();
                r[0] = a[i];
                t.Rows.Add(r);
            }
            return t;
        }
    }
}