using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is provided to give an example for how to change the speed of multiple conveyor lines independently at runtime.
/// </summary>
public class DemoManager : MonoBehaviour {

    // First, we gather a reference to the parent GameObject of each independent conveyor line.
    // This can be as short as one belt, or a line of hundreds of belts and rollers together.
    // See the demo scene for how this could be set up.
    [SerializeField] private GameObject mainConveyorLine;
    [SerializeField] private GameObject rightConveyorLine;
    [SerializeField] private GameObject leftConveyorLine;
    [Space]
    [SerializeField] private Slider mainSlider;
    [SerializeField] private Slider rightSlider;
    [SerializeField] private Slider leftSlider;
    [Space]
    [SerializeField] private Text mainSliderValueText;
    [SerializeField] private Text rightSliderValueText;
    [SerializeField] private Text leftSliderValueText;

    // We create an array of ConveyorBehaviors for each independent conveyor line.
    // ConveyorBehavior is the base class that BeltBehavior and RollerBehavior extends.
    private ConveyorBehavior[] mainConveyors;
    private ConveyorBehavior[] rightConveyors;
    private ConveyorBehavior[] leftConveyors;

    private void Start()
    {
        // Then, we fill our ConveyorBehavior arrays with each ConveyorBehavior found in
        // the parent GameObject's children.
        mainConveyors = mainConveyorLine.GetComponentsInChildren<ConveyorBehavior>();
        rightConveyors = rightConveyorLine.GetComponentsInChildren<ConveyorBehavior>();
        leftConveyors = leftConveyorLine.GetComponentsInChildren<ConveyorBehavior>();
    }

    private void Update ()
    {
        float mainValue = mainSlider.value;
        float rightValue = rightSlider.value;
        float leftValue = leftSlider.value;

        // Then, for every conveyor line, we loop through each ConveyorBehavior in
        // each corresponding array and change the public speed variable to whatever we want.
        // In this example, we take the value from a UI Slider and pass that into each ConveyorBehavior
        // in the conveyor line.
        foreach (ConveyorBehavior behavior in mainConveyors)
            behavior.speed = mainValue;

        foreach (ConveyorBehavior behavior in rightConveyors)
            behavior.speed = rightValue;

        foreach (ConveyorBehavior behavior in leftConveyors)
            behavior.speed = leftValue;

        mainSliderValueText.text = mainValue.ToString();
        rightSliderValueText.text = rightValue.ToString();
        leftSliderValueText.text = leftValue.ToString();
	}
}