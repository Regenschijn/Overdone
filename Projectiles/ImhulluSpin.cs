using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ImhulluSpin : DodoModProjectile {

        public override void SetDefaults() {
            Projectile.Size = new Vector2( 80 );
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 10;
            Projectile.tileCollide = false;
        }        

        public override void AI() {            
            var player = Main.player[Projectile.owner];
            if ( !player.channel )
                Projectile.Kill();

            Projectile.direction = player.direction;
            Projectile.position = player.position + new Vector2( 50f*player.direction, -20f );
            Projectile.rotation += 1f;            
        }
    }
}

