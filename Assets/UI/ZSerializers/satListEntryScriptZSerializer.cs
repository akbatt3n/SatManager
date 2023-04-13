[System.Serializable]
public sealed class satListEntryScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject satellite;
    public UnityEngine.GameObject satHighlightToggle;
    public UnityEngine.GameObject detailsPanel;
    public UnityEngine.GameObject ghost;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public satListEntryScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         satellite = (UnityEngine.GameObject)typeof(satListEntryScript).GetField("satellite").GetValue(instance);
         satHighlightToggle = (UnityEngine.GameObject)typeof(satListEntryScript).GetField("satHighlightToggle").GetValue(instance);
         detailsPanel = (UnityEngine.GameObject)typeof(satListEntryScript).GetField("detailsPanel").GetValue(instance);
         ghost = (UnityEngine.GameObject)typeof(satListEntryScript).GetField("ghost").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(satListEntryScript).GetField("satellite").SetValue(component, satellite);
         typeof(satListEntryScript).GetField("satHighlightToggle").SetValue(component, satHighlightToggle);
         typeof(satListEntryScript).GetField("detailsPanel").SetValue(component, detailsPanel);
         typeof(satListEntryScript).GetField("ghost").SetValue(component, ghost);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}