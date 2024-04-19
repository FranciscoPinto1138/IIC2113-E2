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
    public Stats unitCombatStats;
    public Stats opponentCombatStats;

    public Skill(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats)
    {
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
        this.unitCombatStats = unitCombatStats;
        this.opponentCombatStats = opponentCombatStats;
    }
    public abstract void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats);
}

public abstract class Bonus : Skill
{
    public Bonus(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName, Stats unitCombatStats, Stats opponentCombatStats) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName, unitCombatStats, opponentCombatStats)
    {
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
        this.unitCombatStats = unitCombatStats;
        this.opponentCombatStats = opponentCombatStats;
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent, Stats unitCombatStats, Stats opponentCombatStats)
    {
        throw new NotImplementedException();
    }
}