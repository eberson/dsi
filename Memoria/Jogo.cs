using System.Diagnostics;

namespace Memoria
{
    public delegate void TentativaHandler(int tentativas);
    public delegate void GameOverHandler();

    internal class Jogo(params PictureBox[] pictures)
    {
        private List<Carta> cartas;
        private List<PictureBox> pictures = [.. pictures];

        private Carta? primeira;
        private Carta? segunda;

        private Stopwatch cronometro = new Stopwatch();
        private int tentativas;

        public bool GameOver
        {
            get
            {
                return cartas.Where(c => c.Habilitado).Count() == 0;
            }
        }

        public string TimePassed
        {
            get
            {
                var elapsed = cronometro.Elapsed;
                return $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
            }
        }

        public event TentativaHandler TentativaHandler;
        public event GameOverHandler GameOverHandler;

        public void New()
        {
            tentativas = 0;
            OnTentativa(tentativas);

            cartas = FabricaCartas.Gera();

            for (var i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var carta = cartas[i];
                carta.Image = picture;

                picture.Image = Image.FromFile(carta.Face);
                picture.Click += Prepare(carta);
            }

            cronometro.Reset();
            cronometro.Start();
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

            tentativas++;
            OnTentativa(tentativas);

            if (GameOver)
            {
                cronometro.Stop();
                OnGameOver();
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

        private void OnTentativa(int tentativa)
        {
            var handler = TentativaHandler;
            if (handler != null)
            {
                handler.Invoke(tentativa);
            }
        }

        private void OnGameOver()
        {
            var handler = GameOverHandler;
            if (handler != null)
            {
                handler.Invoke();
            }
        }
    }
}
