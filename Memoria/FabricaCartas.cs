namespace Memoria
{
    internal class FabricaCartas
    {
        private static readonly string VersoCarta = "../../../Assets/Images/memoria.jpg";

        private static readonly string Imagem1 = "../../../Assets/Images/banana.png";
        private static readonly string Imagem2 = "../../../Assets/Images/abacate.jpg";
        private static readonly string Imagem3 = "../../../Assets/Images/abacaxi.jpg";
        private static readonly string Imagem4 = "../../../Assets/Images/laranja.jpg";
        private static readonly string Imagem5 = "../../../Assets/Images/limao.jpg";
        private static readonly string Imagem6 = "../../../Assets/Images/morango.jpg";

        static void Shuffle(string[] images)
        {
            var rand = new Random();

            for (var i = images.Length - 1; i >= 0; i--)
            {
                int rIndex = rand.Next(i + 1);
                var a = images[i];
                var b = images[rIndex];

                images[i] = b;
                images[rIndex] = a;
            }
        }

        public static List<Carta> Gera()
        {
            //vetor de styring que corresponde as faces das cartas
            string[] images = [Imagem1, Imagem2, Imagem3, Imagem4, Imagem5, Imagem6];

            var cartas = new List<Carta>();

            //embaralha as imgs do veotr
            Shuffle(images);

            foreach (var image in images)
            {
                cartas.Add(new Carta(image, VersoCarta));
            }
            //agr precisamos gerar o segundo cinjunto de cartas 
            //pois cada carta precisa ter duas para funcionar o jogo

            //embaralha de novo
            Shuffle(images);

            //gerao segunndo conjunto de cartas
            foreach (var image in images)
            {
                cartas.Add(new Carta(image, VersoCarta));
            }

            return cartas;
        }
    }
}
