public class Program
{
    public static async Task Main()
    {
        Chain chain = new Chain(new string[] { "し", "か", "の", "こ", "た", "ん", "_" });

        chain.setProbability(0, 1, 0.5);
        chain.setProbability(0, 4, 0.5);
        chain.setProbability(1, 2, 1);
        chain.setProbability(2, 3, 1);
        chain.setProbability(3, 2, 0.5);
        chain.setProbability(3, 3, 0.25);
        chain.setProbability(3, 0, 0.25);
        chain.setProbability(4, 5, 1);
        chain.setProbability(5, 4, 0.5);
        chain.setProbability(5, 6, 0.5);
        chain.setProbability(6, 0, 0.5);
        chain.setProbability(6, 6, 0.5);

        Console.Write(chain.current());
        while (true)
        {
            string currentObject = chain.goNext();
            await Task.Delay(50);
            if (currentObject == null)
            {
                break;
            }
            Console.Write(currentObject);
        }
        Console.ReadLine();
    }
}
