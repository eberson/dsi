namespace Memoria
{
    internal class Carta
    {

        public string Frente { get; private set; }
        public string Verso { get; private set; }
        public bool Habilitado { get; private set; }
        public PictureBox Image { get; set; }
        public bool Mostrando { get
            {
                return mostrando;
            }
        }

        public string Face
        {
            get
            {
                //if (mostrando)
                //{
                //    return Frente;
                //}
                //else
                //{
                //    return Verso;
                //}

                //o código abaixo é uma versão simplificada
                // do de cima (conhecida com if ternario)
                return mostrando ? Frente : Verso;
            }
        }

        private bool mostrando;

        public Carta(string frente, string verso)
        {
            Frente = frente;
            Verso = verso;
            Habilitado = true;
            mostrando = false;
        }

        public void Vira()
        {
            if (Habilitado)
            {
                mostrando = !mostrando;
                Image.Image = System.Drawing.Image.FromFile(Face);
            }
        }

        public void Desvira()
        {
            if (Habilitado && Mostrando)
            {
                Vira();
            }
        }

        public void Desabilita()
        {
            Habilitado = false;
        }

    }
}
