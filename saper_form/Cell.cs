using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace saper_form {
    class Cage {

        private Button CellCage;
        public int Number;
        public bool IsMine;
        public bool IsClicked;
        public List<int> Neighbour;
        public String Text {
            get {
                return CellCage.Text;
            }
            set {
                CellCage.Text = value;
            }
        }

        public Color BackColor {
            get {
                return CellCage.BackColor;
            }
            set {
                CellCage.BackColor = value;
            }
        }

        public Color ForeColor {
            get {
                return CellCage.ForeColor;
            }
            set {
                CellCage.ForeColor = value;
            }
        }

        public Dictionary<int, Color> ColorDictionary = new Dictionary<int, Color>() 
        {
            { 1, Color.SpringGreen },
            { 2, Color.OrangeRed },
            { 3, Color.Magenta},
            { 4, Color.DeepSkyBlue },
            { 5, Color.Chocolate },
            { 6, Color.Orange },
            { 7, Color.SkyBlue },
            { 8, Color.Red }
        };

        public Cage(Button Cage, int CountCellX, int CountCellY) {
            CellCage = Cage;
            Number = int.Parse(Cage.Name.Remove(0, 3));
            Neighbour = new List<int>();

            if (Number > CountCellX) {
                if (Number % CountCellX != 1) {
                    Neighbour.Add(Number - CountCellX);
                    Neighbour.Add(Number - CountCellX - 1);

                    Neighbour.Add(Number - 1);

                    if (Number != CountCellX * CountCellY)
                        if (Number / CountCellX != CountCellY - 1 || Number % CountCellX == 0) {
                            Neighbour.Add(Number + CountCellX - 1);
                            Neighbour.Add(Number + CountCellX);
                        }

                    if (Number % CountCellX != 0) {
                        Neighbour.Add(Number - CountCellX + 1);
                        Neighbour.Add(Number + 1);
                        if (Number / CountCellX != CountCellY - 1)
                            Neighbour.Add(Number + CountCellX + 1);
                    }
                }
                else {
                    Neighbour.Add(Number - CountCellX);
                    Neighbour.Add(Number - CountCellX + 1);

                    Neighbour.Add(Number + 1);

                    if (Number / CountCellX != CountCellY - 1) {
                        Neighbour.Add(Number + CountCellX);
                        Neighbour.Add(Number + CountCellX + 1);
                    }
                }
            }
            else {
                if (Number != 1) {
                    Neighbour.Add(Number + CountCellX);
                    Neighbour.Add(Number + CountCellX - 1);

                    Neighbour.Add(Number - 1);

                    if (Number % CountCellX != 0) {
                        Neighbour.Add(Number + 1);
                        Neighbour.Add(Number + CountCellX + 1);
                    }
                }
                else {
                    Neighbour.Add(Number + 1);
                    Neighbour.Add(Number + CountCellX);
                    Neighbour.Add(Number + CountCellX + 1);
                }
            }
        }

    }
}
