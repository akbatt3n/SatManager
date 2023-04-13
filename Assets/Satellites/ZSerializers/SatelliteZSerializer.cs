[System.Serializable]
public sealed class SatelliteZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.String type;
    public System.String satName;
    public System.Single fuel;
    public System.Int32 scaleFactor;
    public System.Single M;
    public System.Single r;
    public System.Single altitude;
    public UnityEngine.GameObject primaryObj;
    public Primary primary;
    public UnityEngine.GameObject listEntry;
    public UnityEngine.Vector3 velocity;
    public System.Single velMag;
    public UnityEngine.Vector3 gravity;
    public UnityEngine.Vector3 acceleration;
    public System.Boolean circular;
    public System.Boolean equitorial;
    public System.Single a;
    public System.Single e;
    public System.Single i;
    public System.Single raan;
    public System.Single argPeriapsis;
    public System.Single tAnomaly;
    public UnityEngine.Vector3 eVector;
    public UnityEngine.Vector3 hVector;
    public UnityEngine.Vector3 nVector;
    public UnityEngine.Vector3 posVector;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public SatelliteZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         type = (System.String)typeof(Satellite).GetField("type").GetValue(instance);
         satName = (System.String)typeof(Satellite).GetField("satName").GetValue(instance);
         fuel = (System.Single)typeof(Satellite).GetField("fuel").GetValue(instance);
         scaleFactor = (System.Int32)typeof(Satellite).GetField("scaleFactor").GetValue(instance);
         M = (System.Single)typeof(Satellite).GetField("M").GetValue(instance);
         r = (System.Single)typeof(Satellite).GetField("r").GetValue(instance);
         altitude = (System.Single)typeof(Satellite).GetField("altitude").GetValue(instance);
         primaryObj = (UnityEngine.GameObject)typeof(Satellite).GetField("primaryObj").GetValue(instance);
         primary = (Primary)typeof(Satellite).GetField("primary").GetValue(instance);
         listEntry = (UnityEngine.GameObject)typeof(Satellite).GetField("listEntry").GetValue(instance);
         velocity = (UnityEngine.Vector3)typeof(Satellite).GetField("velocity").GetValue(instance);
         velMag = (System.Single)typeof(Satellite).GetField("velMag").GetValue(instance);
         gravity = (UnityEngine.Vector3)typeof(Satellite).GetField("gravity").GetValue(instance);
         acceleration = (UnityEngine.Vector3)typeof(Satellite).GetField("acceleration").GetValue(instance);
         circular = (System.Boolean)typeof(Satellite).GetField("circular").GetValue(instance);
         equitorial = (System.Boolean)typeof(Satellite).GetField("equitorial").GetValue(instance);
         a = (System.Single)typeof(Satellite).GetField("a").GetValue(instance);
         e = (System.Single)typeof(Satellite).GetField("e").GetValue(instance);
         i = (System.Single)typeof(Satellite).GetField("i").GetValue(instance);
         raan = (System.Single)typeof(Satellite).GetField("raan").GetValue(instance);
         argPeriapsis = (System.Single)typeof(Satellite).GetField("argPeriapsis").GetValue(instance);
         tAnomaly = (System.Single)typeof(Satellite).GetField("tAnomaly").GetValue(instance);
         eVector = (UnityEngine.Vector3)typeof(Satellite).GetField("eVector").GetValue(instance);
         hVector = (UnityEngine.Vector3)typeof(Satellite).GetField("hVector").GetValue(instance);
         nVector = (UnityEngine.Vector3)typeof(Satellite).GetField("nVector").GetValue(instance);
         posVector = (UnityEngine.Vector3)typeof(Satellite).GetField("posVector").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Satellite).GetField("type").SetValue(component, type);
         typeof(Satellite).GetField("satName").SetValue(component, satName);
         typeof(Satellite).GetField("fuel").SetValue(component, fuel);
         typeof(Satellite).GetField("scaleFactor").SetValue(component, scaleFactor);
         typeof(Satellite).GetField("M").SetValue(component, M);
         typeof(Satellite).GetField("r").SetValue(component, r);
         typeof(Satellite).GetField("altitude").SetValue(component, altitude);
         typeof(Satellite).GetField("primaryObj").SetValue(component, primaryObj);
         typeof(Satellite).GetField("primary").SetValue(component, primary);
         typeof(Satellite).GetField("listEntry").SetValue(component, listEntry);
         typeof(Satellite).GetField("velocity").SetValue(component, velocity);
         typeof(Satellite).GetField("velMag").SetValue(component, velMag);
         typeof(Satellite).GetField("gravity").SetValue(component, gravity);
         typeof(Satellite).GetField("acceleration").SetValue(component, acceleration);
         typeof(Satellite).GetField("circular").SetValue(component, circular);
         typeof(Satellite).GetField("equitorial").SetValue(component, equitorial);
         typeof(Satellite).GetField("a").SetValue(component, a);
         typeof(Satellite).GetField("e").SetValue(component, e);
         typeof(Satellite).GetField("i").SetValue(component, i);
         typeof(Satellite).GetField("raan").SetValue(component, raan);
         typeof(Satellite).GetField("argPeriapsis").SetValue(component, argPeriapsis);
         typeof(Satellite).GetField("tAnomaly").SetValue(component, tAnomaly);
         typeof(Satellite).GetField("eVector").SetValue(component, eVector);
         typeof(Satellite).GetField("hVector").SetValue(component, hVector);
         typeof(Satellite).GetField("nVector").SetValue(component, nVector);
         typeof(Satellite).GetField("posVector").SetValue(component, posVector);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}