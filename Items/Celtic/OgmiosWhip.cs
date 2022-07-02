using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Items;

namespace Overdone.Items.Celtic
{
	public class OgmiosWhip : DoubleUseDodoModItem
	{
		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<OgmiosWhipProjectile>(), 15, 2, 2); 

			Item.shootSpeed = 2;
			Item.rare = ItemRarityID.Green;

			Item.channel = true;
            base.SetDefaults();
        }
        protected override void SetLeftClickMode() {
            Item.channel = true;
        }
        protected override void SetRightClickMode() {
            Item.channel = false;
        }
        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
    ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
            ref int damage, ref float knockBack ) {
            return true;
        }

        protected override Mythology Mythology => Mythology.Celtic;
        protected override GodDomain GodDomain => GodDomain.Sun;
    }

}