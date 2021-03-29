using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saper_form {
    public partial class Form1 : Form {

        private Game game;
        private int MineCount;
        private int CountCellX;
        private int CountCellY;
        private bool IsWin;

        public Form1() {
            InitializeComponent();

            //
            MineCount = 15;
            CountCellX = 16;
            CountCellY = 16;
            //

            SetArea(75, 75, CountCellX, CountCellY);

            game = new Game(Controls.OfType<Button>().Where(a => a.Size == new Size(30, 30)).ToArray(), CountCellX, CountCellY, MineCount, label1);
            game.GameOver += Game_GameOver;
            game.SetRandomMine(MineCount);
            label1.Text = $"ОСТАЛОСЬ МИН: {MineCount}";
        }

        private void SetArea(int StartPositionX, int StartPositionY, int X, int Y) {

            for (int k = 0; k < Y; k++) {
                for (int z = 1; z <= X; z++) {
                    Button btn = new Button();
                    btn.Name = $"btn{k * CountCellX + z}";
                    btn.Location = new Point(StartPositionX, StartPositionY);
                    btn.Size = new Size(30, 30);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.DarkSlateGray;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("AlphaSmart 3000;", 15.75f, FontStyle.Regular);
                    btn.MouseDown += btn_MouseDown;
                    Controls.Add(btn);
                    StartPositionX += 31;
                }
                StartPositionY += 31;
                StartPositionX = 75;
            }
        }

        private void Game_GameOver(object sender, bool IsWin) {
            this.IsWin = IsWin;
            ChangeSize(true);
        }

        private async void ChangeSize(bool IsExpand) {
            if (Size.Height == 670 && IsExpand || Size.Height == 710 && !IsExpand) {

                label2.ForeColor = IsWin ? Color.GreenYellow : Color.Red;
                label2.Text = IsWin ? "ПОБЕДА!" : "ВЫ ВЗОРВАЛИСЬ!";

                for (int i = 0; i < 20; i++, await Task.Delay(1))
                    Size = new Size(Size.Width, Size.Height + ((IsExpand) ? 2 : -2));
            }
        }

        private async void NewGame(object sender, EventArgs e) {
            game.IsStopAnimation = true;
            await Task.Delay(3);
            if (game.IsGameAnimation)
                return;

            ChangeSize(false);

            game.IsGameAnimation = true;
            game.ResetMine(MineCount);
            game.SetRandomMine(MineCount);
            game.IsGameAnimation = false;
            game.IsStopAnimation = false;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e) {
            if (game.IsGameAnimation)
                return;

            if (e.Button == MouseButtons.Left)
                game.ClickCell(new Cage(sender as Button, 16, 16));
            else if (e.Button == MouseButtons.Right)
                game.ClickCheck(new Cage(sender as Button, 16, 16));
        }

       
    }
}
