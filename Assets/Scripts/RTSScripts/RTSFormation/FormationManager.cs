using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : Singleton<FormationManager>
{
    #region Params
    public FormationTypes CurrentFormationType;
    private FormationTypes cachedFormationType;
    public int _unitXOffset = 5;
    public int _unitZOffset = 5;
    #region FormationStates
    FormationBase currentFormation;
    public BoxFormation boxFormation = new BoxFormation();
    public LineFormation lineFormation = new LineFormation();
    public CircleFormation circleFormation = new CircleFormation();
    public TriangleFormation triangleFormation = new TriangleFormation();
    #endregion
    #endregion
    #region Methods
    private void Start()
    {
        SetFormationType();
        cachedFormationType = CurrentFormationType;
    }
    private void SetFormationType()
    {
        switch (CurrentFormationType)
        {
            case FormationTypes.Box:
                currentFormation = boxFormation;
                break;
            case FormationTypes.Circle:
                currentFormation = circleFormation;
                break;
            case FormationTypes.Line:
                currentFormation = lineFormation;
                break;
            case FormationTypes.Triangle:
                currentFormation = triangleFormation;
                break;
        }
    }
    
    public void CalculateFormationPos(Vector3 mousePoint)
    {

        if (cachedFormationType != CurrentFormationType)
            SetFormationType();
        currentFormation.CalculateFormation(mousePoint);
    }
    #endregion
}

