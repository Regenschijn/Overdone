using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone.Base;


namespace Overdone.Projectiles
{
	public class OgmiosWhipProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// This makes the projectile use whip collision detection and allows flasks to be applied to it.
			ProjectileID.Sets.IsAWhip[Type] = true;
		}

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			Projectile.DefaultToWhip();

			// use these to change from the vanilla defaults
			// Projectile.WhipSettings.Segments = 20;
			// Projectile.WhipSettings.RangeMultiplier = 1f;
		}

		private float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		private float ChargeTime {
			get => Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		// This example uses PreAI to implement a charging mechanic.
		// If you remove this, also remove Item.channel = true from the item's SetDefaults.
		public override bool PreAI() {
			Player owner = Main.player[Projectile.owner];

			// Like other whips, this whip updates twice per frame (Projectile.extraUpdates = 1), so 120 is equal to 1 second.
			if (!owner.channel || ChargeTime >= 120) {
				return true; // Let the vanilla whip AI run.
			}

			if (++ChargeTime % 12 == 0) // 1 segment per 12 ticks of charge.
				Projectile.WhipSettings.Segments++;

			// Increase range up to 2x for full charge.
			Projectile.WhipSettings.RangeMultiplier += 1 / 60f;

			// Reset the animation and item timer while charging.
			owner.itemAnimation = owner.itemAnimationMax;
			owner.itemTime = owner.itemTimeMax;

			return false; // Prevent the vanilla whip AI from running.
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
			base.OnHitNPC( target, damage, knockback, crit );
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 24, 660 );
		}

		// This method draws a line between all points of the whip, in case there's empty space between the sprites.
		private void DrawLine(List<Vector2> list) {
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);

			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++) {
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

				pos += diff;
			}
		}
		
		public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.1f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Lava, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }

		public override bool PreDraw(ref Color lightColor) {
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			//Main.DrawWhip_WhipBland(Projectile, list);
			// The code below is for custom drawing.
			// If you don't want that, you can remove it all and instead call one of vanilla's DrawWhip methods, like above.
			// However, you must adhere to how they draw if you do.

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 pos = list[0];

			for (int i = 0; i < list.Count - 1; i++) {
				// These two values are set to suit this projectile's sprite, but won't necessarily work for your own.
				// You can change them if they don't!
				Rectangle frame = new Rectangle(0, 0, 10, 26);
				Vector2 origin = new Vector2(5, 8);
				float scale = 1;

				// These statements determine what part of the spritesheet to draw for the current segment.
				// They can also be changed to suit your sprite.
				if (i == list.Count - 2) {
					frame.Y = 74;
					frame.Height = 18;

					// For a more impactful look, this scales the tip of the whip up when fully extended, and down when curled up.
					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10) {
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5) {
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0) {
					frame.Y = 26;
					frame.Height = 16;
				}

				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2; // This projectile's sprite faces down, so PiOver2 is used to correct rotation.
				Color color = Lighting.GetColor(element.ToTileCoordinates());

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

				pos += diff;
			}
			return false;
		}
	}
}