namespace Fire_Emblem;

public abstract class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    //public Object[] ConditionEffectFlux;
    public Unit unit;
    public Unit opponent;
    public string firstPlayerOfRoundName;
    public string secondPlayerOfRoundName;

    public Skill(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName)
    {
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
    }
    public abstract void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent);
}

public abstract class Bonus : Skill
{
    public Bonus(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName)
    {
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }

    public abstract void RemoveEffectsAfterCombat(Unit unit, Unit opponent);
}