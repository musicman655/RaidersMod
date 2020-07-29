using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using RaidersMod.Items.projectiles.Minions;
using Microsoft.Xna.Framework;
namespace RaidersMod.Items.weapons
{
    public class Gelatinous_Remote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelatinous Remote");
            Tooltip.SetDefault("ae");//ae
        }
        public override void SetDefaults()
        {
            item.width = item.height = 20;
            item.summon = true;
            item.damage = 35;
            item.knockBack = 1;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = 4;
            item.mana = 10;
            item.maxStack = 1;
            item.useTime = 25;
            item.useAnimation = 25;

            item.buffType = ModContent.BuffType<Buffs.Gelatinous_Buff>();
            item.shoot = ModContent.ProjectileType<Gelatinous_Drone>();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Gelatinous_Drone>()] < 1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType,2);
            position = Main.MouseWorld;
            return true;
        }
    }
}