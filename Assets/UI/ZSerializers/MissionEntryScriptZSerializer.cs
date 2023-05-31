[System.Serializable]
public sealed class MissionEntryScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject mission;
    public UnityEngine.GameObject missionDetailsWindow;
    public MissionSystem missionSystem;
    public System.String missionType;
    public UnityEngine.UI.Text detailsType;
    public UnityEngine.UI.Text detailsDesc;
    public UnityEngine.UI.Text detailsReward;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public MissionEntryScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         mission = (UnityEngine.GameObject)typeof(MissionEntryScript).GetField("mission").GetValue(instance);
         missionDetailsWindow = (UnityEngine.GameObject)typeof(MissionEntryScript).GetField("missionDetailsWindow").GetValue(instance);
         missionSystem = (MissionSystem)typeof(MissionEntryScript).GetField("missionSystem").GetValue(instance);
         missionType = (System.String)typeof(MissionEntryScript).GetField("missionType").GetValue(instance);
         detailsType = (UnityEngine.UI.Text)typeof(MissionEntryScript).GetField("detailsType").GetValue(instance);
         detailsDesc = (UnityEngine.UI.Text)typeof(MissionEntryScript).GetField("detailsDesc").GetValue(instance);
         detailsReward = (UnityEngine.UI.Text)typeof(MissionEntryScript).GetField("detailsReward").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(MissionEntryScript).GetField("mission").SetValue(component, mission);
         typeof(MissionEntryScript).GetField("missionDetailsWindow").SetValue(component, missionDetailsWindow);
         typeof(MissionEntryScript).GetField("missionSystem").SetValue(component, missionSystem);
         typeof(MissionEntryScript).GetField("missionType").SetValue(component, missionType);
         typeof(MissionEntryScript).GetField("detailsType").SetValue(component, detailsType);
         typeof(MissionEntryScript).GetField("detailsDesc").SetValue(component, detailsDesc);
         typeof(MissionEntryScript).GetField("detailsReward").SetValue(component, detailsReward);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}