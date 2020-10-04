
using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        Player p;
        Dealer d;
        int win = 0, lose = 0, games = 0;
        private void NuevoJuego()
        {
            this.p = new Player();
            this.d = new Dealer();

            lblGames.Content = "Victorias: " + win + "\n" + "Derrotas: " + lose + "\n" + "Partidas jugadas: " + games;

            d.Generate();
            d.Randomize();
            d.Init();
            
            p.Init(d.Deal(), d.Deal());
            AsComo11(p.Hand);
            AsComo11(d.Hand);
            ResultsCards(p);
            txtHandDealer.Text = "     " + d.Hand[0].Symbol  + d.Hand[0].Suit + "\n" + "     " + "??";
            btnPedirCarta.IsEnabled = true;
            btnPlantarse.IsEnabled = true;
            btnNewGame.IsEnabled = false;
            lblScoreDealer.Content = Check(d.Hand) - d.Hand[1].Score;
            lblScorePlayer.Content = Check(p.Hand);
            if (Check(p.Hand) == 21)
            {
               Win();
            }
            else if (Check(d.Hand) == 21)
            {

                ResultsCards(d);
                lblScoreDealer.Content = Check(d.Hand);
                Lose();
            }
        }
        public Game()
        {
            InitializeComponent();
            NuevoJuego();
        }

        private void Win()
        {
            btnPedirCarta.IsEnabled = false;
            btnPlantarse.IsEnabled = false;
            MessageBox.Show("           Has ganado. ¡Bien hecho!", "Resultado");
            btnNewGame.IsEnabled = true;
            win += 1;
        }

        private void Lose()
        {
            btnPedirCarta.IsEnabled = false;
            btnPlantarse.IsEnabled = false;
            MessageBox.Show("    Has perdido. ¡Suerte la próxima!", "Resultado");
            btnNewGame.IsEnabled = true;
            lose += 1;
        }


        private void ResultsCards(Player player)
        {
            txtHandPlayer.Text = "";
            foreach (Card c in player.Hand)
            {
                txtHandPlayer.Text += "     " + c.Symbol + c.Suit + "\n";
            }
        }
        private void ResultsCards(Dealer dealer)
        {
            txtHandDealer.Text = "";
            foreach (var item in dealer.Hand)
            {
                txtHandDealer.Text += "     " + item.Symbol + item.Suit + "\n";
            }
        }
        private int Check(List<Card> hand)
        {
            int s = 0;
            foreach (Card card in hand)
            {
                s += card.Score;
            }
            return s;
        }

        private void AsComo11(List<Card> hand)
        {
            foreach (Card card in hand)
            {
                if (card.Symbol == "A")
                {
                    if(Check(hand)-1 <= 10)
                    {
                        card.Score = 11;
                    }
                }
            }
        }

        private void BtnPedirCarta_Click(object sender, RoutedEventArgs e)
        {
            p.AddCard(d.Deal());
            ResultsCards(p);
            AsComo11(p.Hand);
            lblScorePlayer.Content = Check(p.Hand);

            if (Check(p.Hand) > 21)
            {
                Lose();
            }
            else if (Check(p.Hand) == 21)
            {

                if (Check(d.Hand) < 21)
                {
                    Win();
                }
                else if (Check(d.Hand) == 21)
                {
                    Lose();
                }
            }
  
        }
        private void btnPlantarse_Click(object sender, RoutedEventArgs e)
        {
            btnPedirCarta.IsEnabled = false;
            btnPlantarse.IsEnabled = false;
            AsComo11(d.Hand);
            while (Check(d.Hand) < 17 && Check(d.Hand) < 21)
            {
                d.AddCard(d.Deal());
                AsComo11(d.Hand);
                ResultsCards(d);
            }
            ResultsCards(d);
            lblScoreDealer.Content = Check(d.Hand);
            if (Check(d.Hand) > 21)
            {
                Win();
            }
            else if (Check(d.Hand) > Check(p.Hand))
            {
                Lose();
            }
            else if (Check(d.Hand) < Check(p.Hand))
            {
                Win();
            }
            else
            {
                MessageBox.Show("    Empate", "Resultado");
                btnNewGame.IsEnabled = true;
            }
        }
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.games += 1;
            NuevoJuego();
        }

    }
}
