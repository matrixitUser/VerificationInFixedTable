using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Dynamic;
using Newtonsoft.Json;

namespace VerificationInFixedTable
{
    public partial class Form1 : Form
    {
        static float Version = 1.21f;
        //query - запрос; request - опрос
        List<List<string>> gTreeNodesIdandName = new List<List<string>>();
        List<List<string>> gShedules = new List<List<string>>();          //Список расписаний
        List<string> gListIdForAstronTimerControls = new List<string>();
        static System.Threading.Timer timerQuery; //30мин
        static System.Threading.Timer timerRequest;
        public List<List<string>> gAskue = new List<List<string>>();      //таблица объектов
        static object gLocker = new object();
        static string[] gIdForStopRequest;
        public string gServerHost;
        public string gServerPort;
        public string gLogin;
        public string gPassword;
        public string gSessionId = "";
        static int gPeriodRequest = 20;
        static int gHour = 0;
        static int gNumRequestCurrent = 0; // подсчет количество опроса объектов
        static bool gRequestChecked = false;
        static int mapsView = 1;
        public Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        List<string> listMessages = new List<string>();
        List<string> listIdsUpdate = new List<string>();

        List<DateTime> listDate = new List<DateTime>();

        FormDataFromHubs formDataFromHubs = new FormDataFromHubs();
        public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            gServerPort = ConfigurationManager.AppSettings.Get(Const.SERVER_PORT);
            gServerHost = ConfigurationManager.AppSettings.Get(Const.SERVER_HOST);
            gPassword = Helper.MetodMD5(ConfigurationManager.AppSettings.Get(Const.PASSWORD));// "2fd62b045007685213ccb362d87b532b";// MetodMD5(tbPassword.Text);//
            gLogin = ConfigurationManager.AppSettings.Get(Const.LOGIN);
            dtpEnd.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
            dtpStart.Value = dtpEnd.Value.AddMonths(-6);
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MMMM yyyy";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "MMMM yyyy";
            Connection();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            Connection();
        }
        public void Console(string str)
        {
            if (lbConsole.InvokeRequired)
                lbConsole.Invoke(new Action(() => lbConsole.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " | " + str)));
            else
                lbConsole.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " | " + str);
        }

        private void btnGetDataOnlyWithType_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;
            AddColumnsDateInTableFixed(start, end);
            ThreadGetDataOnlyType(start, end, "Fixed");
        }

        private void tsmiVerification_Click(object sender, EventArgs e)
        {
            if(dgvTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбраны объекты. Выберите объекты для верификации и тд");
                return;
            }
            FormVerification formVerification = new FormVerification();
            formVerification.Owner = this;
            formVerification.Show();
            formVerification.dgvVerification.Rows.Add(dgvTable.SelectedRows.Count);
            for(int i = 0; i < dgvTable.SelectedRows.Count; i++)
            {
                formVerification.dgvVerification.Rows[i].Cells[Const.colId].Value = dgvTable.SelectedRows[i].Cells[Const.colId].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colObjectId].Value = dgvTable.SelectedRows[i].Cells[Const.colObjectId].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colName].Value = dgvTable.SelectedRows[i].Cells[Const.colName].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colPname].Value = dgvTable.SelectedRows[i].Cells[Const.colPname].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colValue].Value = dgvTable.SelectedRows[i].Cells[Const.colValue].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colS1].Value = dgvTable.SelectedRows[i].Cells[Const.colS1].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colDate].Value = dgvTable.SelectedRows[i].Cells[Const.colDate].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colG1].Value = dgvTable.SelectedRows[i].Cells[Const.colG1].Value;
                formVerification.dgvVerification.Rows[i].Cells[Const.colVerification].Value = dgvTable.SelectedRows[i].Cells[Const.colVerification].Value;
            }
            if (Convert.ToInt32(dgvTable.Rows[0].Cells[Const.colVerification].Value.ToString()) == 1)
            {
                formVerification.lbText.Text = "Данные верифицированы! Уверены, что хотите убрать верификацию?";
            }
            else
            {
                formVerification.lbText.Text = "Уверены, что хотите верифицировать эти данные?";
            }
        }

        private void dgvTableFixed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            FormVerification formVerification = new FormVerification();
            formVerification.Owner = this;
            formVerification.Show();
            formVerification.dgvVerification.Rows.Add();
            formVerification.dgvVerification.Rows[0].Cells[Const.colId].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colIdf].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colObjectId].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colObjectIdf].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colName].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colNamef].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colPname].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colPnameF].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colValue].Value = dgvTableFixed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colS1].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colS1f].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colG1].Value = dgvTableFixed.Rows[e.RowIndex].Cells[Const.colG1f].Value;
            formVerification.dgvVerification.Rows[0].Cells[Const.colVerification].Value = (dgvTableFixed.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Yellow) ? 0 : 1;

            foreach (var date in listDate)
            {
                if (dgvTableFixed.Columns[e.ColumnIndex].Name.Contains(date.ToString("yyyyMMdd")))
                {
                    formVerification.dgvVerification.Rows[0].Cells[Const.colDate].Value = date.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            if (dgvTableFixed.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Yellow)
            {
                formVerification.lbText.Text = "Уверены, что хотите верифицировать эти данные?";
            }
            else
            {
                formVerification.lbText.Text = "Данные верифицированы! Уверены, что хотите убрать верификацию?";
            }
        }

        private void tsmiGetDataFromHub_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date.AddMonths(1);
            DateTime end = dtpEnd.Value.Date.AddMonths(1);
            formDataFromHubs = new FormDataFromHubs();
            formDataFromHubs.Refresh();
            formDataFromHubs.Owner = this;
            formDataFromHubs.Show();
            ThreadGetRecordsWithIdsAndS1(start, end, "Day");
        }

       
        private void dgvTable_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
              

            }
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            int countVerif = 0;
            for (int i = 0; i < dgvTable.SelectedRows.Count; i++)
            {
                if (Convert.ToInt32(dgvTable.SelectedRows[i].Cells[Const.colVerification].Value) == 1)
                {
                    countVerif++;
                }
            }
            if (countVerif != dgvTable.SelectedRows.Count && countVerif > 0)
                tsmiVerification.Enabled = false;
            else
                tsmiVerification.Enabled = true;
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvTable.Rows[e.RowIndex].Selected = true;
        }

        private void tsmiVerif_Click(object sender, EventArgs e)
        {
            if (dgvTableFixed.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбраны объекты. Выберите объекты для верификации и тд");
                return;
            }
            FormVerification formVerification = new FormVerification();
            formVerification.Owner = this;
            formVerification.Show();
            int countRows = 0;
            for (int i = 0; i < dgvTableFixed.SelectedRows.Count; i++)
            {
                for(int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.SelectedRows[i].Cells[j].Style.BackColor == Color.Yellow) countRows++;
                    }
                }
            }
            formVerification.dgvVerification.Rows.Add(countRows);
            int k = 0;
            for (int i = 0; i < dgvTableFixed.SelectedRows.Count; i++)
            {
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.SelectedRows[i].Cells[j].Style.BackColor != Color.Yellow) continue;

                        formVerification.dgvVerification.Rows[k].Cells[Const.colId].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colIdf].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colObjectId].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colObjectIdf].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colName].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colNamef].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colPname].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colPnameF].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colS1].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colS1f].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colG1].Value = dgvTableFixed.SelectedRows[i].Cells[Const.colG1f].Value;
                        
                        formVerification.dgvVerification.Rows[k].Cells[Const.colValue].Value = dgvTableFixed.SelectedRows[i].Cells[j].Value;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colVerification].Value = 0;
                        formVerification.dgvVerification.Rows[k].Cells[Const.colDate].Value = date.ToString("yyyy-MM-dd HH:mm:ss");
                        k++;
                    }
                }
            }
            formVerification.lbText.Text = "Уверены, что хотите верифицировать эти данные?";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        public void DeleteAutoVerification()
        {
            List<dynamic> records = new List<dynamic>();
            for (int i = 0; i < dgvTableFixed.RowCount; i++)
            {
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            records.Add(FixedDeleteAutoVerification(Guid.Parse(dgvTableFixed.Rows[i].Cells[Const.colObjectIdf].Value.ToString()), date,
                                value, dgvTableFixed.Rows[i].Cells[Const.colS1f].Value.ToString(), Guid.Parse(dgvTableFixed.Rows[i].Cells[Const.colG1f].Value.ToString())));
                      
                        }
                    }
                }
            }
            var msg = Helper.BuildMessage("records-save");
            msg.body.records = records;
            var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
            dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
            if (response == null) return;
            if (response.body == null) return;
            for (int i = 0; i < dgvTableFixed.RowCount; i++)
            {
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            dgvTableFixed.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }
        private void btnAutoVerification_Click(object sender, EventArgs e)
        {
            //DeleteAutoVerification();
            int setPoint = Convert.ToInt32(mtbSetPoint.Text);
            List<dynamic> records = new List<dynamic>();
            for (int i = 0; i < dgvTableFixed.RowCount; i++)
            {
                double lastValue = -1;
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.GreenYellow || dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            lastValue = value;
                        }
                    }
                }
                if (lastValue == -1) continue;
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.Yellow)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            if ((value - lastValue) > setPoint || (value - lastValue) < 0) continue;
                            lastValue = value;
                            records.Add(FixedAutoVerification(Guid.Parse(dgvTableFixed.Rows[i].Cells[Const.colObjectIdf].Value.ToString()), date,
                                value, dgvTableFixed.Rows[i].Cells[Const.colS1f].Value.ToString(), Guid.Parse(dgvTableFixed.Rows[i].Cells[Const.colG1f].Value.ToString())));
                            records.Add(MakeDayRecord(Guid.Parse(dgvTableFixed.Rows[i].Cells[Const.colObjectIdf].Value.ToString()), date,
                                value, dgvTableFixed.Rows[i].Cells[Const.colS1f].Value.ToString(), 0));
                        }
                        else if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.GreenYellow || dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            lastValue = value;
                        }
                    }
                }
            }
            var msg = Helper.BuildMessage("records-save");
            msg.body.records = records;
            var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
            dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
            if (response == null) return;
            if (response.body == null) return;
            for (int i = 0; i < dgvTableFixed.RowCount; i++)
            {
                double lastValue = -1;
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.GreenYellow || dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            lastValue = value;
                        }
                    }
                }
                if (lastValue == -1) continue;
                for (int j = 0; j < dgvTableFixed.ColumnCount; j++)
                {
                    foreach (var date in listDate)
                    {
                        if (!dgvTableFixed.Columns[j].Name.Contains(date.ToString("yyyyMMdd"))) continue;
                        if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.Yellow)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            if ((value - lastValue) > setPoint || (value - lastValue) < 0) continue;
                            lastValue = value;
                            dgvTableFixed.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                        else if (dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.GreenYellow || dgvTableFixed.Rows[i].Cells[j].Style.BackColor == Color.White)
                        {
                            double value = Convert.ToDouble(dgvTableFixed.Rows[i].Cells[j].Value);
                            lastValue = value;
                        }
                    }
                }
            }
            MessageBox.Show("Успешно");
        }
        public dynamic FixedAutoVerification(Guid objectId, DateTime date, double d1, string s1, Guid g1)
        {
            dynamic record = new ExpandoObject();
            record.id = Guid.NewGuid();
            record.type = "Fixed";
            record.objectId = objectId;
            record.date = date;
            record.d1 = d1;
            record.i1 = 1;
            record.i2 = 0;
            record.s1 = s1;
            record.dt1 = DateTime.Now;
            record.g1 = g1;
            return record;
        }
        private dynamic MakeDayRecord(Guid objectId, DateTime date, double value, string parameter, int handsVer)
        {
            dynamic record = new ExpandoObject();
            record.id = Guid.NewGuid();
            record.type = "Day";
            record.objectId = objectId;
            record.date = date;
            record.d1 = value;
            record.i1 = handsVer;
            record.s1 = parameter;
            record.s2 = "кВт";
            record.dt1 = DateTime.Now;
            return record;
        }
        public dynamic FixedDeleteAutoVerification(Guid objectId, DateTime date, double d1, string s1, Guid g1)
        {
            dynamic record = new ExpandoObject();
            record.id = Guid.NewGuid();
            record.type = "Fixed";
            record.objectId = objectId;
            record.date = date;
            record.d1 = d1;
            record.i1 = 0;
            record.i2 = 0;
            record.s1 = s1;
            record.dt1 = DateTime.Now;
            record.g1 = g1;
            return record;
        }

        private void dgvTableFixed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 8) return;
            dgvTableFixed.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
        }
        
        private void btnDelAutoVerif_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите убрать автоматическую верификацию за ", "Убрать автоматическую верификацию",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                DeleteAutoVerification();
            }
        }
    }
}
