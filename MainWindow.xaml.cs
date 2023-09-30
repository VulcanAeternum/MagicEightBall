using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MagicEightBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // A list of potential answers the Magic Eight Ball might give.
        private string[] answers = new[]
        {
            "It is certain.",
            "It is decidedly so.",
            "Without a doubt.",
            "Yes – definitely.",
            "You may rely on it.",
            "Reply hazy, try again.",
            "Ask again later.",
            "Better not tell you now.",
            "Cannot predict now.",
            "Concentrate and ask again.",
            "Don't count on it.",
            "My reply is no.",
            "My sources say no.",
            "Outlook not so good.",
            "Very doubtful.",
            "Deadass.",
            "That's wack, idk.",
            "Fuck no."
        };

        public MainWindow()
        {
            InitializeComponent();
            ShowAnswer();
        }

        private void ShakeButton_Click(object sender, RoutedEventArgs e)
        {
            //Hide the text befiore spining.
            HideAnswer();

            // Spin the triangle.
            DoubleAnimation spinAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(1),
                RepeatBehavior = new RepeatBehavior(1) // Spins the triangle 3 times.
            };

            spinAnimation.Completed += (s, a) => ShowAnswer(); // Display the answer once spinning completes.

            triangleRotation.BeginAnimation(RotateTransform.AngleProperty, spinAnimation);
        }

        private void ShowAnswer()
        {
            // Randomly pick an answer from the list.
            Random rand = new Random();
            string randomAnswer = answers[rand.Next(answers.Length)];

            answerText.Text = randomAnswer;

            // Fade in the answer on the triangle.
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1)
            };

            answerText.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
        }

        private void HideAnswer()
        {
            // Fade in the answer on the triangle.
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(.2)
            };

            answerText.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
        }
    }

}
