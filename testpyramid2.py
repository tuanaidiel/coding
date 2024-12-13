def pyramids (n):
    row = 1
    while (row <= n):
        print ("* " * row)
        row = row + 1

pyramids(5)

print("---------------------------------")

def pyramid(n):
    for i in range (1, n+1):
        for j in range (i):
            print("*", end=" ")
        print()

pyramid(5)