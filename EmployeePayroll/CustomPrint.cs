using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    class CustomPrint
    {
        private static int tableWidth =190;
        public static void PrintDashLine()
        {
            Console.WriteLine(new string('-', tableWidth + 4).PadLeft(tableWidth + 5));
        }
        public static string PrintRow(params string[] columns)
        {
            int width = (tableWidth) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            return row;
        }
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
