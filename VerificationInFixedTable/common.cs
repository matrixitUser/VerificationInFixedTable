using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationInFixedTable
{
    /* Get SessionId */
    public class SessionJson
    {
        public Object head { get; set; }
        public BodyFromSession body { get; set; }
    }
    public class BodyFromSession
    {
        public Object user { get; set; }
        public string sessionId { get; set; }
        public string message { get; set; }
    }

    /*Class Head Api*/
    public class ClassHead
    {
        public string what { get; set; }
        public string sessionId { get; set; }
    }

    #region Get List Of Accounting  Points
    public class GetListOfAccountingPoints
    {
        public ClassHead head { get; set; }
        public GetBodyLOAP body { get; set; }
    }
    public class GetBodyLOAP
    {
        public RowsBody[] rows { get; set; }
    }
    public class RowsBody
    {
        public string id { get; set; }            //точки учета 
        public string state { get; set; }          //статус текущего опроса; NULL - ни разу не опрашивался 
        public string description { get; set; } //причина отключения объекта 
        public string name { get; set; }        //название ОБЪЕКТА учёта 
        public string pname { get; set; }       //название точки учёта 
        public string city { get; set; }
        public string phone { get; set; }       //для модемных объектов 
        public string imei { get; set; }
        public string isDeleted { get; set; }     //объект удалён, если True 
        public string device { get; set; }      //название вычислителя 
        public string isDisabled { get; set; }    //объект отключен от опросов, если True 
        public string abnormals { get; set; }      //количество НС за сутки 
        public string number { get; set; }         //номер договора 
        public string deviceId { get; set; }
        public string resource { get; set; }
        public string fulness { get; set; }     //полнота суточных данных за месяц 
        public string comment { get; set; }
        public string lightMk { get; set; }
        public string lightReal { get; set; }
        public string light { get; set; }
    }
    #endregion
    #region Classes for send api query that get tree
    public class GetApiFolder
    {
        public ClassHead head { get; set; }
        public BodyFromGetApiFolder body { get; set; }

    }
    public class BodyFromGetApiFolder
    {
        public RootBody root { get; set; }
    }
    public class RootBody
    {
        public DataFromRoot data { get; set; }
        public Object group { get; set; }
        public Object expanded { get; set; }
        public Childrens[] children { get; set; }
    }
    public class DataFromRoot
    {
        public string name { get; set; }
    }
    public class Childrens
    {
        public DataFromChildren data { get; set; }
        public string group { get; set; }
        public Childrens[] children { get; set; }
    }
    public class DataFromChildren
    {
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }
    #endregion

    #region Query current indications from database
    public class GetQueryCurrentIndications
    {
        public ClassHead head { get; set; }
        public BodyFromSQCI body { get; set; }
    }
    public class BodyFromSQCI
    {
        public DataFromBodySQCI[] data { get; set; }
    }
    public class DataFromBodySQCI
    {
        public DateTime date { get; set; }
        public Guid objectId { get; set; }
        public double ХВС { get; set; }
        public double XВС2 { get; set; }
        public string GetLightReal { get; set; }
        public string GetLightMk { get; set; }
        public string GetPhotoSenserState { get; set; }
        public string GetControlMetod { get; set; }
        public string PowerP1 { get; set; }
        public string PowerP2 { get; set; }
        public string PowerP3 { get; set; }
        public string ActiveEnergySum { get; set; }
        public string ActiveEnergyT1 { get; set; }
        public string ActiveEnergyT2 { get; set; }
        public string ActiveEnergyT3 { get; set; }
        public string ActiveEnergyT4 { get; set; }
        public string ActiveEnergy1 { get; set; }
        public string ActiveEnergy2 { get; set; }
        public string Power { get; set; }

    }
    #endregion



    #region Query an object for editing by ID 
    public class GetQueryObjectForEditingByID
    {
        public ClassHead head { get; set; }
        public BodyGetQOFEByID body { get; set; }
    }
    public class BodyGetQOFEByID
    {
        public AreaFromBodyFromQueryOFEID area { get; set; }
        public Object Tube { get; set; }
        public TubeFromBodyFromQueryOFEID tube { get; set; }
        public DeviceFromBodyFromQueryOFEID device { get; set; }
        public Object[] relations { get; set; }
        public Object[] devices { get; set; }
    }
    public class AreaFromBodyFromQueryOFEID
    {
        public string city { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
        public string shedule { get; set; }
        public string sheduleName { get; set; }
        public Guid meterId { get; set; }
        public string controlMetod { get; set; }
        public string points { get; set; }
        public string pointsForMaps2 { get; set; }
        public string AstronomicalMinus { get; set; }
        public string AstronomicalPlus { get; set; }
        public string MaxPower { get; set; }
        public string AfterSunSet { get; set; }
        public string BeforeSunRise { get; set; }
    }
    public class TubeFromBodyFromQueryOFEID
    {
        public string logLevel { get; set; }
        public string disabledHistory { get; set; }
        public DateTime startDate1 { get; set; }
        public string name { get; set; }
        public string pname { get; set; }
        public string comment { get; set; }
        public bool logEnable { get; set; }
        public string cmd { get; set; }
        public Guid id { get; set; }
        public string type { get; set; }
        public string networkAddress { get; set; }
        public string version { get; set; }
        public string parameters { get; set; }
        public string startDate { get; set; }
        public string shedule { get; set; }
        public string sheduleName { get; set; }
        public string rtcEnabled { get; set; }
        public Guid meterId { get; set; }


    }
    public class DeviceFromBodyFromQueryOFEID
    {
        public string reference { get; set; }
        public string filename { get; set; }
        public string uploadDate { get; set; }
        public Object[] fieldCaptions { get; set; }
        public Object[] fieldNames { get; set; }
        public Object[] fieldDescriptions { get; set; }
        public string name { get; set; }
        public Guid id { get; set; }
        public string type { get; set; }
        public Object[] tags { get; set; }
    }
    #endregion


    #region Get Tasks
    public class GetQueryGetTasks
    {
        public ClassHead head { get; set; }
        public BodyGetQGTasks body { get; set; }
    }
    public class BodyGetQGTasks
    {
        public TasksFromBodyGetTasks[] tasks { get; set; }
    }
    public class TasksFromBodyGetTasks
    {
        public string name { get; set; }
        public string shedule { get; set; }
        public Guid id { get; set; }
        public int typeNumber { get; set; }
    }
    #endregion
   

}
