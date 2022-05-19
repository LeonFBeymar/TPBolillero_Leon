using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace tpbolillero.core
{
    public class Simulacion
    {
        public long simularSinHilos(Bolillero bolillero, List<byte> jugada, long cantidad)
        {
            return bolillero.JugarN(jugada, cantidad);
        }

        

        public long simularConHilos(Bolillero bolillero, List<byte> jugada, long cantidad, long cantidadHilos)
        {
            Task<long>[] tareas = new Task<long>[cantidadHilos];
            for (int i = 0; i < cantidad; i++)
            {
                Bolillero bolilleroClon = (Bolillero)bolillero.Clone(); 
                tareas[i] = Task<long>.Run(()=> simularSinHilos(bolilleroClon, jugada, cantidad));
                var a = cantidad / cantidadHilos;


                Task<long>.WaitAll(tareas);
                
                return tareas.Sum();
            }
            
        }
    }
}