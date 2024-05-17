def is_sorted_polyndrom(_str):
    """
    checks if the given string is sorted polyndrom
    :param _str: string to check
    :return: (boolean) if string is sorted polyndrom
    """
    str_len = len(_str)
    for start in range(str_len):
        finish = str_len - start - 1

        if start >= finish:  # finish
            return True

        elif _str[start] == _str[finish]:  # polyndorm
            if _str[start] <= _str[start + 1]:  # SORTED polyndorm
                continue
            else:
                return False
        else:
            return False
