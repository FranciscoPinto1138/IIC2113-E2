namespace Fire_Emblem;

public class DistantDef : Hybrid
{
    public DistantDef(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Distant Def";
        this.Description = "Si el rival inicia el combate usando magia o arco, otorga Def/Res+8 y neutraliza los bonus del rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var firstCondition = new UnitHasWeaponTypeCondition("Magic");
        var secondCondition = new UnitHasWeaponTypeCondition("Bow");
        var thirdCondition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(8, StatType.Def);
        var effectOnUnitAdditional = new IncreaseStat(8, StatType.Res);
        var neutralizeStatsOnRivalEffect = new NeutralizeBonusOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP]);
        if (!thirdCondition.IsConditionFulfilled(opponent, unit) ||
            (!firstCondition.IsConditionFulfilled(opponent, unit) &&
             !secondCondition.IsConditionFulfilled(opponent, unit))) return;
        effectOnUnit.ApplyEffect(unit, opponent);
        effectOnUnitAdditional.ApplyEffect(unit, opponent);
        neutralizeStatsOnRivalEffect.ApplyEffect(opponent, unit);
    }
}