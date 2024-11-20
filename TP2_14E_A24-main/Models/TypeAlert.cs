using System.Runtime.Serialization;

namespace Automate.Models
{
    public enum TypeAlert
    {
        [EnumMember(Value = "Aucune alerte")]
        AucuneAlerte,

        [EnumMember(Value = "1 jour avant")]
        UnJourAvant,

        [EnumMember(Value = "2 jours avant")]
        DeuxJoursAvant,

        [EnumMember(Value = "3 jours avant")]
        TroisJoursAvant,

        [EnumMember(Value = "1 semaine avant")]
        UneSemaineAvant,

        [EnumMember(Value = "1 mois avant")]
        UnMoisAvant
    }
}
