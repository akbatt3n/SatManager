[System.Serializable]
public sealed class GrappleMissionZSerializer : ZSerializer.Internal.ZSerializer
{
    public Satellite target;
    public UnityEngine.GameObject targetObj;
    public UnityEngine.GameObject targetPrefab;
    public UnityEngine.GameObject msysObj;
    public System.Single minAlt;
    public System.Single maxAlt;
    public System.Int32 reward;
    public UnityEngine.Material pointMaterial;
    public UnityEngine.Material highlightedPointMaterial;
    public UnityEngine.GameObject listEntry;
    public System.Boolean selected;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public GrappleMissionZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         target = (Satellite)typeof(GrappleMission).GetField("target").GetValue(instance);
         targetObj = (UnityEngine.GameObject)typeof(GrappleMission).GetField("targetObj").GetValue(instance);
         targetPrefab = (UnityEngine.GameObject)typeof(GrappleMission).GetField("targetPrefab").GetValue(instance);
         msysObj = (UnityEngine.GameObject)typeof(GrappleMission).GetField("msysObj").GetValue(instance);
         minAlt = (System.Single)typeof(GrappleMission).GetField("minAlt").GetValue(instance);
         maxAlt = (System.Single)typeof(GrappleMission).GetField("maxAlt").GetValue(instance);
         reward = (System.Int32)typeof(GrappleMission).GetField("reward").GetValue(instance);
         pointMaterial = (UnityEngine.Material)typeof(GrappleMission).GetField("pointMaterial").GetValue(instance);
         highlightedPointMaterial = (UnityEngine.Material)typeof(GrappleMission).GetField("highlightedPointMaterial").GetValue(instance);
         listEntry = (UnityEngine.GameObject)typeof(GrappleMission).GetField("listEntry").GetValue(instance);
         selected = (System.Boolean)typeof(GrappleMission).GetField("selected").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(GrappleMission).GetField("target").SetValue(component, target);
         typeof(GrappleMission).GetField("targetObj").SetValue(component, targetObj);
         typeof(GrappleMission).GetField("targetPrefab").SetValue(component, targetPrefab);
         typeof(GrappleMission).GetField("msysObj").SetValue(component, msysObj);
         typeof(GrappleMission).GetField("minAlt").SetValue(component, minAlt);
         typeof(GrappleMission).GetField("maxAlt").SetValue(component, maxAlt);
         typeof(GrappleMission).GetField("reward").SetValue(component, reward);
         typeof(GrappleMission).GetField("pointMaterial").SetValue(component, pointMaterial);
         typeof(GrappleMission).GetField("highlightedPointMaterial").SetValue(component, highlightedPointMaterial);
         typeof(GrappleMission).GetField("listEntry").SetValue(component, listEntry);
         typeof(GrappleMission).GetField("selected").SetValue(component, selected);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}