using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using RaidersMod.Items.craftingMaterials;
namespace RaidersMod.Items.tools
{
    public class PlanitiumAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Axe");
            Tooltip.SetDefault("An axe of the jungle"); //yogurt idk what to put here so you do it
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.Size = new Microsoft.Xna.Framework.Vector2(28);
            item.knockBack = 3f;
            item.autoReuse = true;
            item.melee = true;
            item.value = Item.buyPrice(0,0,90,0);
            item.axe = 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores,10);
            recipe.AddIngredient(ItemType<Planitium_Bar>(),14); 
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
