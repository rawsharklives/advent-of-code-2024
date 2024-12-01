FILE_PATH: str = "./../../csharp/InputFiles/01.txt"
TEST_FILE_PATH: str = "./../../csharp/InputFiles/01TestFile.txt"

def day_01(use_test_files: bool = False):
    file_path = get_input_file(use_test_files)
    part_1(file_path)
    part_2(file_path)

def part_1(file_path):
    lhs, rhs = open_input_file(file_path)
    lhs.sort()
    rhs.sort()

    result = sum(abs(lvalue - rvalue) for lvalue, rvalue in zip(lhs, rhs))

    print(f'Day 01 Part 1 - {result}')

def part_2(file_path):
    lhs, rhs = open_input_file(file_path)

    result = sum(value * rhs.count(value) for value in lhs)

    print(f'Day 01 Part 2 - {result}')

def open_input_file(file_path: str) -> ([], []):
    lhs = []
    rhs = []
    with open(file_path, 'r') as file:
        for line in file:
            pairs = line.split()
            lhs.append(int(pairs[0]))
            rhs.append(int(pairs[1]))
    return lhs, rhs

def get_input_file(use_test_files: bool = False):
    if use_test_files:
        return TEST_FILE_PATH
    else:
        return FILE_PATH