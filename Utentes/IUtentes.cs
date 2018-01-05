using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Utentes
{
    [ServiceContract]
    public interface IUtentesSOAP
    {
        [OperationContract]
        bool IsWorkingSOAP();

        [OperationContract]
        void DoWorkSOAP();

        [OperationContract]
        bool AddUtenteSOAP(Utente utente);

        [OperationContract]
        Utente GetUtenteByNifSOAP(string nif);
    }

    [ServiceContract]
    public interface IUtentesREST
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "teste")]
        string Teste();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "isworking")]
        bool IsWorkingREST();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "dowork")]
        void DoWorkREST();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "utente/add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool AddUtenteREST(Utente utente);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "utente/getbynif/{nif}")]
        Utente GetUtenteByNifREST(string nif);
    }
}
