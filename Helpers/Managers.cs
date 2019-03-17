using System.Collections.Generic;
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

        //public static IEnumerable<BattleCharacter> AlternativeDotTarget
        //{
        //    get
        //    {
        //        return GameObjectManager.GetObjectsOfType<BattleCharacter>(true).Where(eu => eu.IsEnemy())
        //            .OrderByDescending(DamageAdjustment);
        //    }
        //}

        //private static float MedalsAdjustment(this GameObject unit)
        //{
        //    var c = unit as Character;
        //    float adjust = 1;
        //    return c.HasAura(1502) ? adjust * 1.2F :
        //        c.HasAura(1501) ? adjust * 1.15F :
        //        c.HasAura(1500) ? adjust * 1.1F :
        //        c.HasAura(1499) ? adjust * 1.05F :
        //        c.HasAura(1503) ? adjust * 0.99F :
        //        c.HasAura(1504) ? adjust * 0.95F :
        //        c.HasAura(1505) ? adjust * 0.9F :
        //        c.HasAura(1506) ? adjust * 0.8F :
        //        adjust;
        //}

        //private static float StatusAdjustment(this GameObject unit)
        //{
        //    var c = unit as Character;
        //    float adjust = 1;
        //    return c.HasAura(1415) ? adjust * 0.75F :
        //        c.HasAura(1395) ? adjust * 0.8F :
        //        c.HasAura(1396) ? adjust * 0.8F :
        //        c.HasAura(1397) ? adjust * 0.8F :
        //        c.HasAura(1329) ? adjust * 1.05F :
        //        c.HasAura(1371) ? adjust * 1.1F :
        //        c.HasAura(1406) ? adjust * 1.05F :
        //        c.HasAura(1408) ? adjust * 1.25F :
        //        c.HasAura(655) ? adjust * 0.75F :
        //        c.HasAura(397) ? adjust * 0.75F :
        //        adjust;
        //}

        //private static float RoleAdjustment(this GameObject unit)
        //{
        //    var c = unit as Character;
        //    float adjust = 1;
        //    return c.IsHealer() ? adjust * 0.999F :
        //           c.IsMelee() ? adjust * 1.001F :
        //           c.IsTank() ? adjust * 0.998F :
        //           adjust;
        //}

        //private static float WeatherAdjustment(this GameObject unit)
        //{
        //    var c = unit as Character;
        //    float adjust = 1;
        //    return c.HasAura(994) ? adjust * 1.1F : adjust;
        //}

        //private static float DamageAdjustment(Character c)
        //{
        //    return c.StatusAdjustment() * c.MedalsAdjustment() * c.RoleAdjustment();
        //}
    }
}
