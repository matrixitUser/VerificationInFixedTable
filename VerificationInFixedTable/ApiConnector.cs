using Microsoft.AspNet.SignalR.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VerificationInFixedTable
{
    class ApiConnector
    {
        static ApiConnector() { }

        private static readonly ApiConnector instance = new ApiConnector();
        public static ApiConnector Instance
        {
            get
            {
                return instance;
            }
        }

        public Guid SessionId
        {
            get
            {
                var raw = ConfigurationManager.AppSettings.Get(Const.SESSION_ID);
                Guid sessionId = Guid.Empty;
                Guid.TryParse(raw, out sessionId);
                return sessionId;
            }
            set
            {
                UpdateSetting(Const.SESSION_ID, value.ToString());
            }
        }

        public string ServerUrl
        {
            get
            {
                string serverPort = ConfigurationManager.AppSettings.Get(Const.SERVER_PORT);
                var serverUrl = string.Format("http://{0}{1}{2}", ConfigurationManager.AppSettings.Get(Const.SERVER_HOST), (serverPort != "") ? ":" : "", serverPort);
                return serverUrl;
            }
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configuration.AppSettings.Settings[key] == null)
            {
                configuration.AppSettings.Settings.Add(key, value);
            }
            else
            {
                configuration.AppSettings.Settings[key].Value = value;
            }

            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
        public dynamic SendByAPI(dynamic message)
        {
            try
            {
                var client = new RestClient(ServerUrl);
                RestRequest request = new RestRequest(Const.API_PATH, RestSharp.Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(message);
                var response = client.Execute(request);
                dynamic answer = JsonConvert.DeserializeObject<ExpandoObject>(response.Content, new Newtonsoft.Json.JsonSerializerSettings { DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local });
                return answer;
            }
            catch (Exception ex) { }
            return null;
        }
        public dynamic SendMessage(dynamic message)
        {
            if (SessionId != Guid.Empty)
            {
                message.head.sessionId = SessionId;
            }
            return SendByAPI(message);
        }

        public dynamic SendByAPI1(dynamic message)
        {
            try
            {
                var client = new RestClient(ServerUrl);
                RestRequest request = new RestRequest(Const.API_PATH, RestSharp.Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(message);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public dynamic SendMessageGetResponse(dynamic message)
        {
            if (SessionId != Guid.Empty)
            {
                message.head.sessionId = SessionId;
            }
            return SendByAPI1(message);
        }

        public bool AuthBySession()
        {
            if (SessionId != Guid.Empty)
            {
                var authBySession = Helper.BuildMessage("auth-by-session");
                authBySession.body.sessionId = SessionId;
                var sessionAns = SendByAPI(authBySession);
                if (sessionAns == null) return false;

                if (sessionAns.head.what == "auth-success")
                {
                    SessionId = Guid.Parse((string)sessionAns.body.sessionId);
                    return true;
                }
            }
            return false;
        }
        public dynamic AuthByLoginWithGetSession(string login, string password)
        {
            var authByLogin = Helper.BuildMessage("auth-by-login");
            authByLogin.body.login = login;
            authByLogin.body.password = password;
            var loginAns = SendByAPI(authByLogin);
            if (loginAns.head.what == "auth-success")
            {
                SessionId = Guid.Parse((string)loginAns.body.sessionId);
            }
            return loginAns;
        }
        public dynamic AuthByLoginWithoutGetSession(string login, string password)
        {
            var authByLogin = Helper.BuildMessage("auth-by-login1");
            authByLogin.body.login = login;
            authByLogin.body.password = password;
            var loginAns = SendByAPI(authByLogin);
            return loginAns;
        }
    }
}
