using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BSoftBody))]
public class BSoftBodyEditor : Editor 
{

	private SerializedObject serObj;
	
	private SerializedProperty SoftBodyType;
	
	
	private SerializedProperty RigidBodyAnchor;
	private SerializedProperty AnchorNode;
	private SerializedProperty AnchorPivot;
	private SerializedProperty SoftCollisionType;
	private SerializedProperty ClusterNum;
	private SerializedProperty SelfCollision;
	private SerializedProperty bAeroMode;
	private SerializedProperty Mass;
	private SerializedProperty MaterialLinearStiffness; //[0,1]
	private SerializedProperty MaterialAngularStiffness; //[0,1]
	private SerializedProperty MaterialVolumeStiffness;  //[0,1]
	private SerializedProperty DynamicFrictionCoefficient; // [0,1]
	private SerializedProperty DampingCoefficient; //[0,1]
	private SerializedProperty PressureCoefficient;
	private SerializedProperty VolumeConversationCoefficient;
	private SerializedProperty RigidContactsHardness;
	private SerializedProperty LiftCoefficient;
	private SerializedProperty DragCoefficient;
	//Patch
    private SerializedProperty PatchCorner00;	 
	private SerializedProperty PatchCorner01;
	private SerializedProperty PatchCorner10;	 
	private SerializedProperty PatchCorner11;
    private SerializedProperty CornerFix00;
	private SerializedProperty CornerFix01;
	private SerializedProperty CornerFix10;
	private SerializedProperty CornerFix11;
	private SerializedProperty PatchResolutionX;
	private SerializedProperty PatchResolutionY;
	
	//Ellipsoid
	private SerializedProperty EllipsoidRadius;
	private SerializedProperty MeshResolution;
	
	//rope
	private SerializedProperty RopeFromPos;
	private SerializedProperty RopeToPos;
	private SerializedProperty RopeResolution;
	private SerializedProperty FixRopeBegin;
	private SerializedProperty FixRopeEnd;
	private SerializedProperty RopeColor;
	private SerializedProperty RopeWidth;
	
	public void OnEnable () 
	{
		serObj = new SerializedObject (target); 
		
		SoftBodyType = serObj.FindProperty("softBodyType"); 
		
		RigidBodyAnchor = serObj.FindProperty("RigidBodyAnchor"); 
		AnchorNode = serObj.FindProperty("AnchorNode");
		AnchorPivot = serObj.FindProperty("AnchorPivot");
		SoftCollisionType = serObj.FindProperty("SoftCollisionType");
		SelfCollision = serObj.FindProperty("SelfCollision");
		ClusterNum = serObj.FindProperty("ClusterNum");
		bAeroMode = serObj.FindProperty("bAeroMode");
		
		Mass = serObj.FindProperty("Mass"); 
		MaterialLinearStiffness = serObj.FindProperty("MaterialLinearStiffness"); 
		MaterialAngularStiffness = serObj.FindProperty("MaterialAngularStiffness"); 
		MaterialVolumeStiffness = serObj.FindProperty("MaterialVolumeStiffness"); 
		DynamicFrictionCoefficient = serObj.FindProperty("DynamicFrictionCoefficient");
		DampingCoefficient = serObj.FindProperty("DampingCoefficient");
		PressureCoefficient = serObj.FindProperty("PressureCoefficient");
		VolumeConversationCoefficient = serObj.FindProperty("VolumeConversationCoefficient");
		RigidContactsHardness = serObj.FindProperty("RigidContactsHardness");
		LiftCoefficient = serObj.FindProperty("LiftCoefficient");
		DragCoefficient = serObj.FindProperty("DragCoefficient");
		
		PatchCorner00 = serObj.FindProperty("PatchCorner00"); 
		PatchCorner01 = serObj.FindProperty("PatchCorner01");   
		PatchCorner10 = serObj.FindProperty("PatchCorner10");   
		PatchCorner11 = serObj.FindProperty("PatchCorner11"); 
		
		CornerFix00 = serObj.FindProperty("CornerFix00");   
		CornerFix01 = serObj.FindProperty("CornerFix01");   
		CornerFix10 = serObj.FindProperty("CornerFix10");   
		CornerFix11 = serObj.FindProperty("CornerFix11");   
		
		PatchResolutionX = serObj.FindProperty("PatchResolutionX");   
		PatchResolutionY = serObj.FindProperty("PatchResolutionY");   
		
		EllipsoidRadius = serObj.FindProperty("EllipsoidRadius");   
		MeshResolution = serObj.FindProperty("MeshResolution"); 
		
		RopeFromPos = serObj.FindProperty("RopeFromPos");   
		RopeToPos = serObj.FindProperty("RopeToPos");   
		RopeResolution = serObj.FindProperty("RopeResolution");   
		FixRopeBegin = serObj.FindProperty("FixRopeBegin");   
		FixRopeEnd = serObj.FindProperty("FixRopeEnd");   
		RopeColor = serObj.FindProperty("RopeColor"); 
		RopeWidth = serObj.FindProperty("RopeWidth");   
	}
	
