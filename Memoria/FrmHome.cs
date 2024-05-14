namespace Memoria
{
    public partial class FrmHome : Form
    {
        private Jogo jogo;

        public FrmHome()
        {
            InitializeComponent();

            jogo = new Jogo(picCard1, picCard2, picCard3, picCard4, picCard5, picCard6, picCard7, picCard8, picCard9, picCard10, picCard11, picCard12);
        }




    }
}
