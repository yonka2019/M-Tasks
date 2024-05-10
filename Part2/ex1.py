import math


def num_len(num):
    """
    returns the number of the digits in the given number
    :param num: a natural number
    :return: number of digits
    """
    return math.floor(math.log10(num)) + 1
