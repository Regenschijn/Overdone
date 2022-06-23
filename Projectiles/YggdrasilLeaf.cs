using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class YggdrasilLeaf : DodoModProjectile {
        public override void SetDefaults() {
            var proj = Projectile;
            proj.width = 14;
            proj.height = 14;
            proj.aiStyle = 1;
            proj.friendly = true;
            proj.DamageType = DamageClass.Throwing;
            proj.penetrate = 1;
            proj.timeLeft = 300;
            AIType = 0;            
        }

        public override void Kill( int timeLeft ) {
            Projectile proj = Projectile;
            for ( var i = 0; i < 10; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.Everscream,
                    proj.velocity.X * 0.11f, proj.velocity.Y * 0.11f, 125, Color.White );
            }
        }

        public override bool OnTileCollide( Vector2 oldVelocity ) {
            Projectile.Kill();
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }
    }
}