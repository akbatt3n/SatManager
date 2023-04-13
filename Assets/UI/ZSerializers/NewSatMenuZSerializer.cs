[System.Serializable]
public sealed class NewSatMenuZSerializer : ZSerializer.Internal.ZSerializer
{
    public TMPro.TMP_InputField nameField;
    public TMPro.TMP_Dropdown typeSelect;
    public TMPro.TMP_InputField altitudeField;
    public UnityEngine.GameObject leoButton;
    public UnityEngine.GameObject meoButton;
    public UnityEngine.GameObject geoButton;
    public TMPro.TMP_InputField inclinationField;
    public TMPro.TMP_InputField raanField;
    public TMPro.TMP_Dropdown fuelSelect;
    public UnityEngine.GameObject costDisplay;
    public UnityEngine.GameObject launchButton;
    public UnityEngine.GameObject cancelButton;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public NewSatMenuZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         nameField = (TMPro.TMP_InputField)typeof(NewSatMenu).GetField("nameField").GetValue(instance);
         typeSelect = (TMPro.TMP_Dropdown)typeof(NewSatMenu).GetField("typeSelect").GetValue(instance);
         altitudeField = (TMPro.TMP_InputField)typeof(NewSatMenu).GetField("altitudeField").GetValue(instance);
         leoButton = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("leoButton").GetValue(instance);
         meoButton = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("meoButton").GetValue(instance);
         geoButton = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("geoButton").GetValue(instance);
         inclinationField = (TMPro.TMP_InputField)typeof(NewSatMenu).GetField("inclinationField").GetValue(instance);
         raanField = (TMPro.TMP_InputField)typeof(NewSatMenu).GetField("raanField").GetValue(instance);
         fuelSelect = (TMPro.TMP_Dropdown)typeof(NewSatMenu).GetField("fuelSelect").GetValue(instance);
         costDisplay = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("costDisplay").GetValue(instance);
         launchButton = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("launchButton").GetValue(instance);
         cancelButton = (UnityEngine.GameObject)typeof(NewSatMenu).GetField("cancelButton").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(NewSatMenu).GetField("nameField").SetValue(component, nameField);
         typeof(NewSatMenu).GetField("typeSelect").SetValue(component, typeSelect);
         typeof(NewSatMenu).GetField("altitudeField").SetValue(component, altitudeField);
         typeof(NewSatMenu).GetField("leoButton").SetValue(component, leoButton);
         typeof(NewSatMenu).GetField("meoButton").SetValue(component, meoButton);
         typeof(NewSatMenu).GetField("geoButton").SetValue(component, geoButton);
         typeof(NewSatMenu).GetField("inclinationField").SetValue(component, inclinationField);
         typeof(NewSatMenu).GetField("raanField").SetValue(component, raanField);
         typeof(NewSatMenu).GetField("fuelSelect").SetValue(component, fuelSelect);
         typeof(NewSatMenu).GetField("costDisplay").SetValue(component, costDisplay);
         typeof(NewSatMenu).GetField("launchButton").SetValue(component, launchButton);
         typeof(NewSatMenu).GetField("cancelButton").SetValue(component, cancelButton);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}