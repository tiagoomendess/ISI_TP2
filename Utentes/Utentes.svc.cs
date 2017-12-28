using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Utentes
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Utentes" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Utentes.svc ou Utentes.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Utentes : IUtentesSOAP, IUtentesREST
    {

        public void DoWorkREST()
        {
            throw new NotImplementedException();
        }

        public void DoWorkSOAP()
        {
            throw new NotImplementedException();
        }

        public bool IsWorkingREST()
        {
            return true;
        }

        public bool IsWorkingSOAP()
        {
            return true;
        }
    }
}
