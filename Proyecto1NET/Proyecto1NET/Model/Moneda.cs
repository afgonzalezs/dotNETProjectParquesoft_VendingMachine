using System;
using System.Threading.Channels;

namespace Proyecto1NET.Model
{
    public class Moneda
    {
        public string cambio(int change)
        {
            int cambioEnCentavos = (int)(change);
            int billeteDe500 = cambioEnCentavos / 50000;
            cambioEnCentavos %= 50000;
            int billeteDe200 = cambioEnCentavos / 20000;
            cambioEnCentavos %= 20000;
            int billeteDe100 = cambioEnCentavos / 10000;
            cambioEnCentavos %= 10000;
            int billeteDe50 = cambioEnCentavos / 5000;
            cambioEnCentavos %= 5000;
            int monedaDe1000 = cambioEnCentavos / 1000;
            cambioEnCentavos %= 1000;
            int monedaDe500 = cambioEnCentavos / 500;
            cambioEnCentavos %= 500;
            int monedaDe200 = cambioEnCentavos / 200;
            cambioEnCentavos %= 200;
            int monedaDe100 = cambioEnCentavos / 100;
            cambioEnCentavos %= 100;
            int monedaDe50 = cambioEnCentavos / 50;

            string cambio = "$Cambio: \n \n";
            if (billeteDe500 > 0)
            {
                cambio += $"{billeteDe500} billete(s) de 50.000 \n ";
            }

            if (billeteDe200 > 0)
            {
                cambio += $"{billeteDe200} billete(s) de 20.000 \n";
            }

            if (billeteDe100 > 0)
            {
                cambio += $"{billeteDe100} billete(s) de 10.000 \n";
            }

            if (billeteDe50 > 0)
            {
                cambio += $"{billeteDe50} billete(s) de 5.000 \n";
            }

            if (monedaDe1000 > 0)
            {
                cambio += $"{monedaDe1000} moneda(s) de 1.000 \n ";
            }

            if (monedaDe500 > 0)
            {
                cambio += $"{monedaDe500} moneda(s) de 500 \n";
            }

            if (monedaDe200 > 0)
            {
                cambio += $"{monedaDe200} moneda(s) de 200 \n ";
            }

            if (monedaDe100 > 0)
            {
                cambio += $"{monedaDe100} moneda(s) de 100 \n ";
            }

            if (monedaDe50 > 0)
            {
                cambio += $"{monedaDe50} moneda(s) de 50";
            }

            return cambio;
        }
    }
}
