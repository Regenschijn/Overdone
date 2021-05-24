using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;

namespace Overdone.Items.Norse {
    public class YggdrasilSmall : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Twig of Yggdrasil");
            Tooltip.SetDefault( "Someone tore a branch off of the world tree. \n LMB: Shoot leaves. RMB: Take a bite of world tree wood for HP/MP regen" );
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
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
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

        protected override void SetRightClickMode() {
            item.damage = 5;
            item.mana = 15;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item2;
            item.shoot = ProjectileID.Seed;
            item.shootSpeed = 5f;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( player.HasBuff( BuffID.Regeneration ) && player.HasBuff( BuffID.ManaRegeneration ) ) {

            } else {
                player.AddBuff( BuffID.Regeneration, 900 );
                player.AddBuff( BuffID.ManaRegeneration, 900 );
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