using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BConstraint))]
public class BConstraintEditor : Editor {

	private SerializedObject serObj;
    private SerializedProperty ConstraintType;	 
	private SerializedProperty PivotInA;
	private SerializedProperty PivotInB;
	private SerializedProperty AxisInA;
	private SerializedProperty AxisInB;
	private SerializedProperty useReferenceFrameAHinge;
	private SerializedProperty useLinearReferenceFrameASlider;
	private SerializedProperty RotationA;
	private SerializedProperty RotationB;
	private SerializedProperty GearConstraintRatio;
	private SerializedProperty RigidBodyA;
	private SerializedProperty RigidBodyB;

	private SerializedProperty UseLinearLimit;
	private SerializedProperty LinearLowerLimit;
	private SerializedProperty LinearUpperLimit;
	private SerializedProperty UseAngularLimit;
	private SerializedProperty AngularLowerLimit;
	private SerializedProperty AngularUpperLimit;
	 
 
	public void OnEnable () 
	{
		serObj = new SerializedObject (target); 
		ConstraintType = serObj.FindProperty("ConstraintType");   		
		PivotInA = serObj.FindProperty("PivotInA");
		PivotInB = serObj.FindProperty("PivotInB");
		AxisInA = serObj.FindProperty("AxisInA");
		AxisInB = serObj.FindProperty("AxisInB");
		useReferenceFrameAHinge = serObj.FindProperty("useReferenceFrameAHinge");
		useLinearReferenceFrameASlider = serObj.FindProperty("useLinearReferenceFrameASlider");
		RotationA = serObj.FindProperty("RotationA");
		RotationB = serObj.FindProperty("RotationB");
		GearConstraintRatio = serObj.FindProperty("GearConstraintRatio");
		RigidBodyA = serObj.FindProperty("RigidBodyA");
		RigidBodyB = serObj.FindProperty("RigidBodyB");
		UseLinearLimit = serObj.FindProperty("UseLinearLimit");
		LinearLowerLimit = serObj.FindProperty("LinearLowerLimit");
		LinearUpperLimit = serObj.FindProperty("LinearUpperLimit");
		UseAngularLimit = serObj.FindProperty("UseAngularLimit");
		AngularLowerLimit = serObj.FindProperty("AngularLowerLimit");
		AngularUpperLimit = serObj.FindProperty("AngularUpperLimit");
	}
	
	public override void OnInspectorGUI () 
	{
		serObj.Update();
    	
		BConstraint shapeObj = (BConstraint)serObj.targetObject;
		GameObject gameObj = shapeObj.gameObject;
 
		EditorGUILayout.PropertyField(ConstraintType,new GUIContent("Constraint Type"));
		
		EditorGUILayout.PropertyField(RigidBodyA,new GUIContent("RigidBody A"));
		EditorGUILayout.PropertyField(RigidBodyB,new GUIContent("RigidBody B"));
		
		if( ConstraintType.intValue == (int)BConstraint.ConstraintTypes.Point2Point )
		{
			EditorGUILayout.PropertyField(PivotInA,new GUIContent("PivotInA"));
			EditorGUILayout.PropertyField(PivotInB,new GUIContent("PivotInB"));
		}
		else if( ConstraintType.intValue == (int)BConstraint.ConstraintTypes.Hinge )
		{
			EditorGUILayout.PropertyField(PivotInA,new GUIContent("PivotInA"));
			EditorGUILayout.PropertyField(AxisInA,new GUIContent("AxisInA"));
			
			EditorGUILayout.PropertyField(PivotInB,new GUIContent("PivotInB"));
			EditorGUILayout.PropertyField(AxisInB,new GUIContent("AxisInB"));
			
			EditorGUILayout.PropertyField(useReferenceFrameAHinge,new GUIContent("ReferenceFrameA"));
		}
		else if( ConstraintType.intValue == (int)BConstraint.ConstraintTypes.Slider )
		{
			EditorGUILayout.PropertyField(PivotInA,new GUIContent("PivotInA"));
			EditorGUILayout.PropertyField(RotationA,new GUIContent("RotationA"));
			
			EditorGUILayout.PropertyField(PivotInB,new GUIContent("PivotInB"));
			EditorGUILayout.PropertyField(RotationB,new GUIContent("RotationB"));
			
			EditorGUILayout.PropertyField(useLinearReferenceFrameASlider,new GUIContent("LinearReferenceFrameA"));
		}
		else if(ConstraintType.intValue == (int)BConstraint.ConstraintTypes.ConeTwist )
		{
			EditorGUILayout.PropertyField(PivotInA,new GUIContent("PivotInA"));
			EditorGUILayout.PropertyField(RotationA,new GUIContent("RotationA"));
			
			EditorGUILayout.PropertyField(PivotInB,new GUIContent("PivotInB"));
			EditorGUILayout.PropertyField(RotationB,new GUIContent("RotationB"));
		}
		else if( ConstraintType.intValue == (int)BConstraint.ConstraintTypes.Gear )
		{
			EditorGUILayout.PropertyField(AxisInA,new GUIContent("AxisInA"));
			EditorGUILayout.PropertyField(AxisInB,new GUIContent("AxisInB"));
			EditorGUILayout.PropertyField(GearConstraintRatio,new GUIContent("GearConstraintRatio"));
		}
		else if( ConstraintType.intValue == (int)BConstraint.ConstraintTypes.Generic6Dof )
		{
			EditorGUILayout.PropertyField(PivotInA,new GUIContent("PivotInA"));
			EditorGUILayout.PropertyField(RotationA,new GUIContent("RotationA"));
			
			EditorGUILayout.PropertyField(PivotInB,new GUIContent("PivotInB"));
			EditorGUILayout.PropertyField(RotationB,new GUIContent("RotationB"));
			EditorGUILayout.PropertyField(UseLinearLimit,new GUIContent("UseLinearLimit"));
			if( UseLinearLimit.boolValue == true )
			{
			    EditorGUILayout.PropertyField(LinearLowerLimit,new GUIContent("LinearLowerLimit"));
			    EditorGUILayout.PropertyField(LinearUpperLimit,new GUIContent("LinearUpperLimit"));
			}
			EditorGUILayout.PropertyField(UseAngularLimit,new GUIContent("UseAngularLimit"));
			if( UseAngularLimit.boolValue == true )
			{
			    EditorGUILayout.PropertyField(AngularLowerLimit,new GUIContent("AngularLowerLimit"));
			    EditorGUILayout.PropertyField(AngularUpperLimit,new GUIContent("AngularUpperLimit"));
			}
			EditorGUILayout.PropertyField(useLinearReferenceFrameASlider,new GUIContent("LinearReferenceFrameA"));
		}
		
		
	 
 
    	serObj.ApplyModifiedProperties();
	
	}
	
	 
}
