using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class MoralltachProjectile : DodoModProjectile {
        public override void SetDefaults() {
            projectile.width = 60;
            projectile.height = 60;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;

            aiType = 49;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.1f;
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, DustID.Copper, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 0.75f );
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            // een of ander on hit effect?
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}