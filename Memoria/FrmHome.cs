namespace Memoria
{
    public partial class FrmHome : Form
    {
        private Jogo jogo;

        public FrmHome()
        {
            InitializeComponent();

            var cartas = new List<Carta>()
            {
                new Carta(
                    "../../../Assets/Images/abacate.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/abacaxi.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/banana.png",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/laranja.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/limao.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/morango.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/abacate.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/abacaxi.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/banana.png",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/laranja.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/limao.jpg",
                    "../../../Assets/Images/memoria.jpg"
                ),
                new Carta(
                    "../../../Assets/Images/morango.jpg",
                    "../../../Assets/Images/memoria.jpg"
                )
            };

            jogo = new Jogo(
                cartas,
                [picCard1, picCard2, picCard3, picCard4, picCard5,
                picCard6, picCard7, picCard8, picCard9, picCard10,
                picCard11, picCard12]
            );
        }

        


    }
}
