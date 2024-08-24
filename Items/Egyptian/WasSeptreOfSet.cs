using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Egyptian {
    public class WasSeptreOfSet : DoubleUseOverdoneModItem {
        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Afterlife | GodDomain.Sun;
        

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Set's Was Septre" );
            // Tooltip.SetDefault( "LMB: melee boink. RMB: Heavy havoc" );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 70;
            Item.height = 70;
            Item.value = Item.sellPrice( gold: 20 );
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }
  

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            if ( player.altFunctionUse == 2 ) {
                target.AddBuff( BuffID.Ichor, 90 );
            }
            base.OnHitNPC( player, target, damage, knockBack, crit );
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override void SetLeftClickMode() {
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.damage = 33;
            Item.crit = 19;
            Item.mana = 0;
            Item.useTime = 33;
            Item.useAnimation = 33;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 13f;
            Item.UseSound = SoundID.DD2_MonkStaffSwing;
            Item.shoot = default;
            Item.shootSpeed = default;
            Item.noMelee = false;
            Item.autoReuse = true;
            ComboBuildPerHit = 3;
        }

        protected override void SetRightClickMode() {
            Item.DamageType = DamageClass.Magic;
            Item.damage = 35;
            Item.crit = 0;
            Item.mana = 20;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.DD2_FlameburstTowerShot;
            Item.shoot = ModContent.ProjectileType<AhnkProjectile>();
            Item.shootSpeed = 15f;
            Item.noMelee = true;
            Item.autoReuse = true;
            ComboBuildPerHit = 0;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }
    }
}