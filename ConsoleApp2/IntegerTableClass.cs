using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate void Notify(int[] size);
    class IntegerTableClass
    {
        public event Notify ZmieanaRozmiaru;
        private int[,] twoDimensionIntegerArray;
        public int[] TwoDimensionIntegerArray
        {
            get
            {
                int[] temp =  { twoDimensionIntegerArray.GetLength(0), twoDimensionIntegerArray.GetLength(1) } ;
                return temp;
            }
        }

        
        public int this[int row, int col]
        {
            get
            {
                try
                {
                    
                    return twoDimensionIntegerArray[row, col];
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new ArgumentException("Index is out of range", nameof(col) + nameof(row), ex);
                }
            }

            set
            {
                int currentRow = twoDimensionIntegerArray.GetLength(0);
                int currentColumn = twoDimensionIntegerArray.GetLength(1);

                int[] pasEv = { row + 1, col + 1 };
                if ( currentColumn - 1 < col && currentRow - 1 < row)
                {
                    ZmieanaRozmiaru?.Invoke(pasEv);
                    int[,] tempArr = new int[row + 1, col + 1];
                    for (int i = 0; i < currentRow; i++)
                    {
                        for(int j = 0; j < currentColumn; j++)
                        {
                            tempArr[i, j] = twoDimensionIntegerArray[i, j];
                        }
                    }
                    twoDimensionIntegerArray = tempArr;
                }else if ( currentColumn - 1 < col)
                {
                    ZmieanaRozmiaru?.Invoke(pasEv);
                    int[,] tempArr = new int[currentRow, col + 1];
                    for (int i = 0; i < currentRow; i++)
                    {
                        for (int j = 0; j < currentColumn; j++)
                        {
                            tempArr[i, j] = twoDimensionIntegerArray[i, j];
                        }
                    }
                    twoDimensionIntegerArray = tempArr;
                }else if (currentRow - 1 < row)
                {
                    ZmieanaRozmiaru?.Invoke(pasEv);
                    int[,] tempArr = new int[row + 1, currentColumn];
                    for (int i = 0; i < currentRow; i++)
                    {
                        for (int j = 0; j < currentColumn; j++)
                        {
                            tempArr[i, j] = twoDimensionIntegerArray[i, j];
                        }
                    }
                    twoDimensionIntegerArray = tempArr;
                }
                
                twoDimensionIntegerArray[row, col] = value;
            }
        }

        
        public IntegerTableClass(int rows, int columns)
        {
            twoDimensionIntegerArray = new int[rows, columns];
        }



    }
}
