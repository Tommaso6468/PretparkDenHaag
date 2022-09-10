
using System.Collections.Generic;
using System.Linq;

namespace Pretpark;

public class GebruikerContext : IGebruikerContext
{

    private List<Gebruiker> gebruikers = new List<Gebruiker>();

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

    public Gebruiker NieuweGebruiker(string naam, string email, string wachtwoord)
    {
        Gebruiker g = new Gebruiker(naam, email, wachtwoord);
        gebruikers.Add(g);
        return g;
    }

}
