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
    public class ApolloBlast : OverdoneModProjectile {
        public override void SetDefaults() {
            var proj = Projectile;
            proj.width = 8;
            proj.height = 10;
            proj.aiStyle = 8;
            proj.friendly = true;
            proj.DamageType = DamageClass.Magic;
            proj.penetrate = 1;
            proj.timeLeft = 300;
            AIType = 1;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.9f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.BubbleBurst_White, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }
        
        public override void Kill( int timeLeft ) {
            Projectile proj = Projectile;
            for ( var i = 0; i < 10; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.FireworkFountain_Red,
                    proj.velocity.X * 0.2f, proj.velocity.Y * 0.2f, 125, Color.Gold );
            }
        }

        public override bool OnTileCollide( Vector2 oldVelocity ) {
            Projectile.Kill();
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }
    }
}