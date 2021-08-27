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

namespace Overdone.Items.Roman {
    public class NeptunesKiss : DoubleUseDodoModItem {
        private int _counter;        

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Neptunes Kiss" );
            Tooltip.SetDefault( "Neptunes Trident \n LMB: Stabs. Every 5th hit is a quick smack. \n RMB: Shoot Neptunes Kiss \n every something, something happens" );
        }

        public override void SetDefaults() {
            item.damage = 24;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 15;
            item.value = 10000;
            item.crit = 7;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 10;
            item.mana = 0;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 10;
            item.autoReuse = true;
            item.noMelee = false;
            item.crit = (int) (7 + (ComboManager.Combo / 25f));
        }

        protected override void SetRightClickMode() {
            item.damage = 13;
            item.mana = 10;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 12f;
            item.noMelee = true;
            item.autoReuse = true;
            item.reuseDelay = 37;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {            
            _counter++;
            if ( _counter < 5 )
                return false;

            for ( var i = 0; i < 3; i++ ) {
                item.damage = damage + 25;
                item.useStyle = ItemUseStyleID.SwingThrow;
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {

            Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -30, 30 ) / 150f, speedY + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<AquaKiss>(), damage, knockBack, player.whoAmI, 0f, 0f );

            return true;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Roman;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}