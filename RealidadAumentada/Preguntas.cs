using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealidadAumentada
{
    public class Preguntas
    {
        public String pregunta, resA, resB, resC, imagen;
        public bool contestada;

        public Preguntas(String pregunta,String resA,String resB,String resC,String imagen)
        {
            this.pregunta = pregunta;
            this.resA = resA;
            this.resB = resB;
            this.resC = resC;
            this.imagen = imagen;
            contestada = false;
        }
    }
}
