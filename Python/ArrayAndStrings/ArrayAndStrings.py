def IsUnique(word):
    letters = set(word)
    return len(word) == len(letters)

print(IsUnique("abc"))