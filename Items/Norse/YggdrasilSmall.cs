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

namespace Overdone.Items.Norse {
    public class YggdrasilSmall : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Twig of Yggdrasil");
            Tooltip.SetDefault( "Someone tore a branch off of the world tree. \n LMB: Shoot leaves. RMB: Take a bite of world tree wood for HP/MP regen" );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            UseCombo = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 10;
            Item.mana = 4;
            Item.thrown = false/* tModPorter Suggestion: Remove. See Item.DamageType */;

            Item.shootSpeed = 20f;
            Item.useTime = 20;
            Item.useAnimation = 20;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shoot = ModContent.ProjectileType<YggdrasilLeaf>();

            Item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            Item.damage = 5;
            Item.mana = 15;
            Item.DamageType = DamageClass.Throwing;

            Item.shootSpeed = 5f;
            Item.useTime = 50;
            Item.useAnimation = 50;

            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item2;
            Item.shoot = ProjectileID.Seed;

            

            Item.autoReuse = true;
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
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }
        
        protected override Mythology Mythology => Mythology.Norse;
        protected override GodDomain GodDomain => GodDomain.Creation;
    }
}