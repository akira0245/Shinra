using System.Threading.Tasks;
using System.Linq;
using ff14bot;
using ff14bot.Managers;
using ShinraCo.Settings;
using ShinraCo.Spells.Main;
using Resource = ff14bot.Managers.ActionResourceManager.Warrior;

namespace ShinraCo.Rotations
{
    public sealed partial class Warrior
    {
        private WarriorSpells MySpells { get; } = new WarriorSpells();

        #region Damage

        private async Task<bool> HeavySwing()
        {
            return await MySpells.HeavySwing.Cast();
        }

        private async Task<bool> SkullSunder()
        {
            if (ActionManager.LastSpell.Name == MySpells.HeavySwing.Name)
            {
                return await MySpells.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> ButchersBlock()
        {
            if (ActionManager.LastSpell.Name == MySpells.SkullSunder.Name)
            {
                return await MySpells.ButchersBlock.Cast();
            }
            return false;
        }

        private async Task<bool> Maim()
        {
            if (ActionManager.LastSpell.Name != MySpells.HeavySwing.Name) return false;

            if (Shinra.Settings.TankMode == TankModes.DPS && ActionManager.HasSpell(MySpells.StormsPath.Name) ||
                Shinra.Settings.WarriorMaim && !Core.Player.CurrentTarget.HasAura(819, false, 6000) ||
                ActionManager.HasSpell(MySpells.StormsEye.Name) && UseStormsEye)
            {
                return await MySpells.Maim.Cast();
            }
            return false;
        }

        private async Task<bool> StormsPath()
        {
            if (ActionManager.LastSpell.Name == MySpells.Maim.Name)
            {
                return await MySpells.StormsPath.Cast();
            }
            return false;
        }

        private async Task<bool> StormsEye()
        {
            if (ActionManager.LastSpell.Name != MySpells.Maim.Name || !UseStormsEye)
                return false;

            return await MySpells.StormsEye.Cast();
        }

        private async Task<bool> InnerBeast()
        {
            if (Shinra.Settings.WarriorInnerBeast && DefianceStance && Resource.BeastGauge >= 50 && !Core.Player.HasAura(MySpells.InnerBeast.Name))
            {
                return await MySpells.InnerBeast.Cast();
            }
            return false;
        }

        private async Task<bool> FellCleave()
        {
            if (!Shinra.Settings.WarriorFellCleave || !DeliveranceStance) return false;

            if (Core.Player.HasAura(1177) || Resource.BeastGauge == 100 && !HeavySwingNext || MySpells.Infuriate.Cooldown() < 6000 ||
                ActionManager.LastSpell.Name == MySpells.Maim.Name && Resource.BeastGauge > 80 && !UseStormsEye)
            {
                return await MySpells.FellCleave.Cast();
            }
            return false;
        }

        #endregion

        #region AoE

        private async Task<bool> Overpower()
        {
            if (Shinra.Settings.WarriorOverpower && Core.Player.CurrentTPPercent > 30)
            {
                return await MySpells.Overpower.Cast();
            }
            return false;
        }

        private async Task<bool> SteelCyclone()
        {
            if (Shinra.Settings.WarriorSteelCyclone && DefianceStance && Resource.BeastGauge >= 50)
            {
                return await MySpells.SteelCyclone.Cast();
            }
            return false;
        }

        private async Task<bool> Decimate()
        {
            if (Shinra.Settings.WarriorDecimate && DeliveranceStance && Resource.BeastGauge >= 50)
            {
                return await MySpells.Decimate.Cast();
            }
            return false;
        }

        #endregion

        #region Cooldown

        private async Task<bool> Onslaught()
        {
            if (Shinra.Settings.WarriorOnslaught && Core.Player.TargetDistance(10))
            {
                return await MySpells.Onslaught.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> Upheaval()
        {
            if (Shinra.Settings.WarriorUpheaval && Core.Player.CurrentHealthPercent > 70 &&
                (Core.Player.HasAura(MySpells.InnerRelease.Name) || MySpells.InnerRelease.Cooldown() > 8000) || Core.Player.ClassLevel < 70)
            {
                var count = Shinra.Settings.CustomAoE ? Shinra.Settings.CustomAoECount : 3;

                if (Shinra.Settings.RotationMode == Modes.Single ||
                    Shinra.Settings.RotationMode == Modes.Smart && Helpers.EnemiesNearTarget(5) < count)
                {
                    return await MySpells.Upheaval.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Buff

        private async Task<bool> Berserk()
        {
            if (Shinra.Settings.WarriorBerserk && Core.Player.ClassLevel < 70)
            {
                return await MySpells.Berserk.Cast();
            }
            return false;
        }

        private async Task<bool> ThrillOfBattle()
        {
            if (Shinra.Settings.WarriorThrillOfBattle && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorThrillOfBattlePct)
            {
                return await MySpells.ThrillOfBattle.Cast();
            }
            return false;
        }

        private async Task<bool> Unchained()
        {
            if (Shinra.Settings.WarriorUnchained && DefianceStance)
            {
                return await MySpells.Unchained.Cast();
            }
            return false;
        }

        private async Task<bool> Vengeance()
        {
            if (Shinra.Settings.WarriorVengeance && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorVengeancePct)
            {
                return await MySpells.Vengeance.Cast();
            }
            return false;
        }

        private async Task<bool> Infuriate()
        {
            if (Shinra.Settings.WarriorInfuriate && BeastDeficit >= 50)
            {
                return await MySpells.Infuriate.Cast();
            }
            return false;
        }

        private async Task<bool> EquilibriumTP()
        {
            if (Shinra.Settings.WarriorEquilibriumTP && DeliveranceStance &&
                Core.Player.CurrentTPPercent < Shinra.Settings.WarriorEquilibriumTPPct)
            {
                return await MySpells.Equilibrium.Cast();
            }
            return false;
        }

        private async Task<bool> ShakeItOff()
        {
            if (Shinra.Settings.WarriorShakeItOff)
            {
                return await MySpells.ShakeItOff.Cast(null, false);
            }
            return false;
        }

        private async Task<bool> InnerRelease()
        {
            if (!Shinra.Settings.WarriorInnerRelease || !DeliveranceStance) return false;

            var gcd = DataManager.GetSpellData(31).Cooldown.TotalMilliseconds;

            if (gcd == 0 || gcd > 700) return false;

            return await MySpells.InnerRelease.Cast();
        }

        #endregion

        #region Heal

        private async Task<bool> Equilibrium()
        {
            if (Shinra.Settings.WarriorEquilibrium && DefianceStance &&
                Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorEquilibriumPct)
            {
                return await MySpells.Equilibrium.Cast();
            }
            return false;
        }

        #endregion

        #region Stance

        private async Task<bool> Defiance()
        {
            if (Shinra.Settings.WarriorStance == WarriorStances.Defiance || Shinra.Settings.WarriorStance == WarriorStances.Deliverance &&
                !ActionManager.HasSpell(MySpells.Deliverance.Name))
            {
                if (!DefianceStance)
                {
                    return await MySpells.Defiance.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Deliverance()
        {
            if (Shinra.Settings.WarriorStance == WarriorStances.Deliverance)
            {
                if (!DeliveranceStance)
                {
                    return await MySpells.Deliverance.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Role

        private async Task<bool> Rampart()
        {
            if (Shinra.Settings.WarriorRampart && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorRampartPct)
            {
                return await MySpells.Role.Rampart.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Shinra.Settings.WarriorConvalescence && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorConvalescencePct)
            {
                return await MySpells.Role.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Anticipation()
        {
            if (Shinra.Settings.WarriorAnticipation && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorAnticipationPct)
            {
                return await MySpells.Role.Anticipation.Cast();
            }
            return false;
        }

        private async Task<bool> Reprisal()
        {
            if (Shinra.Settings.WarriorReprisal)
            {
                return await MySpells.Role.Reprisal.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Shinra.Settings.WarriorAwareness && Core.Player.CurrentHealthPercent < Shinra.Settings.WarriorAwarenessPct)
            {
                return await MySpells.Role.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region PVP

        private async Task<bool> StormsPathPVP()
        {
            return await MySpells.PVP.StormsPath.Cast();
        }

        private async Task<bool> ButchersBlockPVP()
        {
            if (!Core.Player.CurrentTarget.HasAura(1371, false, 7000) && 
                ActionManager.LastSpell.Name != MySpells.PVP.Maim.Name &&
                Core.Player.CurrentTarget.Name != "奋战补给箱" &&
                Core.Player.CurrentTarget.Name != "狼心")
            {
                return await MySpells.PVP.ButchersBlock.Cast();
            }

            return false;
            }

        private async Task<bool> FellCleavePVP()
        {
            if (Core.Player.CurrentTarget.CurrentHealth < 3000 &&
                Core.Player.CurrentTarget.Name != "奋战补给箱" &&
                Core.Player.CurrentTarget.Name != "木人" || Resource.BeastGauge == 100 ||
                Core.Player.CurrentTarget.HasAura(1343) ||
                Resource.BeastGauge == 90 && ActionManager.LastSpell.Name == MySpells.PVP.Maim.Name
                || PVPDefianceStance && Core.Player.CurrentHealthPercent < 70 &&
                !Core.Player.HasAura(1398, true, 2000) ||
                Core.Player.HasAura(MySpells.PVP.InnerRelease.Name)) 
                
            {
                return await MySpells.PVP.FellCleave.Cast();
            }

            return false;
        }

        private async Task<bool> OnslaughtPVP()
        {
            var target = Helpers.EnemyUnit.FirstOrDefault(eu =>
                eu.IsLimitBreaking() && !eu.HasAura(1349) && eu.Distance(Core.Player) < 15);
            if (target != null)
            {
                return await MySpells.PVP.Onslaught.Cast(target);
            }

            return false;
        }

        private async Task<bool> TomahawkPVP()
        {
            var target = Helpers.EnemyUnit.FirstOrDefault(eu =>
                (eu.IsMelee() || eu.IsTank()) && eu.Distance(Core.Player) < 15 &&
                eu.Distance(eu.TargetGameObject) > 5 &&
                !eu.HasAura(1350) || eu.HasAura(396));
            if (target != null || !Core.Player.HasAura(MySpells.PVP.InnerRelease.Name))
            {
                return await MySpells.PVP.Tomahawk.Cast(target);
            }

            return false;
        }

        private async Task<bool> HolmgangPVP()
        {
            var target = Helpers.EnemyUnit.FirstOrDefault(eu =>
                eu.IsLimitBreaking() && eu.Distance(Core.Player) > 3 && eu.Distance(Core.Player) < 10 ||
                Core.Player.CurrentHealthPercent < 20 && eu.IsVisible && eu.Distance(Core.Player) < 10);
            if (target != null)
            {
                return await MySpells.PVP.Holmgang.Cast(target);
            }

            return false;
        }

        private async Task<bool> ThrillofWarPVP()
        {
            var partylowhealth = Managers.PartyMembers.Count(pm =>
                                     pm.CurrentHealthPercent < 70 && pm.IsAlive && pm.Distance(Core.Player) < 15) > 1;
            var pmlowhealth = Managers.PartyMembers.Any(pm =>
                                   pm.CurrentHealthPercent < 40 && pm.IsAlive && pm.Distance(Core.Player) < 15);

            if (partylowhealth || pmlowhealth)
            {
                return await MySpells.PVP.ThrillofWar.Cast();
            }

            return false;
        }

        private async Task<bool> SafeguardPVP()
        {
            if (Core.Player.CurrentHealthPercent < 65 && !Core.Player.HasAura(1415))
            {
                return await MySpells.Adventurer.Safeguard.Cast();
            }

            return false;
        }

        private async Task<bool> RecuperatePVP()
        {
            if (Core.Player.CurrentHealthPercent < 40)
            {
                return await MySpells.Adventurer.Recuperate.Cast();
            }

            return false;
        }

        //private async Task<bool> DefiancePVP()
        //{
        //    if (PVPDeliveranceStance && (Core.Player.CurrentHealthPercent < 70 || Managers.HeavyMedal()) ||
        //        PVPDefianceStance && !Managers.HeavyMedal() && Core.Player.CurrentHealthPercent > 95) 
        //    {
        //        return await MySpells.Defiance.Cast();
        //    }

        //    return false;
        //}

        #endregion

        #region Custom

        private static int BeastDeficit => 100 - Resource.BeastGauge;
        private static bool DefianceStance => Core.Player.HasAura(91);
        private static bool DeliveranceStance => Core.Player.HasAura(729);
        private static bool PVPDefianceStance => Core.Player.HasAura(1396);
        private static bool PVPDeliveranceStance => !Core.Player.HasAura(1396);
        private static bool HeavySwingNext => ActionManager.LastSpellId == 42 || ActionManager.LastSpellId == 45 || 
                                              ActionManager.LastSpellId == 47;

        private int StormEyeTime => (int)MySpells.InnerRelease.Cooldown() + 17000;
        private bool UseStormsEye => Shinra.Settings.WarriorStormsEye &&
                                     (!Core.Player.HasAura(90, true, 9000) || Core.Player.ClassLevel == 70 &&
                                      MySpells.InnerRelease.Cooldown() < 10000 && !Core.Player.HasAura(90, true, StormEyeTime));

        #endregion
    }
}