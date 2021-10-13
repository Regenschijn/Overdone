using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ArrowApollo : DodoModProjectile {
        public override void SetDefaults() {
            projectile.width = 4;
            projectile.height = 20;
            projectile.aiStyle = 0;
            projectile.penetrate = 2;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.melee = false;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.2f;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, DustID.BubbleBurst_White, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            base.OnHitNPC(target, damage, knockback, crit);
            Player owner = Main.player[projectile.owner];
            target.AddBuff( 20, 180 );
        }
    }
}