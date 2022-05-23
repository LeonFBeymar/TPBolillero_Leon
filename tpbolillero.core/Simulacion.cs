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

        

        public long simularConHilos(Bolillero bolillero, List<byte> jugada, long cantidadSimulaciones, long cantidadHilos)
        {
            long SimulacionesPorHilo = cantidadSimulaciones / cantidadHilos;

            Task<long>[] tareas = new Task<long>[cantidadHilos];
            
            for (long i = 0; i < cantidadHilos; i++)
            {
                
                for (int a = 0; a < SimulacionesPorHilo; a++)
                {
                    Bolillero bolilleroClon = (Bolillero)bolillero.Clone();
                    tareas[i] = Task<long>.Run(()=> simularSinHilos(bolilleroClon, jugada, cantidadSimulaciones));
                }
            }
            Task<long>.WaitAll(tareas);
            return tareas.Sum(x => x.Result);
        }
    }
}
