namespace Pretpark;

public class Gebruiker
{

    public string? Wachtwoord { get; set; }
    public string? Naam { get; set; }
    public string? Email { get; set; }

    private VerificatieToken vToken = new VerificatieToken();

    public Gebruiker(string naam, string email, string wachtwoord)
    {
        this.Naam = naam;
        this.Wachtwoord = wachtwoord;
        this.Email = email;
    }

    public void ClearToken()
    {
        vToken = null;

    }

    public VerificatieToken? GetToken()
    {
        if (vToken != null)
        {
            return vToken;
        }
        return null;
    }

    public bool Geverifieerd()
    {
        if (vToken == null) return true;
        return false;
    }

}
