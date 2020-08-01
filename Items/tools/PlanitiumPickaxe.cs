using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using RaidersMod.Items.craftingMaterials;
namespace RaidersMod.Items.tools
{
    public class PlanitiumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Pickaxe");
            Tooltip.SetDefault("A pickaxe of the jungle");
        }
        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 8;
            item.knockBack = 2.5f;
            item.rare = 1;
            item.useTime = 8;
            item.useAnimation = 16;
            item.Size = new Microsoft.Xna.Framework.Vector2(28);
            item.value = Item.buyPrice(0,0,50,0);
            item.pick = 40;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores,10);
            recipe.AddIngredient(ItemType<Planitium_Bar>(),12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
