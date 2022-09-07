interface IGebruikerService {
    Gebruiker Registreer(string naam, string email, string wachtwoord);
    bool Login(string email, string wachtwoord);
    bool Verifieer(string email, string token);
}