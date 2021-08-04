using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Greek {
    public class RodOfAsclepius : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Rod of Asclepius " );
            Tooltip.SetDefault( "LMB: Shoot venom. Every 10 combo decreases mana cost by 1. RMB: Create an aura that inflicts poison and gives hp regen to allies." );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 5 );
            item.rare = ItemRarityID.Orange;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.autoReuse = true;
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode () {
            item.damage = 31;
            item.mana = 20;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item79;
            item.shoot = ProjectileID.PoisonFang;
            item.noMelee = true;
            item.reuseDelay = 25;
            item.mana = (int) (20 - ComboManager.Combo / 10);
        }

        
        protected override void SetRightClickMode() {
            item.damage = 0;
            item.mana = 20;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item42;
            item.shoot = ModContent.ProjectileType<PoisonAura>();
            item.shootSpeed = 4f;
            item.noMelee = true;
            item.reuseDelay = 50;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ProjectileID.PoisonFang, (int)(damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
            Main.PlaySound( SoundID.Item45, player.position );
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 10 ) )
                Projectile.NewProjectile( ((Entity)player). Center, new Vector2( 0f, 0f ), ModContent.ProjectileType<PoisonAura>(), 0, 0f, ((Entity)player).whoAmI, 0f, 0f );;
            return false;       

        }

      

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() => new Vector2( -1, -1 );
        
        
        
        public override void UseStyle( Player player ) {
            base.UseStyle( player );
        }

        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Healing;
    }
}