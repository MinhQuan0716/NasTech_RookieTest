using System.Text.RegularExpressions;

namespace RotateMatrix
{
    internal class Program
    {
        // the Input to test is SD0123,BPO4567;SD1234,BPO1111;SD222,BPO5678;BPO4568;SD3465
        public static void Main()
        {
            var input = Console.ReadLine();
            StaffCounting(input);
        }

        public static void StaffCounting(string input)
        {
            // Initialize counters and a HashSet to track processed staff codes
            int countSd = 0;
            int countBd = 0;
            HashSet<string> processedStaffCodes = new HashSet<string>();

            // Define delimiters (comma and semicolon)
            char[] delimiter = { ',', ';' };

            // Split the input into individual staff codes
            string[] staffCodes = input.Split(delimiter);

            // Define regular expressions for valid SD and BPO codes
            string sdPattern = @"^SD\d{4}$";  // SD followed by exactly 4 digits
            string bpoPattern = @"^BPO\d{4}$"; // BPO followed by exactly 4 digits

            foreach (string staffCode in staffCodes)
            {
                // Trim any leading or trailing spaces from the staff code
                string trimmedCode = staffCode.Trim();

                // Skip if the staff code has been processed before
                if (processedStaffCodes.Contains(trimmedCode))
                {
                    continue;
                }

                // Add the staff code to the set of processed codes
                processedStaffCodes.Add(trimmedCode);

                // Check if the staff code matches the SD or BPO pattern
                if (Regex.IsMatch(trimmedCode, sdPattern))
                {
                    countSd++;
                }
                else if (Regex.IsMatch(trimmedCode, bpoPattern))
                {
                    countBd++;
                }
            }

            // Output the result
            Console.WriteLine($"SD: {countSd}");
            Console.WriteLine($"BPO: {countBd}");
        }

        /*  The input for test is 
         *  string input = "abccca388**
                      aaaaaaccccc

                         abc


                        a c d e^^^^
                      Hello Everyone";*/
        /* 
          static public void Main()
       {
          string input;
        input = Console.In.ReadToEnd();
        string[] data = input.Split("\n");
        foreach (string item in data)
        {
            ParseText(item);
        }
    }
         * 
         * static public void ParseText(string data)
         {
             data = data.TrimEnd();
             if (data.Length == 0) Console.WriteLine("empty");
             if (data.Equals(" ")) Console.WriteLine("space");
             Dictionary<char, int> counter = new Dictionary<char, int>();
             foreach (char c in data)
             {
                 if (counter.ContainsKey(c))
                 {
                     counter[c]++;
                 }
                 else
                 {
                     counter.Add(c, 1);
                 }
             }
             List<string> output = new List<string>();
             foreach (KeyValuePair<char, int> kvp in counter)
             {
                 if (kvp.Key == ' ') // Special case for spaces
                 {
                     output.Add("space " + kvp.Value);
                 }
                 else
                 {
                     output.Add(kvp.Key + " " + kvp.Value);
                 }
             }

             Console.WriteLine(string.Join(",", output));
         }

     */
        /* The input to test is 
         4
         5 1 9 11
         2 4 8 10
         13 3 6 7
         15 14 12 16
         */
        /*  static void Main(string[] args)
          {
              int n = int.Parse(Console.ReadLine());

              string[][] matrix = new string[n][];
              for (int i = 0; i < n; i++)
              {
                  matrix[i] = Console.ReadLine().Split(' ');
              }

              RotateMatrix(matrix);
          }

          static void RotateMatrix(string[][] matrix)
          {
              // TODO: Let's rock 'n roll here
              int n = matrix.Length;

              // Perform Transpose
              for (int i = 0; i < n; i++)
              {
                  for (int j = i + 1; j < n; j++)
                  {
                      string temp = matrix[i][j];
                      matrix[i][j] = matrix[j][i];
                      matrix[j][i] = temp;
                  }
              }

              // Reverse each row
              for (int i = 0; i < n; i++)
              {
                  Array.Reverse(matrix[i]);
              }
              for (int i = 0; i < n; i++)
              {
                  for (int j = 0; j < matrix[i].Length; j++)
                  {
                      Console.Write(matrix[i][j] + " ");
                  }
                  Console.WriteLine();
              }

          }*/

    }
}