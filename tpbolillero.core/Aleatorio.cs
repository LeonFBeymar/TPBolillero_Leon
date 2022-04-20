using System.Collections.Generic;
using System;
namespace tpbolillero.core
{    public class Aleatorio : IAzar
    {
        public Random r = new Random();
        public byte SacarBolilla(List<byte> bolillas)
        {
            int cantidad = bolillas.Count;
            var indice = r.Next(0,cantidad);
            return bolillas[indice];
        }
    }
}