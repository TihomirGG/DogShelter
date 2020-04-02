namespace DogShelter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Area
    {
        Sofia = 1,
        Qmbol = 2,
        Shumen = 3,
        Haskovo = 4,
        Turgovishte = 5,
        [Display(Name ="Stara Zagora")]
        StaraZagora = 6,
        Smolqn = 7,
        Sliven = 8,
        Silistra = 9,
        Ruse = 10,
        Razgrad = 11,
        Plovdiv = 12,
        Pleven = 13,
        Pernik = 14,
        Pazardjik = 15,
        Montana = 16,
        Lovech = 17,
        Kustendil = 18,
        Kurdjali = 19,
        Dobrich = 20,
        Gabrovo = 21,
        Vraca = 22,
        Vidin = 23,
        [Display(Name = "Veliko Turnovo")]
        VelikoTurnovo = 24,
        Varna = 25,
        Burgas = 26,
        Blagoevgrad = 27,
    }
}
