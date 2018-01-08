using RestSharp;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.ServiceModel.Web;

namespace Utentes
{
    public class Utentes : IUtentesSOAP, IUtentesREST
    {

        #region METODOS_REST

        public string Teste()
        {

            MyRestClient rest = new MyRestClient("http://localhost:53039/Utentes.svc/rest/utente/getbynif/123456789");
            StreamReader stream = new StreamReader(rest.GetRequest().GetResponseStream());

            return stream.ReadToEnd();

            //string consumerKey = "test";
            //string consumerSecret = "segredo";
            //var uri = new Uri("http://localhost:53039/Utentes.svc/rest/utente/getbynif/264628773");
            //string url, param;
            //var oAuth = new OAuthBase();
            //var nonce = oAuth.GenerateNonce();
            //var timeStamp = oAuth.GenerateTimeStamp();
            //var signature = oAuth.GenerateSignature(uri, consumerKey,
            //consumerSecret, string.Empty, string.Empty, "GET", timeStamp, nonce, out url, out param);

            //WebResponse webrespon = WebRequest.Create(string.Format("{0}?{1}&oauth_signature={2}", url, param, signature)).GetResponse();
            //StreamReader stream = new StreamReader(webrespon.GetResponseStream());

            //return stream.ReadToEnd();

        }
        public void DoWorkREST()
        {
            throw new NotImplementedException();
        }

        public bool IsWorkingREST()
        {
            return true;
        }

        public bool AddUtenteREST(Utente utente)
        {
            if (MyAuth.Authenticate(WebOperationContext.Current.IncomingRequest))
            {
                return AddUtente(utente);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }
        }

        /// <summary>
        /// Procura na base de dados um objeto de utente
        /// </summary>
        /// <param name="nif">Nif do utente</param>
        /// <returns>Utente default caso nao exista, ou utente preenchido com o nif coorespondente</returns>
        public Utente GetUtenteByNifREST(string nif)
        {
            if (MyAuth.Authenticate(WebOperationContext.Current.IncomingRequest))
            {
                return GetUtenteByNif(nif);
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return new Utente();
            }   
        }

        public Utente GetUtenteByNifNoAuth(string nif)
        {
            return GetUtenteByNif(nif);
        }
        #endregion

        #region METODOS_SOAP
        public void DoWorkSOAP()
        {
            throw new NotImplementedException();
        }

        public bool IsWorkingSOAP()
        {
            return true;
        }

        public bool AddUtenteSOAP(Utente utente)
        {
            return AddUtente(utente);
        }

        public Utente GetUtenteByNifSOAP(string nif)
        {
            return GetUtenteByNif(nif);
        }

        #endregion

        #region OUTROS_METODOS

        /// <summary>
        /// Procura por um utente na base de dados
        /// </summary>
        /// <param name="nif">Nif do utente a procurar</param>
        /// <returns></returns>
        Utente GetUtenteByNif(string nif)
        {
            DBConnection db = new DBConnection();
            DataTable dt;
            Utente utente = new Utente();

            dt = db.Query("SELECT * FROM utentes WHERE nif = @0 LIMIT 1", nif);

            if (dt == null | dt.Rows.Count != 1)
                return utente;
            else
            {
                utente = new Utente();
                utente.Id = int.Parse(dt.Rows[0]["id"].ToString());
                utente.Nome = dt.Rows[0]["nome"].ToString();
                utente.Nif = nif;
                utente.Sucesso = true;
            }

            return utente;
        }

        /// <summary>
        /// Adiciona um utente na base de dados
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        bool AddUtente(Utente utente)
        {
            DBConnection db = new DBConnection();
            int rows = 0;

            rows = db.NonQuery("INSERT INTO utentes (nif, nome) VALUES (@0, @1)", utente.Nif, utente.Nome);

            if (rows != 1)
                return false;
            else
                return true;
        }
        #endregion

    }
}
