from Modules import ex1


def test1():
    i = 1234

    o = ex1.num_len(i)
    return i, o


def test2():
    i = 124356

    o = ex1.num_len(i)
    return i, o


def test3():
    i = 9

    o = ex1.num_len(i)
    return i, o


def test4():
    i = 9125371

    o = ex1.num_len(i)
    return i, o


def test5():
    i = 1

    o = ex1.num_len(i)
    return i, o
