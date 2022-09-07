class GebruikerService : IGebruikerService {

    private IGebruikersContext gContext = new GebruikerContext();

    public Gebruiker Registreer(string naam, string email, string wachtwoord) {
        if (gContext.GetGebruiker(email) != null) throw new Exception();
        return gContext.NieuweGebruiker(wachtwoord,naam,email);
    }

    public bool Login(string email, string wachtwoord) {

        Gebruiker? g = gContext.GetGebruiker(email);

        if (g == null) return false;
        if (g.Wachtwoord != wachtwoord) return false;
        if (!g.Geverifieerd()) return false;

        return true;
    }

    public bool Verifieer(string email, string token) {

        Gebruiker? g = gContext.GetGebruiker(email);

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