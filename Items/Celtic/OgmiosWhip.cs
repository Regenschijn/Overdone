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
	public class OgmiosWhip : DoubleUseOverdoneModItem
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
            Item.DefaultToWhip( ModContent.ProjectileType<OgmiosWhipProjectile>(), 15, 2, 2 );
            Item.autoReuse = true;
        }
        protected override void SetRightClickMode() {
            Item.damage = (int)(20 + (ComboManager.Combo / 25f));
            Item.mana = 0;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 2f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.reuseDelay = 0;
            Item.shoot = ModContent.ProjectileType<InvictusBolt>();
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