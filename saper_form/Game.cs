using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saper_form {
    class Game {

        public Cage[] CellCage;
        public Cage[] RandomCages;
        public int CountCellX;
        public int CountCellY;
        public int MineCount;
        private int MineCountStatic;
        private int mineCount;
        private bool IsGameOver;
        private Label label;
        private Random rnd;
        public bool IsGameAnimation = false;
        public bool IsStopAnimation = false;

        public event EventHandler<bool> GameOver;

        private void OnGameOver(object sender, bool e) {
            GameOver?.Invoke(sender, e);
        }

        public Game(Button[] Cell, int CountCellX, int CountCellY, int MineCount, Label label) {
            this.CountCellX = CountCellX;
            this.CountCellY = CountCellY;
            this.MineCount = MineCount;
            CellCage = new Cage[Cell.Length];
            this.label = label;
            for (int i = 0; i < CellCage.Length; i++)
                CellCage[i] = new Cage(Cell[i], CountCellX, CountCellY);
        }

        public void SetRandomMine(int Count) {
            MineCountStatic = Count;
            mineCount = Count;

            rnd = new Random();
            RandomCages = CellCage.OrderBy(x => rnd.Next()).ToArray();

            for (int i = 0; i < Count; i++)
                CellCage.Where(a => a.Number == RandomCages[i].Number).First().IsMine = true;
        }

        public void ResetMine(int MineCount) {
            foreach (Cage cageRand in RandomCages) {
                Cage cage = CellCage.Where(a => a.Number == cageRand.Number).First();
                cage.Text = String.Empty;
                cage.BackColor = Color.DarkSlateGray;
                cage.ForeColor = Color.White;
                cage.IsMine = false;
                cage.IsClicked = false;
            }
            MineCountStatic = MineCount;
            mineCount = MineCountStatic;
            label.Text = $"ОСТАЛОСЬ МИН: {MineCountStatic}";
            IsGameOver = false;
        }

        public async void ClickCell(Cage cellCage) {
            Cage MainCage = CellCage.Where(a => a.Number == cellCage.Number).First();

            if (IsGameOver)
                return;

            if (MainCage.BackColor == Color.Yellow) {
                if (MainCage.Text == "✘")
                    mineCount++;
                MainCage.Text = String.Empty;
                label.Text = $"ОСТАЛОСЬ МИН: {mineCount}";
            }

            if (MainCage.IsMine) {
                MineOpen(MainCage);
                IsGameOver = true;
                OnGameOver(this, false);
                return;
            }

            MainCage.BackColor = Color.FromArgb(35, 59, 59);
            MainCage.IsClicked = true;
            await Task.Delay(10);

            int MineCount = CountMineAroundCage(MainCage);
            if (MineCount == 0) {
                foreach (int neighborNumber in MainCage.Neighbour) {
                    Cage cage = CellCage.Where(a => a.Number == neighborNumber).First();
                    int MineCountNeigh = CountMineAroundCage(cage);

                    if (cage.BackColor == Color.Yellow) {
                        if (cage.Text == "✘")
                            mineCount++;
                        cage.Text = String.Empty;
                        label.Text = $"ОСТАЛОСЬ МИН: {mineCount}";
                    }

                    if (MineCountNeigh != 0) {
                        cage.ForeColor = cage.ColorDictionary[MineCountNeigh];
                        cage.BackColor = Color.FromArgb(35, 59, 59);
                        cage.Text = MineCountNeigh.ToString();
                    }
                    else if (!cage.IsClicked) {
                        ClickCell(cage);
                    }
                }
            }
            else {
                MainCage.ForeColor = MainCage.ColorDictionary[MineCount];
                MainCage.Text = MineCount.ToString();
            }

            int CellWithoutMine = CellCage.Length - MineCountStatic;
            int CountColorCorrect = 0;
            foreach (Cage cage in CellCage)
                if (cage.BackColor == Color.FromArgb(35, 59, 59))
                    CountColorCorrect++;
            if (CountColorCorrect == CellWithoutMine && !IsGameOver) {
                IsGameOver = true;
                label.Text = "ОСТАЛОСЬ МИН: 0";
                OnGameOver(this, true);
            }
        }

        private async void MineOpen(Cage FirstCage) {
            IsGameAnimation = true;
            if (FirstCage.Text != "✘") {
                FirstCage.BackColor = Color.Red;
                FirstCage.ForeColor = Color.Black;
                FirstCage.Text = "✘";
            }
            await Task.Delay(new Random().Next(2, 10));
            if (IsStopAnimation)
                goto Here;
            foreach (Cage cage in CellCage) {
                if (cage.BackColor == Color.FromArgb(35, 59, 59))
                    continue;
                if (cage.Text != "✘" && cage.IsMine) {
                    cage.BackColor = Color.Red;
                    cage.ForeColor = Color.Black;
                    cage.Text = "✘";
                }
                else if (!cage.IsMine && cage.Text == "✘") {
                    cage.BackColor = Color.DarkSlateGray;
                    cage.Text = String.Empty;
                    mineCount++;
                }
                await Task.Delay(new Random().Next(2, 10));
                label.Text = $"ПРАВИЛЬНЫХ МИН: {MineCount - mineCount} / {MineCount}";
                if (IsStopAnimation)
                    break;
            }
        Here:
            IsGameAnimation = false;
        }

        public void ClickCheck(Cage cellCage) {
            Cage MainCage = CellCage.Where(a => a.Number == cellCage.Number).First();

            if (!(cellCage.BackColor == Color.FromArgb(35, 59, 59) || IsGameOver)) {
                if (MainCage.BackColor == Color.Yellow && MainCage.Text == "?") {
                    MainCage.BackColor = Color.DarkSlateGray;
                    MainCage.ForeColor = Color.White;
                    MainCage.Text = String.Empty;
                }
                else {
                    if (MainCage.Text == "✘") {
                        mineCount++;
                        MainCage.BackColor = Color.Yellow;
                        MainCage.ForeColor = Color.Black;
                        MainCage.Text = "?";
                    }
                    else {
                        mineCount--;
                        MainCage.BackColor = Color.Yellow;
                        MainCage.ForeColor = Color.Black;
                        MainCage.Text = "✘";
                    }
                }
                label.Text = $"ОСТАЛОСЬ МИН: {mineCount}";
            }
        }

        private int CountMineAroundCage(Cage cage) {
            int MineCount = 0;
            foreach (int num in cage.Neighbour)
                if (CellCage.Where(a => a.Number == num).First().IsMine)
                    MineCount++;
            return MineCount;
        }
    }
}
