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
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            SetStabMode();
        }

        private void SetStabMode() {
            Item.damage = 10;
            Item.mana = 4;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shoot = ProjectileID.Leaf;
            Item.shootSpeed = 20f;
            Item.autoReuse = true;
            Item.noMelee = true;
        }

        private void SetThrowMode() {
            Item.damage = 13;
            Item.mana = 15;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 15f;
            Item.UseSound = SoundID.Item2;
            Item.shoot = ProjectileID.Leaf;
            Item.noMelee = true;
            Item.autoReuse = true;
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
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }
    }
}