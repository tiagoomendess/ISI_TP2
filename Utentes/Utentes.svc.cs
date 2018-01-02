using System;
using System.Data;

namespace Utentes
{
    public class Utentes : IUtentesSOAP, IUtentesREST
    {

        #region METODOS_REST
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
            return AddUtente(utente);
        }

        /// <summary>
        /// Procura na base de dados um objeto de utente
        /// </summary>
        /// <param name="nif">Nif do utente</param>
        /// <returns>Utente default caso nao exista, ou utente preenchido com o nif coorespondente</returns>
        public Utente GetUtenteByNifREST(string nif)
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
