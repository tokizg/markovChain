public class Chain
{
    List<State> states = new List<State>();

    public void addState(string word)
    {
        states.Add(new State(word));
    }

    public void setNext(int currentIdx, int nextIdx, double prob)
    {
        states[currentIdx].addNext(states[nextIdx], prob);
    }

    public async void Start(int initialStateIdx)
    {
        State current = states[initialStateIdx];
        while (current != State.nullReturn)
        {
            Console.Write(current.word + " ");
            current = await current.goNext();
        }
    }

    class State
    {
        public string word;
        public List<double> probs = new List<double>();
        public List<State> nexts = new List<State>();

        public static State nullReturn = new State("");

        public State(string word)
        {
            this.word = word;
        }

        public void addNext(State next, double prob)
        {
            probs.Add(prob);
            nexts.Add(next);
        }

        public async Task<State> goNext()
        {
            var rand = new Random();
            double r = rand.NextDouble();
            await Task.Delay(100);

            for (int i = 0; i < probs.Count; i++)
            {
                double p = probs[i];
                if (r < p)
                {
                    return nexts[i];
                }
                r -= p;
            }
            return nullReturn;
        }
    }
}
