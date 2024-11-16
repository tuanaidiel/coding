# truth table   

# AND
x = 7            # 1 1 1
y = 4            # 1 0 0
print (x & y)    # 1 0 0

# OR
x = 7            # 1 1 1
y = 4            # 1 0 0
print (x | y)    # 1 1 1

# XOR
x = 7            # 1 1 1
y = 4            # 1 0 0
print (x ^ y)    # 0 1 1       

# NO
x = 7            # 0 0 0 0 0 1 1 1
print (~x)       # 1 1 1 1 1 0 0 0     if most significance bit is 1 then -ve

print ("----------------------------------------------------------------")

# encryption

x = 85
key = 51
print ("Original value:", 85)

encryptedvalue = x ^ key
print ("Encryptedvalue:", encryptedvalue)

decryptedvalue = encryptedvalue ^ key
print ("Decryptedvalue:", decryptedvalue)

# divisible
x = 19
print ((x + 9) & ~9)  # divisible by 10
print ((x + 7) & ~7)  # divisible by 8
print ((x + 5) & ~5)  # divisible by 6
print ((x + 3) & ~3)  # divisible by 4
print ((x + 1) & ~1)  # divisible by 2

print ("----------------------------------------------------------------")

# swap 2 number using XOR

x = 5
y = 3

x = x ^ y
y = x ^ y
x = x ^ y
print ("x =", x)
print ("y =", y)

# shift operators
# << left shift
# >> right shift

x = 10          # 0000 1010    #10
print (x >> 1)  # 0000 0101    #5
print (x >> 2)  # 0000 0010    #2

print (x << 1)  # 0001 0100    #20      # x * (2 ** 1)
print (x << 2)  # 0010 1000    #40      # x * (2 ** 2)
print (x << 3)  # 0101 0000    #40      # x * (2 ** 3)

x = x << 4
print (x << 1)  # x / (2 ** 1)
print (x << 2)  # x / (2 ** 2)
print (x << 3)  # x / (2 ** 3)

print ("----------------------------------------------------------------")

# complex number 

x = complex (3,4)    # 3 + 4j
y = 5 + 6j
print (x,y)
print (x + y)
print (x - y) 

print (x.real)
print (x.imag) 

print ("----------------------------------------------------------------")

# complex multiplication
# (a + bj) * (c + dj) = (ac - bd) + (ad + bc)j
# ((3 * 5) - (4 * 6)) + ((3 * 6) + (4 * 5))j
# (15 - 24) + (18 + 20)j

print (x * y)

# complex division
# (a + bj) / (c + dj) = (a + bj)(c - dj)/((c + dj)(c - dj))

# (ac + bd)          (bc - ad)
# -----------   +   ------------ j
# c**2 + d**2       c**2 + d**2

print (x / y)

print (x)      

print (abs(x))      # sqrt (realsquare + imaginarysquare) 
                    # sqrt (3**2 + 4**2)



