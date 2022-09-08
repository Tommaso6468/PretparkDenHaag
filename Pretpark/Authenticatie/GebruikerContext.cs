
using System.Collections.Generic;
using System.Linq;

namespace Pretpark;

public class GebruikerContext : IGebruikerContext
{

    private static List<Gebruiker> gebruikers = new List<Gebruiker>();

    public int AantalGebruikers()
    {
        return gebruikers.Count();
    }

    public Gebruiker GetGebruiker(int i)
    {
        return gebruikers[i];
    }

    public Gebruiker GetGebruiker(string email)
    {
        for (var i = 0; i < gebruikers.Count; i++)
        {
            if (gebruikers[i].Email == email) return gebruikers[i];
        }
        return null;
    }

    public Gebruiker NieuweGebruiker(string wachtwoord, string naam, string email)
    {
        Gebruiker g = new Gebruiker(naam, wachtwoord, email);
        gebruikers.Add(g);
        return g;
    }

}
