namespace Memoria
{
    internal class Carta
    {
        public string Frente { get; private set; }
        public string Verso { get; private set; }
        public string Face { get { 
                if (mostrando)
                {
                    return Frente;
                } else
                {
                    return Verso;
                }
            } 
        }

        private bool mostrando = false;

        public Carta(string frente, string verso)
        {
            Frente = frente;
            Verso = verso;
        }

        public void Vira()
        {
            mostrando = !mostrando;
        }
    }
}
