using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace VerificationInFixedTable
{
    public partial class Form1 : Form
    {
        #region Get sessionId, correct login and password

        public bool isGetSession(string login, string password)
        {
            try
            {
                if (ApiConnector.Instance.AuthBySession())
                {
                    var loginAns = ApiConnector.Instance.AuthByLoginWithoutGetSession(login, password);
                    if (loginAns == null)
                    {
                        Console("Не удалось соединиться с сервером");
                        return false;
                    }
                    if (loginAns.head.what == "auth-success")
                    {
                        Console("Cоединие с сервером установлено");
                        gSessionId = ApiConnector.Instance.SessionId.ToString();
                        return true;
                    }
                    else
                    {
                        Console((string)loginAns.body.message);
                    }
                }
                else
                {
                    var loginAns = ApiConnector.Instance.AuthByLoginWithGetSession(login, password);
                    if (loginAns == null)
                    {
                        Console("Не удалось соединиться с сервером");
                        return false;
                    }

                    if (loginAns.head.what == "auth-success")
                    {
                        Console("Cоединие с сервером установлено");
                        gSessionId = ApiConnector.Instance.SessionId.ToString();
                        return true;
                    }
                    else
                    {
                        Console((string)loginAns.body.message);
                    }
                }
            }
            catch(Exception ex)
            {
                Console("Не удалось соединиться с сервером");
            }
            return false;
        }
        #endregion
        #region Get data only type
        public void ThreadGetDataOnlyType(DateTime start, DateTime end, string type)
        {
            dynamic data = new ExpandoObject();
            data.start = start;
            data.end = end;
            data.type = type;
            Thread myThread = new Thread(GetDataOnlyType);           //Создаем новый объект потока (Thread)
            myThread.Start(data);                             //запускаем поток
            myThread.IsBackground = true;
        }
        public void GetDataOnlyType(object obj)
        {
            Thread.Sleep(100);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            try
            {
                dynamic data = (dynamic)obj;
                if (data == null) return;
                var msg = Helper.BuildMessage("records-get-only-with-type");
                msg.body.start = data.start;
                msg.body.end = data.end;
                msg.body.type = data.type;
                var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
                dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
                if (response.body == null) return;
                ParseGetDataOnlyType(response.body.records);
            }
            catch (Exception ex) { Console(ex.Message + MethodInfo.GetCurrentMethod().Name); }
        }
        public void dgvTable1(dynamic records)
        {
            if (records.Count == 0) return;
            dgvTable.Invoke(new Action(() => dgvTable.Rows.Clear()));
            dgvTable.Invoke(new Action(() => dgvTable.Rows.Add(records.Count)));
            for (int i = 0; i < records.Count; i++)
            {
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colId].Value = records[i].id));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colObjectId].Value = records[i].objectId));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colDate].Value = records[i].date.ToString("yyyy-MM-dd HH:mm:ss")));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colDt].Value = records[i].dt1.ToString("yyyy-MM-dd HH:mm:ss")));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colS1].Value = records[i].s1));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colValue].Value = records[i].d1));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colVerification].Value = Int32.Parse(records[i].i1.ToString())));
                dgvTable.Invoke(new Action(() => dgvTable.Rows[i].Cells[Const.colG1].Value = records[i].g1));
            }
        }
        public void dgvTableFixedMetod(dynamic records, List<Guid> listObjectId, List<dynamic> listObject)
        {
            if (records.Count == 0) return;
            
            string tmp;

            foreach(var localObject in listObject) 
            {
                int lenghtTmp = localObject.s1.IndexOf("_") - 2; //example: na33_Э...
                int networkAddress = Convert.ToInt32(localObject.s1.Substring(2, lenghtTmp));
                localObject.networkAddress = networkAddress;
            }
            
            dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows.Clear()));
            dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows.Add(listObject.Count)));
            var tmpObject = listObject.GroupBy(x => x.objectId);

            int i1 = 0;
            listObject = listObject.OrderBy(x => x.objectId).ToList();
            for(int i = 0; i < listObject.Count; i++)
            {
                if(listObject[i].s1.Contains(Const.tariff1InS1))
                {
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colIdf].Value = listObject[i].id));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colObjectIdf].Value = listObject[i].objectId));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colNetworkAddressf].Value = listObject[i].networkAddress));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colTariff].Value = Const.tariff1));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colS1f].Value = listObject[i].s1));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colG1f].Value = listObject[i].g1));
                    i1++;
                }
                else if (listObject[i].s1.Contains(Const.tariff2InS1))
                {
                    if(listObject[i].s1 =="na45_Электроэнергия (тариф 2)")
                    {

                    }
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colIdf].Value = listObject[i].id));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colObjectIdf].Value = listObject[i].objectId));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colNetworkAddressf].Value = listObject[i].networkAddress));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colTariff].Value = Const.tariff2));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colS1f].Value = listObject[i].s1));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colG1f].Value = listObject[i].g1));
                    i1++;
                }
                else if (listObject[i].s1.Contains(Const.tariffAllInS1))
                {
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colIdf].Value = listObject[i].id));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colObjectIdf].Value = listObject[i].objectId));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colNetworkAddressf].Value = listObject[i].networkAddress));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colTariff].Value = Const.tariffAll));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colS1f].Value = listObject[i].s1));
                    dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[i1].Cells[Const.colG1f].Value = listObject[i].g1));
                    i1++;
                }
            }

            ThreadRowsGet4(listObjectId.ToArray());
            for (int i = 0; i < records.Count; i++)
            {
                for(int j = 0; j < dgvTableFixed.RowCount; j++)
                {
                    if((string)records[i].objectId == dgvTableFixed.Rows[j].Cells[Const.colObjectIdf].Value.ToString() 
                        && ((string)records[i].s1).Contains(ParseTariff(dgvTableFixed.Rows[j].Cells[Const.colTariff].Value.ToString()))
                        && ((string)records[i].s1).Contains(dgvTableFixed.Rows[j].Cells[Const.colNetworkAddressf].Value.ToString()))
                    {
                        try
                        {
                            dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[$"col{records[i].date.ToString("yyyyMMdd")}"].Value = records[i].d1));
                            if((int)records[i].i1 == 1 && (int)records[i].i2 == 1)
                            {
                                dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[$"col{records[i].date.ToString("yyyyMMdd")}"].Style.BackColor = Color.GreenYellow));
                            }
                            else if ((int)records[i].i1 == 1 && (int)records[i].i2 == 0)
                            {
                                dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[$"col{records[i].date.ToString("yyyyMMdd")}"].Style.BackColor = Color.White));
                            }
                            else if ((int)records[i].i1 == 0)
                            {
                                dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[$"col{records[i].date.ToString("yyyyMMdd")}"].Style.BackColor = Color.Yellow));
                            }
                            else if((int)records[i].i1 == -1)
                            {
                                dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[$"col{records[i].date.ToString("yyyyMMdd")}"].Style.BackColor = Color.OrangeRed));
                            }
                        }
                        catch { }
                    }
                }
            }
            for(int j = 0; j < dgvTableFixed.RowCount; j++)
            {
                
            }
        }
        public string ParseTariff(string tariff)
        {
            switch (tariff)
            {
                case Const.tariff1:
                    return Const.tariff1InS1;
                case Const.tariff2:
                    return Const.tariff2InS1;
                case Const.tariffAll:
                    return Const.tariffAllInS1;
                default:
                    return "---";
            }
        }
        public void ParseGetDataOnlyType(dynamic records)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            try
            {
                dgvTable1(records);
                List<Guid> listObjectId = new List<Guid>();
                List<dynamic> listObjectIdAndS1 = new List<dynamic>();
                Guid objectId;
                for (int i = 0; i < records.Count; i++)
                {
                    objectId = Guid.Parse((string)records[i].objectId);
                    if(!listObjectId.Contains(objectId)) listObjectId.Add(objectId);
                    dynamic tmp = new ExpandoObject();
                    tmp = records[i];
                    if (listObjectIdAndS1.Find(x => x.objectId == tmp.objectId && x.s1 == tmp.s1) == null) listObjectIdAndS1.Add(tmp);

                }

                dgvTableFixedMetod(records, listObjectId, listObjectIdAndS1);
            }
            catch (Exception ex) { Console(ex.Message + MethodInfo.GetCurrentMethod().Name); }
        }
        #endregion
        #region RowsGet4
        public void ThreadRowsGet4(Guid[] ids)
        {
            Thread myThread = new Thread(RowsGet4);           //Создаем новый объект потока (Thread)
            myThread.Start(ids);                             //запускаем поток
            myThread.IsBackground = true;
        }
        public void RowsGet4(object obj)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            try
            {
                Guid[] ids = (Guid[])obj;
                if (ids.Length == 0) return;
                var msg = Helper.BuildMessage("rows-get-4");
                msg.body.ids = ids;
                var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
                dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
                if (response.body == null) return;
                ParseRowsGet4(response.body.rows);
            }
            catch (Exception ex) { Console(ex.Message + MethodInfo.GetCurrentMethod().Name); }
        }
        
        public void ParseRowsGet4(dynamic rows)
        {
            Thread.Sleep(1000);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            try
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < dgvTable.RowCount; j++)
                    {
                        if (dgvTable.Rows[j].Cells[Const.colObjectId].Value.ToString() == rows[i].id.ToString())
                        {
                            dgvTable.Invoke(new Action(() => dgvTable.Rows[j].Cells[Const.colName].Value = rows[i].name));
                            dgvTable.Invoke(new Action(() => dgvTable.Rows[j].Cells[Const.colPname].Value = rows[i].pname));
                        }
                    }
                    for (int j = 0; j < dgvTableFixed.RowCount; j++)
                    {
                        if (dgvTableFixed.Rows[j].Cells[Const.colObjectIdf].Value.ToString() == rows[i].id.ToString())
                        {
                            dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[Const.colNamef].Value = rows[i].name));
                            dgvTableFixed.Invoke(new Action(() => dgvTableFixed.Rows[j].Cells[Const.colPnameF].Value = rows[i].pname));
                        }
                    }
                }
            }
            catch (Exception ex) { Console(ex.Message + MethodInfo.GetCurrentMethod().Name); }
        }
        #endregion
        public void ThreadGetRecordsWithIdsAndS1(DateTime start, DateTime end, string type)
        {
            dynamic data = new ExpandoObject();
            data.start = start;
            data.end = end;
            data.type = type;
            Thread myThread = new Thread(GetRecordsWithIdsAndS1);          
            myThread.Start(data);                          
            myThread.IsBackground = true;
        }
       
        public void GetRecordsWithIdsAndS1(object obj)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // используется для типа double, при парсировании ошибок не было
            try
            {
                dynamic data = (dynamic)obj;
                if (data == null) return;
                var msg = Helper.BuildMessage("records-get-with-ids-and-s1");
                msg.body.start = data.start;
                msg.body.end = data.end;
                msg.body.type = data.type;
                msg.body.objectId = Guid.Parse(dgvTableFixed.SelectedRows[0].Cells[Const.colObjectIdf].Value.ToString());
                msg.body.s1 = dgvTableFixed.SelectedRows[0].Cells[Const.colS1f].Value.ToString();
                msg.body.cmd = "ids:" + dgvTableFixed.SelectedRows[0].Cells[Const.colG1f].Value.ToString();
                var answer = ApiConnector.Instance.SendMessageGetResponse(msg);
                dynamic response = JsonConvert.DeserializeObject<ExpandoObject>(answer);
                
                if (response == null || response.body == null) return;
                formDataFromHubs.FillDataInDGV(response.body.records);
            }
            catch (Exception ex) { Console(ex.Message + MethodInfo.GetCurrentMethod().Name); }
        }
    }
}
