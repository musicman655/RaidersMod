using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
namespace RaidersMod.Items.SummoningItems
{
    public class Impetum_Transmitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impetum Transmitter");
            Tooltip.SetDefault("Summons Impetum Scout");//Yogurt put tooltip here cuz yes
        }
        public override void SetDefaults()
        {
            item.width = item.height = 20;
            item.consumable = true;
            item.maxStack = 20;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.hardMode && player.ZoneSkyHeight;
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X - Main.rand.Next(-500,500),(int)player.Center.Y - Main.rand.Next(200,250),ModContent.NPCType<NPCs.Bosses.Impetum_Scout.Impetum_Scout>(),0,0,0,0,0,player.whoAmI);
            Main.PlaySound(SoundID.Roar,player.position,0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar,10);
            recipe.AddIngredient(ItemID.Gel,20);
            recipe.AddIngredient(ModContent.ItemType<Items.craftingMaterials.SlimeFeather>(),5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}