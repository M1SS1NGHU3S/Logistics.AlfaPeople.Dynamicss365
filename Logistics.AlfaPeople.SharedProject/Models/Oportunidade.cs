using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistiscs.AlfaPeople.Models.Models
{
    public class Oportunidade : ModelCore
    {
        public Oportunidade(IOrganizationService serviceClient)
        {
            this.ServiceClient = serviceClient;
            this.LogicName = "opportunity"
        }

        //Cria o padrão do número OPP-12365-A1A2
        //public string CreateNumberIdentificador(string start, string end, int incrementNumber, string padFunc, string finalNumberProtocol)
        //{
        //    Entity oportunidade = new Entity(this.Logical);
        //    start = "OPP-";
        //    end = "-A1A2"
        //    incrementNumber = +1;
        //    padFunc = incrementNumber.ToString().PadLeft(5, '0');

        //    return finalNumberProtocol = start + padFunc + end;
        //}

        public bool Update(string start, string end)
        {
            Entity oportunidade = new Entity(this.Logicalname, accountId);

            start = "OPP-";
            end = "-A1A2";

            oportunidade["grp_nmr_identificador"] = ;
            this.ServiceClient.Update(oportunidade);
            return false;
        }
    } 
}
