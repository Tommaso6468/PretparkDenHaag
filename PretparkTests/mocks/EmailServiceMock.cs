using System;
using Pretpark;

namespace PretparkTests;
public class EmailServiceMock : IEmailService {
    
    public void Email(string tekst, string naarAdres) {
        Console.WriteLine("Aan: " + naarAdres);
        Console.WriteLine();
        Console.WriteLine(tekst);
    }

}