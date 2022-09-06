static class GebruikerContext {

    private static List<Gebruiker> gebruikers = new List<Gebruiker>();

    public static int AantalGebruikers() {
        return gebruikers.Count();
    }

    public static Gebruiker GetGebruiker(int i) {
        return gebruikers[i];
    }

    public static Gebruiker GetGebruiker(string email) {
        for (var i = 0; i < gebruikers.Count; i++) {
            if (gebruikers[i].Email == email) return gebruikers[i]; 
        }
        return null;
    }

    public static Gebruiker NieuweGebruiker(string wachtwoord, string naam, string email) {
        Gebruiker g = new Gebruiker(naam,wachtwoord,email);
        gebruikers.Add(g);
        return g;
    }

}