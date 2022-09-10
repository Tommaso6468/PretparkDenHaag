using System;

namespace Pretpark;
public class GebruikerService
{

    private IGebruikerContext gContext;
    private IEmailService eService;

    public GebruikerService(IGebruikerContext gebruikerContext, IEmailService emailService)
    {
        this.gContext = gebruikerContext;
        this.eService = emailService;
    }

    public Gebruiker Registreer(string naam, string email, string wachtwoord)
    {
        if (gContext.GetGebruiker(email) != null) return null;
        Gebruiker g = gContext.NieuweGebruiker(naam, email, wachtwoord);
        eService.Email("Uw verificatie token is: " + g.GetToken(), email);
        return g;
    }

    public bool Login(string email, string wachtwoord)
    {

        Gebruiker? g = gContext.GetGebruiker(email);

        if (g == null) return false;
        if (g.Wachtwoord != wachtwoord) return false;
        if (!g.Geverifieerd()) return false;

        return true;
    }

    public bool Verifieer(string email, string token, DateTime dateTimeCurrent)
    {

        Gebruiker? g = gContext.GetGebruiker(email);

        if (g == null) return false;
        if (g.GetToken() == null) return false;
        if (g.GetToken().token != token) return false;

        DateTime tokenDateTime = (DateTime) g.GetToken().verloopDatum;
        var aantalDagen = (tokenDateTime - dateTimeCurrent).TotalDays;
        if (aantalDagen < 0)
        {
            g.GetToken().ResetToken();
            eService.Email("Uw verificatie token is: " + g.GetToken(), email);
            return false;
        }

        g.ClearToken();
        return true;
    }

}
