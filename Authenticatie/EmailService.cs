class EmailService : IEmailService {

    public void Email(string tekst, string naarAdres) {
        Console.WriteLine("Aan: " + naarAdres);
        Console.WriteLine();
        Console.WriteLine(tekst);
    }

}