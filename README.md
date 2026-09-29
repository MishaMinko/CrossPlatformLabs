# How to start project

To run the program, enter the following commands in the project's root directory:
- **dotnet build Build.proj -p:Solution=Lab1 -t:Build**
- **dotnet build Build.proj -p:Solution=Lab1 -t:Run**
- **dotnet build Build.proj -p:Solution=Lab1.Tests -t:Test**

# Number 62


# Lab 3

Some of you may be familiar with the game Zuma, about the adventures of a frog.
In this problem, the rules are similar and quite simple: there is a row of multicolored balls in a stone chute; a cannon located next to the chute has a supply of multicolored balls and periodically fires them into the chute.
The balls that are dropped fall into the row. If, after a shot, a continuous sequence of three or more balls of the same color—including the dropped ball—forms in the chute, they disappear, and the adjacent balls shift to close the gap.
If, after the balls disappear, there are adjacent balls (on both the left and right) at the junction that form a continuous sequence of three or more balls of the same color, they also disappear, and so on. The goal of the game is to eliminate all the balls.

| Stage | Illustration                                          | Explanation                                                                                                                                               |
|-------|-------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1     | ![Example 1](./images/lab3-1.jpg “Process Diagram 1”) | A new ball “B” is fired, landing in the position after ball No. 1                                                                                         |
| 2     | ![Example 2](./images/lab3-2.jpg “Process Diagram 2”) | After being fired, the new ball forms a sequence of color “B” with its neighbors in positions 2–5. The sequence length is ≥3, so balls 2–5 will disappear |
| 3     | ![Example 3](./images/lab3-3.jpg “Process Diagram 3”) | The remaining balls will occupy positions 1–3, and since the new “A” color sequence has a length of ≥3, it will also disappear                            |

Let’s number the balls from left to right, starting with 1. When a ball is fired into position n, it will land to the right of the ball numbered n and end up in position n+1. The numbers of the balls located to the right of the incoming ball are incremented by one.
A ball landing to the left of the row is denoted by position 0. After some balls have disappeared, the balls in the chute are renumbered from left to right, starting with 1.
Write a program that determines the optimal shooting strategy. The optimal strategy is the one in which the fewest number of shots results in the elimination of all balls.

## Input Data

The input file `INPUT.TXT` contains a description of a row of balls; the color of each ball is denoted by a capital letter of the English alphabet (A–Z). It is known that the length of the row does not exceed 14 balls, and no more than 10 shots are needed to destroy the row if the optimal strategy is followed.

## Output

Write the following to the output file `OUTPUT.TXT`: first, the minimum number of shots; then, separated by a space, a letter-number pair indicating the ball’s color and the shot’s position. The shots in the output must be listed in the order in which they are fired in the game.
If there are multiple optimal strategies, choose any one of them.

## Examples

| № | INPUT.TXT  | OUTPUT.TXT                       |
|---|------------|----------------------------------|
| 1 | ABBBAA     | 1 B1                             |
| 2 | ACMNEERC   | 10 A0 A0 C0 M2 M2 N2 N2 E2 R2 R2 |
| 3 | BAAA       | 3 B0 B0 A0                       |


# Lab 2

Let’s consider a numerical sequence that initially consists of two elements: 1, 1.
Next, at each subsequent step, we will insert the sum of two adjacent elements between them. In the example, the elements being added are highlighted:
| Step number    | Sequence			  |
|----------------|----------------------------|
| 0              | 1, 1						  |
| 1              | 1, 2, 1                    |
| 2              | 1, 3, 2, 3, 1              |
| 3              | 1, 4, 3, 5, 2, 5, 3, 4, 1  |

Write a program that calculates the sum of the elements in a sequence constructed in K steps.

## Input

The input file `INPUT.TXT` contains a single natural number K (0 ≤ K ≤ 100)—the number of the last step.

## Output

The output file `OUTPUT.TXT` must contain a single natural number—the sum of the elements of the sequence constructed in K steps.

## Examples

| № | INPUT.TXT  | OUTPUT.TXT  |
|---|------------|-------------|
| 1 | 3          | 28          |
| 2 | 10         | 59050       |


# Lab 1

Mishko and Masha, two Martians, decided to pick out a birthday present for Katya together. When they finally found what they wanted and wrapped it in a nice box, they had to decide how to sign the gift. The friends thought the best solution would be to write a joint signature that included both of their names in succession.

Keep in mind that on Mars, it’s customary to sign with full names, and Martian names can be quite long.

## Input

The input file `INPUT.TXT` contains two lines with the friends’ full names. Surprisingly, the names consist of letters from the English alphabet, with only the first letter capitalized. The names are between 1 and 1,000 characters long.

## Output

Write the shortest string in which both Misha’s and Masha’s names appear to the output file `OUTPUT.TXT`. The letters with which the names begin in this string must be capitalized. If there are multiple solutions, output the one that is earlier in alphabetical order (consider any uppercase letter to be earlier than any lowercase letter).

## Examples

| № | INPUT.TXT        | OUTPUT.TXT  |
|---|------------------|-------------|
| 1 | Misha <br> Masha | MashaMisha  |
| 2 | Julya <br> Lyalya| JuLyalya    |
