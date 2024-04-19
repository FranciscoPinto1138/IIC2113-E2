namespace Fire_Emblem;

public abstract class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    //public Object[] ConditionEffectFlux;
    public Unit unit;
    public Unit opponent;
    public Stats unitCombatStats;
    public Stats opponentCombatStats;

    public Skill(Unit unit, Unit opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    public abstract void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent);
}

public abstract class Bonus : Skill
{
    public Bonus(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}