using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BCollisionShape))]
public class BCollisionShapeEditor : Editor {
	
	private SerializedObject serObj;
    private SerializedProperty collisionShapeType;
	private SerializedProperty boxShapeVec;
	private SerializedProperty sphereShapeRadius;
	private SerializedProperty capsuleShapeRadius;
	private SerializedProperty capsuleShapeHeight;
	private SerializedProperty cylinderRadius;
	private SerializedProperty cylinderHeight;
    private SerializedProperty coneShapeRadius;
	private SerializedProperty coneShapeHeight;
	private SerializedProperty staticPlaneShapeNormal;
	private SerializedProperty staticPlaneConstant;
	private SerializedProperty compoundShapeArray;
	 
	public void OnEnable () 
	{
		serObj = new SerializedObject (target); 
		collisionShapeType = serObj.FindProperty("ShapeType");   	
		
		boxShapeVec = serObj.FindProperty("BoxShapeVec");
		
		sphereShapeRadius = serObj.FindProperty("SphereShapeRadius");
	 
		capsuleShapeRadius = serObj.FindProperty("CapsuleRadius");
		capsuleShapeHeight = serObj.FindProperty("CapsuleHeight");
		
		cylinderRadius = serObj.FindProperty("CylinderRadius");
		cylinderHeight = serObj.FindProperty("CylinderHeight");
		
		coneShapeRadius = serObj.FindProperty("ConeRadius");
		coneShapeHeight = serObj.FindProperty("ConeHeight");
 
		staticPlaneShapeNormal = serObj.FindProperty("StaticPlaneNormal");
		staticPlaneConstant = serObj.FindProperty("StaticPlaneConstant");
		
		compoundShapeArray = serObj.FindProperty("CollisionShapeArray");
	}
	
	// Update is called once per frame
	public override void OnInspectorGUI () 
	{
		serObj.Update();
    	
		BCollisionShape shapeObj = (BCollisionShape)serObj.targetObject;
		GameObject gameObj = shapeObj.gameObject;
 
		EditorGUILayout.PropertyField(collisionShapeType,new GUIContent("Collision shape"));
		
		
		if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.BoxShape )
		{
			EditorGUILayout.PropertyField(boxShapeVec,new GUIContent("Box Shape HalfSize"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.SphereShape )
		{
			EditorGUILayout.PropertyField(sphereShapeRadius,new GUIContent("Sphere Shape Radius"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.CapsuleShape )
		{
			EditorGUILayout.PropertyField(capsuleShapeRadius,new GUIContent("Capsule Shape Radius"));
			EditorGUILayout.PropertyField(capsuleShapeHeight,new GUIContent("Capsule Shape Height"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.CylinderShape )
		{
			EditorGUILayout.PropertyField(cylinderRadius,new GUIContent("Cylinder Shape Radius"));
			EditorGUILayout.PropertyField(cylinderHeight,new GUIContent("Cylinder Shape Height"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.ConeShape )
		{
			EditorGUILayout.PropertyField(coneShapeRadius,new GUIContent("Cone Shape Radius"));
			EditorGUILayout.PropertyField(coneShapeHeight,new GUIContent("Cone Shape Height"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.StaticPlaneShape )
		{
			EditorGUILayout.PropertyField(staticPlaneShapeNormal,new GUIContent("Static Plane Normal"));
			EditorGUILayout.PropertyField(staticPlaneConstant,new GUIContent("Static Plane Constant"));
		}
		else if( collisionShapeType.intValue == (int)BCollisionShape.CollisionShapeType.CompoundShape )
		{
			EditorGUILayout.PropertyField(compoundShapeArray,new GUIContent("Collision Shape Array"),true); 
		}
 
    	serObj.ApplyModifiedProperties();
	
	}
}
