FILE_PATH = "./../../csharp/InputFiles/02.txt"
TEST_FILE_PATH = "./../../csharp/InputFiles/02TestFile.txt"

def day_02(use_test_files = False):
    file_path = get_input_file(use_test_files)
    part_1(file_path)
    part_2(file_path)

def part_1(file_path):
    result = open_input_file(file_path)
    print(f'Day 02 Part 1 - {result}')

def part_2(file_path):
    result = open_input_file(file_path, True)
    print(f'Day 02 Part 2 - {result}')

def open_input_file(file_path, part_two = False):
    safe_count = 0
    with open(file_path, 'r') as file:
        for line in file:
            levels = line.split()
            if is_safe(levels, -1):
                safe_count += 1
            else:
                if part_two:
                    for i in range(len(levels)):
                        if is_safe(levels, i):
                            safe_count += 1
                            break

    return safe_count

def is_safe(arr, ignore_ordinal):
    tolerance = 3
    arr = [arr[i] for i in range(len(arr)) if i != ignore_ordinal]
    ascending = all(1 <= int(arr[i]) - int(arr[i + 1]) <= tolerance for i in range(len(arr) - 1))
    descending = all(-1 >= int(arr[i]) - int(arr[i + 1]) >= tolerance * -1 for i in range(len(arr) - 1))
    return ascending or descending

def get_input_file(use_test_files = False):
    return TEST_FILE_PATH if use_test_files else FILE_PATH
