using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ArrowEgypt : DodoModProjectile {
        public override void SetDefaults() {
            projectile.width = 4;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.penetrate = 2;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.melee = false;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void AI() {
            base.AI();
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            base.OnHitNPC(target, damage, knockback, crit);
            Player owner = Main.player[projectile.owner];
            target.AddBuff( 20, 180 );
        }
    }
}