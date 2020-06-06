using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.Localization;
namespace RaidersMod.Tiles
{
    public class Planitium_Ore_Tile : ModTile
    {
         public override void SetDefaults()
        {
        	TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = true; 
			Main.tileShine[Type] = 975; 
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Planitium");
			AddMapEntry(new Color(35, 84, 10), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.craftingMaterials.Planitium_Ore>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			minPick = 15;
        }
    }
}