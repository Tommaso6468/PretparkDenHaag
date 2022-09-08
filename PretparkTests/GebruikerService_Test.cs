using System;
using Pretpark;

namespace PretparkTests;
public class GebruikerService_Test {

    [Fact]
    public void Verifieer_TokenVerlopen_False()
    {
        IEmailService emailService = new EmailServiceMock(); 
        IGebruikerContext gebruikerContext = new GebruikerContextMock();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext,emailService);

        Gebruiker g = new Gebruiker("Bob", "1234", "bob@gmail.com");

        Assert.False(gebruikerService.Verifieer(g.Email,g.GetToken().token,DateTime.Now.AddDays(4)));
    }

}