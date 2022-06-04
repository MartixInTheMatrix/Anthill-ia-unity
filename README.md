# Anthill-ia-unity 🐜
An ant simulation for unity 2D

## IA rules 📖
- Random movement while searching food (epxressed by the `foundFood` variable)
- When it found food, it register the food location `foodLocation` and bring back the piece of food to the anthill `houseLocation` 
- For each collision `onTriggerEnter()` with the others ants, they're informed of the food location
