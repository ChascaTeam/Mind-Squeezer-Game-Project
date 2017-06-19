using System.Data;

namespace MindSqueezer.Utilities
{
    public class Calculator
    {
        public static int CalculateEquation(string equation)
        {
            DataTable dt = new DataTable();
            var v = int.Parse(dt.Compute(equation, "").ToString());
            return v;
        }
    }
}
