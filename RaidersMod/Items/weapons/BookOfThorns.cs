using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace RaidersMod.RaidersMod.Items.weapons
{
    public class BookOfThorns : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("this book shoots stings... ouch");
        }    
        public override void SetDefaults()
        {         
            item.damage = 14;                        
            item.magic = true;                     //this make the item do magic damage
            item.width = 24;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;        //this is how the item is holded
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 1000;
            item.rare = 6;
            item.mana = 5;             //mana use
            item.UseSound = SoundID.Item21;            //this is the sound when you use the item
            item.autoReuse = true;
            item.shoot = ProjectileID.PoisonDart;   //this make the item shoot your projectile
            item.shootSpeed = 8f;    //projectile speed when shoot
        }      
    }
}
