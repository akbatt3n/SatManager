
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace ZSerializer {

[System.Serializable]
public sealed class LineRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single startWidth;
    public System.Single endWidth;
    public System.Single widthMultiplier;
    public System.Int32 numCornerVertices;
    public System.Int32 numCapVertices;
    public System.Boolean useWorldSpace;
    public System.Boolean loop;
    public UnityEngine.Color startColor;
    public UnityEngine.Color endColor;
    public System.Int32 positionCount;
    public System.Single shadowBias;
    public System.Boolean generateLightingData;
    public UnityEngine.LineTextureMode textureMode;
    public UnityEngine.LineAlignment alignment;
    public UnityEngine.AnimationCurve widthCurve;
    public UnityEngine.Gradient colorGradient;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public LineRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.LineRenderer;
        startWidth = instance.startWidth;
        endWidth = instance.endWidth;
        widthMultiplier = instance.widthMultiplier;
        numCornerVertices = instance.numCornerVertices;
        numCapVertices = instance.numCapVertices;
        useWorldSpace = instance.useWorldSpace;
        loop = instance.loop;
        startColor = instance.startColor;
        endColor = instance.endColor;
        positionCount = instance.positionCount;
        shadowBias = instance.shadowBias;
        generateLightingData = instance.generateLightingData;
        textureMode = instance.textureMode;
        alignment = instance.alignment;
        widthCurve = instance.widthCurve;
        colorGradient = instance.colorGradient;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.LineRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.LineRenderer)component;
        instance.startWidth = startWidth;
        instance.endWidth = endWidth;
        instance.widthMultiplier = widthMultiplier;
        instance.numCornerVertices = numCornerVertices;
        instance.numCapVertices = numCapVertices;
        instance.useWorldSpace = useWorldSpace;
        instance.loop = loop;
        instance.startColor = startColor;
        instance.endColor = endColor;
        instance.positionCount = positionCount;
        instance.shadowBias = shadowBias;
        instance.generateLightingData = generateLightingData;
        instance.textureMode = textureMode;
        instance.alignment = alignment;
        instance.widthCurve = widthCurve;
        instance.colorGradient = colorGradient;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.LineRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshFilterZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public UnityEngine.HideFlags hideFlags;
    public MeshFilterZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshFilter;
        sharedMesh = instance.sharedMesh;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshFilter)component;
        instance.sharedMesh = sharedMesh;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh additionalVertexStreams;
    public UnityEngine.Mesh enlightenVertexStream;
    public System.Single scaleInLightmap;
    public UnityEngine.ReceiveGI receiveGI;
    public System.Boolean stitchLightmapSeams;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public MeshRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshRenderer;
        additionalVertexStreams = instance.additionalVertexStreams;
        enlightenVertexStream = instance.enlightenVertexStream;
        scaleInLightmap = instance.scaleInLightmap;
        receiveGI = instance.receiveGI;
        stitchLightmapSeams = instance.stitchLightmapSeams;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshRenderer)component;
        instance.additionalVertexStreams = additionalVertexStreams;
        instance.enlightenVertexStream = enlightenVertexStream;
        instance.scaleInLightmap = scaleInLightmap;
        instance.receiveGI = receiveGI;
        instance.stitchLightmapSeams = stitchLightmapSeams;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class RectTransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector2 anchorMin;
    public UnityEngine.Vector2 anchorMax;
    public UnityEngine.Vector2 anchoredPosition;
    public UnityEngine.Vector2 sizeDelta;
    public UnityEngine.Vector2 pivot;
    public UnityEngine.Vector3 anchoredPosition3D;
    public UnityEngine.Vector2 offsetMin;
    public UnityEngine.Vector2 offsetMax;
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public RectTransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.RectTransform;
        anchorMin = instance.anchorMin;
        anchorMax = instance.anchorMax;
        anchoredPosition = instance.anchoredPosition;
        sizeDelta = instance.sizeDelta;
        pivot = instance.pivot;
        anchoredPosition3D = instance.anchoredPosition3D;
        offsetMin = instance.offsetMin;
        offsetMax = instance.offsetMax;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.RectTransform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.RectTransform)component;
        instance.anchorMin = anchorMin;
        instance.anchorMax = anchorMax;
        instance.anchoredPosition = anchoredPosition;
        instance.sizeDelta = sizeDelta;
        instance.pivot = pivot;
        instance.anchoredPosition3D = anchoredPosition3D;
        instance.offsetMin = offsetMin;
        instance.offsetMax = offsetMax;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.RectTransform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class TransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public TransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Transform;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Transform)component;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SphereColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public System.Single radius;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public SphereColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SphereCollider;
        center = instance.center;
        radius = instance.radius;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SphereCollider)component;
        instance.center = center;
        instance.radius = radius;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class HingeJoint2DZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Boolean useMotor;
    public System.Boolean useLimits;
    public UnityEngine.JointMotor2D motor;
    public UnityEngine.JointAngleLimits2D limits;
    public UnityEngine.Vector2 anchor;
    public UnityEngine.Vector2 connectedAnchor;
    public System.Boolean autoConfigureConnectedAnchor;
    public UnityEngine.Rigidbody2D connectedBody;
    public System.Boolean enableCollision;
    public System.Single breakForce;
    public System.Single breakTorque;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public Vector2 serializableLimits;
    public Vector2 serializableMotor;
    public HingeJoint2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.HingeJoint2D;
        useMotor = instance.useMotor;
        useLimits = instance.useLimits;
        motor = instance.motor;
        limits = instance.limits;
        anchor = instance.anchor;
        connectedAnchor = instance.connectedAnchor;
        autoConfigureConnectedAnchor = instance.autoConfigureConnectedAnchor;
        connectedBody = instance.connectedBody;
        enableCollision = instance.enableCollision;
        breakForce = instance.breakForce;
        breakTorque = instance.breakTorque;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.HingeJoint2D)component;
        instance.useMotor = useMotor;
        instance.useLimits = useLimits;
        instance.motor = motor;
        instance.limits = limits;
        instance.anchor = anchor;
        instance.connectedAnchor = connectedAnchor;
        instance.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor;
        instance.connectedBody = connectedBody;
        instance.enableCollision = enableCollision;
        instance.breakForce = breakForce;
        instance.breakTorque = breakTorque;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class CanvasRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Boolean hasPopInstruction;
    public System.Int32 materialCount;
    public System.Int32 popMaterialCount;
    public System.Boolean cullTransparentMesh;
    public System.Boolean cull;
    public UnityEngine.Vector2 clippingSoftness;
    public UnityEngine.HideFlags hideFlags;
    public CanvasRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.CanvasRenderer;
        hasPopInstruction = instance.hasPopInstruction;
        materialCount = instance.materialCount;
        popMaterialCount = instance.popMaterialCount;
        cullTransparentMesh = instance.cullTransparentMesh;
        cull = instance.cull;
        clippingSoftness = instance.clippingSoftness;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CanvasRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.CanvasRenderer)component;
        instance.hasPopInstruction = hasPopInstruction;
        instance.materialCount = materialCount;
        instance.popMaterialCount = popMaterialCount;
        instance.cullTransparentMesh = cullTransparentMesh;
        instance.cull = cull;
        instance.clippingSoftness = clippingSoftness;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CanvasRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
}