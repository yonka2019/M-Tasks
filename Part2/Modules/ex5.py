import math


def reverse_n_pi_digits(n):
    print(str(math.pi)[:(n + 1)][::-1])  # n + 1 -> because of the dot (3.)
