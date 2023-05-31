[System.Serializable]
public sealed class ImageMissionZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 minReward;
    public System.Int32 maxReward;
    public System.Int32 reward;
    public UnityEngine.Material pointMaterial;
    public UnityEngine.Material highlightedPointMaterial;
    public UnityEngine.GameObject listEntry;
    public System.Boolean selected;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public ImageMissionZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         minReward = (System.Int32)typeof(ImageMission).GetField("minReward").GetValue(instance);
         maxReward = (System.Int32)typeof(ImageMission).GetField("maxReward").GetValue(instance);
         reward = (System.Int32)typeof(ImageMission).GetField("reward").GetValue(instance);
         pointMaterial = (UnityEngine.Material)typeof(ImageMission).GetField("pointMaterial").GetValue(instance);
         highlightedPointMaterial = (UnityEngine.Material)typeof(ImageMission).GetField("highlightedPointMaterial").GetValue(instance);
         listEntry = (UnityEngine.GameObject)typeof(ImageMission).GetField("listEntry").GetValue(instance);
         selected = (System.Boolean)typeof(ImageMission).GetField("selected").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(ImageMission).GetField("minReward").SetValue(component, minReward);
         typeof(ImageMission).GetField("maxReward").SetValue(component, maxReward);
         typeof(ImageMission).GetField("reward").SetValue(component, reward);
         typeof(ImageMission).GetField("pointMaterial").SetValue(component, pointMaterial);
         typeof(ImageMission).GetField("highlightedPointMaterial").SetValue(component, highlightedPointMaterial);
         typeof(ImageMission).GetField("listEntry").SetValue(component, listEntry);
         typeof(ImageMission).GetField("selected").SetValue(component, selected);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}