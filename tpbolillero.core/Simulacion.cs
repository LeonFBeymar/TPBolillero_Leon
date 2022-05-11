using System.Collections.Generic;
namespace tpbolillero.core
{
    public class Simulacion
    {
        public long simularSinHilos(Bolillero bolillero, List<byte> jugada, long cantidad)
        {
            return bolillero.JugarN(jugada, cantidad);
        }

        public long simularConHilos()
        {

        }
    }
}