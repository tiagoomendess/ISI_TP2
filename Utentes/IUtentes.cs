using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Utentes
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IUtentes" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IUtentesSOAP
    {
        [OperationContract]
        bool IsWorkingSOAP();

        [OperationContract]
        void DoWorkSOAP();
    }

    [ServiceContract]
    public interface IUtentesREST
    {

        [OperationContract]
        bool IsWorkingREST();

        [OperationContract]
        void DoWorkREST();
    }
}
