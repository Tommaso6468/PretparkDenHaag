using Pretpark;

namespace PretparkTests;
public class GebruikerService_TestsMoq
{

    //Registreer

    [Fact]
    public void Registreer_BestaandeGebruiker_Null()
    {
        var gebruikerContextStub = new Mock<IGebruikerContext>();
        gebruikerContextStub.Setup(x => x.GetGebruiker("marty@gmail.com")).Returns((new Gebruiker("marty", "marty@gmail.com", "88mph")));
        IEmailService emailService = new EmailService();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContextStub.Object, emailService);

        Assert.Null(gebruikerService.Registreer("marty", "marty@gmail.com", "88mph"));
    }

    //Login

    [Fact]
    public void Login_GebruikerBestaatNiet_False()
    {
        var gebruikerContextStub = new Mock<IGebruikerContext>();
        gebruikerContextStub.Setup(x => x.GetGebruiker("marty@gmail.com")).Returns((Gebruiker)null);
        IEmailService emailService = new EmailService();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContextStub.Object, emailService);

        Assert.False(gebruikerService.Login("marty@gmail.com", "88mph"));
    }

    [Fact]
    public void Login_FoutWachtwoord_False()
    {
        var gebruikerContextStub = new Mock<IGebruikerContext>();
        gebruikerContextStub.Setup(x => x.GetGebruiker("marty@gmail.com")).Returns((new Gebruiker("marty", "marty@gmail.com", "88mph")));
        IEmailService emailService = new EmailService();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContextStub.Object, emailService);

        Assert.False(gebruikerService.Login("marty@gmail.com", "12345"));
    }

    //Verifieer

    [Fact]
    public void Verifieer_GebruikerBestaatNiet_False()
    {
        var gebruikerContextStub = new Mock<IGebruikerContext>();
        gebruikerContextStub.Setup(x => x.GetGebruiker("marty@gmail.com")).Returns((Gebruiker)null);
        IEmailService emailService = new EmailService();
        GebruikerService gebruikerService = new GebruikerService(gebruikerContextStub.Object, emailService);

        Assert.False(gebruikerService.Verifieer("marty@gmail.com", "1234", DateTime.Now));
    }

}