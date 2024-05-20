namespace Fire_Emblem;

public class BlindingFlash : Skill
{
    public BlindingFlash()
    {
        this.Name = "Blinding Flash";
        this.Description = "Si la unidad inicia el combate, inflige Spd-4 en el rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(new UnitStartsCombatCondition(), 
                new DecreaseOpponentStats([StatType.Spd], [4])) };
    }
}