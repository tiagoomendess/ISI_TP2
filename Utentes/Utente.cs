using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utentes
{
    public class Utente
    {

        #region ATRIBUTOS
        int id;
        string nif;
        string nome;
        #endregion

        #region CONSTRUTORES
        public Utente()
        {
            id = 0;
            nif = "";
            nome = "";
        }

        public Utente(int id, string nif, string nome)
        {
            this.id = id;
            this.nif = nif;
            this.nome = nome;
        }
        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        #endregion

        #region METODOS
        #endregion

    }
}