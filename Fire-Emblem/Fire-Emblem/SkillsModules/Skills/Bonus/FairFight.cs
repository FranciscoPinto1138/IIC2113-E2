namespace Fire_Emblem;

public class FairFight : Bonus
{
    public FairFight(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName)
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
        //var conditions = new List<Condition> { new UnitStartsCombatCondition() };
        //var effects = new List<Effect> { new IncreaseAtk(6) };
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseAtk(6);
        var effectOnOpponent = new IncreaseAtk(6);
        if (condition.IsConditionFulfilled(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnOpponent.ApplyEffect(opponent, unit);
        }
    }

    public override void RemoveEffectsAfterCombat(Unit unit, Unit opponent)
    {
        var effectOnUnit = new IncreaseAtk(6);
        var effectOnOpponent = new IncreaseAtk(6);
        effectOnUnit.RemoveEffect(unit, opponent);
        effectOnOpponent.RemoveEffect(opponent, unit);
    }
}