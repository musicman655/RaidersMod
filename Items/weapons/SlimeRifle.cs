using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace RaidersMod.Items.weapons
{
    public class SlimeRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SlimeRifle");
            Tooltip.SetDefault(""); //Yogurt insert the tooltip here cuz idk what to put
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.autoReuse = true;
            item.noMelee = true;
            item.damage = 56;
            item.knockBack = 1f;
            item.maxStack = 1;
            item.shootSpeed = 15;
            item.value = Item.buyPrice(0,1,20,0);
            item.useTime = 4;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 20;
            item.reuseDelay = 24;
            item.UseSound = SoundID.Item1;
            item.width = 25;
            item.height = 14;
            item.scale *= 1.5f;
            item.useAmmo = AmmoID.Gel;
            item.shoot = 10;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(!target.friendly)
            {
                target.AddBuff(BuffID.Slow,600,false);
            }
        }
    }
}
