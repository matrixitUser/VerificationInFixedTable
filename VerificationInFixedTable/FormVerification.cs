using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificationInFixedTable
{
    public partial class FormVerification : Form
    {
        Form1 form1;
        public FormVerification()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ThreadRecordsSave();
        }
        public void ThreadRecordsSave()
        {
            Thread myThread = new Thread(RecordsSave);           //Создаем новый объект потока (Thread)
            myThread.Start();                             //запускаем поток
            myThread.IsBackground = true;
        }
        public void RecordsSave()
        {
            form1 = this.Owner as Form1;
            if (form1 == null)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            List<dynamic> records = new List<dynamic>();
            List<Guid> listIdsForDelete = new List<Guid>();
           
            try
            {
                for(int i = 0; i < dgvVerification.RowCount; i++)
                {
                    records.Add(MakeFixedRecord(i));
                    records.Add(MakeDayRecord(i));
                    if (DateTime.Parse(dgvVerification.Rows[i].Cells[Const.colDate].Value.ToString()).Hour != 0)
                    {
                        listIdsForDelete.Add(Guid.Parse(dgvVerification.Rows[i].Cells[Const.colId].Value.ToString()));
                    }
                }

                var msg = Helper.BuildMessage("records-save");
                msg.body.records = records;
                var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
                dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
                if (response == null) return;
                if (response.body == null) return;
                //MessageBox.Show("Успешно");
                DeleteData(listIdsForDelete);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " в " + MethodInfo.GetCurrentMethod().Name); }
        }
        private dynamic MakeDayRecord(int i)
        {
            DateTime dtTmp = DateTime.Parse(dgvVerification.Rows[i].Cells[Const.colDate].Value.ToString());

            if (dtTmp.Hour != 0)
            {
                dtTmp = dtTmp.AddHours(-dtTmp.Hour);
            }
            dynamic record = new ExpandoObject();
            record.id = Guid.NewGuid();
            record.type = "Day";
            record.objectId = Guid.Parse(dgvVerification.Rows[i].Cells[Const.colObjectId].Value.ToString());
            record.date = dtTmp;
            record.d1 = Convert.ToDouble(dgvVerification.Rows[i].Cells[Const.colValue].Value);
            record.i1 = Convert.ToInt32(dgvVerification.Rows[i].Cells[Const.colVerification].Value.ToString());
            record.s1 = dgvVerification.Rows[i].Cells[Const.colS1].Value.ToString();
            record.s2 = "кВт";
            record.dt1 = DateTime.Now;
            return record;
        }
        private dynamic MakeFixedRecord(int i)
        {
            DateTime dtTmp = DateTime.Parse(dgvVerification.Rows[i].Cells[Const.colDate].Value.ToString());

            if (dtTmp.Hour != 0)
            {
               dtTmp = dtTmp.AddHours(-dtTmp.Hour);
            }
            int iRec = switchVerif(i);
            dynamic record = new ExpandoObject();
            record.id = Guid.NewGuid();
            record.type = "Fixed";
            record.objectId = Guid.Parse(dgvVerification.Rows[i].Cells[Const.colObjectId].Value.ToString());
            record.date = dtTmp;
            record.d1 = Convert.ToDouble(dgvVerification.Rows[i].Cells[Const.colValue].Value);
            record.i1 = iRec;
            record.i2 = iRec;
            record.s1 = dgvVerification.Rows[i].Cells[Const.colS1].Value.ToString();
            record.dt1 = DateTime.Now;
            record.g1 = Guid.Parse(dgvVerification.Rows[i].Cells[Const.colG1].Value.ToString());
            return record;
        }
        public int switchVerif(int i)
        {
            for (int j = 0; j < form1.dgvTable.RowCount; j++)
            {
                if (form1.dgvTable.Rows[j].Cells[Const.colId].Value.ToString() == dgvVerification.Rows[i].Cells[Const.colId].Value.ToString())
                {
                    if (Convert.ToInt32(dgvVerification.Rows[i].Cells[Const.colVerification].Value) == 0)
                    {
                        form1.dgvTable.Rows[j].Cells[Const.colVerification].Value = 1;
                    }
                    else
                    {
                        form1.dgvTable.Rows[j].Cells[Const.colVerification].Value = 0;
                    }
                }
            }

            DateTime dtTmp = DateTime.Parse(dgvVerification.Rows[i].Cells[Const.colDate].Value.ToString());
            for (int j = 0; j < form1.dgvTableFixed.RowCount; j++)
            {
                if (form1.dgvTableFixed.Rows[j].Cells[Const.colObjectIdf].Value.ToString() == dgvVerification.Rows[i].Cells[Const.colObjectId].Value.ToString()
                        && dgvVerification.Rows[i].Cells[Const.colS1].Value.ToString().Contains(form1.ParseTariff(form1.dgvTableFixed.Rows[j].Cells[Const.colTariff].Value.ToString()))
                        && dgvVerification.Rows[i].Cells[Const.colS1].Value.ToString().Contains(form1.dgvTableFixed.Rows[j].Cells[Const.colNetworkAddressf].Value.ToString()))
                {
                    if (Convert.ToInt32(dgvVerification.Rows[i].Cells[Const.colVerification].Value.ToString()) == 0)
                    {
                        form1.dgvTableFixed.Rows[j].Cells[$"col{dtTmp.ToString("yyyyMMdd")}"].Style.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        form1.dgvTableFixed.Rows[j].Cells[$"col{dtTmp.ToString("yyyyMMdd")}"].Style.BackColor = Color.Yellow;
                    }
                }
            }
            if (Convert.ToInt32(dgvVerification.Rows[i].Cells[Const.colVerification].Value.ToString()) == 0)
            {
                dgvVerification.Rows[i].Cells[Const.colVerification].Value = 1;
                return 1;
            }
            else
            {
                dgvVerification.Rows[i].Cells[Const.colVerification].Value = 0;
                return 0;
            }

        }
        public void DeleteData(List<Guid> listIds)
        {
            var msg = Helper.BuildMessage("records-delete");
            msg.body.ids = listIds.ToArray();
            msg.body.type = "Fixed";
            var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDeleteRows_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dgvVerification.SelectedRows.Count; i++)
            {
                dgvVerification.Rows.Remove(dgvVerification.SelectedRows[i]);
            }
        }
    }
}
