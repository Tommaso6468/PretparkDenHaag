class Gebruiker {

    private IEmailService eService = new EmailService();

    public string? Wachtwoord {get; set;}
    public string? Naam {get; set;}
    public string? Email {get; set;}

    private VerificatieToken vToken = new VerificatieToken();

    public Gebruiker(string naam, string wachtwoord, string email) {
        this.Naam = naam;
        this.Wachtwoord = wachtwoord;
        this.Email = email;
    }

    public void ClearToken() {
        if (vToken != null) {
            this.vToken.ResetToken();
            eService.Email("Uw verificatie token is: " + vToken.token, Email);
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