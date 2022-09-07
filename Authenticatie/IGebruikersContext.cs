interface IGebruikersContext {
    int AantalGebruikers();
    Gebruiker GetGebruiker(int i);
    Gebruiker GetGebruiker(string email);
    Gebruiker NieuweGebruiker(string wachtwoord, string naam, string email);

}