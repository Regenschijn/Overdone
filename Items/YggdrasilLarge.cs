using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class YggdrasilLarge : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Full Twig of Yggdrasil" );
            Tooltip.SetDefault( "Someone tore a full branch off of the world tree. \n LMB: Shoot leaves. RMB: Nova blast of leaves." );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Green;
            item.noMelee = false;
            item.noUseGraphic = false;
            SetStabMode();
        }

        private void SetStabMode() {
            item.damage = 10;
            item.mana = 4;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shoot = ProjectileID.Leaf;
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
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shoot = default;
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

        public override bool Shoot( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {



            if ( player.altFunctionUse == 2 ) 
                {
                float numberProjectiles = 24;
                float rotation = MathHelper.ToRadians( 360 );
                position += Vector2.Normalize( new Vector2( speedX, speedY ) ) * 45f;
                for ( int i = 0; i < numberProjectiles; i++ ) {
                    Vector2 perturbedSpeed = new Vector2( speedX, speedY ).RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                    Projectile.NewProjectile( position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI );
                }
            }
            else {
                for ( var i = 0; i < 2; i++ ) {
                    Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -130, 330 ) / 150f, speedY + (float)Main.rand.Next( -330, 130 ) / 150f, ProjectileID.Leaf, damage, knockBack, ((Entity)player).whoAmI, 0f, 0f );
                }
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
    }
}