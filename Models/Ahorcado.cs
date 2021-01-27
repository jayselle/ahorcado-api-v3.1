using System.Collections.Generic;

namespace Models
{
    public class AhorcadoRequest
    {
        public string Letra { get; set; }
        public string Palabra { get; set; }
    }

    public class AhorcadoResponse
    {
        public string Palabra { get; set; }
        public string Modelo { get; set; }
        public int Intentos { get; set; }
        public bool Acierto { get; set; }
        public bool GameOver { get; set; }
        public bool Win { get; set; }
        public List<string> LetrasIngresadas { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}