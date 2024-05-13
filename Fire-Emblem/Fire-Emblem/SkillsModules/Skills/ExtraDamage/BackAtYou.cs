namespace Fire_Emblem;

public class BackAtYou : ExtraDamage
{
    public BackAtYou()
    {
        this.Name = "Back at You";
        this.Description = "Si el rival inicia el combate, la unidad inflige daño extra en cada ataque = mitad del HP que la unidad ha perdido (considera solo el HP perdido hasta el combate anterior).";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new OpponentStartsCombatCondition();
        var effectOnUnit = new IncreaseExtraDamageByUnitLostHP();
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}