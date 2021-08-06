using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Egyptian {
    public class WasSeptreOfSet : DoubleUseDodoModItem {
        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Afterlife | GodDomain.Sun;
        

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Set's Was Septre" );
            Tooltip.SetDefault( "LMB: melee boink. RMB: Heavy havoc" );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.value = Item.sellPrice( gold: 20 );
            item.rare = ItemRarityID.Yellow;
            item.noMelee = false;
            item.noUseGraphic = false;
            ComboBuildPerHit = 2;
            base.SetDefaults();
        }
  

        public override void OnHitNPC( Player player, NPC target, int damage, float knockBack, bool crit ) {
            if ( player.altFunctionUse == 2 ) {
                target.AddBuff( BuffID.Ichor, 90 );
            }
            base.OnHitNPC( player, target, damage, knockBack, crit );
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override void SetLeftClickMode() {
            item.melee = true;
            item.magic = false;
            item.damage = 23;
            item.crit = 19;
            item.mana = 0;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 13f;
            item.UseSound = SoundID.DD2_MonkStaffSwing;
            item.shoot = default;
            item.shootSpeed = default;
            item.noMelee = false;
            item.autoReuse = true;            
        }

        protected override void SetRightClickMode() {
            item.melee = false;
            item.magic = true;
            item.damage = 35;
            item.crit = 0;
            item.mana = 1;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.DD2_FlameburstTowerShot;
            item.shoot = ModContent.ProjectileType<AhnkProjectile>();
            item.shootSpeed = 15f;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }
    }
}