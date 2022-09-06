static class GebruikerService {

    public static Gebruiker Registreer(string naam, string email, string wachtwoord) {
        if (GebruikerContext.GetGebruiker(email) != null) throw new Exception();
        VerificatieToken vToken = new VerificatieToken();
        EmailService.Email("Uw verificatie token is: " + vToken.token, email);
        return GebruikerContext.NieuweGebruiker(wachtwoord,naam,email,vToken);
    }

    public static bool Login(string email, string wachtwoord) {

        Gebruiker? g = GebruikerContext.GetGebruiker(email);

        if (g == null) return false;
        if (g.Wachtwoord != wachtwoord) return false;
        if (!g.Geverifieerd()) return false;

        return true;
    }

    public static bool Verifieer(string email, string token) {

        Gebruiker? g = GebruikerContext.GetGebruiker(email);

        if (g == null) return false;
        if (g.GetToken() == null) return false;
        if (g.GetToken().token != token) return false;

        DateTime tokenDateTime = (DateTime) g.GetToken().verloopDatum;
        var aantalDagen = (tokenDateTime - DateTime.Now).TotalDays;
        if (aantalDagen < 0) {
            g.GetToken().ResetToken();
            return false;
        }

        return true;
    }

}