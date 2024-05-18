import os
from termcolor import colored

import ex1Tests
import ex2Tests
import ex3Tests
import ex4Tests
import ex5Tests


def main():
    os.system('color')

    test_classes = [ex1Tests,
                    ex2Tests,
                    ex3Tests,
                    ex4Tests,
                    ex5Tests]

    for tc in test_classes:  # iterate all test classes and execute all test functions
        print(f"{colored(f"\n-- {tc.__name__} --\n", "light_red")}")

        method_list = [func for func in dir(tc) if callable(getattr(tc, func))]
        for idx, m in enumerate(method_list):
            c_m = getattr(tc, m)
            (i, o) = c_m()
            print_io(f"[{tc.__name__} - {idx + 1}]", i, o)


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
