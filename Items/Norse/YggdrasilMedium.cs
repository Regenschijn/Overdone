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
    public class YggdrasilMedium : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Lush Twig of Yggdrasil" );
            Tooltip.SetDefault( "Someone tore a lush branch off of the world tree. \n LMB: Shoot leaves. RMB: Burst of leaves." );
        }


        public override void SetDefaults() {
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Green;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.shoot = ModContent.ProjectileType<YggdrasilLeaf>();
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 10;
            Item.mana = 4;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 18f;
            Item.autoReuse = true;
            Item.noMelee = true;
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.mana = 15;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item56;
            Item.shootSpeed = 20f;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 2; i++ ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -130, 330 ) / 150f, velocity.Y + Main.rand.Next( -330, 130 ) / 150f, ModContent.ProjectileType<YggdrasilLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 10; i++ ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -190, 590 ) / 150f, velocity.Y + Main.rand.Next( -590, 190 ) / 150f, ModContent.ProjectileType<YggdrasilLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return false;
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