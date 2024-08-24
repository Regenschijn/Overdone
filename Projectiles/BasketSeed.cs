using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class BasketSeed : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Flower Basket Blast";
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
        
        public override void Kill( int timeLeft ) {
            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.position.X,
                Projectile.position.Y,
                0, 0,
                ProjectileID.InfernoFriendlyBlast,
                (int) (Projectile.damage * 1.1f),
                Projectile.knockBack,
                Main.myPlayer
            );
        }

    }
}

