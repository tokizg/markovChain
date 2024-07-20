public class Chain
{
    public int currentStateIndex = 0;

    string[] states = new string[0];
    double[,] probabilities = new double[0, 0];

    public Chain(string[] words)
    {
        currentStateIndex = 0;
        states = new string[words.Length];
        probabilities = new double[words.Length, words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            states[i] = new string(words[i]);
        }
    }

    public Chain(string[] words, double[,] probs)
    {
        currentStateIndex = 0;
        states = new string[words.Length];
        probabilities = new double[words.Length, words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            states[i] = new string(words[i]);
        }
        for (int i = 0; i < probs.GetLength(0); i++)
        {
            for (int j = 0; j < probs.GetLength(1); j++)
            {
                probabilities[i, j] = probs[i, j];
            }
        }
    }

    public void setProbability(int startIdx, int endIdx, double prob)
    {
        probabilities[startIdx, endIdx] = prob;
    }

    public string current()
    {
        return states[currentStateIndex];
    }

    public string goNext()
    {
        var rand = new Random();
        double r = rand.NextDouble();
        for (int i = 0; i < probabilities.GetLength(1); i++)
        {
            double p = probabilities[currentStateIndex, i];
            if (r < p)
            {
                currentStateIndex = i;
                return states[i];
            }
            r -= p;
        }
        return null;
    }
}
