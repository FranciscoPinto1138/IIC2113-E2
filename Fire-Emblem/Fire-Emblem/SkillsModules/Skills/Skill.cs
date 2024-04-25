namespace Fire_Emblem;

public abstract class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    //public Object[] ConditionEffectFlux;
    public Unit unit;
    public Unit opponent;

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

public abstract class Penalty : Skill
{
    public Penalty(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}

public abstract class Hybrid : Skill
{
    public Hybrid(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}

public abstract class BonusNeutralizer : Skill
{
    public BonusNeutralizer(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}

public abstract class PenaltyNeutralizer : Skill
{
    public PenaltyNeutralizer(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.unit = unit;
        this.opponent = opponent;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}