
using System.Collections.Generic;

namespace tpbolillero.core
{
    public class Primera : IAzar
    {
        public byte SacarBolilla(List<byte> bolillas) => bolillas[0];
    }
}