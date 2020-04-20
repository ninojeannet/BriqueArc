
using System.Windows.Controls;
using BriqueArcWPF.Game.Models;

namespace BriqueArcWPF.Game.Views
{
    class Bar : Button
    {
        private Models.Bar model;

        public Bar()
        {
            model = new Models.Bar();
            this.Width = 100;
            this.Height = 20;
        }

        public int Position
        {
            get { return model.Position; }
            set { model.Position = value; }
        }

        public void Refresh()
        {
            Canvas.SetLeft(this, model.Position);
        }
    }
}
