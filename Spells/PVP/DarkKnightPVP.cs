namespace ShinraCo.Spells.PVP
{
    public class DarkKnightPVP
    {
        public Spell PowerSlash { get; } = new Spell
        {
            Name = "Power Slash",
            ID = 8771,
            Combo = 5,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Souleater { get; } = new Spell
        {
            Name = "Souleater",
            ID = 8773,
            Combo = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell SyphonStrike { get; } = new Spell
        {
            Name = "Syphon Strike",
            ID = 8772,
            Combo = 6,
            GCDType = GCDType.On,
            SpellType = SpellType.PVP,
            CastType = CastType.Target
        };

        public Spell Bloodspiller { get; } = new Spell
        {
            Name = "Bloodspiller",
            ID = 8776,
            GCDType = GCDType.On,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Grit { get; } = new Spell
        {
            Name = "Grit",
            ID = 9459,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Self
        };

        public Spell TheBlackestNight { get; } = new Spell
        {
            Name = "The Blackest Night",
            ID = 8779,
            GCDType = GCDType.Off,
            SpellType = SpellType.Buff,
            CastType = CastType.Target
        };

        public Spell LowBlow { get; } = new Spell
        {
            Name = "Low Blow",
            ID = 8774,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };

        public Spell Unmend { get; } = new Spell
        {
            Name = "Unmend",
            ID = 8775,
            GCDType = GCDType.Off,
            SpellType = SpellType.Damage,
            CastType = CastType.Target
        };
    }
}