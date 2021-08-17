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
using Overdone.Projectiles;

namespace Overdone.Items.Egyptian {
    public class BowOfAnhur : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Bow of Anhur" );
            Tooltip.SetDefault( "LMB: Shoot 3 poison arrows \n RMB: shoot more arrows in an unconventional way" );
        }

        public override void SetDefaults() {
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 14 );
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 2;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 10;
            item.autoReuse = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            item.damage = 13;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 25f;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 3 ) ) {
                const float numberProjectiles = 7;
                const float rotation = (float)(0.7 * Math.PI);
                position += Vector2.Normalize( new Vector2( speedX, speedY ) ) * 45f;

                for ( int i = 0; i < numberProjectiles; i++ ) {
                    Vector2 perturbedSpeed = new Vector2( speedX, speedY ).RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                    Projectile.NewProjectile( position.X, position.Y, perturbedSpeed.X * 2.5f, perturbedSpeed.Y * 2.5f, type, damage, knockBack, player.whoAmI );
                }
            }
            return false;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Hunting;
    }
}