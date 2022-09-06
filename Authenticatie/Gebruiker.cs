class Gebruiker {

    public string? Wachtwoord {get; set;}
    public string? Naam {get; set;}
    public string? Email {get; set;}

    private VerificatieToken? vToken;

    public Gebruiker(string naam, string wachtwoord, string email, VerificatieToken vToken) {
        this.Naam = naam;
        this.Wachtwoord = wachtwoord;
        this.Email = email;
        this.vToken = vToken;
    }

    public void ClearToken() {
        if (vToken != null) {
            this.vToken.ResetToken();
        }
    }

    public VerificatieToken GetToken() {
        if (vToken != null) {
            return vToken;
        }
        return null;
    }

    public bool Geverifieerd() {
        if (vToken == null) return true;
        return false;
    }

}