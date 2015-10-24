using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows;

namespace NFA_DFA
{
    class ExpounderFile
    {
        #region Varibal

        string[] FileNFA; // save File NFA at this var
        ArrayList AlphabetWord = new ArrayList(); // Save Alphabet word's of FileNFA to Array
        int NumberOfVertex = 0;
        ArrayList FinalVertex = new ArrayList();
        ArrayList VectorQ1 = new ArrayList();
        ArrayList VectorQ2 = new ArrayList();
        ArrayList VectorArrow = new ArrayList();
        bool correct = false;

        #endregion

        #region Function

        public ExpounderFile(string strPath) // Constructor Function
        {
            FileNFA = File.ReadAllLines(strPath);
        }

        public  void Read()
        {
            // First Line of FileNFA[0] for search about Alphabet Words -------------------------------
            char[] AlphabetChar = FileNFA[0].ToCharArray();
            for (int i = 0; i < AlphabetChar.Length; i++)
            {
                if (AlphabetChar[i] == ' ') continue;
                else
                {
                    string ReadMultiChar = string.Empty;
                    for (; i < AlphabetChar.Length && AlphabetChar[i] != ' '; i++)
                        ReadMultiChar += AlphabetChar[i];
                    AlphabetWord.Add(ReadMultiChar);
                }
            }
            //-----------------------------------------------------------------------------------------
            // Secondly Line of FileNFA[1] for search about NumberOfVertex ++++++++++++++++++++++++++++++
            char[] numVertex = FileNFA[1].ToCharArray();
            for (int i = 0; i < numVertex.Length; i++)
            {
                if (numVertex[i] == ' ') continue;
                else if (char.IsDigit(numVertex[i])) 
                {
                    string ReadMultiChar = string.Empty;
                    for (; i < numVertex.Length && char.IsDigit(numVertex[i]); i++)
                        ReadMultiChar += numVertex[i].ToString();
                    NumberOfVertex = int.Parse(ReadMultiChar);
                    break;
                }
                else
                {
                    MessageBox.Show("Your NFA File is Incorrect! \nSystem can not match the Number of Vertex in Line 2 by any charactors",
                        "Synatx Error");
                    return;
                }
            }  
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Tertiary Line of FileNFA[2] for search about Final Vertex ==============================
            char[] FinalVertexCH = FileNFA[2].ToCharArray();
            for (int i = 0; i < FinalVertexCH.Length; i++)
            {
                if (FinalVertexCH[i] == ' ') continue;
                else if (FinalVertexCH[i] == 'q')
                {
                    string ReadMultiChar = string.Empty;
                    for (i++; i < FinalVertexCH.Length; i++)
                        if (char.IsDigit(FinalVertexCH[i]))
                            ReadMultiChar += FinalVertexCH[i].ToString();
                        else if (FinalVertexCH[i] == ' ')
                            break;
                        else
                        {
                            MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line 3 in NFA File", "Syntax Error");
                            return;
                        }
                    if (!string.IsNullOrEmpty(ReadMultiChar))
                        FinalVertex.Add(int.Parse(ReadMultiChar));
                    else
                    {
                        MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line 3 in NFA File", "Syntax Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line 3 in NFA File", "Syntax Error");
                    return;
                }
            }
            //=========================================================================================
            // Other Line Search Any Vector ***********************************************************
            char[] VectorCH;
            bool FindQ1 = false;
            bool FindQ2 = false;
            for (int index = 3; index < FileNFA.Length; index++)
            {
                FindQ1 = false;
                FindQ2 = false;
                int Q1 = -1;
                string ArrowCH = string.Empty;
                VectorCH = FileNFA[index].ToCharArray();
                for (int i = 0; i < VectorCH.Length; i++)
                    if (VectorCH[i] == ' ') continue;
                    else if (VectorCH[i] == 'q')
                    {
                        string ReadMultiChar = string.Empty;
                        for (i++; i < VectorCH.Length; i++)
                        {
                            if (char.IsDigit(VectorCH[i]))
                                ReadMultiChar += VectorCH[i].ToString();
                            else if (VectorCH[i] == ' ')
                                break;
                            else
                            {
                                MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line " + index.ToString() +
                                                " at the your File", "Syntax Error");
                                return;
                            }
                        }
                        if (string.IsNullOrEmpty(ReadMultiChar))
                        {
                            MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line " + index.ToString() +
                                            " at the your File", "Syntax Error");
                            return;
                        }
                        else
                        {
                            if (FindQ1)
                            {
                                if (string.IsNullOrEmpty(ArrowCH)) ArrowCH = "λ";
                                VectorArrow.Add(ArrowCH);
                                VectorQ1.Add(Q1);
                                VectorQ2.Add(int.Parse(ReadMultiChar));
                                FindQ2 = true;
                            }
                            else
                            {
                                FindQ1 = true;
                                Q1 = int.Parse(ReadMultiChar);
                            }
                        }
                    }
                    else if(FindQ1 && !FindQ2)
                    {
                        string ReadMultiChar = string.Empty;
                        for (; i < VectorCH.Length && VectorCH[i] != ' '; i++)
                            ReadMultiChar += VectorCH[i].ToString();
                        ArrowCH = ReadMultiChar;
                    }
                    else
                    {
                        MessageBox.Show("Your NFA File is Incorrect! \nSystem can not read Line " + index.ToString() +
                                        " at the your File", "Syntax Error");
                        return;
                    }
            }
            correct = true;
            //*****************************************************************************************
        }

        public ArrayList AlphabetWord1
        {
            get
            {
                return AlphabetWord;
            }
        }
        public bool Correct
        {
            get
            {
                return correct;
            }
        }
        public ArrayList FinalVertex1
        {
            get
            {
                return FinalVertex;
            }
        }
        public int NumberOfVertex1
        {
            get
            {
                return NumberOfVertex;
            }
        }
        public ArrayList VectorArrow1
        {
            get
            {
                return VectorArrow;
            }
        }
        public ArrayList VectorQ11
        {
            get
            {
                return VectorQ1;
            }
        }
        public ArrayList VectorQ21
        {
            get
            {
                return VectorQ2;
            }
        }

        #endregion
    }
}
