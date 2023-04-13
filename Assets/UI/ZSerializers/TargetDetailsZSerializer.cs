[System.Serializable]
public sealed class TargetDetailsZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject satellite;
    public UnityEngine.GameObject satName;
    public UnityEngine.GameObject alt;
    public UnityEngine.GameObject semiMajor;
    public UnityEngine.GameObject eccentricity;
    public UnityEngine.GameObject inclination;
    public UnityEngine.GameObject raan;
    public UnityEngine.GameObject argPeri;
    public UnityEngine.GameObject tAnomaly;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public TargetDetailsZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         satellite = (UnityEngine.GameObject)typeof(TargetDetails).GetField("satellite").GetValue(instance);
         satName = (UnityEngine.GameObject)typeof(TargetDetails).GetField("satName").GetValue(instance);
         alt = (UnityEngine.GameObject)typeof(TargetDetails).GetField("alt").GetValue(instance);
         semiMajor = (UnityEngine.GameObject)typeof(TargetDetails).GetField("semiMajor").GetValue(instance);
         eccentricity = (UnityEngine.GameObject)typeof(TargetDetails).GetField("eccentricity").GetValue(instance);
         inclination = (UnityEngine.GameObject)typeof(TargetDetails).GetField("inclination").GetValue(instance);
         raan = (UnityEngine.GameObject)typeof(TargetDetails).GetField("raan").GetValue(instance);
         argPeri = (UnityEngine.GameObject)typeof(TargetDetails).GetField("argPeri").GetValue(instance);
         tAnomaly = (UnityEngine.GameObject)typeof(TargetDetails).GetField("tAnomaly").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(TargetDetails).GetField("satellite").SetValue(component, satellite);
         typeof(TargetDetails).GetField("satName").SetValue(component, satName);
         typeof(TargetDetails).GetField("alt").SetValue(component, alt);
         typeof(TargetDetails).GetField("semiMajor").SetValue(component, semiMajor);
         typeof(TargetDetails).GetField("eccentricity").SetValue(component, eccentricity);
         typeof(TargetDetails).GetField("inclination").SetValue(component, inclination);
         typeof(TargetDetails).GetField("raan").SetValue(component, raan);
         typeof(TargetDetails).GetField("argPeri").SetValue(component, argPeri);
         typeof(TargetDetails).GetField("tAnomaly").SetValue(component, tAnomaly);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}