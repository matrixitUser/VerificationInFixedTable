using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificationInFixedTable
{
    public partial class Form1 : Form
    {
        public void Connection()
        {
            if (isGetSession(gLogin, gPassword))
            {
                btnGetDataOnlyWithType.Enabled = true;
            }
            else
            {
                btnGetDataOnlyWithType.Enabled = false;
            }
        }
        public void AddColumnsDateInTableFixed(DateTime start, DateTime end)
        {
            dgvTableFixed.Columns.Clear();
            dgvTableFixed.Columns.Add(Const.colIdf, "id");
            dgvTableFixed.Columns[Const.colIdf].Visible = false;
            dgvTableFixed.Columns.Add(Const.colObjectIdf, "objectId");
            dgvTableFixed.Columns[Const.colObjectIdf].Visible = false;
            dgvTableFixed.Columns.Add(Const.colS1f, "s1");
            dgvTableFixed.Columns[Const.colS1f].Visible = false;
            dgvTableFixed.Columns.Add(Const.colG1f, "g1");
            dgvTableFixed.Columns[Const.colG1f].Visible = false;
            dgvTableFixed.Columns.Add(Const.colNamef, Const.headerColName);
            dgvTableFixed.Columns[Const.colNamef].Width = 160;
            dgvTableFixed.Columns.Add(Const.colPnameF, Const.headerColPname);
            dgvTableFixed.Columns[Const.colPnameF].Width = 160;
            dgvTableFixed.Columns.Add(Const.colNetworkAddressf, Const.headerColNetworkAddress);
            dgvTableFixed.Columns[Const.colNetworkAddressf].Width = 55;
            dgvTableFixed.Columns.Add(Const.colTariff, Const.headerColTariff);
            dgvTableFixed.Columns[Const.colTariff].Width = 50;

            listDate.Clear();
            if (start.Day == 1) listDate.Add(start);
            DateTime dt;
            for (int i = 1; start.AddMonths(i).Ticks <= end.Ticks; i++)
            {
                dt = start.AddMonths(i);
                listDate.Add(dt.AddDays(1 - dt.Day));
            }
            foreach(var date in listDate)
            {
                dgvTableFixed.Columns.Add($"col{date.ToString("yyyyMMdd")}", ParseMonthForPLC(date));
                dgvTableFixed.Columns[$"col{date.ToString("yyyyMMdd")}"].Width = 68;
            }
            
        }

        //because data is stored at the beginning of the next month, then we shift by one month
        public string ParseMonthForPLC(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                    return $"01.Январь {date.Year}г";
                case 2:
                    return $"01.Февраль {date.Year}г";
                case 3:
                    return $"01.Март {date.Year}г";
                case 4:
                    return $"01.Апрель {date.Year}г";
                case 5:
                    return $"01.Май {date.Year}г";
                case 6:
                    return $"01.Июнь {date.Year}г";
                case 7:
                    return $"01.Июль {date.Year}г";
                case 8:
                    return $"01.Август {date.Year}г";
                case 9:
                    return $"01.Сентябрь {date.Year}г";
                case 10:
                    return $"01.Октябрь {date.Year}г";
                case 11:
                    return $"01.Ноябрь {date.Year}г";
                case 12:
                    return $"01.Декабрь {date.Year}г";
                default:
                    return $"{date.ToString("yyyy-MM-dd")}";
            }
        }
    }
}
