using System.Collections.Generic;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        public static bool IsInterruptibleSpell(this GameObject unit)
        {
            var unitAsCharacter = unit as Character;
            if (unitAsCharacter == null) return false;
            return unitAsCharacter.IsCasting && InterruptibleSpellIds.Contains(unitAsCharacter.CastingSpellId)
                   || unitAsCharacter.HasAura(1455);
        }

        private static readonly HashSet<uint> InterruptibleSpellIds = new HashSet<uint>
        {
            3360, 3361, 4249, 8831
        };
    }
}