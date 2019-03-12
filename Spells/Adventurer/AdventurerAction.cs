namespace ShinraCo.Spells.Adventurer
{
	public class AdventurerAction
	{
		public Spell Recuperate { get; } = new Spell
        {
            Name = "Recuperate",
            ID = 1590,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Muse { get; } = new Spell
        {
            Name = "Muse",
            ID = 1583,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Enliven { get; } = new Spell
        {
            Name = "Enliven",
            ID = 1580,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Purify { get; } = new Spell
        {
            Name = "Purify",
            ID = 1584,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Concentrate { get; } = new Spell
        {
            Name = "Concentrate",
            ID = 1582,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Safeguard { get; } = new Spell
        {
            Name = "Safeguard",
            ID = 1585,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };

        public Spell Bolt { get; } = new Spell
        {
            Name = "Bolt",
            ID = 8925,
            GCDType = GCDType.Off,
            SpellType = SpellType.Cooldown,
            CastType = CastType.Self
        };
	}
}