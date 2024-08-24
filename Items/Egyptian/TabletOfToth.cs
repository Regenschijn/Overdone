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
    public class TabletOfToth : DoubleUseOverdoneModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Tablet of Toth" );
            // Tooltip.SetDefault( "The book of Toth for when you don't have papyrus" );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( gold: 14 );
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            Item.shoot = ProjectileID.UnholyArrow;
            SetStabMode();
        }

        private void SetStabMode() {
            Item.damage = 10;
            Item.mana = 11;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 10;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.reuseDelay = 0;
        }

        private void SetThrowMode() {
            Item.damage = 13;
            Item.mana = 4;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 25f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.reuseDelay = 37;
            
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

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 2; i++ ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -130, 330 ) / 150f, velocity.Y + Main.rand.Next( -330, 130 ) / 150f, ProjectileID.UnholyArrow, damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            const float numberProjectiles = 6;
            const float rotation = (float) (1.5 * Math.PI);
            position += Vector2.Normalize( velocity ) * 45f;
            for ( int i = 0; i < numberProjectiles; i++ ) {
                Vector2 perturbedSpeed = velocity.RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI );
            }
            return true;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Afterlife | GodDomain.Wisdom;
    }
}