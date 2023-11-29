namespace Levenshtein.Data
{
    public class Levenshtein
    {
        private int[,] matrix;
        private string str1;
        private string str2;

        private Levenshtein(string s1, string s2)
        {
            str1 = s1;
            str2 = s2;
            matrix = new int[str1.Length + 1, str2.Length + 1];

        }

        public static Levenshtein O_new(string s1, string s2)
        {
            return new Levenshtein(s1, s2);
        }

        public int ComputeLevenshteinDistance()
        {
            int lenStr1 = str1.Length + 1;
            int lenStr2 = str2.Length + 1;

            for (int i = 0; i < lenStr1; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j < lenStr2; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i < lenStr1; i++)
            {
                for (int j = 1; j < lenStr2; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost
                    );
                }
            }

            return matrix[lenStr1 - 1, lenStr2 - 1];
        }

        public int[,] GetMatrix()
        {
            return matrix;
        }
        public string getStr1()
        {
            return str1;
        }
        public string getStr2()
        {
            return str2;
        }
        public List<string> ExtractOperations()
        {
            List<string> operations = new List<string>();
            int i = str1.Length;
            int j = str2.Length;

            while (i > 0 || j > 0)
            {
                int currentCost = matrix[i, j];

                if (i > 0 && matrix[i - 1, j] + 1 == currentCost)
                {
                    operations.Insert(0, $"Delete '{str1[i - 1]}' at position {i - 1} in '{str1}'");
                    i--;
                }
                else if (j > 0 && matrix[i, j - 1] + 1 == currentCost)
                {
                    operations.Insert(0, $"Insert '{str2[j - 1]}' at position {j - 1} in '{str2}'");
                    j--;
                }
                else
                {
                    if (i > 0 && j > 0 && matrix[i - 1, j - 1] + (str1[i - 1] == str2[j - 1] ? 0 : 1) == currentCost)
                    {
                        if (str1[i - 1] != str2[j - 1])
                        {
                            operations.Insert(0, $"Replace '{str1[i - 1]}' with '{str2[j - 1]}' at position {i - 1} in '{str1}'");
                        }
                        else
                        {
                            operations.Insert(0, $"Same character '{str1[i - 1]}' at position {i - 1}");
                        }

                        i--;
                        j--;
                    }
                }
            }

            return operations;
        }
    }
}
