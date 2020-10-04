using BlackJack_OmarNova_SilviaPabon;
using System;
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
    /// Lógica de interacción para Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow NuevoJuego = (MainWindow)Window.GetWindow(this);
            NuevoJuego.frameMain.NavigationService.Navigate(new Game());
        }
    }
}
