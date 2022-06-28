using System;

[Serializable]
public class Pet
{
    public string lastTimeDirt;
    public string lastTimeHappiness;
    public string lastTimeEnergy;
    public string lastTimeFood;

    public int dirt;
    public int happiness;
    public int energy;
    public int food;

    public Pet(string lastTimeDirt, string lastTimeHappiness,
        string lastTimeEnergy, string lastTimeFood, 
        int dirt, int happiness, int energy, int food)
    {
        this.lastTimeDirt = lastTimeDirt;
        this.lastTimeHappiness = lastTimeHappiness;
        this.lastTimeEnergy = lastTimeEnergy;
        this.lastTimeFood = lastTimeFood;
        this.dirt = dirt;
        this.happiness = happiness;
        this.energy = energy;
        this.food = food;
    }

}
