using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class MoralltachProjectile : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.aiStyle = 19;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 10;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;

            AIType = 49;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.1f;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Copper, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 0.75f );
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            // een of ander on hit effect?
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}