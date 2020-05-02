using BriqueArcWPF.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Controles possible de la fenètre
        /// </summary>
        public enum Controls { Login, Register, Game}

        private LoginControl loginControl;
        private RegisterControl registerControl;
        private GameControl gameControl;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            loginControl = new LoginControl();
            registerControl = new RegisterControl();
            gameControl = new GameControl();

            SetControl(Controls.Login);
        }

        /// <summary>
        /// Modifie le control actuel
        /// </summary>
        /// <param name="control">Le nouveau control</param>
        public void SetControl(Controls control)
        {
            grid.Children.Clear();

            switch(control)
            {
                case Controls.Login:
                    grid.Children.Add(loginControl);
                    break;
                case Controls.Register:
                    grid.Children.Add(registerControl);
                    break;
                case Controls.Game:
                    grid.Children.Add(gameControl);
                    break;
            }
        }
    }
}
