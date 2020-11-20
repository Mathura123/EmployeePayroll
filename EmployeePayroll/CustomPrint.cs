namespace EmployeePayroll
{
    using System;
    /// <summary>
    ///   For creating custom printing
    /// </summary>
    public class CustomPrint
    {
        private static int tableWidth =190;
        /// <summary>Prints the dash line</summary>
        public static void PrintDashLine()
        {
            Console.WriteLine(new string('-', tableWidth + 4).PadLeft(tableWidth + 5,'+').PadRight(tableWidth + 6,'+'));
        }
        /// <summary>Prints the row.</summary>
        /// <param name="columns">The values.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
        /// <summary>Aligns in centre.</summary>
        /// <param name="text">The text.</param>
        /// <param name="width">The width.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
        /// <summary>Prints the line in red.</summary>
        /// <param name="s">The string.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <param name="footer">if set to <c>true</c> [footer].</param>
        public static void PrintInRed(string s, bool header = false, bool footer = false)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
        /// <summary>Prints the line in magenta.</summary>
        /// <param name="s">The string.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <param name="footer">if set to <c>true</c> [footer].</param>
        public static void PrintInMagenta(string s, bool header = false, bool footer = true)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
    }
}
