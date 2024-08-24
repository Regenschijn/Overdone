using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class Fish1 : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Dead fish";
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 120;
            Projectile.knockBack = 2;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            base.OnHitNPC( target, damage, knockback, crit );
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 103, 660 );
            target.AddBuff( 20, 60 );
        }

    }
}

