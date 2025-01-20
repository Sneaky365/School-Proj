using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
   
    public partial class GameSpace : Form
     
    {
        public int score;
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();
        public GameSpace()
        {
            InitializeComponent();
            loadCanvas();
            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            this.KeyDown += Form1_KeyDown;
        }
        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        int width = 15;
        int height = 20;
        int[,] DotArray;
        int dotSize = 20;
        private void loadCanvas()
        {

            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);
            pictureBox1.Image = canvasBitmap;
            DotArray = new int[width, height];
        }
        int currentX;
        int currentY;
        public event Action onHomeRequested;
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();
            currentX = 7;
            currentY = -shape.Height;
            return shape;
        }
        private void updateCanvasDotArrayWithCurrentShape()
        {
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        try
                        {
                            DotArray[currentX + i, currentY + j] = 1;
                        }catch(Exception e)
                        {
                            checkIfGameOver();
                            break;
                        }
                        

                        
                    }
                }
            }
        }
        private void checkIfGameOver()
        {
            
            if (currentY < 0)
            {
                timer.Stop();
                DialogResult result = MessageBox.Show("Game Over! Do you wish to restart?", "", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    onHomeRequested?.Invoke();
                    this.Close();
                }
                
            }
        }

        private bool moveShapeIfPossible(int moveDown = 0, int moveSide = 0)
        {
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;
            if (newX < 0 || newX + currentShape.Width > width
                || newY + currentShape.Height > height)
                return false;
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (newY + j > 0 && DotArray[newX + i, newY + j] == 1 && currentShape.Dots[j, i] == 1)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;
        private void Timer_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            if (!isMoveSuccess)
            {
                canvasBitmap = new Bitmap(workingBitmap);

                updateCanvasDotArrayWithCurrentShape();

                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowsAndUpdateScore();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var verticalMove = 0;
            var horizontalMove = 0;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    verticalMove--;
                    break;

                case Keys.Right:
                    verticalMove++;
                    break;

                case Keys.Down:
                    horizontalMove++;
                    break;

                case Keys.Up:
                    currentShape.turn();
                    break;
                default:
                    return;
            }

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            if (!isMoveSuccess && e.KeyCode == Keys.Up)
                currentShape.rollback();
        }

        private void drawShape()
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                        workingGraphics.FillRectangle(Brushes.Black, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;
        }
        
        public void clearFilledRowsAndUpdateScore()
        {
            for (int i = 0; i < height; i++)
            {
                int j;
                for (j = width - 1; j >= 0; j--)
                {
                    if (DotArray[j, i] == 0)
                        break;
                }

                if (j == -1)
                {
                    score++;
                    label1.Text = "Score: " + score;
                    label2.Text = "Level: " + score / 10;
                    timer.Interval -= 10;

                    for (j = 0; j < width; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            DotArray[j, k] = DotArray[j, k - 1];
                        }

                        DotArray[j, 0] = 0;
                    }
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(
                        DotArray[i, j] == 1 ? Brushes.Black : Brushes.LightGray,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape()
        {
            var shape = getRandomShapeWithCenterAligned();

            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);

            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] == 1 ? Brushes.Black : Brushes.LightGray,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

        private void GameSpace_Load(object sender, EventArgs e)
        {

        }
    }
}
