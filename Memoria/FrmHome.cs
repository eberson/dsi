using System.Diagnostics;

namespace Memoria
{
    public partial class FrmHome : Form
    {
        private Jogo jogo;

        public FrmHome()
        {
            InitializeComponent();

            jogo = new Jogo(picCard1, picCard2, picCard3, picCard4, picCard5, picCard6, picCard7, picCard8, picCard9, picCard10, picCard11, picCard12);
            jogo.TentativaHandler += TentativaHandler;
            jogo.GameOverHandler += OnGameOverHandler;
            jogo.New();

        }

        public void TentativaHandler(int tentativas)
        {
            if (InvokeRequired)
            {
                Invoke((TentativaHandler)TentativaHandler, tentativas);
            }
            else
            {
                lblTentativas.Text = tentativas.ToString();
            }
        }

        public void OnGameOverHandler()
        {
            if (InvokeRequired)
            {
                Invoke((GameOverHandler)OnGameOverHandler, null);
            }
            else
            {
                btnRestart.Visible = true;
            }
        }

        private void relogio_Tick(object sender, EventArgs e)
        {
            lblTempo.Text = jogo.TimePassed;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            jogo.New();
            btnRestart.Visible = false;
        }
    }
}
