# AdventCode2020
The 2020 Advent of Code Challenge

## xUnit tests
After a day is complete I change the xUnit tests to skip.

* Fact(Skip = "Daily completed")
* Theory(Skip = "Daily completed")

If you change the string to "" the tests should run.

## Special xUnit tests
If the xUnit tests have a skip message other than "Daily Completed" the test probably do not end in less than an hour.

## Results

This is the first Advent of Code that I have completed all puzzles!
I have competed in Advent of Code since 2017. I have gone as far as I could until I was stumped.
I am stubborn and want to solve them myself.

But I must admit I "cheated" twice this year 2020. Why? Because for each star earned, Knowit paid an amount of money to charity.

### Day 13 cheat

My solution for Day 13 puzzle 2 ran more than 4+ hours and did not seem to be nearing a solution.
I had done a quick guess that since all buses were prime numbers that the time would be all the primes multiplied together.
This was of course incorrect. So my second solution went slowly iterating over the values trying to find the solution.
I think my solution might have worked in a day or 2. I started looking at my colleagues solutions.
Rebecka's kotlin solution was interesting but I am working in C# so I never translated that correctly.
I then looked at my another colleague Sani's solution and it was an elegant c# linq solution.
So that is the one here.

### Day 20 cheat

My Day 20 part 1 solution worked fine and I found the corners and the value wanted.
The problem was that while I found the corners, I was not building the entire image to find the monster.
I worked rather hard at this as can be seen in my code JurassicJigsaw.cs but my code never stopped on a complete image.
While I don't know if it ever would stop, I had the feeling I was flipping and rotating in an infinite loop.
Again I took a look at my friends solutions but Kotlin to c# is not completely straight forward.
I found the solution by Perska by googling. It works but I still haven't understood why that one finishes and mine does not.
