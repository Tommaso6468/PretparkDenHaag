using System;
using Pretpark;

namespace PretparkTests;
public class GebruikerService_Test
{

    //Registreer

    [Fact]
    public void Registreer_NieuweGebruiker_NotNull()
    {
        IEmailService emailService = new EmailServiceMock();
        IGebruikerContext gebruikerContext = new GebruikerContextMock();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.NotNull(gebruikerService.Registreer("frits", "frits@gmail.com", "12345"));

    }

    [Fact]
    public void Registreer_BestaandeGebruiker_Null()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        gebruikerContext.gebruikers = new List<Gebruiker>() { new Gebruiker("marty", "marty@gmail.com", "88mph") };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.Null(gebruikerService.Registreer("marty", "marty@gmail.com", "88mph"));

    }

    //Login

    [Fact]
    public void Login_GebruikerBestaatNiet_False()
    {
        IEmailService emailService = new EmailServiceMock();
        IGebruikerContext gebruikerContext = new GebruikerContextMock();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.False(gebruikerService.Login("marty@gmail.com", "88mph"));
    }

    [Fact]
    public void Login_FoutWachtwoord_False()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        gebruikerContext.gebruikers = new List<Gebruiker>() { new Gebruiker("marty", "marty@gmail.com", "88mph") };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.False(gebruikerService.Login("marty@gmail.com", "90mph"));
    }

    [Fact]
    public void Login_Unverified_False()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        gebruikerContext.gebruikers = new List<Gebruiker>() { new Gebruiker("marty", "marty@gmail.com", "88mph") };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.False(gebruikerService.Login("marty@gmail.com", "88mph"));
    }

    [Fact]
    public void Login_True()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");
        gebruikerContext.gebruikers = new List<Gebruiker>() { g };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);
        gebruikerService.Verifieer(g.Email, g.GetToken().token, DateTime.Now);

        Assert.True(gebruikerService.Login("marty@gmail.com", "88mph"));
    }


    //Verifieer

    [Fact]
    public void Verifieer_GebruikerBestaatNiet_False()
    {
        IEmailService emailService = new EmailServiceMock();
        IGebruikerContext gebruikerContext = new GebruikerContextMock();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");

        Assert.False(gebruikerService.Verifieer(g.Email, g.GetToken().token, DateTime.Now));
    }

    [Fact]
    public void Verifieer_GebruikerAlVerified_False()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");
        gebruikerContext.gebruikers = new List<Gebruiker>() { g };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);
        string token = g.GetToken().token;
        gebruikerService.Verifieer(g.Email, token, DateTime.Now);

        Assert.False(gebruikerService.Verifieer(g.Email, token, DateTime.Now));
    }

    [Fact]
    public void Verifieer_OnjuisteToken_False()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");
        gebruikerContext.gebruikers = new List<Gebruiker>() { g };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.False(gebruikerService.Verifieer(g.Email, "1234abcd", DateTime.Now));
    }

    [Fact]
    public void Verifieer_TokenVerlopen_False()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");
        gebruikerContext.gebruikers = new List<Gebruiker>() { g };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.False(gebruikerService.Verifieer(g.Email, g.GetToken().token, DateTime.Now.AddDays(4)));
    }

    [Fact]
    public void Verifieer_True()
    {
        IEmailService emailService = new EmailServiceMock();
        GebruikerContextMock gebruikerContext = new GebruikerContextMock();
        Gebruiker g = new Gebruiker("marty", "marty@gmail.com", "88mph");
        gebruikerContext.gebruikers = new List<Gebruiker>() { g };
        GebruikerService gebruikerService = new GebruikerService(gebruikerContext, emailService);

        Assert.True(gebruikerService.Verifieer(g.Email, g.GetToken().token, DateTime.Now));
    }

}