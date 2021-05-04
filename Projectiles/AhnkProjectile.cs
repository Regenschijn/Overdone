using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles {
    public class AhnkProjectile : ModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Ahnk";
            projectile.width = 25;
            projectile.height = 25;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.timeLeft = 100;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;

        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.5f; 
            projectile.rotation += (float)projectile.direction * 0.5f; 
            int DustID = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default( Color ), 0.75f ); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
            if ( projectile.timeLeft % 10 == 0 ) //”%” is modulate, which means the remainder, so this is saying that it will spawn projectiles every 15 frames
            {
                Projectile.NewProjectile( projectile.position.X, projectile.position.Y, MathHelper.Lerp( -1f, 1f, (float)Main.rand.NextDouble() ), MathHelper.Lerp( -1f, 1f, (float)Main.rand.NextDouble() ), mod.ProjectileType( "ExampleBulletB" ), 5 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer ); //owner.rangedDamage is basically the damage multiplier for ranged weapons
            }
        }

        //When you hit an NPC
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next( 2 ); 
            if ( rand == 0 ) {
                n.AddBuff( 24, 180 ); //On Fire! debuff for 3 seconds
            }
            else if ( rand == 1 ) {
                owner.statLife += 5; //Gives 5 Health
                owner.HealEffect( 5, true ); //Shows you have healed by 5 health
            }
        }

        //When the projectile hits a tile
        public override bool OnTileCollide( Vector2 velocityChange ) {
            if ( projectile.velocity.X != velocityChange.X ) {
                projectile.velocity.X = -velocityChange.X / 2; //Goes in the opposite direction with half of its x velocity
            }
            if ( projectile.velocity.Y != velocityChange.Y ) {
                projectile.velocity.Y = -velocityChange.Y / 2; //Goes in the opposite direction with half of its y velocity
            }
            return false;
        }

        //After the projectile is dead
        public override void Kill( int timeLeft ) {
            int rand = Main.rand.Next( 5 ); //Generates integers from 0 to 4
            Projectile.NewProjectile( projectile.position.X, projectile.position.Y, 0, 0, 296, (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer ); // 296 is the explosion from the Inferno Fork
        }
    }
}

