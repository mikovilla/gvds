# Activity Selection Algorithm

This repository implements the **Activity Selection Problem** using different data structures, including tuples, HashMaps, and custom activity classes. The goal is to determine the maximum number of non-overlapping activities, following a **greedy approach** where activities are sorted by their earliest finishing time.

## Algorithm Overview

1. **Randomized Activities** are generated.
2. **Sorting** is performed based on the earliest finishing time.
3. **Greedy Selection** starts with the first activity.
4. **Filtering** ensures only non-overlapping activities are selected.
5. **Execution Time** is measured for different data structures.

## Results & Performance
![image](https://github.com/user-attachments/assets/c1a1e39b-60b4-4746-9659-e3c16fcc0f9b)

## Disclaimer
The execution times presented in this document reflect one of many possible runs of the activity selection algorithm. Due to variations in system load, memory usage, and processor scheduling, results may slightly fluctuate across executions. 
In particular, while the **HashMap implementation** may outperform the **Custom Activity Class** in some runs, and vice versa, the differences in execution time remain marginal. Therefore, the overall performance trend is more relevant than the specific nanosecond measurements from any single run.
