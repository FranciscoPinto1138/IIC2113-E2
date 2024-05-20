namespace Fire_Emblem;

public class DecreaseStats : PenaltyEffect
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public DecreaseStats(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
    {
        _bufferedStatsList = bufferedStatsList;
        _changeFactorsList = changeFactorsList;
        this.SetPriority(1);
    }
    
    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        for (int i = 0; i < _bufferedStatsList.Count; i++)
        {
            switch (_bufferedStatsList[i])
            {
                case StatType.Atk:
                    unit.PenaltyStatsDiff.Atk -= _changeFactorsList[i];
                    break;
                case StatType.Spd:
                    unit.PenaltyStatsDiff.Spd -= _changeFactorsList[i];
                    break;
                case StatType.Def:
                    unit.PenaltyStatsDiff.Def -= _changeFactorsList[i];
                    break;
                case StatType.Res:
                    unit.PenaltyStatsDiff.Res -= _changeFactorsList[i];
                    break;
            }
        }
    }
}