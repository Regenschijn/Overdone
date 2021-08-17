using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class AquaKiss : DodoModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Aquatic Kiss";
            projectile.width = 24;
            projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.penetrate = 4;
            projectile.timeLeft = 100;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.5f;
        }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[projectile.owner];
                    n.AddBuff( 103, 180 ); 
            }
        
    public override void Kill( int timeLeft ) {
        Projectile.NewProjectile(
                projectile.position.X,
                projectile.position.Y,
                projectile.oldVelocity.X * 0.75f, projectile.oldVelocity.Y * 0.5f, 
                ProjectileID.WaterStream,
                (int) (projectile.damage * 1.5f),
                projectile.knockBack,
                Main.myPlayer
            );
        }
    }
}

