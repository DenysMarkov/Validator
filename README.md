## This is the solution to the following test task:

Let's say we have a text file that looks like this:

```
a 1-5: abcdj
z 2-4: asfalseiruqwo
b 3-6: bhhkkbbjjjb
```

Each line consists of a password requirement and the password itself. The password requirement specifies the character that must be in the password and how many times it must occur. For example, the requirement in the first line means that the character "a" must occur between 1 and 5 times. In the example above, two passwords (1 and 3) are valid because they meet their requirements, the 2nd one is not, because the character "z" should appear 2 to 4 times in it, but does not occur even once.

You need to write code that will count the number of valid passwords in such a file.
