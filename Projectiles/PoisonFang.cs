using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class PoisonFang : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.width = 4;
            Projectile.height = 20;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 90;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Generic;
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            base.OnHitNPC(target, damage, knockback, crit);
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 20, 660 );
        }
    }
}