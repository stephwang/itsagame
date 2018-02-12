using System;
using System.ComponentModel;

public static class Constants {
	// ====================================
	// CONSTANT DECLARATIONS FOR ABILITIES
	// ====================================
	public enum Ability{
		[Description("Sword")]
		Sword,
		[Description("Bow")]
		Bow,
		[Description("Staff")]
		Staff,
		[Description("Shield")]
		Shield,
		[Description("Blast")]
		Blast,
		[Description("Move")]
		Move,
		[Description("Beast")]
		Beast,
		[Description("???")]
		Unknown
	}

	public enum Modifier{
		[Description("Flaming")]
		Fire,
		[Description("Weeping")]
		Water,
		[Description("Frozen")]
		Ice,
		[Description("Holy")]
		Light,
		[Description("Shadow")]
		Dark,
		[Description("Heavy")]
		Stone,
		Unknown1,
		Unknown2h
	}

	public static string ToDescription(this Enum value)
	{
		DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
		return da.Length > 0 ? da[0].Description : value.ToString();
	}
}
