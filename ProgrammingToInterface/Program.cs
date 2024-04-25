using static ProgrammingToInterface.InterfaceDemo;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome the Messaging Application \n");

        // imagine these are objects created by user at the runtime 
        Sms sms = new();
        Email email = new();

        // Passed to this static method at runtime so program to interface
        Messageprovider.Send(sms, "Vita");
        Messageprovider.Send(email, "Vita");

    }
}