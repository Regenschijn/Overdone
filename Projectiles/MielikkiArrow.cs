using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class MielikkiArrow : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Mielikki Arrow";
            Projectile.width = 4;
            Projectile.height = 20;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 75;
            Projectile.knockBack = 1;

            ProjectileID.Sets.TrailingMode[Type] = 0;
            ProjectileID.Sets.TrailCacheLength[Type] = 20;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            UseCombo = true;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0f;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Water_Jungle, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true;
            if ( Projectile.velocity != Vector2.Zero ) {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
        }
        public override void OnKill( int timeLeft ) {
            Projectile proj = Projectile;
            for ( var i = 0; i < 20; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.Grass,
                    proj.velocity.X * 0.9f, proj.velocity.Y * 0.9f, 125, Color.Green );
            }
            var explosionArea = 200;
            _ = Projectile.Size;
            // Resize the projectile hitbox to be bigger.
            Projectile.position = Projectile.Center;
            Projectile.Size += new Vector2( explosionArea );
            Projectile.Center = Projectile.position;
            Projectile.maxPenetrate = -1;
            Projectile.penetrate = -1;

            Projectile.tileCollide = false;
            Projectile.velocity *= 0.01f;
            // Damage enemies inside the hitbox area
            Projectile.Damage();
            Projectile.scale = 0.01f;

            //Resize the hitbox to its original size
            //Projectile.position = Projectile.Center;
            //Projectile.Size = new Vector2( 10 );
            //Projectile.Center = Projectile.position;

            for ( int i = 0; i < 50; i++ ) {
                int dustIndex = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y ), Projectile.width, Projectile.height, DustID.Grass, 0f, 0f, 100, default( Color ), 2f );
                Main.dust[dustIndex].velocity *= 1.4f;
            }

        }
    }
}

