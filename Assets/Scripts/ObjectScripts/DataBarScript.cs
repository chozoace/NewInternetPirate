using UnityEngine;
using System.Collections;

public class DataBarScript : MonoBehaviour 
{
    float _maxDataValue = 50;
    public float MaxDataValue { get { return _maxDataValue; } set { _maxDataValue = value; } }
    float _currentDataValue;

    //Don't know what to reference

	void Start () 
    {
        _currentDataValue = 0;
        this.gameObject.transform.localScale = new Vector3(0, 1, 1);
        this.gameObject.transform.position -= new Vector3(1.4f, 0, 0);
	}
	
	public void ModifyDataValue(int dataValue)
    {
        float increaseScale = dataValue / _maxDataValue;
        _currentDataValue += dataValue;
        this.gameObject.transform.localScale += new Vector3(increaseScale, 0, 0);
        this.gameObject.transform.position += new Vector3(.28f, 0, 0);
    }
}
