using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class HarpeSwordHead : DodoModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Medusa Head";
            projectile.width = 25;
            projectile.height = 25;
            projectile.aiStyle = 8;
            projectile.penetrate = 1;
            projectile.timeLeft = 100;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.aiStyle = AiStyles.Boulder;
        }

        public override void Kill( int timeLeft ) {
            Projectile.NewProjectile( projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.Electrosphere, (int) (projectile.damage * 1.5), projectile.knockBack, Main.myPlayer );
        }
    }
}

