using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace NFA_DFA
{
    public partial class FirstForm : Form
    {
        #region Global Varibale
        // for Read File true 
        public static bool FileOK = false;
        // nfaMatris3D[NumberOfVertex][NumberOfAlphabetWords + 1][NumberOfVertex]
        public static Boolean[, ,] nfaMatris3D;
        // dfaMatris2D[NumberOfNewVertex][NumberOfAlphabetWords-λ] = NumberOfNewVertex
        public static int[,] dfaMatris2D;
        public static bool[,] dfaVertexName2D;
        //Alphabet Words Dynamical Varibale ===============================================
        public ArrayList AlphabetName = new ArrayList();
        public static string[] strAlphabetWord;
        public TextBox[] txtAlphabetWord;
        public Label[] lblAlphabetCama; // ","
        //===========================================================================
        //Number Of Vertex **********************************************************
        public static int NumberOfVertex = 0;
        public static int NumberOfNewVertex = 1;
        //***************************************************************************
        //Final Vertex Dynamical Varibale -------------------------------------------
        public ArrayList FinalVertexName = new ArrayList();
        public Label[] lblFinalVertexAculad; // "{q"
        public Label[] lblFinalVertexCama; // ","
        public Label[] lblFinalVertexEndAculad; // "}"
        public NumericUpDown[] numUPFinalVertex;
        public static int[] FinalVertexNFA;
        public static ArrayList FinalVertexDFA = new ArrayList();
        //---------------------------------------------------------------------------
        //Vector Information Dynamical Varibale +++++++++++++++++++++++++++++++++++++
        public Label[] lblVectorBeginningQ; // "q"
        public Label[] lblVectorDestinationQ; // "q"
        public Label[] lblVectorArrow; // "------->"
        public ComboBox[] cmbVectorBeginning;
        public ComboBox[] cmbVectorDestination;
        public TextBox[] txtVector;
        public ArrayList VectorBeginning = new ArrayList();
        public ArrayList VectorDestination = new ArrayList();
        public ArrayList VectorArrow = new ArrayList();
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Print Varibale
        public static string[] PrintDFA;

        #endregion

        public FirstForm()
        {
            InitializeComponent();
        }

        #region Solve

        bool FirstRun = false;

        private void Solve()
        {
            ClearAllLanda();
            dfaMatris2D = new int[NumberOfNewVertex, strAlphabetWord.Length - 1];
            for (int i = 0; i < NumberOfNewVertex; i++) // Cleanup dfaMatris2D by Number '-1'
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                    dfaMatris2D[i, j] = -1;
            
            dfaVertexName2D = new bool[NumberOfNewVertex, NumberOfVertex + 1];
            
            // Define the info of dfaVertexName2D[0,NameQ0] +++++++++++++++++++++++++++++++++++++++
            dfaVertexName2D[0, 0] = true; // it mean is q0 name is 0
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                    SearchNewVertex(i, j);

            Trapping(); // Find '-1' and create Trap or NewVertex for Self-Loop 
            DefineFinalVertexDFA(); // Define Final Vertex in DFA Matris2D
            PrintToFile();

            FirstRun = true;
            btnShowGraph.Enabled = true;
            btnExport.Enabled = true;
            btnImport.Enabled = false;
            ShownAnswer Answer = new ShownAnswer();
            Answer.ShowDialog();
        }

        // Define Final Vertex in DFA Matris2D
        private void DefineFinalVertexDFA()
        {
            FinalVertexDFA.Clear();
            for (int i = 0; i < FinalVertexNFA.Length; i++) // for enum in 'int FinalVertexNFA[]' 
                for (int j = 0; j < NumberOfNewVertex; j++) // for Search and enum in dfaVertexName2D[j,int[strAlphabet]]
                    if (dfaVertexName2D[j, FinalVertexNFA[i]])
                        if (!FinalVertexDFA.Contains(j))
                            FinalVertexDFA.Add(j);
        }

        // Find '-1' and create Trap or NewVertex for Self-Loop 
        private void Trapping()
        {
            int VirtualNum = NumberOfNewVertex;
            Boolean Trapping = false;
            for (int i = 0; i < VirtualNum; i++)
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                    if (dfaMatris2D[i, j] == -1)
                        if (Trapping)
                        {
                            dfaMatris2D[i, j] = NumberOfNewVertex - 1;
                        }
                        else
                        {
                            Trapping = true;
                            increaseArrays();
                            dfaMatris2D[i, j] = NumberOfNewVertex - 1;
                            // Create Loop by All Alphabet Words Arrow to Self Vertex
                            for (int L = 0; L < strAlphabetWord.Length - 1; L++)
                                dfaMatris2D[NumberOfNewVertex - 1, L] = NumberOfNewVertex - 1;
                        }
        }

        private void PrintToFile()
        {
            //Print DFA in File-------------------------------------------------------------------------------------------------
            PrintDFA = new string[(NumberOfNewVertex * (strAlphabetWord.Length - 1)) + 4];
            int index2 = 0;
            // Print Alphabet Word at First Line ----> Print[0]
            PrintDFA[index2] = "∑ = {";
            for (int i = 0; i < strAlphabetWord.Length - 2; i++)
                PrintDFA[index2] += strAlphabetWord[i] + ", ";
            PrintDFA[index2] += strAlphabetWord[strAlphabetWord.Length - 2];
            PrintDFA[index2] += "}";

            // Print New Vertex Name at Line 2 ----> Print[1]
            index2++;
            PrintDFA[index2] = "Vertex Name = {q0";
            for (int i = 1; i < NumberOfNewVertex; i++)
                PrintDFA[index2] += ", q" + i.ToString();
            PrintDFA[index2] += "}";

            // Print Final Vertex Name at Line 3 ----> Print[2]
            index2++;
            PrintDFA[index2] = "Final Vertex Name = {";
            int Counter = FinalVertexDFA.Count;
            foreach (int FinalV in FinalVertexDFA)
            {
                if (Counter == 1) //Last Home of FinalVertexDFA
                {
                    PrintDFA[index2] += "q" + FinalV.ToString() + "}";
                    break; // foreach Self be breaken and not necessary this "break;" 
                }
                else
                {
                    PrintDFA[index2] += "q" + FinalV.ToString() + " , ";
                    Counter--;
                }
            }
            // Print Vector Between Two Vertex
            index2++;
            PrintDFA[index2] = "All Vector : ";
            index2++;
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                {
                    PrintDFA[index2] = "                    q" + i.ToString() + "  Arrow(" + strAlphabetWord[j] + ")  q" + (dfaMatris2D[i, j]).ToString();
                    index2++;
                }
            //------------------------------------------------------------------------------------------------------------------
        }

        private void FindLanadaInfo(int Q1, int Q2)
        {
            for (int i = 0; i < strAlphabetWord.Length; i++) // for enum AlphabetWord
                for (int j = 0; j < NumberOfVertex; j++) // for enum Vertex
                    if (nfaMatris3D[Q2, i, j]) // The Vector is True
                    {
                        if (i == strAlphabetWord.Length - 1) // Q2 has λ vector
                            FindLanadaInfo(Q1, j);
                        else
                            nfaMatris3D[Q1, i, j] = true;
                    }
        }

        public void ClearAllLanda()
        {
            // Find λ for delete and return vertex's
            for (int i = 0; i <= NumberOfVertex; i++)
                for (int k = 0; k <= NumberOfVertex; k++)
                    if (nfaMatris3D[i, strAlphabetWord.Length - 1, k]) 
                        {
                            nfaMatris3D[i, strAlphabetWord.Length - 1, k] = false;
                            FindLanadaInfo(i, k);
                        }
        }

        private void increaseArrays()
        {
            int[,] matris3d = new int[NumberOfNewVertex, strAlphabetWord.Length - 1];
            bool[,] matris2d = new bool[NumberOfNewVertex, NumberOfVertex + 1];

            // Copy of dfaMatris2D to matris3d
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                        matris3d[i, j] = dfaMatris2D[i, j];
            
            // Copy of dfaVertexName2D to matris2d
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int j = 0; j <= NumberOfVertex; j++)
                    matris2d[i, j] = dfaVertexName2D[i, j];
            
            // increase dfaMatris2D
            dfaMatris2D = new int[NumberOfNewVertex + 1, strAlphabetWord.Length - 1];
            
            //Cleanup dfaMatris2D by Number '-1' آخرین یا جدید ترین خانه های آرایه برابر
            for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                dfaMatris2D[NumberOfNewVertex, j] = -1;
            
            // increase dfaVertexName2D
            dfaVertexName2D = new bool[NumberOfNewVertex + 1, NumberOfVertex + 1];

            // matris3d information Paste to dfaMatris3D
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int j = 0; j < strAlphabetWord.Length - 1; j++)
                        dfaMatris2D[i, j] = matris3d[i, j];

            // matris2d information Paste to dfaVertexName2D
            for (int i = 0; i < NumberOfNewVertex; i++)
                for (int k = 0; k <= NumberOfVertex; k++)
                    dfaVertexName2D[i, k] = matris2d[i, k];

            // increase NumberOfNewVertex
            NumberOfNewVertex += 1;
        }

        private bool Compare2Array(bool[] Q, int index)
        {
            for (int i = 0; i <= NumberOfVertex; i++) 
                if (Q[i] != dfaVertexName2D[index, i]) 
                    return false;
            return true;
        }

        private void SearchNewVertex(int Q, int numArrow)
        {
            bool[] newVertex = new bool[NumberOfVertex + 1]; // for Save New Vertex

            for (int i = 0; i <= NumberOfVertex; i++)
                if (dfaVertexName2D[Q, i]) // Check for new Vertex Name
                    for (int j = 0; j <= NumberOfVertex; j++)
                        if (nfaMatris3D[i, numArrow, j]) // enum for Vertex Neme
                            newVertex[j] = true; // Find and Checked
            // Check this new vertex by another new vertex
            for (int i = 0; i < NumberOfNewVertex; i++) 
                if (Compare2Array(newVertex, i)) // If (True) then the newVertex was Exist in matris
                {
                    dfaMatris2D[Q, numArrow] = i;
                    return;
                }
            // The newVertex in Not Exist in dfaMatris3D so add in Array List
            increaseArrays();
            for (int i = 0; i <= NumberOfVertex; i++)
                if (newVertex[i])
                {
                    dfaVertexName2D[NumberOfNewVertex - 1, i] = true; //Add newVertex to Matrix2D List
                }
            dfaMatris2D[Q, numArrow] = NumberOfNewVertex - 1; // Conjunctive newVertex to Array List and OldnewVertex in dfaMatris3D 
        }
        #endregion

        #region Dynamical Form
        private void FirstForm_Load(object sender, EventArgs e)
        {
            //Disable btnExport and btnShowGraph, because Problem is not Solve.
            btnExport.Enabled = false;
            btnShowGraph.Enabled = false;

            //Alphabet Dynamical Varibale 
            this.txtAlphabetWord = new TextBox[1];
            this.lblAlphabetCama = new Label[1];

            //Final Vertex Dynamical Varibale
            this.lblFinalVertexAculad = new Label[1];
            this.numUPFinalVertex = new NumericUpDown[1];
            this.lblFinalVertexEndAculad = new Label[1];
            this.lblFinalVertexCama = new Label[1];

            //Vector Information Dynamical Varibale
            this.lblVectorBeginningQ = new Label[1];
            this.lblVectorDestinationQ = new Label[1];
            this.lblVectorArrow = new Label[1];
            this.txtVector = new TextBox[1];
            this.cmbVectorBeginning = new ComboBox[1];
            this.cmbVectorDestination = new ComboBox[1];

            //*****************************************************************************************************
            //Create txtAlphabetWord[0] 
            this.txtAlphabetWord[0] = new TextBox();
            this.txtAlphabetWord[0].Location = new Point(157 + lblTextAlphabet.Location.X, 21 + lblTextAlphabet.Location.Y);
            this.txtAlphabetWord[0].Size = new Size(28, 22);
            this.txtAlphabetWord[0].MaxLength = 3;
            this.txtAlphabetWord[0].TextAlign = HorizontalAlignment.Center;
            this.txtAlphabetWord[0].BackColor = Color.NavajoWhite;
            this.txtAlphabetWord[0].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.txtAlphabetWord[0].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.Controls.Add(this.txtAlphabetWord[0]);
            this.Controls.Add(this.lblAlphabetCama[0]);
            lblEndSigma.Location = new Point(lblTextAlphabet.Location.X + 188, lblTextAlphabet.Location.Y + 20);
            //*****************************************************************************************************
            //-----------------------------------------------------------------------------------------------------
            //Create lblFinalVertexAculad[0]
            this.lblFinalVertexAculad[0] = new Label();
            this.lblFinalVertexAculad[0].Font = new Font(lblFinalVertexAculad[0].Font.Name, 12, FontStyle.Bold);
            this.lblFinalVertexAculad[0].Text = "{q";
            this.lblFinalVertexAculad[0].Location = new Point(144 + lblTextFinalVertex.Location.X, 19 + lblTextFinalVertex.Location.Y);
            this.lblFinalVertexAculad[0].Size = new Size(25, 20);
            this.lblFinalVertexAculad[0].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.lblFinalVertexAculad[0]);

            //Craete numUPFinalVertex[0]
            this.numUPFinalVertex[0] = new NumericUpDown();
            this.numUPFinalVertex[0].Location = new Point(165 + lblTextFinalVertex.Location.X, 30 + lblTextFinalVertex.Location.Y);
            this.numUPFinalVertex[0].Size = new Size(35, 16);
            this.numUPFinalVertex[0].Maximum = 999;
            this.numUPFinalVertex[0].BorderStyle = BorderStyle.None;
            this.numUPFinalVertex[0].BackColor = Color.Pink;
            this.numUPFinalVertex[0].InterceptArrowKeys = false;
            this.numUPFinalVertex[0].ThousandsSeparator = true;
            this.numUPFinalVertex[0].Maximum = (decimal)(0);
            this.Controls.Add(this.numUPFinalVertex[0]);
            this.numUPFinalVertex[0].BringToFront();

            //Create lblFinalVertexEndAculad[0] && Add(lblFinalVertexCama[0])
            this.lblFinalVertexEndAculad[0] = new Label();
            this.lblFinalVertexEndAculad[0].Font = new Font(lblFinalVertexEndAculad[0].Font.Name, 12, FontStyle.Bold);
            this.lblFinalVertexEndAculad[0].Text = "}";
            this.lblFinalVertexEndAculad[0].Location = new Point(197 + lblTextFinalVertex.Location.X, 19 + lblTextFinalVertex.Location.Y);
            this.lblFinalVertexEndAculad[0].Size = new Size(15, 20);
            this.lblFinalVertexEndAculad[0].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(this.lblFinalVertexEndAculad[0]);
            this.Controls.Add(this.lblFinalVertexCama[0]);
            //---------------------------------------------------------------------------------------------------------
            //=================================================================================
            //Create lblVectorBeginningQ[0]
            this.lblVectorBeginningQ[0] = new Label();
            this.lblVectorBeginningQ[0].Font = new Font(lblVectorBeginningQ[0].Font.Name, 12);
            this.lblVectorBeginningQ[0].Text = "q";
            this.lblVectorBeginningQ[0].Location = new Point(51 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y);
            this.lblVectorBeginningQ[0].Size = new Size(15, 24);
            this.lblVectorBeginningQ[0].TextAlign = ContentAlignment.MiddleCenter;
            this.lblVectorBeginningQ[0].UseCompatibleTextRendering = true;
            this.toolTip.SetToolTip(this.lblVectorBeginningQ[0], "Define Beginning Vertex ");
            this.Controls.Add(this.lblVectorBeginningQ[0]);

            //Create lblVectorDestinationQ[0]
            this.lblVectorDestinationQ[0] = new Label();
            this.lblVectorDestinationQ[0].Font = new Font(lblVectorDestinationQ[0].Font.Name, 12);
            this.lblVectorDestinationQ[0].Text = "q";
            this.lblVectorDestinationQ[0].Location = new Point(156 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y);
            this.lblVectorDestinationQ[0].Size = new Size(15, 24);
            this.lblVectorDestinationQ[0].TextAlign = ContentAlignment.MiddleCenter;
            this.lblVectorDestinationQ[0].UseCompatibleTextRendering = true;
            this.toolTip.SetToolTip(this.lblVectorDestinationQ[0], "Define Destination Vertex ");
            this.Controls.Add(this.lblVectorDestinationQ[0]);

            //Create cmbVectorBeginning[0]
            this.cmbVectorBeginning[0] = new ComboBox();
            this.cmbVectorBeginning[0].BackColor = System.Drawing.Color.PaleGreen;
            this.cmbVectorBeginning[0].Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbVectorBeginning[0].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVectorBeginning[0].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVectorBeginning[0].FormatString = "N0";
            this.cmbVectorBeginning[0].FormattingEnabled = true;
            this.cmbVectorBeginning[0].Location = new System.Drawing.Point(69 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y);
            this.cmbVectorBeginning[0].MaxLength = 3;
            this.cmbVectorBeginning[0].Size = new System.Drawing.Size(44, 21);
            this.cmbVectorBeginning[0].Sorted = true;
            this.toolTip.SetToolTip(this.cmbVectorBeginning[0], "Define Beginning Vertex ");
            this.Controls.Add(cmbVectorBeginning[0]);
          
            //Create cmbVectorDestination[0]
            this.cmbVectorDestination[0] = new ComboBox();
            this.cmbVectorDestination[0].BackColor = System.Drawing.Color.PaleGreen;
            this.cmbVectorDestination[0].Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbVectorDestination[0].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVectorDestination[0].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbVectorDestination[0].FormatString = "N0";
            this.cmbVectorDestination[0].FormattingEnabled = true;
            this.cmbVectorDestination[0].Location = new System.Drawing.Point(174 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y);
            this.cmbVectorDestination[0].MaxLength = 3;
            this.cmbVectorDestination[0].Size = new System.Drawing.Size(44, 21);
            this.cmbVectorDestination[0].Sorted = true;
            this.toolTip.SetToolTip(this.cmbVectorDestination[0], "Define Destination Vertex ");
            this.Controls.Add(cmbVectorDestination[0]);

            //Create txtVector[0]
            this.txtVector[0] = new TextBox();
            this.txtVector[0].BackColor = System.Drawing.Color.PaleGreen;
            this.txtVector[0].BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVector[0].Location = new System.Drawing.Point(119 + lblTextVector.Location.X, 24 + lblTextVector.Location.Y);
            this.txtVector[0].MaxLength = 3;
            this.txtVector[0].Size = new System.Drawing.Size(25, 13);
            this.txtVector[0].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.txtVector[0], "Alphabet Word\'s for Vector ");
            this.txtVector[0].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.txtVector[0].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.Controls.Add(txtVector[0]);
            this.txtVector[0].BringToFront();

            //Create lblVectorArrow[0]
            this.lblVectorArrow[0] = new Label();
            this.lblVectorArrow[0].AutoSize = true;
            this.lblVectorArrow[0].Location = new System.Drawing.Point(114 + lblTextVector.Location.X, 32 + lblTextVector.Location.Y);
            this.lblVectorArrow[0].Size = new System.Drawing.Size(43, 13);
            this.lblVectorArrow[0].Text = "---------->";
            this.toolTip.SetToolTip(this.lblVectorArrow[0], "Alphabet Word\'s for Vector ");
            this.Controls.Add(lblVectorArrow[0]);

            btnDelVector.Location = new Point(lblTextVector.Location.X, lblTextVector.Location.Y + 19);
            btnAddVector.Location = new Point(lblTextVector.Location.X + 224, lblTextVector.Location.Y + 19);
            btnTypeLanda.Location = new Point(lblTextVector.Location.X + 281, lblTextVector.Location.Y + 16);

            //Add AutoCompleteCustomSource & ComboBox.item Information
            FillComboBox(1);
            //=================================================================================================================================
        }

        bool Space = false;
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                Space = true;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Space) e.Handled = true;
            Space = false;
        }

        private void btnAddAlphabet_Click(object sender, EventArgs e)
        {
            AlphabetName.Clear();
            int index = 0;
            foreach (TextBox Checktxt in txtAlphabetWord)
            {
                if (Checktxt.Text == " " || Checktxt.Text == "  " || Checktxt.Text == "   " || Checktxt.Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    txtAlphabetWord[index].Select();
                    return;
                }
                else AlphabetName.Add(Checktxt.Text);
                index++;
            }
            CleanupAlphabet();
            CreateAlphabet(index);
        }

        private void CreateAlphabet(int index)
        {
            //Move lblEndSigma to End of Textbox
            lblEndSigma.Location = new Point(157 + lblTextAlphabet.Location.X + ((index * 47) + 31), lblTextAlphabet.Location.Y + 21);

            this.txtAlphabetWord = new TextBox[index + 1];
            this.lblAlphabetCama = new Label[index];
            //Create txtAlphabetWord[index] 
            for (int i = 0; i <= index; i++)  
            {
                this.txtAlphabetWord[i] = new TextBox();
                this.txtAlphabetWord[i].Location = new Point(157 + lblTextAlphabet.Location.X + (i * 47), lblTextAlphabet.Location.Y + 21);
                this.txtAlphabetWord[i].Size = new Size(28, 22);
                this.txtAlphabetWord[i].MaxLength = 3;
                this.txtAlphabetWord[i].TextAlign = HorizontalAlignment.Center;
                this.txtAlphabetWord[i].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
                this.txtAlphabetWord[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
                this.txtAlphabetWord[i].BackColor = Color.NavajoWhite;
                if (i != index) // Because The Final txtAlphabetWord Not Value & is Empty
                    this.txtAlphabetWord[i].Text = (string)AlphabetName[i];
                this.Controls.Add(this.txtAlphabetWord[i]);
            }
            //Create txtAlphabetCama[index - 1] 
            for (int i = 0; i < index; i++)
            {
                this.lblAlphabetCama[i] = new Label();
                this.lblAlphabetCama[i].Font = new Font(lblAlphabetCama[i].Font.Name, 12, FontStyle.Bold);
                this.lblAlphabetCama[i].Text = ",";
                this.lblAlphabetCama[i].Location = new Point(txtAlphabetWord[i].Location.X + 30, lblTextAlphabet.Location.Y + 21);
                this.lblAlphabetCama[i].Size = new Size(14, 20);
                this.Controls.Add(this.lblAlphabetCama[i]);
            }
            txtAlphabetWord[txtAlphabetWord.Length - 1].Select();
        }

        public void CleanupAlphabet()
        {
            for (int j = 0; j < txtAlphabetWord.Length; j++) 
            {
                this.Controls.Remove(this.txtAlphabetWord[j]);
            }
            for (int j = 0; j < lblAlphabetCama.Length; j++)
                this.Controls.Remove(this.lblAlphabetCama[j]);
        }

        private void btnDelAlphabet_Click(object sender, EventArgs e)
        {
            AlphabetName.Clear();
            int index = 0;
            for (int i = 0; i < txtAlphabetWord.Length - 1; i++)
            {
                if (txtAlphabetWord[i].Text == " " || txtAlphabetWord[i].Text == "  " || txtAlphabetWord[i].Text == "   "
                    || txtAlphabetWord[i].Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    txtAlphabetWord[i].Select();
                    return;
                }
                else AlphabetName.Add(txtAlphabetWord[i].Text);
                index = i;
            }
            CleanupAlphabet();
            CreateAlphabet(index);
        }

        private void btnAddFinalVertex_Click(object sender, EventArgs e)
        {
            FinalVertexName.Clear();
            int index = 0;
            foreach (NumericUpDown Checktxt in numUPFinalVertex)
            {
                FinalVertexName.Add(Checktxt.Value);
                index++;
            }
            CleanupFinalVertex();
            CreateFinalVertex(index);
        }

        private void CleanupFinalVertex()
        {
            for (int j = 0; j < numUPFinalVertex.Length; j++)
            {
                this.Controls.Remove(this.numUPFinalVertex[j]);
                this.Controls.Remove(this.lblFinalVertexAculad[j]);
                this.Controls.Remove(this.lblFinalVertexEndAculad[j]);
            }
            for (int j = 0; j < lblFinalVertexCama.Length; j++)
                this.Controls.Remove(this.lblFinalVertexCama[j]);
        }

        private void CreateFinalVertex(int index)
        {
            this.lblFinalVertexAculad = new Label[index + 1];
            this.numUPFinalVertex = new NumericUpDown[index + 1];
            this.lblFinalVertexEndAculad = new Label[index + 1];
            this.lblFinalVertexCama = new Label[index];

            //Create lblFinalVertexAculad[i]
            for (int i = 0; i <= index; i++)
            {
                this.lblFinalVertexAculad[i] = new Label();
                this.lblFinalVertexAculad[i].Font = new Font(lblFinalVertexAculad[i].Font.Name, 12, FontStyle.Bold);
                this.lblFinalVertexAculad[i].Text = "{q";
                this.lblFinalVertexAculad[i].Location = new Point(144 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 19);
                this.lblFinalVertexAculad[i].Size = new Size(25, 20);
                this.lblFinalVertexAculad[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.lblFinalVertexAculad[i]);
            }

            //Craete numUPFinalVertex[i]
            for (int i = 0; i <= index; i++)
            {
                this.numUPFinalVertex[i] = new NumericUpDown();
                this.numUPFinalVertex[i].Location = new Point(165 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 30);
                this.numUPFinalVertex[i].Size = new Size(35, 16);
                this.numUPFinalVertex[i].Maximum = 999;
                this.numUPFinalVertex[i].BorderStyle = BorderStyle.None;
                this.numUPFinalVertex[i].BackColor = Color.Pink;
                this.numUPFinalVertex[i].InterceptArrowKeys = false;
                this.numUPFinalVertex[i].ThousandsSeparator = true;
                if (i != index)
                    this.numUPFinalVertex[i].Value = (Decimal)FinalVertexName[i];
                this.Controls.Add(this.numUPFinalVertex[i]);
                this.numUPFinalVertex[i].BringToFront();
                this.numUPFinalVertex[i].Maximum = (decimal)(NumberOfVertex);
            }

            //Create lblFinalVertexEndAculad[i] 
            for (int i = 0; i <= index; i++)
            {
                this.lblFinalVertexEndAculad[i] = new Label();
                this.lblFinalVertexEndAculad[i].Font = new Font(lblFinalVertexEndAculad[i].Font.Name, 12, FontStyle.Bold);
                this.lblFinalVertexEndAculad[i].Text = "}";
                this.lblFinalVertexEndAculad[i].Location = new Point(197 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 19);
                this.lblFinalVertexEndAculad[i].Size = new Size(15, 20);
                this.lblFinalVertexEndAculad[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.lblFinalVertexEndAculad[i]); 
            }
            //Create lblFinalVertexCama[i] 
            for (int i = 0; i < index; i++)
            {
                this.lblFinalVertexCama[i] = new Label();
                this.lblFinalVertexCama[i].Font = new Font(lblFinalVertexCama[i].Font.Name, 12, FontStyle.Bold);
                this.lblFinalVertexCama[i].Text = ",";
                this.lblFinalVertexCama[i].Location = new Point(208 + lblTextFinalVertex.Location.X + (i * 74), lblTextFinalVertex.Location.Y + 21);
                this.lblFinalVertexCama[i].Size = new Size(12, 20);
                this.lblFinalVertexCama[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(this.lblFinalVertexCama[i]);
                lblFinalVertexCama[i].BringToFront();
            }   
        }

        private void btnDelFinalVertex_Click(object sender, EventArgs e)
        {
            FinalVertexName.Clear();
            int index = 0;
            for (int i = 0; i < numUPFinalVertex.Length - 1; i++)
            {
                FinalVertexName.Add(numUPFinalVertex[i].Value);
                index = i;
            }
            CleanupFinalVertex();
            CreateFinalVertex(index);
        }

        private void btnAddVector_Click(object sender, EventArgs e)
        {
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            int index = 0;
            foreach (TextBox Checktxt in txtVector)
            {
                if (Checktxt.Text == " " || Checktxt.Text == "  " || Checktxt.Text == "   " || Checktxt.Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    txtVector[index].Select();
                    return;
                }
                else if (cmbVectorBeginning[index].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    cmbVectorBeginning[index].Select();
                    return;
                }
                else if (cmbVectorDestination[index].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    cmbVectorDestination[index].Select();
                    return;
                }
                else
                {
                    VectorArrow.Add(txtVector[index].Text);
                    VectorBeginning.Add(cmbVectorBeginning[index].SelectedItem.ToString());
                    VectorDestination.Add(cmbVectorDestination[index].SelectedItem.ToString());
                    index++;
                }
            }
            CleanupVector();
            CreateVector(index + 1);
        }

        private void CleanupVector()
        {
            for (int j = 0; j < txtVector.Length; j++)
            {
                this.Controls.Remove(this.txtVector[j]);
                this.Controls.Remove(this.lblVectorArrow[j]);
                this.Controls.Remove(this.lblVectorBeginningQ[j]);
                this.Controls.Remove(this.lblVectorDestinationQ[j]);
                this.Controls.Remove(this.cmbVectorBeginning[j]);
                this.Controls.Remove(this.cmbVectorDestination[j]);
            }
        }

        private void CreateVector(int index)
        {
            //Vector Information Dynamical Varibale
            this.lblVectorBeginningQ = new Label[index];
            this.lblVectorDestinationQ = new Label[index];
            this.lblVectorArrow = new Label[index];
            this.txtVector = new TextBox[index];
            this.cmbVectorBeginning = new ComboBox[index];
            this.cmbVectorDestination = new ComboBox[index];

            //Create lblVectorBeginningQ[i]
            for (int i = 0; i < index; i++)
            {
                this.lblVectorBeginningQ[i] = new Label();
                this.lblVectorBeginningQ[i].Font = new Font(lblVectorBeginningQ[i].Font.Name, 12);
                this.lblVectorBeginningQ[i].Text = "q";
                this.lblVectorBeginningQ[i].Location = new Point(51 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y + (i * 27));
                this.lblVectorBeginningQ[i].Size = new Size(15, 24);
                this.lblVectorBeginningQ[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lblVectorBeginningQ[i].UseCompatibleTextRendering = true;
                this.toolTip.SetToolTip(this.lblVectorBeginningQ[i], "Define Beginning Vertex ");
                this.Controls.Add(this.lblVectorBeginningQ[i]);
            }

            //Create lblVectorDestinationQ[i]
            for (int i = 0; i < index; i++)
            {
                this.lblVectorDestinationQ[i] = new Label();
                this.lblVectorDestinationQ[i].Font = new Font(lblVectorDestinationQ[i].Font.Name, 12);
                this.lblVectorDestinationQ[i].Text = "q";
                this.lblVectorDestinationQ[i].Location = new Point(156 + lblTextVector.Location.X, 16 + lblTextVector.Location.Y + (i * 27));
                this.lblVectorDestinationQ[i].Size = new Size(15, 24);
                this.lblVectorDestinationQ[i].TextAlign = ContentAlignment.MiddleCenter;
                this.lblVectorDestinationQ[i].UseCompatibleTextRendering = true;
                this.toolTip.SetToolTip(this.lblVectorDestinationQ[i], "Define Destination Vertex ");
                this.Controls.Add(this.lblVectorDestinationQ[i]);
            }

            //Create cmbVectorBeginning[i]
            for (int i = 0; i < index; i++)
            {
                this.cmbVectorBeginning[i] = new ComboBox();
                this.cmbVectorBeginning[i].BackColor = System.Drawing.Color.PaleGreen;
                this.cmbVectorBeginning[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.cmbVectorBeginning[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbVectorBeginning[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.cmbVectorBeginning[i].FormatString = "N0";
                this.cmbVectorBeginning[i].FormattingEnabled = true;
                this.cmbVectorBeginning[i].Location = new System.Drawing.Point(69 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y + (i * 27));
                this.cmbVectorBeginning[i].MaxLength = 3;
                this.cmbVectorBeginning[i].Size = new System.Drawing.Size(44, 21);
                this.toolTip.SetToolTip(this.cmbVectorBeginning[i], "Define Beginning Vertex ");
                this.Controls.Add(cmbVectorBeginning[i]);
            }

            //Create cmbVectorDestination[i]
            for (int i = 0; i < index; i++)
            {
                this.cmbVectorDestination[i] = new ComboBox();
                this.cmbVectorDestination[i].BackColor = System.Drawing.Color.PaleGreen;
                this.cmbVectorDestination[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.cmbVectorDestination[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbVectorDestination[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.cmbVectorDestination[i].FormatString = "N0";
                this.cmbVectorDestination[i].FormattingEnabled = true;
                this.cmbVectorDestination[i].Location = new System.Drawing.Point(174 + lblTextVector.Location.X, 21 + lblTextVector.Location.Y + (i * 27));
                this.cmbVectorDestination[i].MaxLength = 3;
                this.cmbVectorDestination[i].Size = new System.Drawing.Size(44, 21);
                this.toolTip.SetToolTip(this.cmbVectorDestination[i], "Define Destination Vertex ");
                this.Controls.Add(cmbVectorDestination[i]);
                
            }

            //Create txtVector[i]
            for (int i = 0; i < index; i++)
            {
                this.txtVector[i] = new TextBox();
                this.txtVector[i].BackColor = System.Drawing.Color.PaleGreen;
                this.txtVector[i].BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.txtVector[i].Location = new System.Drawing.Point(119 + lblTextVector.Location.X, 24 + lblTextVector.Location.Y + (i * 27));
                this.txtVector[i].MaxLength = 3;
                this.txtVector[i].Size = new System.Drawing.Size(25, 13);
                this.txtVector[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.toolTip.SetToolTip(this.txtVector[i], "Alphabet Word\'s for Vector ");
                this.txtVector[i].KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
                this.txtVector[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
                this.Controls.Add(txtVector[i]);
                this.txtVector[i].BringToFront();                    
            }

            //Create lblVectorArrow[i]
            for (int i = 0; i < index; i++)
            {
                this.lblVectorArrow[i] = new Label();
                this.lblVectorArrow[i].AutoSize = true;
                this.lblVectorArrow[i].Location = new System.Drawing.Point(114 + lblTextVector.Location.X, 32 + lblTextVector.Location.Y + (i * 27));
                this.lblVectorArrow[i].Size = new System.Drawing.Size(43, 13);
                this.lblVectorArrow[i].Text = "---------->";
                this.toolTip.SetToolTip(this.lblVectorArrow[i], "Alphabet Word\'s for Vector ");
                this.Controls.Add(lblVectorArrow[i]);
            }
            btnAddVector.Location = new Point(224 + lblTextVector.Location.X, cmbVectorDestination[cmbVectorDestination.Length - 1].Location.Y - 2);
            btnDelVector.Location = new Point(lblTextVector.Location.X, cmbVectorDestination[cmbVectorDestination.Length - 1].Location.Y - 2);
            btnTypeLanda.Location = new Point(lblTextVector.Location.X + 281, btnAddVector.Location.Y - 3);
            //Add AutoCompleteCustomSource & ComboBox.item Information
            FillComboBox(index);  
        }

        public void FillComboBox(int index) // ComboBox.item Information
        {
            // First Remove All Information
            for (int i = 0; i < index; i++)
            {
                cmbVectorBeginning[i].Items.Clear();
                cmbVectorDestination[i].Items.Clear();
            }
            // Second Adding All Information to ItemList
            for (int j = 0; j <= NumberOfVertex; j++)
            {
                for (int k = 0; k < index; k++)
                {
                    cmbVectorBeginning[k].Items.Add(j);
                    cmbVectorDestination[k].Items.Add(j);
                }
            }
            if (FileOK) // Fill For as File
            {
                for (int l = 0; l < cmbVectorBeginning.Length; l++)
                {
                    cmbVectorBeginning[l].Text = (string)VectorBeginning[l];
                    cmbVectorDestination[l].Text = (string)VectorDestination[l];
                    this.txtVector[l].Text = (string)VectorArrow[l];
                }
            }
            else
            {
                // Back ComboBox Text
                for (int l = 0; l < cmbVectorBeginning.Length - 1; l++)
                {
                    cmbVectorBeginning[l].Text = (string)VectorBeginning[l];
                    cmbVectorDestination[l].Text = (string)VectorDestination[l];
                    this.txtVector[l].Text = (string)VectorArrow[l];
                }
            }
        }

        private void msktxtNumberOfVertex_Leave(object sender, EventArgs e)
        {
            if (msktxtNumberOfVertex.Text != string.Empty)
            {
                NumberOfVertex = Convert.ToInt16(msktxtNumberOfVertex.Text) - 1;
                FillComboBox(cmbVectorDestination.Length);
                for (int i = 0; i < numUPFinalVertex.Length; i++)
                    this.numUPFinalVertex[i].Maximum = (decimal)(NumberOfVertex);
            }
        }

        private void btnDelVector_Click(object sender, EventArgs e)
        {
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            int index = 0;
            for (int i = 0; i < cmbVectorDestination.Length - 1; i++)
            {
                if (txtVector[i].Text == " " || txtVector[i].Text == "  " || txtVector[i].Text == "   "
                    || txtVector[i].Text == string.Empty)
                {
                    MessageBox.Show("TextBox is Empty", "Syntax Error");
                    txtVector[i].Select();
                    return;
                }
                else if (cmbVectorBeginning[i].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    cmbVectorBeginning[i].Select();
                    return;
                }
                else if (cmbVectorDestination[i].SelectedIndex == -1)
                {
                    MessageBox.Show("ComboBox is Empty", "Syntax Error");
                    cmbVectorDestination[i].Select();
                    return;
                }
                else
                {
                    VectorArrow.Add(txtVector[index].Text);
                    VectorBeginning.Add(cmbVectorBeginning[index].SelectedItem.ToString());
                    VectorDestination.Add(cmbVectorDestination[index].SelectedItem.ToString());
                    index = i;
                }
            }
            CleanupVector();
            CreateVector(index + 1);
        }

        private void btnTypeLanda_Click(object sender, EventArgs e)
        {
            txtVector[txtVector.Length - 1].Text = "λ";
        }

        #endregion

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!FirstRun)
            {
                //
                // Definition Varibale
                //
                strAlphabetWord = new string[txtAlphabetWord.Length + 1];
                strAlphabetWord[strAlphabetWord.Length - 1] = "λ";
                FinalVertexNFA = new int[numUPFinalVertex.Length];
                int[] VectorBeginningINT = new int[txtVector.Length];
                int[] VectorDestinationINT = new int[txtVector.Length];
                string[] strAlphabetInterfaceQ = new string[txtVector.Length];
                //
                //check Alphabet Words trust ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                for (int i = 0; i < txtAlphabetWord.Length; i++)
                {
                    if (txtAlphabetWord[i].Text == " " || txtAlphabetWord[i].Text == "  "
                        || txtAlphabetWord[i].Text == "   " || txtAlphabetWord[i].Text == string.Empty) // Check Empty
                    {
                        MessageBox.Show("TextBox is Empty", "Syntax Error");
                        txtAlphabetWord[i].Select();
                        return;
                    }
                    for (int j = i + 1; j < txtAlphabetWord.Length; j++) // Check Repeat
                        if (txtAlphabetWord[i].Text == txtAlphabetWord[j].Text)
                        {
                            MessageBox.Show("Alphabet Word Repeated", "Synatax Error");
                            txtAlphabetWord[j].Select();
                            return;
                        }
                    strAlphabetWord[i] = txtAlphabetWord[i].Text.Trim();
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //check Number of Vertex trust %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                if (msktxtNumberOfVertex.Text == " " || msktxtNumberOfVertex.Text == "  "
                    || msktxtNumberOfVertex.Text == "   " || msktxtNumberOfVertex.Text == string.Empty)
                {
                    MessageBox.Show("TextBox Number Of Vertex is Empty", "Syntax Error");
                    msktxtNumberOfVertex.Select();
                    return;
                }
                else
                    if (int.TryParse(msktxtNumberOfVertex.Text, out NumberOfVertex))
                    {
                        if (NumberOfVertex < 0)
                        {
                            MessageBox.Show("Number Of Vertex Does not Negative", "Syntax Error");
                            msktxtNumberOfVertex.Select();
                            msktxtNumberOfVertex.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number Of Vertex Just be Number", "Syntax Error");
                        msktxtNumberOfVertex.Select();
                        msktxtNumberOfVertex.SelectAll();
                        return;
                    }
                //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                // Check Final Vertex number trust &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                for (int V = 0; V < numUPFinalVertex.Length; V++)
                {
                    for (int S = V + 1; S < numUPFinalVertex.Length; S++)
                        if (numUPFinalVertex[V].Value == numUPFinalVertex[S].Value)
                        {
                            MessageBox.Show("Number Of Final Vertex Repeated", "Syntax Error");
                            numUPFinalVertex[S].Select();
                            return;
                        }
                    FinalVertexNFA[V] = (int)numUPFinalVertex[V].Value;
                }
                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                // Check Vector Information trust ############################################################################
                for (int m = 0; m < txtVector.Length; m++)
                {
                    if (txtVector[m].Text == " " || txtVector[m].Text == "  " || txtVector[m].Text == "   " || txtVector[m].Text == "")
                    {
                        MessageBox.Show("TextBox is Empty", "Syntax Error");
                        txtVector[m].Select();
                        return;
                    }
                    else if (cmbVectorBeginning[m].SelectedIndex == -1)
                    {
                        MessageBox.Show("ComboBox is Empty", "Syntax Error");
                        cmbVectorBeginning[m].Select();
                        return;
                    }
                    else if (cmbVectorDestination[m].SelectedIndex == -1)
                    {
                        MessageBox.Show("ComboBox is Empty", "Syntax Error");
                        cmbVectorDestination[m].Select();
                        return;
                    }
                    bool FindWord = false;
                    for (int d = 0; d < strAlphabetWord.Length; d++)
                    {
                        if (txtVector[m].Text == strAlphabetWord[d])
                        {
                            FindWord = true;
                            break;
                        }
                    }
                    if (!FindWord)
                    {
                        MessageBox.Show("Vector Arrow Text is not a Alphabet Word's", "Syntax Error");
                        txtVector[m].Select();
                        txtVector[m].SelectAll();
                        return;
                    }
                    VectorDestinationINT[m] = Convert.ToInt16(cmbVectorDestination[m].Text);
                    VectorBeginningINT[m] = Convert.ToInt16(cmbVectorBeginning[m].Text);
                    strAlphabetInterfaceQ[m] = txtVector[m].Text;
                }
                //############################################################################################################
                nfaMatris3D = new Boolean[NumberOfVertex + 1, strAlphabetWord.Length, NumberOfVertex + 1];
                // Clean All nfaMatris3D by False
                for (int i = 0; i <= NumberOfVertex; i++)
                    for (int j = 0; j < strAlphabetWord.Length; j++)
                        for (int k = 0; k <= NumberOfVertex; k++)
                            nfaMatris3D[i, j, k] = false;
                // add all nfa information to nfaMatris3D
                for (int i = 0; i < strAlphabetInterfaceQ.Length; i++)
                    for (int j = 0; j < strAlphabetWord.Length; j++)
                        if (strAlphabetInterfaceQ[i] == strAlphabetWord[j])
                            nfaMatris3D[VectorBeginningINT[i], j, VectorDestinationINT[i]] = true;

                // All Information is Checked and now Solve this Question
                Solve();
            }
            else
            {
                ShownAnswer Answer = new ShownAnswer();
                Answer.ShowDialog();
            }
        }

        private  void btnCleanUp_Click(object sender, EventArgs e)
        {
            btnAddVector.Enabled = true;
            btnDelVector.Enabled = true;
            FileOK = false;
            FirstRun = false;
            msktxtNumberOfVertex.Text = string.Empty;
            CleanupAlphabet();
            CleanupFinalVertex();
            CleanupVector();
            AlphabetName.Clear();
            VectorArrow.Clear();
            VectorBeginning.Clear();
            VectorDestination.Clear();
            FinalVertexName.Clear();
            FirstForm_Load(sender, e);
            NumberOfVertex = 0;
            NumberOfNewVertex = 1;
            FinalVertexDFA.Clear();
            btnImport.Enabled = true;
            btnExport.Enabled = false;
            btnShowGraph.Enabled = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnCleanUp_Click(sender , e);
            DialogResult Import = openFileDialogImport.ShowDialog();
            if (Import == DialogResult.OK)
            {
                string strPathImportFile = openFileDialogImport.FileName;
                ExpounderFile ReadFile = new ExpounderFile(strPathImportFile);
                ReadFile.Read();
                if (ReadFile.Correct)
                {
                    int counter = 0;
                    foreach (string word in ReadFile.AlphabetWord1)
                    {
                        counter++;
                        txtAlphabetWord[txtAlphabetWord.Length - 1].Text = word;
                        if (ReadFile.AlphabetWord1.Count != counter)
                            btnAddAlphabet_Click(sender, e);
                    }
                    msktxtNumberOfVertex.Text = ReadFile.NumberOfVertex1.ToString();
                    msktxtNumberOfVertex_Leave(sender, e);
                    counter = 0;
                    foreach (int finaly in ReadFile.FinalVertex1)
                    {
                        counter++;
                        numUPFinalVertex[numUPFinalVertex.Length - 1].Value = (decimal)finaly;
                        if (ReadFile.FinalVertex1.Count != counter)
                            btnAddFinalVertex_Click(sender, e);
                    }
                    counter = 0;
                    VectorArrow.Clear();
                    VectorBeginning.Clear();
                    VectorDestination.Clear();
                    for (int i = 0; i < ReadFile.VectorQ11.Count; i++)
                    {
                        counter++;
                        // Check the Vertex Number in every vector
                        if ((int)ReadFile.VectorQ11[i] < ReadFile.NumberOfVertex1 && (int)ReadFile.VectorQ21[i] < ReadFile.NumberOfVertex1)  
                        {
                            VectorBeginning.Add(ReadFile.VectorQ11[i].ToString());
                            //cmbVectorBeginning[cmbVectorBeginning.Length - 1].Text = ReadFile.VectorQ11[i].ToString();
                            VectorArrow.Add(ReadFile.VectorArrow1[i].ToString());
                            //txtVector[txtVector.Length - 1].Text = ReadFile.VectorArrow1[i].ToString();
                            VectorDestination.Add(ReadFile.VectorQ21[i].ToString());
                            //cmbVectorDestination[cmbVectorDestination.Length-1].Text=ReadFile.VectorQ21[i].ToString();
                        }
                    }
                    CleanupVector();
                    FileOK = true;
                    CreateVector(VectorBeginning.Count);
                    btnSolve_Click(sender, e);
                    btnAddVector.Enabled = false;
                    btnDelVector.Enabled = false;
                }
                else return;
            }
        }

        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            DrawGraph DFA = new DrawGraph();
            DFA.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult Export = saveFileDialogExport.ShowDialog();
            if (Export == DialogResult.OK) 
            {
                string strPathExportFile = saveFileDialogExport.FileName;
                File.WriteAllLines(strPathExportFile, PrintDFA);
            }
        }
    }
}
