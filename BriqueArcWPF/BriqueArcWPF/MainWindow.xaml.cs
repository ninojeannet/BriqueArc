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
        public enum Controls { Login, Register, Game}

        private LoginControl loginControl;
        private RegisterControl registerControl;
        private GameControl gameControl;

        public MainWindow()
        {
            InitializeComponent();

            loginControl = new LoginControl();
            registerControl = new RegisterControl();
            gameControl = new GameControl();

            SetControl(Controls.Login);
        }

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
