using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace RaidersMod.RaidersMod.Items.accessories
{
    public class GiftOfTheJungle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Made with various elements of the deep jungle"
                                + "\nThis item's thorns makes enemies take 25% of the damage dealth to you"
                                + "\nThis item's essence increases your life and mana regeneration and endurance");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 28;
            item.height = 28;
            item.value = item.value = Item.buyPrice(0, 3, 10, 0);
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 3;
            player.manaRegen += 3;
            player.endurance += 0.1f;
            player.thorns = 0.25f;
        }
public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleRose);
            recipe.AddIngredient(ItemID.NaturesGift);
            recipe.AddIngredient(ItemID.Stinger, 10);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.RichMahogany, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
