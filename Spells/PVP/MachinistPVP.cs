namespace ShinraCo.Spells.PVP
{
    public class MachinistPVP
    {
        public Spell SplitShot { get; } = new Spell
        {
            Name = "Split Shot",
            ID = 8845,
            Combo = 18,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell HotShot { get; } = new Spell
        {
            Name = "Hot Shot",
            ID = 9627,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell GaussBarrel { get; } = new Spell
        {
            Name = "Gauss Barrel",
            ID = 8856,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell QuickReload { get; } = new Spell
        {
            Name = "Quick Reload",
            ID = 9628,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell BetweentheEyes { get; } = new Spell
        {
            Name = "Between the Eyes",
            ID = 1591,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Blank { get; } = new Spell
        {
            Name = "Blank",
            ID = 8853,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell LegGraze { get; } = new Spell
        {
            Name = "Leg Graze",
            ID = 8854,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Wildfire { get; } = new Spell
        {
            Name = "Wildfire",
            ID = 8855,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };
    }
}