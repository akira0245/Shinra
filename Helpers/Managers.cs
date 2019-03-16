﻿using System.Collections.Generic;
using System.Linq;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace ShinraCo
{
    public static class Managers
    {
        public static IEnumerable<BattleCharacter> DragonSight
        {
            get
            {
                return PartyMembers.Where(pm => pm.InCombat && pm.IsAlive && pm.Distance(Core.Player) < 11)
                                   .OrderByDescending(DragonSightScore);
            }
        }

        public static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return PartyManager.VisibleMembers.Select(pm => pm.GameObject as BattleCharacter)
                                   .Where(pm => pm != null && pm.IsTargetable);
            }
        }

        private static int DragonSightScore(BattleCharacter c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Samurai: return 60;
                case ClassJobType.Monk: return 50;
                case ClassJobType.Ninja: return 40;
                case ClassJobType.Dragoon: return 30;
            }
            return c.IsDPS() ? 20 : c.IsTank() ? 10 : 0;
        }

        public static IEnumerable<BattleCharacter> TheBlackestNightTarget
        {
            get
            {
                return PartyMembers
                    .Where(pm => pm.CurrentHealthPercent < 70 && pm.IsAlive && pm.Distance(Core.Player) < 30)
                    .OrderByDescending(Importance);
            }
        }

        private static int Importance(BattleCharacter c)
        {
            return c.IsHealer() ? 60 : c.IsDPS() ? 40 : c.IsTank() ? 20 : 0;
        }

        public static bool HeavyMedal()
        {
            return Core.Player.HasAura(1500) || Core.Player.HasAura(1501) || Core.Player.HasAura(1502);
        }

        public static bool BeingWatched()
        {
            return Helpers.EnemyUnit.Count(eu => eu.HasTarget && eu.TargetGameObject.IsMe) > 2;
        }
    }
}
