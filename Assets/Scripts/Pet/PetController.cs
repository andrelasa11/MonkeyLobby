using UnityEngine;
using System;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
    [Header("Status")]
    public int dirt;
    public int happiness;
    public int energy;
    public int food;

    [Header("Tick")]
    [SerializeField] private int dirtTickRate;
    [SerializeField] private int happinessTickRate;
    [SerializeField] private int energyTickRate;
    [SerializeField] private int foodTickRate;

    [Header("DateTime")]
    public DateTime lastTimeDirt;
    public DateTime lastTimeHappiness;
    public DateTime lastTimeEnergy;
    public DateTime lastTimeFood;

    [Header("Dependencies")]
    [SerializeField] private TimingController timingController;
    [SerializeField] private UIController uiController;

    public void Initialize(int dirt, int happiness, int energy, int food,
        int dirtTickRate, int happinessTickRate, int energyTickRate, int foodTickRate)
    {
        lastTimeDirt = DateTime.Now;
        lastTimeHappiness = DateTime.Now;
        lastTimeEnergy = DateTime.Now;
        lastTimeFood = DateTime.Now;
        this.dirt = dirt;
        this.happiness = happiness;
        this.energy = energy;
        this.food = food;
        this.dirtTickRate = dirtTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        this.foodTickRate = foodTickRate;
    }

    public void Initialize(int dirt, int happiness, int energy, int food,
       int dirtTickRate, int happinessTickRate, int energyTickRate, int foodTickRate,
       DateTime lastTimeDirt, DateTime lastTimeHappiness, DateTime lastTimeEnergy,
       DateTime lastTimeFood)
    {
        this.lastTimeDirt = lastTimeDirt;
        this.lastTimeHappiness = lastTimeHappiness;
        this.lastTimeEnergy = lastTimeEnergy;
        this.lastTimeFood = lastTimeFood;
        this.dirt = dirt - dirtTickRate * LastTimeToCurrentTime(lastTimeDirt, timingController.hourLength);
        this.happiness = happiness - happinessTickRate * LastTimeToCurrentTime(lastTimeHappiness, timingController.hourLength);
        this.energy = energy - energyTickRate * LastTimeToCurrentTime(lastTimeEnergy, timingController.hourLength);
        this.food = food - foodTickRate * LastTimeToCurrentTime(lastTimeFood, timingController.hourLength);
        this.dirtTickRate = dirtTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        this.foodTickRate = foodTickRate;

        if(this.dirt < 0) this.dirt = 0;
        if(this.happiness < 0) this.happiness = 0;
        if(this.energy < 0) this.energy = 0;
        if(this.food < 0) this.food = 0;
    }

    private void Awake()
    {
        Initialize(dirt, happiness, energy, food, dirtTickRate, happinessTickRate, energyTickRate, foodTickRate);
    }

    private void Start()
    {
        uiController.SetDirt(dirt);
        uiController.SetHappiness(happiness);
        uiController.SetEnergy(energy);
        uiController.SetFood(food);
    }

    private void Update()
    {
        if(timingController.gameHourTimer <= 0)
        {            
            SetDirt(-dirtTickRate);
            SetHappiness(-happinessTickRate);
            SetEnergy(-energyTickRate);
            SetFood(-foodTickRate);

            uiController.SetDirt(dirt);
            uiController.SetHappiness(happiness);
            uiController.SetEnergy(energy);
            uiController.SetFood(food);
        }
    }

    public void SetDirt(int value)
    {
        dirt += value;

        if (value > 0) lastTimeDirt = DateTime.Now;

        if (dirt < 0) OnDie();
        else if (dirt > 100) dirt = 100;

        uiController.SetDirt(dirt);
        DatabaseManager.instance.shouldSave = true;
    }

    public void SetHappiness(int value)
    {
        happiness += value;

        if (value > 0) lastTimeHappiness = DateTime.Now;

        if (happiness < 0) OnDie();
        else if (happiness > 100) happiness = 100;

        uiController.SetHappiness(happiness);
        DatabaseManager.instance.shouldSave = true;
    }

    public void SetEnergy(int value)
    {
        energy += value;

        if (value > 0) lastTimeEnergy = DateTime.Now;

        if (energy < 0) OnDie();
        else if (energy > 100) energy = 100;

        uiController.SetEnergy(energy);
        DatabaseManager.instance.shouldSave = true;
    }

    public void SetFood(int value)
    {
        food += value;

        if (value > 0) lastTimeFood = DateTime.Now;

        if (food < 0) OnDie();
        else if (food > 100) food = 100;

        uiController.SetFood(food);
        DatabaseManager.instance.shouldSave = true;
    }

    public void OnDie()
    {
        Debug.Log("You're dead!");
    }

    public int LastTimeToCurrentTime(DateTime lastTime, float tickRateInSeconds)
    {
        DateTime now = DateTime.Now;
        int dayOfYearDifference = now.DayOfYear - lastTime.DayOfYear;

        if (now.Year > lastTime.Year || dayOfYearDifference >= 7) return 1500;

        int dayDifferenceSecondsAmount = dayOfYearDifference * 86400;
        if (dayOfYearDifference > 0) return Mathf.RoundToInt(dayDifferenceSecondsAmount/tickRateInSeconds);

        int hourDifferenceSecondsAmount = (now.Hour - lastTime.Hour) * 3600;
        if (hourDifferenceSecondsAmount > 0) return Mathf.RoundToInt(hourDifferenceSecondsAmount / tickRateInSeconds);

        int minuteDifferenceSecondsAmount = (now.Minute - lastTime.Minute) * 60;
        if (minuteDifferenceSecondsAmount > 0) return Mathf.RoundToInt(minuteDifferenceSecondsAmount / tickRateInSeconds);

        int secondDifferenceAmount = now.Second - lastTime.Second;
        return Mathf.RoundToInt(secondDifferenceAmount / tickRateInSeconds);
    }
}
