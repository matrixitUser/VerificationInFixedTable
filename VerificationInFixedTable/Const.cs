using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificationInFixedTable
{
    static class Const
    {
        public const string VERSION = "1.2"; //Версия прогрмаммы
        public const string ProgramPassword = "ytrewq";

        public const string SESSION_ID = "sessionId";
        public const string LOGIN = "login";
        public const string PASSWORDMD5 = "password-md5";
        public const string PASSWORD = "password";
        public const string SERVER_HOST = "server-host";
        public const string SERVER_PORT = "server-port";
        public const string SIGNALR_CONNECTOR = "messageacceptor";
        public const string API_PATH = "api/transport";

        public const int SECOND = 1000;
        public const int MINUTE = 1000 * 60;
        public const int HOUR = 1000 * 60 * 60;
        public const int CONNECTION_TIMEOUT = 5 * 60 * 1000;

        public const string colId = "colId";
        public const string colName = "colName";
        public const string colPname = "colPname";
        public const string colObjectId = "colObjectId"; 
        public const string colS1 = "colS1";
        public const string colDate = "colDate";
        public const string colValue = "colValue";
        public const string colDt = "colDt";
        public const string colVerification = "colVerification";
        public const string colG1 = "colG1";

        public const string colIdf = "colIdf";
        public const string colNamef = "colNamef";
        public const string colPnameF = "colPnameF";
        public const string colObjectIdf = "colObjectIdf";
        public const string colNetworkAddressf = "colNetworkAddressf";
        public const string colTariff = "colTariff";
        public const string colG1f = "colG1f";
        public const string colS1f = "colS1f";

        public const string headerColName = "Название объекта учета";
        public const string headerColPname = "Название точки учета";
        public const string headerColNetworkAddress = "Сетевой адрес";
        public const string headerColTariff = "Тариф";

        public const string tariff1InS1 = "тариф 1";
        public const string tariff2InS1 = "тариф 2";
        public const string tariffAllInS1 = "все тарифы";

        public const string tariff1 = "T1";
        public const string tariff2 = "T2";
        public const string tariffAll = "TСум";

        public const string colType = "colType";
            
    }
}
