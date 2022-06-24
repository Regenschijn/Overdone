using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Greek {
    public class RodOfAsclepius : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Rod of Asclepius " );
            Tooltip.SetDefault( "LMB: Shoot venom. Every 10 combo decreases mana cost by 1. RMB: Create an aura that inflicts poison and gives hp regen to allies." );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( gold: 5 );
            Item.rare = ItemRarityID.Orange;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.autoReuse = true;
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode () {
            Item.damage = 31;
            Item.mana = 20;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.DD2_OgreSpit;
            Item.shoot = ModContent.ProjectileType<PoisonFang>();
            Item.shootSpeed = 20f;
            Item.noMelee = true;
            Item.reuseDelay = 25;
            Item.mana = (int) (20 - ComboManager.Combo / 10);
        }

        
        protected override void SetRightClickMode() {
            Item.damage = 0;
            Item.mana = 20;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item42;
            Item.shoot = ModContent.ProjectileType<PoisonAura>();
            Item.shootSpeed = 4f;
            Item.noMelee = true;
            Item.reuseDelay = 50;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
            ref int damage, ref float knockBack ) {
            Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, velocity.X * 1.85f, velocity.Y * 1.85f, ModContent.ProjectileType<PoisonFang>(), (int)(damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
            SoundEngine.PlaySound( SoundID.Item45, player.position );
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type,
            ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 10 ) )
                Projectile.NewProjectile( player.GetSource_FromAI(), player.Center, new Vector2( 0f, 0f ), ModContent.ProjectileType<PoisonAura>(), 0, 0f, player.whoAmI );;
            return false;       

        }

      

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        public override Vector2? HoldoutOffset() => new Vector2( -1, -1 );
        
        
        
        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            base.UseStyle( player, heldItemFrame );
        }

        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Healing;
    }
}