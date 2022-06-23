using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Mounts
{
	public class Chariot : ModMount
	{
		public override void SetStaticDefaults() {
			MountData.spawnDust = DustID.Cloud;
			MountData.buff = ModContent.BuffType<Buffs.ChariotMount>();
			MountData.heightBoost = 20;
			MountData.fallDamage = 0.5f;
			MountData.runSpeed = 11f;
			MountData.dashSpeed = 8f;
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 0;
			MountData.jumpHeight = 5;
			MountData.acceleration = 0.19f;
			MountData.jumpSpeed = 4f;
			MountData.blockExtraJumps = false;
			MountData.totalFrames = 4;
			MountData.constantJump = true;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++) {
				array[l] = 20;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 13;
			MountData.bodyFrame = 3;
			MountData.yOffset = -12;
			MountData.playerHeadOffset = 22;
			MountData.standingFrameCount = 4;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 12;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 4;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server) {
				return;
			}

            MountData.textureWidth = MountData.backTexture.Width;
			MountData.textureHeight = MountData.backTexture.Height;
            
        }

		public override void UpdateEffects(Player player) {

			// This code spawns some dust if we are moving fast enough.
			if (!(Math.Abs(player.velocity.X) > 4f)) {
				return;
			}
			Rectangle rect = player.getRect();
			// Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, DustID.fartfartfart());
		}

		// Since only a single instance of ModMountData ever exists, we can use player.mount._mountSpecificData to store additional data related to a specific mount.
		// Using something like this for gameplay effects would require ModPlayer syncing, but this example is purely visual.
		
		public override void SetMount(Player player, ref bool skipDust) {
			// This code bypasses the normal mount spawning dust and replaces it with our own visual.
			for (int i = 0; i < 16; i++) {
				Dust.NewDustPerfect(player.Center + new Vector2(80, 0).RotatedBy(i * Math.PI * 2 / 16f), MountData.spawnDust);
			}
			skipDust = true;
		}
    }
}