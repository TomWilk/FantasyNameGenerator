# 🧙‍♂️ Simple Fantasy Name Generator

Simple console-based Fantasy Name Generator powered by Markov Chain

## How It Works

This program uses a Markov Chain to generate names based on a training set you provide. The more names you feed it, the better the results!

1. **Prepare your training data**

  Create a `.txt` file containing fantasy names, one per line. For example:
  ```
   Elrond
   Arwen
   Legolas
   Gimli
  ```
2. **Train the model**

Run the following command to train the model with your dataset:
```
FantasyNameGenerator.exe --train
```

3. **Generate names**

Once trained, you can generate fantasy names by running:
```
FantasyNameGenerator.exe --generate
```
Or simply:
```
FantasyNameGenerator.exe
```
The generator will output 10 unique names.

## Under Development
This project is still in active development.
