using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class YggdrasilMedium : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lush Twig of Yggdrasil");
            Tooltip.SetDefault( "Someone tore a lush branch off of the world tree. \n LMB: Shoot leaves. RMB: Burst of leaves." );
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
        }

        private void SetThrowMode() {
            item.damage = 13;
            item.mana = 15;
            item.useTime = 25;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item56;
            item.shoot = default;
            item.shootSpeed = 20f;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool AltFunctionUse( Player player ) => true;
        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) { // Throw mode
                SetThrowMode();
             } else { // Stab mode
                SetStabMode();
            }
            return true;
        }

        public override bool Shoot( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {

            for ( var i = 0; i < 1; i++ ) {
                Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -130, 330 ) / 150f, speedY + (float)Main.rand.Next( -330, 130 ) / 150f, ProjectileID.Leaf, damage, knockBack, ((Entity)player).whoAmI, 0f, 0f );
            }

            if ( player.altFunctionUse == 2 ) {
                for ( var i = 0; i < 10; i++ ) {
                    Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -190, 590 ) / 150f, speedY + (float)Main.rand.Next( -590, 190 ) / 150f, ProjectileID.Leaf, damage, knockBack, ((Entity)player).whoAmI, 0f, 0f );
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