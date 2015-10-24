using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace NFA_DFA
{
    public partial class DrawGraph : Form
    {
        public DrawGraph()
        {
            InitializeComponent();
        }

        #region Var

        private Microsoft.VisualBasic.PowerPacks.LineShape[] Line; // 4 line for ever vector Arrow
        public int CounterLine = 0; // for save index of Line Array to continue create vector arrow
        private Microsoft.VisualBasic.PowerPacks.OvalShape[] Ellipse; // for Alphabet Word by FillColor
        private Microsoft.VisualBasic.PowerPacks.OvalShape[] Oval; // for Vertex or FinalVertex;
        private Microsoft.VisualBasic.PowerPacks.OvalShape[] BeiziLoop; // for Vector LoopSelf 
        public int numBeiziLoop = 0;
        private Label[] lblAlphabetName; // for Alphabet Word
        private Label[] lblVertexName; // for Vertex Name
        private Color[] VectorColor; // for Arrow and FillColor
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer PointShape; // for Add All shape to page view
        #endregion

        private void DrawGraph_Load(object sender, EventArgs e)
        {
            PointShape = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            // Array Length is Number of Vector
            Line = new Microsoft.VisualBasic.PowerPacks.LineShape[(FirstForm.strAlphabetWord.Length - 1) * (FirstForm.NumberOfNewVertex) * 4];
            // Array Length is Number of Alphabet Words
            Ellipse = new Microsoft.VisualBasic.PowerPacks.OvalShape[FirstForm.strAlphabetWord.Length - 1]; 
            // Array Length is NumberOfNewVertex + Number Of FinalVertex
            Oval = new Microsoft.VisualBasic.PowerPacks.OvalShape[FirstForm.NumberOfNewVertex + FirstForm.FinalVertexDFA.Count]; 
            lblAlphabetName = new Label[FirstForm.strAlphabetWord.Length - 1]; // Array Length is Number of Alphabet Words
            lblVertexName = new Label[FirstForm.NumberOfNewVertex]; // Array Length is NumberOfNewVertex
            // BeiziLoop Array Length is  NumberOfNewVertex * (strAlphabetWord.Length - 1)
            BeiziLoop = new Microsoft.VisualBasic.PowerPacks.OvalShape[FirstForm.NumberOfNewVertex * (FirstForm.strAlphabetWord.Length - 1)];

            // Craete PointShape Object
            this.PointShape.Location = new Point(0, 0);
            this.PointShape.Margin = new System.Windows.Forms.Padding(0);
            this.PointShape.Size = new System.Drawing.Size(3000, 3000);
            this.PointShape.TabIndex = 1;
            this.PointShape.TabStop = false;

            //------------------------------------------------------SOLVE---------------------------------------------------------------------
            DrawVertexCircle();
            DrawFinalVertexCircle();
            RandomyColor(FirstForm.strAlphabetWord.Length - 1);
            DrawAlphabetEllipse();
            DrawAllLine();
            this.Controls.Add(PointShape);
            //--------------------------------------------------------------------------------------------------------------------------------
        }

        public void RandomyColor(int CountArray)
        {
            Random r = new Random();
            VectorColor = new Color[CountArray];
            for (int index = 0, Red, Green, Blue; index < CountArray; index++)
            {
            CreateNewColor: // Label for Loop
                do
                {
                    Red = r.Next(0, 255);
                    Green = r.Next(0, 255);
                    Blue = r.Next(0, 255);
                }
                while (Red == 255 && Green == 255 && Blue == 255); // if Color be White
                for (int i = 0; i < index; i++)
                    if (Color.FromArgb(Red, Green, Blue) == VectorColor[i]) // if Color be Repeated
                        goto CreateNewColor;
                VectorColor[index] = Color.FromArgb(Red, Green, Blue);
            }
        }

        //                        
        //                                      O  
        //                                       \ 
        // (Start Point)O-------------------------O (End Point)     
        //                                       /
        //                                      O
        //
        public void DrawVectorArrow(Point StartPoint, Point EndPoint, Color color) // Draw 4 Line for create a Vector by Arrow
        {
            // Public Info
            // Line1 ========================================================================
            Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Line[CounterLine].BorderColor = color;
            this.Line[CounterLine].BorderWidth = 2;
            this.Line[CounterLine].Enabled = false;
            this.Line[CounterLine].X1 = StartPoint.X;
            this.Line[CounterLine].X2 = EndPoint.X;
            this.Line[CounterLine].Y1 = StartPoint.Y;
            this.Line[CounterLine].Y2 = StartPoint.Y;
            this.PointShape.Shapes.Add(Line[CounterLine]);
            CounterLine++; // go to create other line
            //===============================================================================
            // Line2 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Line[CounterLine].BorderColor = color;
            this.Line[CounterLine].BorderWidth = 2;
            this.Line[CounterLine].Enabled = false;
            this.Line[CounterLine].X1 = EndPoint.X;
            this.Line[CounterLine].X2 = EndPoint.X;
            this.Line[CounterLine].Y1 = StartPoint.Y;
            this.Line[CounterLine].Y2 = EndPoint.Y;
            this.PointShape.Shapes.Add(Line[CounterLine]);
            CounterLine++; // go to create other line
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            // Line1 (Start Point) O-------------------------O
            // Line2                                     O   |   O
            // Line3                                      \  |  /
            // Line4                                       \ | /
            //                                               O
            //                                          (End Point)
            #region DOWN Arrow
            if (StartPoint.Y < EndPoint.Y)
            {
                // Line3 ------------------------------------------------------------------------
                Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
                this.Line[CounterLine].BorderColor = color;
                this.Line[CounterLine].BorderWidth = 2;
                this.Line[CounterLine].Enabled = false;
                this.Line[CounterLine].X1 = EndPoint.X;
                this.Line[CounterLine].X2 = EndPoint.X - 5; // Left
                this.Line[CounterLine].Y1 = EndPoint.Y;
                this.Line[CounterLine].Y2 = EndPoint.Y - 10;
                this.PointShape.Shapes.Add(Line[CounterLine]);
                CounterLine++; // go to create other line
                //-------------------------------------------------------------------------------
                // Line4 ************************************************************************
                Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
                this.Line[CounterLine].BorderColor = color;
                this.Line[CounterLine].BorderWidth = 2;
                this.Line[CounterLine].Enabled = false;
                this.Line[CounterLine].X1 = EndPoint.X;
                this.Line[CounterLine].X2 = EndPoint.X + 5; // Right
                this.Line[CounterLine].Y1 = EndPoint.Y;
                this.Line[CounterLine].Y2 = EndPoint.Y - 10;
                this.PointShape.Shapes.Add(Line[CounterLine]);
                CounterLine++; // go to create other line
                //*******************************************************************************
            }
            #endregion

            //        (End Point)
            //             O
            // Line1     / | \
            // Line2    /  |  \
            // Line3   O   |   O
            // Line4       O-------------------------O (Start Point)
            #region UP Arrow
            else 
            {
                // Line3 ------------------------------------------------------------------------
                Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
                this.Line[CounterLine].BorderColor = color;
                this.Line[CounterLine].BorderWidth = 2;
                this.Line[CounterLine].Enabled = false;
                this.Line[CounterLine].X1 = EndPoint.X;
                this.Line[CounterLine].X2 = EndPoint.X - 5; // Left
                this.Line[CounterLine].Y1 = EndPoint.Y;
                this.Line[CounterLine].Y2 = EndPoint.Y + 10;
                this.PointShape.Shapes.Add(Line[CounterLine]);
                CounterLine++; // go to create other line
                //-------------------------------------------------------------------------------
                // Line4 ************************************************************************
                Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.Line[CounterLine].AccessibleRole = System.Windows.Forms.AccessibleRole.None;
                this.Line[CounterLine].BorderColor = color;
                this.Line[CounterLine].BorderWidth = 2;
                this.Line[CounterLine].Enabled = false;
                this.Line[CounterLine].X1 = EndPoint.X;
                this.Line[CounterLine].X2 = EndPoint.X + 5; // Right
                this.Line[CounterLine].Y1 = EndPoint.Y;
                this.Line[CounterLine].Y2 = EndPoint.Y + 10;
                this.PointShape.Shapes.Add(Line[CounterLine]);
                CounterLine++; // go to create other line
                //*******************************************************************************
            }
            #endregion
        }

        public void DrawVertexCircle()
        {
            for (int i = 0; i < FirstForm.NumberOfNewVertex; i++)
            {
                // Create Vertex Circle by Radiuse 25 , <-----> (50)
                this.Oval[i] = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                this.Oval[i].BorderWidth = 2;
                this.Oval[i].Location = new System.Drawing.Point(70 + (i * 70), 70 + (i * 70));
                this.Oval[i].Size = new System.Drawing.Size(50, 50);
                this.PointShape.Shapes.Add(Oval[i]);

                // Create Label Vertex Name into Vertex Circle
                this.lblVertexName[i] = new Label();
                this.lblVertexName[i].AutoSize = true;
                this.lblVertexName[i].Location = new System.Drawing.Point(82 + (70 * i), 87 + (70 * i));
                this.lblVertexName[i].Size = new System.Drawing.Size(29, 17);
                this.lblVertexName[i].Text = "q" + i.ToString();
                this.lblVertexName[i].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.lblVertexName[i].UseCompatibleTextRendering = true;
                this.Controls.Add(lblVertexName[i]);
            }
        }

        public void DrawFinalVertexCircle()
        {
            int counter = FirstForm.NumberOfNewVertex;
            foreach (int FinalQ in FirstForm.FinalVertexDFA)
            {
                this.Oval[counter] = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                this.Oval[counter].Enabled = false;
                this.Oval[counter].Location = new System.Drawing.Point(75 + (FinalQ * 70), 75 + (FinalQ * 70));
                this.Oval[counter].Size = new System.Drawing.Size(40, 40);
                this.PointShape.Shapes.Add(Oval[counter]);
                counter++;
            }
        }

        private void DrawAlphabetEllipse()
        {
            for (int i = 0; i < FirstForm.strAlphabetWord.Length - 1; i++)
            {
                // create Ellipse by FillColor
                this.Ellipse[i] = new Microsoft.VisualBasic.PowerPacks.OvalShape();
                this.Ellipse[i].BorderColor = VectorColor[i];
                this.Ellipse[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.Ellipse[i].FillColor = VectorColor[i];
                this.Ellipse[i].FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
                this.Ellipse[i].Location = new System.Drawing.Point(118 + (i * 77), 9);
                this.Ellipse[i].Size = new System.Drawing.Size(20, 20);
                PointShape.Shapes.Add(Ellipse[i]);

                // Create lblAlphabetName
                this.lblAlphabetName[i] = new Label();
                this.lblAlphabetName[i].AutoSize = true;
                this.lblAlphabetName[i].FlatStyle = System.Windows.Forms.FlatStyle.System;
                this.lblAlphabetName[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                this.lblAlphabetName[i].Location = new System.Drawing.Point(146 + (i * 77), 11);
                this.lblAlphabetName[i].Size = new System.Drawing.Size(17, 16);
                this.lblAlphabetName[i].Text = FirstForm.strAlphabetWord[i];
                this.lblAlphabetName[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.lblAlphabetName[i].ForeColor = VectorColor[i];
                this.Controls.Add(lblAlphabetName[i]);   
            }
        }

        private Point FindFreeLoc(Point Loc, string Arrow) // Search or Check the Point Location by Other Line Locate
        {
            LOOP:
            for (int i = 0; i < CounterLine; i++)
            {
                Point P1 = new Point(Line[i].X1, Line[i].Y1);
                Point P2 = new Point(Line[i].X2, Line[i].Y2);
                if(Loc == P1 || Loc == P2)
                    switch (Arrow)
                    {
                        case "UP": 
                            { 
                                Loc.X += 5;  
                                goto LOOP;
                            }
                        case "DOWN":
                            {
                                Loc.X -= 5;
                                goto LOOP;
                            }
                        case "LEFT":
                            {
                                Loc.Y -= 5;
                                goto LOOP;
                            }
                        case "RIGHT":
                            {
                                Loc.Y += 5;
                                goto LOOP;
                            }
                        default: return Loc;
                    }
            }
            return Loc;
        }

        public void DrawAllLine()
        {
            for (int i = 0; i < FirstForm.NumberOfNewVertex; i++)
                for (int j = 0; j < FirstForm.strAlphabetWord.Length - 1; j++)
                {
                    if (i < FirstForm.dfaMatris2D[i, j]) // Q1 < Q2 then check RIGHT & UP
                    {
                        Point Q1 = new Point(120 + (i * 70), 95 + (i * 70));
                        Q1 = FindFreeLoc(Q1, "RIGHT");
                        Point Q2 = new Point(95 + (FirstForm.dfaMatris2D[i, j] * 70), 70 + (FirstForm.dfaMatris2D[i, j] * 70));
                        Q2 = FindFreeLoc(Q2, "UP");
                        DrawVectorArrow(Q1, Q2, VectorColor[j]);
                    }
                    else if (i > FirstForm.dfaMatris2D[i, j]) // Q1 > Q2 then check LEFT & DOWN
                    {
                        Point Q1 = new Point(70 + (i * 70), 95 + (i * 70));
                        Q1 = FindFreeLoc(Q1, "LEFT");
                        Point Q2 = new Point(95 + (FirstForm.dfaMatris2D[i, j] * 70), 120 + (FirstForm.dfaMatris2D[i, j] * 70));
                        Q2 = FindFreeLoc(Q2, "DOWN");
                        DrawVectorArrow(Q1, Q2, VectorColor[j]);
                    }
                    else  // Q1 == Q2 create Loop line for self
                    {
                        DrawLoopSelf(VectorColor[j], FindFreeLoopSelf(i));
                    }
                }
        }

        private Point FindFreeLoopSelf(int Vertex) // Search Any Beizi Loop Self in every Vertex for find fress space
        {
            Point Q = new Point(64 + (Vertex * 70), 50 + (Vertex * 70));
            LoopFor:
            for (int i = 0; i < numBeiziLoop; i++)
            {
                if (BeiziLoop[i].Location == Q)
                {
                    Q.X += 5;
                    Q.Y -= 5;
                    goto LoopFor;
                }
            }
            return Q;
        }

        public void DrawLoopSelf(Color color, Point Q)
        {
            // Create BeiziLoop
            this.BeiziLoop[numBeiziLoop] = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.BeiziLoop[numBeiziLoop].Location = Q;
            this.BeiziLoop[numBeiziLoop].Size = new System.Drawing.Size(17, 29);
            this.BeiziLoop[numBeiziLoop].BorderColor = color;
            this.PointShape.Shapes.Add(BeiziLoop[numBeiziLoop]);            
            
            // Create Right Arrow of Beizi
            this.Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Line[CounterLine].BorderColor = color;
            this.Line[CounterLine].X1 = BeiziLoop[numBeiziLoop].Location.X + 8;
            this.Line[CounterLine].X2 = BeiziLoop[numBeiziLoop].Location.X + 6;
            this.Line[CounterLine].Y1 = BeiziLoop[numBeiziLoop].Location.Y + 20;
            this.Line[CounterLine].Y2 = BeiziLoop[numBeiziLoop].Location.Y + 28;
            this.PointShape.Shapes.Add(Line[CounterLine]);
            CounterLine++;

            // Create Left Arrow of Beizi
            this.Line[CounterLine] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Line[CounterLine].BorderColor = color;
            this.Line[CounterLine].X1 = BeiziLoop[numBeiziLoop].Location.X - 3;
            this.Line[CounterLine].X2 = BeiziLoop[numBeiziLoop].Location.X + 6;
            this.Line[CounterLine].Y1 = BeiziLoop[numBeiziLoop].Location.Y + 26;
            this.Line[CounterLine].Y2 = BeiziLoop[numBeiziLoop].Location.Y + 29;
            this.PointShape.Shapes.Add(Line[CounterLine]);
            CounterLine++;
           
            numBeiziLoop++;
        }
    }
}
