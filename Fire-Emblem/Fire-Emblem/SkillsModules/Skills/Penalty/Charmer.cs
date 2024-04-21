namespace Fire_Emblem;

public class Charmer : Penalty
{
    public Charmer(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Charmer";
        this.Description = "En un combate contra un rival que también es el oponente más reciente de la unidad, inflige Atk/Spd-3 en ese rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new OpponentIsMostRecentRivalOfUnitCondition();
        var effectOnOpponent = new DecreaseStat(3, StatType.Spd);
        var effectOnOpponentAdditional = new DecreaseStat(3, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnOpponent.ApplyEffect(opponent, unit);
            effectOnOpponentAdditional.ApplyEffect(opponent, unit);
        }
    }
}