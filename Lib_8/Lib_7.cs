using System;

namespace Lib_7
{
    public static class RowMinLib
    {
        public static int[] FindMinInEachRow(int[,] sourceMatrix)
        {
            int rowCount = sourceMatrix.GetLength(0);
            int columnCount = sourceMatrix.GetLength(1);
            int[] resultArray = new int[rowCount];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                // Пока считаем минимумом первый элемент строки
                int rowMin = sourceMatrix[rowIndex, 0];

                // Переходим к обработке следующего столбца в строке
                for (int columnIndex = 1; columnIndex < columnCount; columnIndex++)
                {
                    if (sourceMatrix[rowIndex, columnIndex] < rowMin)
                    {
                        rowMin = sourceMatrix[rowIndex, columnIndex];
                    } 
                } 

                resultArray[rowIndex] = rowMin;
            } 

            return resultArray;
        } 
    } 
} 