using Terraria.ModLoader;
using Terraria;
using System;
using System.Collections;
using System.Collections.Generic;
namespace RaidersMod
{
	public class RaidersMod : Mod
	{
		public RaidersMod()
		{
			ModProperties properties = default(ModProperties);
			properties.Autoload = true;
			properties.AutoloadBackgrounds = true;
			properties.AutoloadGores = true;
			properties.AutoloadSounds = true;
			Properties = properties;
		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call
				(
				"AddMiniBoss",
				6.5f,
				ModContent.NPCType<NPCs.Bosses.Impetum_Scout.Impetum_Scout>(),
				this, // Mod
				"Impetum Scout",
				(Func<bool>)(() => RaidersModWorld.DownedImpetum),
				ModContent.ItemType<Items.SummoningItems.Impetum_Transmitter>(),
				new List<int> {},
				new List<int> {ModContent.ItemType<Items.weapons.Gelatinous_Remote>(),ModContent.ItemType<Items.weapons.TheOozebrand>(),ModContent.ItemType<Items.weapons.SlimeRifle>()},
				"Use a Impetum Transmitter in Sky");
			}
		}
	}
}