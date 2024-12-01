FILE_PATH: str = "C:/Repos/advent-of-code-2024/csharp/InputFiles/01.txt"

with open(FILE_PATH, 'r') as file:
    lhs = []
    rhs = []
    for line in file:
        pairs = line.split()
        lhs.append(int(pairs[0]))
        rhs.append(int(pairs[1]))

    lhs.sort()
    rhs.sort()

    result = 0
    for lvalue, rvalue in zip(lhs, rhs):
        result += abs(lvalue - rvalue)

    print(f'Day 01 Part 1 - {result}')
