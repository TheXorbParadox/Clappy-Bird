using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        // A simple flappy bird clone

        int pipeSpeed = 8; // Pipes speed
        int gravity = 5; // Gravity
        int score; // Score

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            // The controls and their functions

            flappyBird.Top += gravity; // Gravity
            pipeDown.Left -= pipeSpeed; // Bottom pipe goes left
            pipeTop.Left -= pipeSpeed; // Top pipe goes left
            ground.Left -= pipeSpeed; // Ground goes left

            scoreText.Text = "Score: " + score; // Counts the score 

            if(pipeDown.Left < -120) // If the bottom pipe is out of window
            {
                pipeDown.Left = 400; // It creates a new pipe
                score++; // Ads 1 score
            }
            if(pipeTop.Left < -180) // If the Top pipe is out of window
            {
                pipeTop.Left = 500; // It creates a new pipe
                score++; // Ads another score
            }
            if(ground.Left < -8) // If the ground is out of window
            {
                ground.Left = 8; // Creates a new ground
            }
            if(flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) || //If bird interacts with bottom pipe 
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || //Or the Top pipe
               flappyBird.Bounds.IntersectsWith(ground.Bounds)) //or the ground
            {
                endGame(); // Game ends
            }

            if(score > 5) //If score is greater than 5
            {
                pipeSpeed = 10; // then increase the pipe speed
            }

            if(flappyBird.Top < -25) // If the bird goes to high or out of bound
            {
                endGame(); // end the game
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) // If "space" button is pressed/hold
            {
                gravity = -5; // The bird starts to rise 
            }

        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // If the user doesn't press the "space" button
            {
                gravity = 5; // The bird starts to fall because of gravity
            }
        }

        private void endGame() // When the game ends
        {
            gameTimer.Stop(); // Game timer stops
            scoreText.Text += " Game over!!"; // And it prints out "game over"
        }
    }
}
