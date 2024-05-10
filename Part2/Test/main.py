import os
from termcolor import colored

import ex1Tests
import ex2Tests


def main():
    os.system('color')

    # Tests - ex1
    print(f"{colored("-- ex1 --", "light_red")}")

    (i, o) = ex1Tests.test1()
    print_io("[ex1] Test 1", i, o)

    (i, o) = ex1Tests.test2()
    print_io("[ex1] Test 2", i, o)

    (i, o) = ex1Tests.test3()
    print_io("[ex1] Test 3", i, o)

    (i, o) = ex1Tests.test4()
    print_io("[ex1] Test 4", i, o)

    print(f"{colored("-- ex2 --", "light_red")}")

    # Tests - ex2
    (i, o) = ex2Tests.test1()
    print_io("[ex2] Test 1", i, o)

    (i, o) = ex2Tests.test2()
    print_io("[ex2] Test 2", i, o)

    (i, o) = ex2Tests.test3()
    print_io("[ex2] Test 3", i, o)

    (i, o) = ex2Tests.test4()
    print_io("[ex2] Test 4", i, o)


def print_io(name, i, o):
    print(f"{colored(name, "light_red")}")
    print(f"Input: {i}")

    if type(o) is list:
        if len(o) == 0:
            print(f"{colored(f"Output: None", "light_cyan")}")

        for item in o:
            print(f"{colored(f"Output: {item}", "light_cyan")}")
    else:
        print(f"{colored(f"Output: {o}", "light_cyan")}")

    print()


if __name__ == '__main__':
    main()
