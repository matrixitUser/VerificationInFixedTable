using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificationInFixedTable
{
    public partial class FormDataFromHubs : Form
    {
        public FormDataFromHubs()
        {
            InitializeComponent();
        }

        public void FillDataInDGV(dynamic records)
        {
            dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows.Add(records.Count)));
            for(int i = 0; i < records.Count; i++)
            {
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colS1].Value = records[i].s1));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colValue].Value = records[i].d1));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colDate].Value = records[i].date.ToString("dd.MM.yyyy HH:mm")));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colId].Value = records[i].id));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colObjectId].Value = records[i].objectId));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colDt].Value = records[i].dt1.ToString("dd.MM.yyyy HH:mm")));
                dgvDataFromHub.Invoke(new Action(() => dgvDataFromHub.Rows[i].Cells[Const.colType].Value = records[i].type));

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
