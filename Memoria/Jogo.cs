namespace Memoria
{
    internal class Jogo
    {   
        public Jogo(List<Carta> cartas, List<PictureBox> pictures) {
            for (var i = 0; i < pictures.Count; i++){
                var picture = pictures[i];
                var carta = cartas[i];

                picture.Image = Image.FromFile(carta.Face);
                picture.Click += PrepareEvent(carta);
            }

            
        }

        private EventHandler PrepareEvent(Carta carta) {
            return (object? sender, EventArgs e) => {
                carta.Vira();

                var pictureBox = sender as PictureBox;

                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(carta.Face);
                }                
            };
        }
    }
}
