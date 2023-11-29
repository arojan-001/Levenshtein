namespace Levenshtein.Data
{
    public class LevenshteinService
    {
        Levenshtein levenshtein;

        public LevenshteinService()
        {
            levenshtein = Levenshtein.O_new("", "");
        }
        public LevenshteinService(string s1, string s2)
        {
            levenshtein = Levenshtein.O_new(s1, s2);
        }
        public void setLevenshtein(string s1, string s2)
        {
            levenshtein = Levenshtein.O_new(s1, s2);
        }
        public int CalculateLevenshteinDistance()
        {
            return levenshtein.ComputeLevenshteinDistance();
        }
        public int[,] GetMatrix()
        {
            return levenshtein.GetMatrix();
        }
        public string getStr1()
        {
            return levenshtein.getStr1();
        }
        public string getStr2()
        {
            return levenshtein.getStr2();
        }
        public int GetValueofMatrix(int i, int j)
        {
            return levenshtein.GetMatrix()[i, j];
        }
        public List<string> GetLevenshteinOperations()
        {
            return levenshtein.ExtractOperations();
        }
    }
}
