using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;

namespace Overdone.Items.Egyptian {
    public class TabletOfToth : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Tablet of Toth" );
            Tooltip.SetDefault( "The book of Toth for when you don't have papyrus" );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            item.magic = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 14 );
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.shoot = ProjectileID.UnholyArrow;
            SetStabMode();
        }

        private void SetStabMode() {
            item.damage = 10;
            item.mana = 11;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 10;
            item.autoReuse = true;
            item.noMelee = true;
            item.reuseDelay = 0;
        }

        private void SetThrowMode() {
            item.damage = 13;
            item.mana = 4;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 25f;
            item.noMelee = true;
            item.autoReuse = true;
            item.reuseDelay = 37;
            
        }

        public override bool AltFunctionUse( Player player ) => true;
        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) { // Throw mode
                SetThrowMode();
            }
            else { // Stab mode
                SetStabMode();
            }
            return true;
        }


        protected override void SetLeftClickMode() {
            throw new NotImplementedException();
        }

        protected override void SetRightClickMode() {
            throw new NotImplementedException();
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 2; i++ ) {
                Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -130, 330 ) / 150f, speedY + Main.rand.Next( -330, 130 ) / 150f, ProjectileID.UnholyArrow, damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            const float numberProjectiles = 6;
            const float rotation = (float) (1.5 * Math.PI);
            position += Vector2.Normalize( new Vector2( speedX, speedY ) ) * 45f;
            for ( int i = 0; i < numberProjectiles; i++ ) {
                Vector2 perturbedSpeed = new Vector2( speedX, speedY ).RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                Projectile.NewProjectile( position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI );
            }
            return true;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Afterlife | GodDomain.Wisdom;
    }
}