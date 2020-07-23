using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_.Net_
{
    //Esta sera mi clase singleton
    public class VarGlo
    {
        //Definimos una instancia estatica de la clase singleton
        private static VarGlo variables;

        //Se define el constructor de la clase como privado, 
        //de esta forma no se podran crear instancias de la clase
        //salvo desde la misma clase
        private VarGlo()
        {

        }

        //Se define un método o propiedad static, la cual será el punto 
        //central por donde se podrá recuperar una instancia de la clase
        //en este punto es donde se valida y crea la instancia de la 
        //variable static definida mas arriba, es por esto que siempre se retorna esta misma instancia.
        public static VarGlo Instance()
        {
            if (variables == null)
            {
                variables = new VarGlo();
            }
            return variables;
        }

        public int CodUsuario { get; set; }
    }
}
