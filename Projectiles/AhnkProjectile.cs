using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class AhnkProjectile : DodoModProjectile {
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
            projectile.rotation += (float) projectile.direction * 0.5f;
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 0.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; //Makes dust not fall
        }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[projectile.owner];
            var rand = Main.rand.Next( 2 );
            switch ( rand ) {
                case 0:
                    n.AddBuff( 24, 180 ); //On Fire! debuff for 3 seconds
                    break;
                case 1:
                    owner.statLife += 5; //Gives 5 Health
                    owner.HealEffect( 5, true ); //Shows you have healed by 5 health
                    break;
            }
            base.OnHitNPC(n, damage, knockback, crit);
        }
        //After the projectile is dead
        public override void Kill( int timeLeft ) {            
            Projectile.NewProjectile(
                projectile.position.X,
                projectile.position.Y,
                projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 
                ModContent.ProjectileType<AhnkTinyProjectile>(),
                (int) (projectile.damage * 1.5f),
                projectile.knockBack,
                Main.myPlayer
            );
        }
    }
}

