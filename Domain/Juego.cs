using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Juego
    {
        public string Palabra { get; set; }
        public bool Win { get; set; }
        public string Modelo { get; set; }
        public List<string> LetrasIngresadas { get; set; }
        public int Intentos { get; set; }
        public bool Acierto { get; set; }

        public Juego(string palabra)
        {
            Palabra = palabra;
            Win = false;
            Modelo = SetModelo(palabra);
            LetrasIngresadas = new List<string>();
            Intentos = 6;
        }

        private string SetModelo(string palabra)
        {
            var modelo = "";

            for (int i = 0; i < palabra.Length; i++)
            {
                modelo += "_ ";
            }

            return modelo.Trim();
        }

        private void UpdateModelo(string letra)
        {
            char l = char.ToLower(char.Parse(letra));

            var p = new List<char>();

            p.AddRange(Palabra.ToLower());

            var modeloSinEspacios = new List<char>();

            modeloSinEspacios.AddRange(Modelo.Replace(" ", ""));

            for (int i = 0; i < p.Count; i++)
            {
                if (p[i] == l)
                    modeloSinEspacios[i] = char.ToUpper(l);
            }

            string str = "";

            for (int i = 0; i < modeloSinEspacios.Count; i++)
            {
                if (i == modeloSinEspacios.Count - 1)
                    str += modeloSinEspacios[i];
                else
                    str += modeloSinEspacios[i] + " ";
            }

            Modelo = str;
        }

        public void CheckLetra(string letra)
        {
            var l = letra.ToLower();

            if (!LetrasIngresadas.Contains(l))
            {
                LetrasIngresadas.Add(l);

                if (Palabra.Contains(l))
                {
                    if (Palabra.All(x => LetrasIngresadas.Contains(x.ToString())))
                        Win = true;

                    UpdateModelo(l);
                    Acierto = true;
                }
                else
                {
                    Intentos--;
                    Acierto = false;
                }
            }
            else if (Palabra.Contains(l))
            {
                Acierto = true;
            }
            else
            {
                Acierto = false;
            }
        }

        public void CheckPalabra(string palabra)
        {
            if (Palabra.Equals(palabra.ToLower()))
            {
                Win = true;
                Acierto = true;
            }
            else
            {
                Intentos = 0;
                Acierto = false;
            }
        }

        public bool IsGameOver()
        {
            if (Intentos == 0)
                return true;
            else
                return false;
        }

        public bool KeepPlaying()
        {
            return !Win && !IsGameOver();
        }
    }
}