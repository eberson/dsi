namespace Memoria
{
    internal class Jogo
    {
        private Carta? primeira;
        private Carta? segunda;        
        private bool terminou = false;

        public Jogo(params PictureBox[] pictures)
        {
            var cartas = FabricaCartas.Gera();

            for (var i = 0; i < pictures.Length; i++)
            {
                var picture = pictures[i];
                var carta = cartas[i];
                carta.Image = picture;

                picture.Image = Image.FromFile(carta.Face);
                picture.Click += Prepare(carta);
            }
        }

        private EventHandler Prepare(Carta carta)
        {
            return (object? sender, EventArgs e) =>
            {//quando um evendto é disparado o obj que disparou o evento
                //é passado na variável sendeer
                //no nosso caso qnd clicamos em um PicBox, ele será
                //enviado na variável sender
                //oq fazemos abaixo é converter de object? para PictureBox?
                PictureBox? pictureBox = sender as PictureBox;

                if (pictureBox != null)
                {
                    carta.Vira();

                    Task.Delay(200).ContinueWith(task =>
                    {
                        Avalia(carta);
                    });
                }
            };
        }

        private void Avalia(Carta carta)
        {
            if (!carta.Habilitado)
            {
                return;
            }

            if (primeira == null)
            {
                primeira = carta;
                return;
            }
            
            if (carta == primeira)
            { 
                Reset();
                return;
            }

            segunda = carta;            

            if (Acertou())
            {
                primeira.Desabilita();
                segunda.Desabilita();
            }
            else
            {
                primeira.Desvira();
                segunda.Desvira();
            }

            Reset();
        }

        private void Reset()
        {
            primeira = null;
            segunda = null;
        }

        private bool Acertou()
        {
            var carta1 = primeira?.Face ?? string.Empty;
            var carta2 = segunda?.Face ?? string.Empty;

            return !string.IsNullOrEmpty(carta1) &&
                carta1 == carta2;
        }
    }
}
