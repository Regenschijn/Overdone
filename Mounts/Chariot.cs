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
	public class Chariot : ModMountData
	{
		public override void SetDefaults() {
			mountData.spawnDust = DustID.Cloud;
			mountData.buff = ModContent.BuffType<Buffs.ChariotMount>();
			mountData.heightBoost = 20;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 11f;
			mountData.dashSpeed = 8f;
			mountData.flightTimeMax = 0;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 5;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 4f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 4;
			mountData.constantJump = true;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++) {
				array[l] = 20;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 13;
			mountData.bodyFrame = 3;
			mountData.yOffset = -12;
			mountData.playerHeadOffset = 22;
			mountData.standingFrameCount = 4;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 4;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 4;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server) {
				return;
			}

            mountData.textureWidth = mountData.textureHeight;
			mountData.textureHeight = mountData.textureWidth;
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
				Dust.NewDustPerfect(player.Center + new Vector2(80, 0).RotatedBy(i * Math.PI * 2 / 16f), mountData.spawnDust);
			}
			skipDust = true;
		}
    }
}