[System.Serializable]
public sealed class CommMissionZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 minReward;
    public System.Int32 maxReward;
    public System.Int32 reward;
    public UnityEngine.GameObject point1;
    public UnityEngine.GameObject point2;
    public UnityEngine.Material pointMaterial;
    public UnityEngine.Material highlightedPointMaterial;
    public UnityEngine.GameObject listEntry;
    public System.Boolean selected;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public CommMissionZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         minReward = (System.Int32)typeof(CommMission).GetField("minReward").GetValue(instance);
         maxReward = (System.Int32)typeof(CommMission).GetField("maxReward").GetValue(instance);
         reward = (System.Int32)typeof(CommMission).GetField("reward").GetValue(instance);
         point1 = (UnityEngine.GameObject)typeof(CommMission).GetField("point1").GetValue(instance);
         point2 = (UnityEngine.GameObject)typeof(CommMission).GetField("point2").GetValue(instance);
         pointMaterial = (UnityEngine.Material)typeof(CommMission).GetField("pointMaterial").GetValue(instance);
         highlightedPointMaterial = (UnityEngine.Material)typeof(CommMission).GetField("highlightedPointMaterial").GetValue(instance);
         listEntry = (UnityEngine.GameObject)typeof(CommMission).GetField("listEntry").GetValue(instance);
         selected = (System.Boolean)typeof(CommMission).GetField("selected").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(CommMission).GetField("minReward").SetValue(component, minReward);
         typeof(CommMission).GetField("maxReward").SetValue(component, maxReward);
         typeof(CommMission).GetField("reward").SetValue(component, reward);
         typeof(CommMission).GetField("point1").SetValue(component, point1);
         typeof(CommMission).GetField("point2").SetValue(component, point2);
         typeof(CommMission).GetField("pointMaterial").SetValue(component, pointMaterial);
         typeof(CommMission).GetField("highlightedPointMaterial").SetValue(component, highlightedPointMaterial);
         typeof(CommMission).GetField("listEntry").SetValue(component, listEntry);
         typeof(CommMission).GetField("selected").SetValue(component, selected);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}