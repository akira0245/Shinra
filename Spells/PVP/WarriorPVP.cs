namespace ShinraCo.Spells.PVP
{
    public class WarriorPVP
    {
        public Spell ThrillofWar { get; } = new Spell
        {
            Name = "Thrill of War",
            ID = 1561,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell HeavySwing { get; } = new Spell
        {
            Name = "Heavy Swing",
            ID = 8835,
            Combo = 3,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell SkullSunder { get; } = new Spell
        {
            Name = "Skull Sunder",
            ID = 8759,
            Combo = 3,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };
        public Spell ButchersBlock { get; } = new Spell
        {
            Name = "Butcher's Block",
            ID = 8760,
            Combo = 3,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };
        public Spell Maim { get; } = new Spell
        {
            Name = "Maim",
            ID = 8761,
            Combo = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };
        public Spell StormsPath { get; } = new Spell
        {
            Name = "Storm's Path",
            ID = 8762,
            Combo = 4,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };
        public Spell FellCleave { get; } = new Spell
        {
            Name = "Fell Cleave",
            ID = 8763,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Tomahawk { get; } = new Spell
        {
            Name = "Tomahawk",
            ID = 8764,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Onslaught { get; } = new Spell
        {
            Name = "Onslaught",
            ID = 8765,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell Holmgang { get; } = new Spell
        {
            Name = "Holmgang",
            ID = 8767,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Target
        };

        public Spell InnerRelease { get; } = new Spell
        {
            Name = "Inner Release",
            ID = 8768,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Defiance { get; } = new Spell
        {
            Name = "Defiance",
            ID = 9458,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };
    }
}