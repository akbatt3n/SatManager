[System.Serializable]
public sealed class UniverseZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject commMissionBucket;
    public UnityEngine.GameObject imageMissionBucket;
    public UnityEngine.GameObject grappleMissionBucket;
    public UnityEngine.GameObject targetContainer;
    public System.Single G;
    public System.Int32 scaleFactor;
    public System.Int32 timeScale;
    public System.Int32 timeSlider;
    public System.Single pMass;
    public System.Single pRadius;
    public UnityEngine.UI.Text speedReadout;
    public UnityEngine.UI.Slider speedSlider;
    public UnityEngine.GameObject satList;
    public UnityEngine.GameObject satContainer;
    public UnityEngine.GameObject satListEntryPrefab;
    public UnityEngine.GameObject detailsPanel;
    public UnityEngine.GameObject ghost;
    public UnityEngine.GameObject deltaVInput;
    public UnityEngine.GameObject directionInput;
    public UnityEngine.GameObject moneyUI;
    public System.Int32 moneyAmount;
    public UnityEngine.GameObject imageSatPrefab;
    public UnityEngine.GameObject commSatPrefab;
    public UnityEngine.GameObject grappleSatPrefab;
    public UnityEngine.GameObject grappleTargetPrefab;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public UniverseZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         commMissionBucket = (UnityEngine.GameObject)typeof(Universe).GetField("commMissionBucket").GetValue(instance);
         imageMissionBucket = (UnityEngine.GameObject)typeof(Universe).GetField("imageMissionBucket").GetValue(instance);
         grappleMissionBucket = (UnityEngine.GameObject)typeof(Universe).GetField("grappleMissionBucket").GetValue(instance);
         targetContainer = (UnityEngine.GameObject)typeof(Universe).GetField("targetContainer").GetValue(instance);
         G = (System.Single)typeof(Universe).GetField("G").GetValue(instance);
         scaleFactor = (System.Int32)typeof(Universe).GetField("scaleFactor").GetValue(instance);
         timeScale = (System.Int32)typeof(Universe).GetField("timeScale").GetValue(instance);
         timeSlider = (System.Int32)typeof(Universe).GetField("timeSlider").GetValue(instance);
         pMass = (System.Single)typeof(Universe).GetField("pMass").GetValue(instance);
         pRadius = (System.Single)typeof(Universe).GetField("pRadius").GetValue(instance);
         speedReadout = (UnityEngine.UI.Text)typeof(Universe).GetField("speedReadout").GetValue(instance);
         speedSlider = (UnityEngine.UI.Slider)typeof(Universe).GetField("speedSlider").GetValue(instance);
         satList = (UnityEngine.GameObject)typeof(Universe).GetField("satList").GetValue(instance);
         satContainer = (UnityEngine.GameObject)typeof(Universe).GetField("satContainer").GetValue(instance);
         satListEntryPrefab = (UnityEngine.GameObject)typeof(Universe).GetField("satListEntryPrefab").GetValue(instance);
         detailsPanel = (UnityEngine.GameObject)typeof(Universe).GetField("detailsPanel").GetValue(instance);
         ghost = (UnityEngine.GameObject)typeof(Universe).GetField("ghost").GetValue(instance);
         deltaVInput = (UnityEngine.GameObject)typeof(Universe).GetField("deltaVInput").GetValue(instance);
         directionInput = (UnityEngine.GameObject)typeof(Universe).GetField("directionInput").GetValue(instance);
         moneyUI = (UnityEngine.GameObject)typeof(Universe).GetField("moneyUI").GetValue(instance);
         moneyAmount = (System.Int32)typeof(Universe).GetField("moneyAmount").GetValue(instance);
         imageSatPrefab = (UnityEngine.GameObject)typeof(Universe).GetField("imageSatPrefab").GetValue(instance);
         commSatPrefab = (UnityEngine.GameObject)typeof(Universe).GetField("commSatPrefab").GetValue(instance);
         grappleSatPrefab = (UnityEngine.GameObject)typeof(Universe).GetField("grappleSatPrefab").GetValue(instance);
         grappleTargetPrefab = (UnityEngine.GameObject)typeof(Universe).GetField("grappleTargetPrefab").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Universe).GetField("commMissionBucket").SetValue(component, commMissionBucket);
         typeof(Universe).GetField("imageMissionBucket").SetValue(component, imageMissionBucket);
         typeof(Universe).GetField("grappleMissionBucket").SetValue(component, grappleMissionBucket);
         typeof(Universe).GetField("targetContainer").SetValue(component, targetContainer);
         typeof(Universe).GetField("G").SetValue(component, G);
         typeof(Universe).GetField("scaleFactor").SetValue(component, scaleFactor);
         typeof(Universe).GetField("timeScale").SetValue(component, timeScale);
         typeof(Universe).GetField("timeSlider").SetValue(component, timeSlider);
         typeof(Universe).GetField("pMass").SetValue(component, pMass);
         typeof(Universe).GetField("pRadius").SetValue(component, pRadius);
         typeof(Universe).GetField("speedReadout").SetValue(component, speedReadout);
         typeof(Universe).GetField("speedSlider").SetValue(component, speedSlider);
         typeof(Universe).GetField("satList").SetValue(component, satList);
         typeof(Universe).GetField("satContainer").SetValue(component, satContainer);
         typeof(Universe).GetField("satListEntryPrefab").SetValue(component, satListEntryPrefab);
         typeof(Universe).GetField("detailsPanel").SetValue(component, detailsPanel);
         typeof(Universe).GetField("ghost").SetValue(component, ghost);
         typeof(Universe).GetField("deltaVInput").SetValue(component, deltaVInput);
         typeof(Universe).GetField("directionInput").SetValue(component, directionInput);
         typeof(Universe).GetField("moneyUI").SetValue(component, moneyUI);
         typeof(Universe).GetField("moneyAmount").SetValue(component, moneyAmount);
         typeof(Universe).GetField("imageSatPrefab").SetValue(component, imageSatPrefab);
         typeof(Universe).GetField("commSatPrefab").SetValue(component, commSatPrefab);
         typeof(Universe).GetField("grappleSatPrefab").SetValue(component, grappleSatPrefab);
         typeof(Universe).GetField("grappleTargetPrefab").SetValue(component, grappleTargetPrefab);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}