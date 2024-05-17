def pythagorean_triplet_by_sum(num):
    """
    returns all pythagorean triples which sums into the required number
    :param num: number which presents sum of pythagorean triplet
    :return: list of all pythagorean triples which sums into the required number
    """
    triplet = []

    if (num > 0) and (type(num) is int):
        for a in range(1, num):
            for b in range(a, num):
                c = num - a - b
                if c > 0:
                    if (a * a) + (b * b) == (c * c):
                        triplet.append(f"{a} < {b} < {c}")

    return triplet
