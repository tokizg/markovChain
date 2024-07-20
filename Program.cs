public class Program
{
    public static void Main()
    {
        Chain chain = new Chain();

        chain.addState("し");
        chain.addState("か");
        chain.addState("の");
        chain.addState("こ");
        chain.addState("た");
        chain.addState("ん");
        chain.addState("_");

        chain.setNext(0, 1, 0.5);
        chain.setNext(0, 4, 0.5);
        chain.setNext(1, 2, 1);
        chain.setNext(2, 3, 1);
        chain.setNext(3, 2, 0.5);
        chain.setNext(3, 3, 0.25);
        chain.setNext(3, 0, 0.25);
        chain.setNext(4, 5, 1);
        chain.setNext(5, 4, 0.5);
        chain.setNext(5, 6, 0.5);
        chain.setNext(6, 0, 0.5);
        chain.setNext(6, 6, 0.5);

        chain.Start(0);
        Console.ReadLine();
    }
}
