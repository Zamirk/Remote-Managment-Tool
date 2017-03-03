using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.EasterEgg
{
    class GameButton: Button
    {
        public GameButton()
        {
            Clicked += FlipButton;
        }

        public bool flipped = false;

        public bool IsFlipped()
        {
            return flipped;
        }

        //Button location in array identifier
        public int Pos { get; set; }

        // Hidden Colour, visible after flip
        public Color HiddenColour { get; set; }

        // Holds the background colour when it is replaced by the hidden colour
        public Color BackgroundColourHolder { get; set; }

        // Button Click
        public async void FlipButton(object sender, EventArgs e)
        {
            IsEnabled = false;
            await Task.WhenAll(this.RotateYTo(90, 250));
            BackgroundColor = HiddenColour;
            await Task.WhenAll(this.RotateYTo(180, 250));
            Clicked -= FlipButton;
            IsEnabled = true;
            flipped = true;
        }
    }
}