	public override void OnInspectorGUI () 
	{
		serObj.Update();
    	
		BSoftBody softBodyObj = (BSoftBody)serObj.targetObject;
		GameObject gameObj = softBodyObj.gameObject;
		
		EditorGUILayout.PropertyField(SoftBodyType,new GUIContent("SoftBody Type"));
		EditorGUILayout.PropertyField(Mass,new GUIContent("TotalMass"));
		EditorGUILayout.Space();
		
		if( SoftBodyType.intValue == (int)BSoftBody.SoftBodyType.Patch )
		{			
			EditorGUILayout.PropertyField(PatchCorner00,new GUIContent("Corner00 Position"));
			EditorGUILayout.PropertyField(CornerFix00,new GUIContent("Corner00 Fix"));
			EditorGUILayout.Space();
			
			EditorGUILayout.PropertyField(PatchCorner01,new GUIContent("Corner01 Position:"));
			EditorGUILayout.PropertyField(CornerFix01,new GUIContent("Corner01 Fix:"));
			EditorGUILayout.Space();
			
			EditorGUILayout.PropertyField(PatchCorner10,new GUIContent("Corner10 Position"));
			EditorGUILayout.PropertyField(CornerFix10,new GUIContent("Corner10 Fix"));
			EditorGUILayout.Space();
			
			EditorGUILayout.PropertyField(PatchCorner11,new GUIContent("Corner11 Position"));
			EditorGUILayout.PropertyField(CornerFix11,new GUIContent("Corner11 Fix"));
			EditorGUILayout.Space();
			
			EditorGUILayout.PropertyField(PatchResolutionX,new GUIContent("Resulution X"));
			EditorGUILayout.PropertyField(PatchResolutionY,new GUIContent("Resulution Y"));
		}
		else if( SoftBodyType.intValue == (int)BSoftBody.SoftBodyType.Ellipsoid )
		{
			EditorGUILayout.PropertyField(EllipsoidRadius,new GUIContent("Radius"));
			EditorGUILayout.PropertyField(MeshResolution, new GUIContent("MeshResolution"));
			
		
		}
		else if( SoftBodyType.intValue == (int)BSoftBody.SoftBodyType.Rope )
		{
			
			EditorGUILayout.PropertyField(RopeFromPos,new GUIContent("Begin"));
			EditorGUILayout.PropertyField(RopeToPos, new GUIContent("End"));
			EditorGUILayout.PropertyField(RopeResolution, new GUIContent("Resolution"));
			EditorGUILayout.PropertyField(FixRopeBegin, new GUIContent("Fixed Begin"));
			EditorGUILayout.PropertyField(FixRopeEnd, new GUIContent("Fixed End"));
			EditorGUILayout.PropertyField(RopeColor, new GUIContent("Color"));
			EditorGUILayout.PropertyField(RopeWidth, new GUIContent("Width"));
			 
		}
		else if( SoftBodyType.intValue == (int)BSoftBody.SoftBodyType.TriangleMesh )
		{
		 
		}
		
		EditorGUILayout.Slider(MaterialLinearStiffness,0.0f,1.0f,new GUIContent("Linear Stiffness"));
	    EditorGUILayout.Slider(DynamicFrictionCoefficient,0.0f,1.0f,new GUIContent("Dynamic Friction"));
		EditorGUILayout.Slider(DampingCoefficient,0.0f,1.0f,new GUIContent("Damping"));
		EditorGUILayout.Slider(RigidContactsHardness,0.0f,1.0f,new GUIContent("Rigid Contacts Hardness"));
		EditorGUILayout.PropertyField(PressureCoefficient,new GUIContent("Pressure"));
		EditorGUILayout.PropertyField(VolumeConversationCoefficient,new GUIContent("Volume Conversation"));
		EditorGUILayout.PropertyField(LiftCoefficient,new GUIContent("Lift"));
		EditorGUILayout.PropertyField(DragCoefficient,new GUIContent("Drag"));
			
		EditorGUILayout.PropertyField(RigidBodyAnchor, new GUIContent("RigidBody Anchor"));
		if( RigidBodyAnchor.objectReferenceValue != null )
		{
		    EditorGUILayout.PropertyField(AnchorPivot, new GUIContent("Anchor Local Pivot"));
		    EditorGUILayout.PropertyField(AnchorNode, new GUIContent("Anchor Node"));	
		}
		
		EditorGUILayout.PropertyField(bAeroMode,new GUIContent("Aero Mode"));
		
		EditorGUILayout.PropertyField(SoftCollisionType, new GUIContent("Collision Type"));
		if( SoftCollisionType.intValue >= (int)BSoftBody.CollisionType.RigidVsSoft_Cluster )
		{
			EditorGUILayout.PropertyField(ClusterNum,new GUIContent("Cluster Number"));
			EditorGUILayout.PropertyField(SelfCollision,new GUIContent("Self Collision"));
			
		}
		
		serObj.ApplyModifiedProperties();
		
	}
}
