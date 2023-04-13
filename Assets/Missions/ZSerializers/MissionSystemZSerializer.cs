[System.Serializable]
public sealed class MissionSystemZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 newMissionTime;
    public UnityEngine.GameObject commMissionPrefab;
    public UnityEngine.GameObject imageMissionPrefab;
    public UnityEngine.GameObject grappleMissionPrefab;
    public UnityEngine.GameObject commMissionBucket;
    public UnityEngine.GameObject imageMissionBucket;
    public UnityEngine.GameObject grappleMissionBucket;
    public UnityEngine.GameObject missionListEntryPrefab;
    public UnityEngine.GameObject missionList;
    public UnityEngine.GameObject missionDetailsWindow;
    public UnityEngine.GameObject grappleTargetDetailsWindow;
    public System.Collections.Generic.List<System.String> targetNames;
    public UnityEngine.GameObject grappleTargetPrefab;
    public System.Boolean commOnly;
    public System.Boolean imageOnly;
    public System.Boolean grappleOnly;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public MissionSystemZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         newMissionTime = (System.Int32)typeof(MissionSystem).GetField("newMissionTime").GetValue(instance);
         commMissionPrefab = (UnityEngine.GameObject)typeof(MissionSystem).GetField("commMissionPrefab").GetValue(instance);
         imageMissionPrefab = (UnityEngine.GameObject)typeof(MissionSystem).GetField("imageMissionPrefab").GetValue(instance);
         grappleMissionPrefab = (UnityEngine.GameObject)typeof(MissionSystem).GetField("grappleMissionPrefab").GetValue(instance);
         commMissionBucket = (UnityEngine.GameObject)typeof(MissionSystem).GetField("commMissionBucket").GetValue(instance);
         imageMissionBucket = (UnityEngine.GameObject)typeof(MissionSystem).GetField("imageMissionBucket").GetValue(instance);
         grappleMissionBucket = (UnityEngine.GameObject)typeof(MissionSystem).GetField("grappleMissionBucket").GetValue(instance);
         missionListEntryPrefab = (UnityEngine.GameObject)typeof(MissionSystem).GetField("missionListEntryPrefab").GetValue(instance);
         missionList = (UnityEngine.GameObject)typeof(MissionSystem).GetField("missionList").GetValue(instance);
         missionDetailsWindow = (UnityEngine.GameObject)typeof(MissionSystem).GetField("missionDetailsWindow").GetValue(instance);
         grappleTargetDetailsWindow = (UnityEngine.GameObject)typeof(MissionSystem).GetField("grappleTargetDetailsWindow").GetValue(instance);
         targetNames = (System.Collections.Generic.List<System.String>)typeof(MissionSystem).GetField("targetNames").GetValue(instance);
         grappleTargetPrefab = (UnityEngine.GameObject)typeof(MissionSystem).GetField("grappleTargetPrefab").GetValue(instance);
         commOnly = (System.Boolean)typeof(MissionSystem).GetField("commOnly").GetValue(instance);
         imageOnly = (System.Boolean)typeof(MissionSystem).GetField("imageOnly").GetValue(instance);
         grappleOnly = (System.Boolean)typeof(MissionSystem).GetField("grappleOnly").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(MissionSystem).GetField("newMissionTime").SetValue(component, newMissionTime);
         typeof(MissionSystem).GetField("commMissionPrefab").SetValue(component, commMissionPrefab);
         typeof(MissionSystem).GetField("imageMissionPrefab").SetValue(component, imageMissionPrefab);
         typeof(MissionSystem).GetField("grappleMissionPrefab").SetValue(component, grappleMissionPrefab);
         typeof(MissionSystem).GetField("commMissionBucket").SetValue(component, commMissionBucket);
         typeof(MissionSystem).GetField("imageMissionBucket").SetValue(component, imageMissionBucket);
         typeof(MissionSystem).GetField("grappleMissionBucket").SetValue(component, grappleMissionBucket);
         typeof(MissionSystem).GetField("missionListEntryPrefab").SetValue(component, missionListEntryPrefab);
         typeof(MissionSystem).GetField("missionList").SetValue(component, missionList);
         typeof(MissionSystem).GetField("missionDetailsWindow").SetValue(component, missionDetailsWindow);
         typeof(MissionSystem).GetField("grappleTargetDetailsWindow").SetValue(component, grappleTargetDetailsWindow);
         typeof(MissionSystem).GetField("targetNames").SetValue(component, targetNames);
         typeof(MissionSystem).GetField("grappleTargetPrefab").SetValue(component, grappleTargetPrefab);
         typeof(MissionSystem).GetField("commOnly").SetValue(component, commOnly);
         typeof(MissionSystem).GetField("imageOnly").SetValue(component, imageOnly);
         typeof(MissionSystem).GetField("grappleOnly").SetValue(component, grappleOnly);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}