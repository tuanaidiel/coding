def pyramid (n):
    row = 1
    while (row <= n):
        print("* " * row)
        row = row + 1

pyramid (5)

print("_____________________________________")

def pyramidsss (n):
    for i in range (1, n+1, 2):   #1 at the end is step size
        for j in range (i):
            print ("*", end=" ")
        print()

pyramidsss (7)