using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class BasketBlast : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Flower Basket Blast";
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 0;
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
            Projectile.light = 0.1f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.JungleGrass, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true;
        }

    }
}

