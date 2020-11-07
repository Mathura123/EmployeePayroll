namespace EmployeePayroll
{
    /// <summary>
    ///   For creating custom printing
    /// </summary>
    class CustomPrint
    {
        private static int tableWidth =190;
        /// <summary>Prints the dash line</summary>
        public static void PrintDashLine()
        {
            Console.WriteLine(new string('-', tableWidth + 4).PadLeft(tableWidth + 5));
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
    }
}
