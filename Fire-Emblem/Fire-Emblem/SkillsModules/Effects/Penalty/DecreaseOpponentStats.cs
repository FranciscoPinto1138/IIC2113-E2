namespace Fire_Emblem;

public class DecreaseOpponentStats : PenaltyEffect
{
    private StatTypeList _bufferedStatsList;
    private ChangeFactorList _changeFactorsList;
    
    public DecreaseOpponentStats(StatTypeList bufferedStatsList, ChangeFactorList changeFactorsList)
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
                    opponent.PenaltyStatsDiff.Atk -= _changeFactorsList[i];
                    break;
                case StatType.Spd:
                    opponent.PenaltyStatsDiff.Spd -= _changeFactorsList[i];
                    break;
                case StatType.Def:
                    opponent.PenaltyStatsDiff.Def -= _changeFactorsList[i];
                    break;
                case StatType.Res:
                    opponent.PenaltyStatsDiff.Res -= _changeFactorsList[i];
                    break;
            }
        }
    }
}