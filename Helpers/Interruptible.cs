using System;
using System.Collections.Generic;
using ff14bot.Objects;

namespace ShinraCo
{
    public static partial class Helpers
    {
        //public static bool IsInterruptible(this GameObject unit)
        //{
        //    return InterruptibleMobsIds.Contains(unit.NpcId);
        //}

        public static bool IsStunableSpell(this GameObject unit)
        {
            var unitAsCharacter = unit as Character;
            if (unitAsCharacter == null) return false;
            return unitAsCharacter.IsCasting && StunableSpellIds.Contains(unitAsCharacter.CastingSpellId) &&
                   !unitAsCharacter.HasAura(1349)
                   || unitAsCharacter.HasAura(1455) || unitAsCharacter.HasAura(1413) || unitAsCharacter.HasAura(1325);
        }

        public static bool IsLimitBreaking(this GameObject unit)
        {
            var unitAsCharacter = unit as Character;
            if (unitAsCharacter == null) return false;
            return unitAsCharacter.IsCasting && PushableSpellIds.Contains(unitAsCharacter.CastingSpellId)
                   || unitAsCharacter.HasAura(1455);
        }

        private static readonly HashSet<uint> StunableSpellIds = new HashSet<uint>
        {
            3360, 3361, 4249, 8831, 7422, 8866
        };

        private static readonly HashSet<uint> PushableSpellIds = new HashSet<uint>
        {
            3360, 3361, 4249
        };

        //private static readonly HashSet<uint> InterruptibleMobsIds = new HashSet<uint>
        //{
        //    113, 116, 117, 270, 275, 304, 305, 345, 353, 411, 560, 858, 865, 894, 1313, 1608, 1673, 1674, 1831, 2316,
        //    2317, 2318, 2319, 2320, 2518, 2681, 2715, 2749, 3376, 3477, 3488, 3494, 3533, 3568, 3571, 3601, 3602, 3603,
        //    3605, 3606, 3746, 4362, 4519, 4607, 4608, 4610, 4612, 4614, 4616, 4617, 4619, 4620, 4622, 4634, 4690, 4699,
        //    4700, 4701, 4713, 4720, 4724, 4797, 4798, 4800, 4802, 4803, 4804, 4805, 4808, 4810, 4811, 4812, 4813
        //};
    }
}