using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Utentes
{
    [DataContract]
    public class Utente
    {

        #region ATRIBUTOS
        //Variaveis da classe
        bool sucesso;
        int id;
        string nif;
        string nome;
        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Instancia um novo objeto de Utente por defeito
        /// </summary>
        public Utente()
        {
            id = 0;
            nif = "";
            nome = "";
            sucesso = false;
        }

        /// <summary>
        /// Instancia uma nova instancia de Utente sem id
        /// </summary>
        /// <param name="nif">Nif</param>
        /// <param name="nome">Nome</param>
        public Utente(string nif, string nome)
        {
            id = 0;
            sucesso = true;
            this.nif = nif;
            this.nome = nome;
        }

        /// <summary>
        /// Instancia um novo objeto de Utente com os parametros de entrada
        /// </summary>
        /// <param name="sucesso">Sucesso ou nao sucesso</param>
        /// <param name="id">Id do objeto</param>
        /// <param name="nif">NIF</param>
        /// <param name="nome">Nome</param>
        public Utente(bool sucesso, int id, string nif, string nome)
        {
            this.id = id;
            this.nif = nif;
            this.nome = nome;
        }
        #endregion

        #region PROPRIEDADES
        [DataMember]
        public bool Sucesso
        {
            get { return sucesso; }
            set { sucesso = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Comprara se um objeto é igual a esta instancia
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Verdaddeiro se fopr igual, falso se for diferente</returns>
        public override bool Equals(object obj)
        {
            Utente aux;

            if (obj.GetType() == typeof(Utente))
                aux = (Utente)obj;
            else
                return false;

            return (aux.Id == id && aux.Nif == nif && aux.Nome == nome);

        }

        /// <summary>
        /// Get's the hashcode of the object
        /// </summary>
        /// <returns>Hashcode of the object</returns>
        public override int GetHashCode()
        {
            var hashCode = 556106532;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nif);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nif);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
        #endregion

    }
}