from Modules import ex2


def test1():
    i = 12

    o = ex2.pythagorean_triplet_by_sum(i)
    return i, o


def test2():
    i = 30

    o = ex2.pythagorean_triplet_by_sum(i)
    return i, o


def test3():
    i = 40

    o = ex2.pythagorean_triplet_by_sum(i)
    return i, o


def test4():
    i = 1

    o = ex2.pythagorean_triplet_by_sum(i)
    return i, o
