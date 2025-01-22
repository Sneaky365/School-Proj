using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Game
{
   
    public partial class GameSpace : Form
     
    {
        public int maxScore = 0;
        public int score = 0;
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
            pictureBox1.Height = height * dotSize;
            pictureBox1.Width = width * dotSize;
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.FillRectangle(Brushes.DarkSlateGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);
            drawGrid(canvasGraphics);
            pictureBox1.Image = canvasBitmap;
            DotArray = new int[width, height];
        }
        private void drawGrid(Graphics g)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int cellX = x * dotSize;
                    int cellY = y * dotSize;

                    g.DrawRectangle(Pens.Gray, cellX, cellY, dotSize, dotSize);
                }
            }
        }
        private void updateCanvas()
        {
            canvasGraphics.FillRectangle(Brushes.DarkSlateGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            drawGrid(canvasGraphics);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (DotArray[x, y] == 1)
                    {
                        canvasGraphics.FillRectangle(Brushes.Black, x * dotSize, y * dotSize, dotSize, dotSize);

                        canvasGraphics.DrawRectangle(Pens.Black, x * dotSize, y * dotSize, dotSize, dotSize);
                    }
                }
            }
            pictureBox1.Image = canvasBitmap;
        }
        int currentX;
        int currentY;
        public event Action<int> onHomeRequested;

        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();
            currentX = 7;
            currentY = -shape.Height + 1;
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
                            
                        }catch (Exception e)
                        {
                            checkIfGameOver();
                            break;
                        }
                        
                    }
                }
            }
            updateCanvas();
        }
        private void checkIfGameOver()
        {
            
            if (currentY < 0)
            {
                timer.Stop();
                DialogResult result = MessageBox.Show("Game Over! Do you wish to restart?", "", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    this.Close();
                    GameSpace gs = new GameSpace();
                    if(score > maxScore)
                    {
                        maxScore = score;
                    }
                    gs.Show();
                }
                else
                {
                    onHomeRequested?.Invoke(maxScore);
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
            canHold = true;
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

                case Keys.Space:
                    while (moveShapeIfPossible(1, 0)) { }
                    break;

                case Keys.C:
                    holdShape();
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
            updateCanvas();
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
                    if (shape.Dots[i, j] == 1)
                    {
                        nextShapeGraphics.FillRectangle(
                            shape.Dots[i, j] == 1 ? Brushes.Black : Brushes.LightGray,
                            (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                        nextShapeGraphics.DrawRectangle(
                            Pens.White,
                            (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                    }
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }
        private Shape heldShape = null;
        private bool canHold = true;
        private void holdShape()
        {
            if (!canHold) return;
            canHold = false;

            if (heldShape == null)
            {
                heldShape = currentShape;
                currentShape = getNextShape();
            }
            else
            {
                var temp = currentShape;
                currentShape = heldShape;
                heldShape = temp;
            }
            currentX = (width - currentShape.Width) / 2;
            currentY = 0;
            drawHoldShape();
            updateCanvas();
        }
        Bitmap holdShapeBitmap;
        Graphics holdShapeGraphics;
        private void drawHoldShape()
        {
            if (heldShape != null)
            {
                holdShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
                holdShapeGraphics = Graphics.FromImage(holdShapeBitmap);

                holdShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, holdShapeBitmap.Width, holdShapeBitmap.Height);

                var startX = (6 - heldShape.Width) / 2;
                var startY = (6 - heldShape.Height) / 2;

                for (int i = 0; i < heldShape.Height; i++)
                {
                    for (int j = 0; j < heldShape.Width; j++)
                    {
                        if (heldShape.Dots[i, j] == 1)
                        {
                            holdShapeGraphics.FillRectangle(
                                Brushes.Black,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );

                            holdShapeGraphics.DrawRectangle(
                                Pens.White,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                        }
                    }
                }

                pictureBox3.Size = holdShapeBitmap.Size; 
                pictureBox3.Image = holdShapeBitmap;

                holdShapeGraphics.Dispose();
            }
            else
            {
                pictureBox3.Image = null;
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
