class EmailService {

    public static void Email(string tekst, string naarAdres) {
        Console.WriteLine("Aan: " + naarAdres);
        Console.WriteLine();
        Console.WriteLine(tekst);
    }

}