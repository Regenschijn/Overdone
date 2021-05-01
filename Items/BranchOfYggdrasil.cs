using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class BranchOfYggdrasil : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("branch of Yggdrasil");
            Tooltip.SetDefault( "Someone tore a branch off of the world tree. \n LMB: Shoot leaves. RMB: melee attack that restores health and mana" );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Blue;
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
            item.shootSpeed = 20f;
            item.autoReuse = true;
            item.noMelee = true;
        }

        private void SetThrowMode() {
            item.damage = 13;
            item.mana = 15;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 12f;
            item.UseSound = SoundID.Item2;
            item.shoot = ProjectileID.CrystalLeaf;
            item.healLife = 3;
            item.noMelee = false;
            item.autoReuse = true;
        }

        public override bool AltFunctionUse( Player player ) => true;
        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) { // Throw mode
                if ( player.HasBuff( BuffID.Regeneration ) && player.HasBuff( BuffID.ManaRegeneration ) ) {

                }
                else {
                    player.AddBuff( BuffID.Regeneration, 900 );
                    player.AddBuff( BuffID.ManaRegeneration, 900 );
                }
                SetThrowMode();
             } else { // Stab mode
                SetStabMode();
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