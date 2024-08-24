using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class HarpeSwordHead : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Medusa Head";
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.aiStyle = 8;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 100;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = AiStyles.Boulder;
        }

        public override void OnKill( int timeLeft ) {
            Projectile.NewProjectile( Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ProjectileID.Electrosphere, (int) (Projectile.damage * 1.5), Projectile.knockBack, Main.myPlayer );
        }
    }
}

