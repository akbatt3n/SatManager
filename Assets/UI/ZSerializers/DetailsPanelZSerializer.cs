[System.Serializable]
public sealed class DetailsPanelZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject satListToggle;
    public UnityEngine.GameObject satellite;
    public UnityEngine.GameObject grappleButton;
    public UnityEngine.GameObject satType;
    public UnityEngine.GameObject satFuel;
    public UnityEngine.GameObject apo;
    public UnityEngine.GameObject peri;
    public UnityEngine.GameObject alt;
    public UnityEngine.GameObject semiMajor;
    public UnityEngine.GameObject eccentricity;
    public UnityEngine.GameObject inclination;
    public UnityEngine.GameObject raan;
    public UnityEngine.GameObject argPeri;
    public UnityEngine.GameObject tAnomaly;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public DetailsPanelZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         satListToggle = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("satListToggle").GetValue(instance);
         satellite = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("satellite").GetValue(instance);
         grappleButton = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("grappleButton").GetValue(instance);
         satType = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("satType").GetValue(instance);
         satFuel = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("satFuel").GetValue(instance);
         apo = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("apo").GetValue(instance);
         peri = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("peri").GetValue(instance);
         alt = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("alt").GetValue(instance);
         semiMajor = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("semiMajor").GetValue(instance);
         eccentricity = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("eccentricity").GetValue(instance);
         inclination = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("inclination").GetValue(instance);
         raan = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("raan").GetValue(instance);
         argPeri = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("argPeri").GetValue(instance);
         tAnomaly = (UnityEngine.GameObject)typeof(DetailsPanel).GetField("tAnomaly").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(DetailsPanel).GetField("satListToggle").SetValue(component, satListToggle);
         typeof(DetailsPanel).GetField("satellite").SetValue(component, satellite);
         typeof(DetailsPanel).GetField("grappleButton").SetValue(component, grappleButton);
         typeof(DetailsPanel).GetField("satType").SetValue(component, satType);
         typeof(DetailsPanel).GetField("satFuel").SetValue(component, satFuel);
         typeof(DetailsPanel).GetField("apo").SetValue(component, apo);
         typeof(DetailsPanel).GetField("peri").SetValue(component, peri);
         typeof(DetailsPanel).GetField("alt").SetValue(component, alt);
         typeof(DetailsPanel).GetField("semiMajor").SetValue(component, semiMajor);
         typeof(DetailsPanel).GetField("eccentricity").SetValue(component, eccentricity);
         typeof(DetailsPanel).GetField("inclination").SetValue(component, inclination);
         typeof(DetailsPanel).GetField("raan").SetValue(component, raan);
         typeof(DetailsPanel).GetField("argPeri").SetValue(component, argPeri);
         typeof(DetailsPanel).GetField("tAnomaly").SetValue(component, tAnomaly);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}