using Microsoft.VisualBasic;
using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sokoban
{
    public class GameWindow : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();

        public GameWindow(DirectoryInfo imagesDirectory = null)
        {
            gameState = new GameState();
            ClientSize = new Size(
                GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight + GameState.ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;

            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Resources");

            foreach (var e in imagesDirectory.GetFiles("*.bmp"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);

            MakeFrame();
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(Form_PreviewKeyDown);
        }

        private void Form_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
                    e.IsInputKey = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Text = "Sokoban";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
            Game.KeyPressed = e.KeyCode;
            MakeFrame();
        }


        protected override void OnKeyUp(KeyEventArgs e)
        {
            Invalidate();
            pressedKeys.Remove(e.KeyCode);
            Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, GameState.ElementSize);
            e.Graphics.FillRectangle(
                Brushes.Khaki, 0, 0, GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight);
            foreach (var a in gameState.Animations)
            {
                e.Graphics.DrawImage(bitmaps[a.Entity.ImageFileName], a.Location);
                e.Graphics.DrawImage(bitmaps[a.Entity.ImageFileName], a.Location);
            }
            e.Graphics.ResetTransform();
            e.Graphics.DrawString("Moves: " + Game.MovesCount.ToString(), new Font("Arial", 16), Brushes.Black, 0, 0);
            if (Game.LevelCleared)
                this.Close();
        }

        private void MakeFrame()
        {
            gameState.BeginAct();
            foreach (var el in gameState.Animations)
                el.Location = new Point(el.Location.X + 26 * el.Command.DeltaX, el.Location.Y + 26 * el.Command.DeltaY);
            gameState.EndAct();
            Invalidate();
        }
    } 
}