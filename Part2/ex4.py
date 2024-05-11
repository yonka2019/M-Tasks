import matplotlib.pyplot as plt
from scipy.stats import pearsonr


def numbers_func():
    nums = []

    while True:
        _input = input("Enter number (until -1): ")

        if _input == "-1":
            print()
            break

        if _input.replace(".", "").replace("-", "").isdigit():
            nums.append(float(_input))

    avg = __count_average(nums)
    pnums = __count_positive_numbers(nums)
    sorted_list = __sort_numbers(nums)
    correlation_coefficient = __show_plot(nums)

    return f"Average: {avg}", f"Positive numbers: {pnums}", f"Sorted numbers: {sorted_list}", f"Correlation coefficient: {correlation_coefficient}"


def __count_average(nums):
    avg = 0

    for num in nums:
        avg += num

    avg /= len(nums)
    return avg


def __count_positive_numbers(nums):
    pnums = 0

    for num in nums:
        if num > 0:
            pnums += 1

    return pnums


def __find_min(nums):
    if len(nums) > 0:
        min_value = nums[0]

        for num in nums:
            if num < min_value:
                min_value = num

        return min_value
    else:
        return None


def __sort_numbers(nums):
    sorted_nums = list(nums)  # duplicating numbers list because I should only show the sorted numbers (not change the original list!)

    # sorting list using nested loops
    for i in range(0, len(sorted_nums)):
        for j in range(i + 1, len(sorted_nums)):
            if sorted_nums[i] >= sorted_nums[j]:
                sorted_nums[i], sorted_nums[j] = sorted_nums[j], sorted_nums[i]

    return sorted_nums


def __show_plot(nums):
    print(nums)
    x = []
    y = []

    i = 0
    while i < len(nums):
        x.append(nums[i])

        if i + 1 <= len(nums) - 1:
            y.append(nums[i + 1])
        else:
            y.append(0)

        i += 2

    plt.plot(x, y)
    plt.show()

    return __calc_pearsonr(x, y)


def __calc_pearsonr(x, y):
    try:
        correlation_coefficient, _ = pearsonr(x, y)
        return correlation_coefficient
    except:
        return None
